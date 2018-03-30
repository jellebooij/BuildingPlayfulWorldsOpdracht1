using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreCounter : MonoBehaviour {


    float timer;
    public Text score;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime;
        score.text = "Score: " + ((int)timer).ToString();

    }

    public void restart()
    {
        SceneManager.LoadScene("Test");
    }
}
