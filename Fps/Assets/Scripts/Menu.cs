using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    // Use this for initialization
    public void Play () {
        SceneManager.LoadScene("Test");
	}
	
	// Update is called once per frame
	public void quit() {
        Application.Quit();
	}
}
