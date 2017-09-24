using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;


public class ButtonClick : MonoBehaviour {

    public GameObject credits;
    public GameObject menu;
    public Button backButton;
	// Use this for initialization
	void Start ()
    {
        backButton.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
	if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }	
	}
    public void showCredits()
    {
        menu.GetComponent<MeshRenderer>().enabled = false;
        credits.GetComponent<MeshRenderer>().enabled = true;
        backButton.gameObject.SetActive(true);

    }
    public void disableCredits()
    {
        menu.GetComponent<MeshRenderer>().enabled = true;
        credits.GetComponent<MeshRenderer>().enabled = false;
        backButton.gameObject.SetActive(false);
    }
   public void TaskOnClick(int scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void Exit()
    {
        Application.Quit();
    }

}
