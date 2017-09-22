using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parking_lot : MonoBehaviour {
    public GameObject Owner;
    public GameObject prefab;
    public Component[] list;
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
                    for (int i = 0; i < 1; i++)
                    {
                        Instantiate(prefab, new Vector3(Random.Range(0, 100), Random.Range(0, 100), Random.Range(0, 100)), new Quaternion(0, 0, 0, 0), transform);
                    }
                }
            }
        }
    }
}
