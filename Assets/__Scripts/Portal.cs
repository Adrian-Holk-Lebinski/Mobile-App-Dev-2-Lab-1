using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D whatHitMe)
    {
        if (whatHitMe.gameObject.tag == "Player")
        {
            whatHitMe.transform.position += new Vector3(10, 0);
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}