using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    const float XBOUND = 3.43f;
    const float YBOUND = 6.5f;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        //Get Horizontal Movement
        float hInput = Input.GetAxis("Horizontal");
        float xOffset = hInput * speed * Time.deltaTime;
        float xPosition = Mathf.Clamp(transform.position.x + xOffset, -XBOUND, XBOUND);

        //Get Vertical Movement
        float yInput = Input.GetAxis("Vertical");
        float yOffset = yInput * speed * Time.deltaTime;
        float yPosition = Mathf.Clamp(transform.position.y + yOffset, -YBOUND, YBOUND);

        //Move the player
        transform.position = new Vector3(xPosition, yPosition, transform.position.z);
    }
}
