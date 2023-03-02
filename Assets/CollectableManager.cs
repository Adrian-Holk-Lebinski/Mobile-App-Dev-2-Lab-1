using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableManager : MonoBehaviour
{
    private UIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.Find("GameController").GetComponent<UIManager>();
        if(!uiManager){
            Debug.Log("NO SCORE MANAGER");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D whatHitMe)
    {
        if (whatHitMe.gameObject.tag == "Player")
        {
            uiManager.UpdateScore(100);
            Destroy(this.gameObject);
        }
    }
}
