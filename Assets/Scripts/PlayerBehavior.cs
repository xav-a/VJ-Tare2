using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float jumpSpeed = 9.8f;
    public float speed = 10.0f;

    private bool isGrounded;

    private float horizontalAxis;
    private float verticalAxis;

    private float isGroundedRayLength = 0.1f;
    LayerMask layerMaskForGrounded;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");

        Vector2 movement = GetComponent<Rigidbody2D>().velocity;

        movement.x = horizontalAxis * speed;

        if (System.Math.Sign(verticalAxis) > 0 && isGrounded) {
            movement.y = jumpSpeed;
            isGrounded = false;
        }

        GetComponent<Rigidbody2D>().velocity = movement;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    /* bool isGrounded
    {
    //https://answers.unity.com/questions/919654/how-do-you-make-a-2d-rigidbody-jump-once-in-unity.html
        get {
            Vector3 position = transform.position;
            int layerMask = 1 << GetComponent<SpriteRenderer>().sortingOrder;



            position.y = GetComponent<Collider2D>().bounds.min.y + 0.01f;
            float length = isGroundedRayLength + 0.01f;

            Debug.DrawRay(position, Vector3.down * length);
            bool grounded = Physics2D.Raycast(
                position,
                Vector3.down,
                length
            );
            return grounded;
        }
    } */

}
