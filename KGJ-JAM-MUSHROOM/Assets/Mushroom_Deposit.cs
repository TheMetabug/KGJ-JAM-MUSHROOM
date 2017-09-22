﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom_Deposit : MonoBehaviour {
    float searchTimer = 4.0f;

    public Transform prefab;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}
    void OnTriggerStay(Collider other)
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SearchingForMushrooms(other.gameObject);
        }
    }
    void SearchingForMushrooms(GameObject other)
    {
        while(searchTimer > 0)
        {
            searchTimer -= 0.1f;
        }
        if(prefab != null)
        {
            Instantiate(prefab, other.transform, false);
        }
    }

    
}
