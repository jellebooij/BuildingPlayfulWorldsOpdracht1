using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    [SerializeField]
    GameObject enemyPrefab;

    [SerializeField]
    Transform[] spawnPoints;

    [SerializeField]
    private float spawnTime;

    float timer;
          
	void Start () {
        spawnTime = GameStateManager.instance.startingSpawnRate;
	}

    public void SetSpawnTime(float spawnTime)
    {
        this.spawnTime = spawnTime;
    }
	
	// Update is called once per frame
	void Update () {

        if(spawnTime > 0)
            spawnTime -= GameStateManager.instance.spawnRateIncreaseSpeed * Time.deltaTime;

        timer += Time.deltaTime;
        if(timer >= spawnTime)
        {
            SpawnEnemy();
            timer = 0;
        }
	}

    void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoints[Random.Range(0, spawnPoints.Length - 1)].position, Quaternion.identity);
    }
}
