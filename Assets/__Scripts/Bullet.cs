using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float boundaryY = 7.2f, boundaryX = 4.15f; 
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //removing bullet if gone off screen
        if(rb.position.y >= boundaryY || rb.position.y <= -boundaryY
        || rb.position.x >= boundaryX || rb.position.x <= -boundaryX){
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision){
        Debug.Log("Collision");
        if(collision.name == "Enemy"){
            Debug.Log("Collision with enemy");
        }
    }
}
