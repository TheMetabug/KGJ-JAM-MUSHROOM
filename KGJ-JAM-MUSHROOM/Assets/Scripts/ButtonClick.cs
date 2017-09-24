using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;


public class ButtonClick : MonoBehaviour {


	// Use this for initialization
	void Start ()
    {
        
	}
	
	// Update is called once per frame
	void Update ()
    {
	if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }	
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
