using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementV2 : MonoBehaviour
{
    [SerializeField] private InputActionReference movement;
    private Vector2 movementInput;
    private Vector2 savedMoveInput;
    private float currentSpeed;
    private float acceleration = 2f;
    private float deceleration = 2f;
    private float maxSpeed = 8f;
    private Rigidbody2D rb;
    const float XBOUND = 3.43f;
    const float YBOUND = 6.5f;
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
    }
    void FixedUpdate()
    {
        if (movementInput.magnitude > 0)
        {
            savedMoveInput = movementInput;
            currentSpeed += acceleration * maxSpeed * Time.deltaTime;
        }
        else
        {
            currentSpeed -= deceleration * maxSpeed * Time.deltaTime;
        }
        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
        Vector2 position = rb.position + savedMoveInput * currentSpeed * Time.deltaTime;
        position.x = Mathf.Clamp(position.x, -XBOUND, XBOUND);
        position.y = Mathf.Clamp(position.y, -YBOUND, YBOUND);
        transform.position = position;
    }
    void Death(){
        gameObject.SetActive(false);
    }
}
