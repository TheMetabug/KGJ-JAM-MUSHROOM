using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomTimer : MonoBehaviour {
    float timer;
	// Use this for initialization
	void Start ()
    {
        timer = 180.0f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer -= 1;
        if(timer < 0)
        {
            Destroy(gameObject);
        }
		
	}
}
