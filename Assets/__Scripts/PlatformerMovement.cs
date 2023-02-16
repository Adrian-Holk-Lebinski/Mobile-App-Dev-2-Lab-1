using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlatformerMovement : MonoBehaviour
{
    const float XBOUND = 11.89f;
    const float YBOUND = 6.5f;
    [SerializeField] private InputActionReference movement;
    [SerializeField] private float jumpSpeed = 5f;
    [SerializeField] private float RunSpeed = 5f;
    private Vector2 movementInput;
    private Vector2 savedMoveInput;
    private float currentSpeed;
    private float acceleration = 2f;
    private float deceleration = 2f;
    private float maxSpeed = 8f;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        movementInput = movement.action.ReadValue<Vector2>();

        if (Input.GetButton("Jump"))
        {
            Jump();
        }
    }
    void FixedUpdate()
    {
        // if (movementInput.magnitude > 0)
        // {
        //     savedMoveInput = movementInput;
        //     currentSpeed += acceleration * maxSpeed * Time.deltaTime;
        // }
        // else
        // {
        //     currentSpeed -= deceleration * maxSpeed * Time.deltaTime;
        // }
        // currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
        // Vector2 position = rb.position + savedMoveInput * currentSpeed * Time.deltaTime;
        // position.x = Mathf.Clamp(position.x, -XBOUND, XBOUND);
        // position.y = Mathf.Clamp(position.y, -YBOUND, YBOUND);
        // transform.position = position;

        //Get Horizontal Movement 
        float hInput = Input.GetAxis("Horizontal");
        float xOffset = hInput * RunSpeed * Time.deltaTime;
        float xPosition = Mathf.Clamp(transform.position.x + xOffset, -XBOUND, XBOUND);

        //Move the player
        transform.position = new Vector3(xPosition, transform.position.y, transform.position.z);

    }
    public void Jump()
    {
        Vector2 jumpVelToAdd = new Vector2(0f, jumpSpeed);
        rb.velocity += jumpVelToAdd;
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            Debug.Log("Collision");
        }
    }
    void OnTriggerEnter2D(Collider2D collision){
if (collision.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }

}
