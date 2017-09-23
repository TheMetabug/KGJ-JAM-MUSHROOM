﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parking_lot : MonoBehaviour {
    public GameObject Owner;
    public GameObject prefab;
    public Component[] list;
    public GameObject canvas;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == Owner.tag)
        {
         
            list = other.GetComponentsInChildren<Transform>();
            foreach (Transform transform in list)
            {
                if (transform.tag == "Chantarelle")
                {
                    canvas.SetActive(true);
                }
            }
        }
    }
}
