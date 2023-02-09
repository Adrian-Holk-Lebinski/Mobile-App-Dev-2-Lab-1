using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponsV2 : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 5.0f;
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float fireRate = 2.0f;
    [SerializeField] private InputActionReference attack;
    private Coroutine firingCoroutine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
    private void OnEnable(){
        attack.action.performed += Attack_performed;
        attack.action.canceled += Attack_canceled;
    }
    private void OnDisable(){
        attack.action.performed += Attack_performed;
        attack.action.canceled += Attack_canceled;
    }
    private void Attack_performed(InputAction.CallbackContext obj){
        firingCoroutine = StartCoroutine(FireCoroutine());
    }
    private void Attack_canceled(InputAction.CallbackContext obj){
        StopCoroutine(firingCoroutine);
    }
}
