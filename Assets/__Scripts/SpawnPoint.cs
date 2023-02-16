using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Enemy enemyPrefab;
    private GameObject[] spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        var childrenList = new List<GameObject>();
        int i = 0;
        foreach (Transform child in transform)
        {
            childrenList.Add(child.gameObject);
            print(++i);
        }
        childrenList.Add(this.gameObject); //adding parent to spawnpoint list
        spawnPoints = childrenList.ToArray();

         InvokeRepeating("SpawnEnemyWaves", 1.5f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnEnemyWaves()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Enemy myEnemy = Instantiate(enemyPrefab);
        myEnemy.transform.position = spawnPoints[spawnIndex].transform.position;

    }
}
