using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float jumpSpeed = 9.8f;
    public float speed = 10.0f;
    public float gravity = 3.0f;

    private bool isGrounded;
    private bool atApex;

    private float horizontalAxis;
    private float verticalAxis;

    private const int IDLE = 0;
    private const int RUNNING = 1;
    private const int JUMPING = 1;
    private const int FALLING = -1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.horizontalAxis = Input.GetAxis("Horizontal");
        this.verticalAxis = Input.GetAxis("Vertical");
        Rigidbody2D body2D = GetComponent<Rigidbody2D>();

        Vector2 movement = GetComponent<Rigidbody2D>().velocity;
        movement.x = this.horizontalAxis * this.speed;

        transform.localScale = new Vector2(
            Mathf.Sign(this.horizontalAxis),
            1.0f
        );

        // Para el salto, cuando el salto llega a su pico, 3x la gravedad
        if (System.Math.Sign(this.verticalAxis) > 0 && this.isGrounded)
        {
            movement.y = this.jumpSpeed;
            this.isGrounded = false;
        }
        else if (body2D.velocity.y < 0 && !this.isGrounded)
        {
            this.atApex = true;
        }
        else if (this.atApex)
        {
            body2D.gravityScale = this.gravity;
        }
        body2D.velocity = movement;

        this.SetAnimationState();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        this.isGrounded = true;
    }

    void SetAnimationState()
    {
        // 0 if none - IDLE
        // 1 if horizontal only - RUNNING
        // +/-(>1) if vertical only - JUMPINT/FALLING
        GetComponent<Animator>().SetBool("onGround", isGrounded);
        int hDirection = System.Math.Sign(this.horizontalAxis);
        int vDirection = System.Math.Sign(this.verticalAxis);
        int h = System.Math.Abs(hDirection);
        int v = System.Math.Abs(vDirection);
        GetComponent<Animator>().SetInteger("horizontal", h);
        GetComponent<Animator>().SetInteger("vertical", v);
    }

}
