using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Weapons : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 5.0f;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float fireRate = 2.0f;
    private Coroutine firingCoroutine;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //FireBullet();
            firingCoroutine = StartCoroutine(FireCoroutine());
        }
        if(Input.GetKeyUp(KeyCode.Space)){
            StopCoroutine(firingCoroutine);
        }

    }
    private void FireBullet()
    {
        Bullet bullet = Instantiate(bulletPrefab);
        // give it the same position as the player
        bullet.transform.position = transform.position;
        // give it velocity and move right
        Rigidbody2D rbb = bullet.GetComponent<Rigidbody2D>();
        //rbb.velocity = new Vector2(1 * speed, 0);
        rbb.velocity = Vector2.up * bulletSpeed;
    }
    private IEnumerator FireCoroutine()
    {
        while (true)
        {
            FireBullet();
            yield return new WaitForSeconds(fireRate);
        }
    }

}
