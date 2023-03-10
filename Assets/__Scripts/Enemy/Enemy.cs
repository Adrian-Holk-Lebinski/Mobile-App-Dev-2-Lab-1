using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 0f;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.down * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision){
        var bullet = collision.GetComponent<Bullet>();

        if(bullet){
            Destroy(bullet.gameObject);
            Destroy(this.gameObject);
        }

    }
}
