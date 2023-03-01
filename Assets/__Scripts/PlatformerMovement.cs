using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformerMovement : MonoBehaviour
{
    const float XBOUND = 11.89f;
    const float YBOUND = 6.5f;
    [SerializeField] private float jumpSpeed = 5f;
    [SerializeField] private float RunSpeed = 5f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private bool isGrounded;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 offset = new Vector3(0, -0.95f, 0);
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position + offset, new Vector2(0.67f, 0.044f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        if (Input.GetButton("Jump") && isGrounded)
        {
            Jump();
        }
    }
    void FixedUpdate()
    {
        //Get Horizontal Movement 
        float hInput = Input.GetAxis("Horizontal");
        float xOffset = hInput * RunSpeed * Time.deltaTime;
        float xPosition = Mathf.Clamp(transform.position.x + xOffset, -XBOUND, XBOUND);

        //Move the player
        transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);

    }
    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            Debug.Log("Collision");
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }

}
