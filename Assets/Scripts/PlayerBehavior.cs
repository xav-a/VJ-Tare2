using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float jumpSpeed = 9.8f;
    public float speed = 10.0f;

    private bool isGrounded;
    private bool atApex;

    private float horizontalAxis;
    private float verticalAxis;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.horizontalAxis = Input.GetAxis("Horizontal");
        this.verticalAxis = Input.GetAxis("Vertical");

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

        if (GetComponent<Rigidbody2D>().velocity.y < 0 && !this.isGrounded)
        {
            this.atApex = true;
        }
        if (this.isGrounded)
        {
            this.atApex = false;
        }
        if (this.atApex)
        {
            GetComponent<Rigidbody2D>().gravityScale = 3;
        }

        GetComponent<Rigidbody2D>().velocity = movement;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        this.isGrounded = true;
    }



}
