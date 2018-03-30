using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateManager : MonoBehaviour {

    public float distanceToPlayer;
    public float startingSpawnRate;
    public float spawnRateIncreaseSpeed;

    public static GameStateManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    public void onDeath() {
        SceneManager.LoadScene("MainMenu 1");
	}
	
}
