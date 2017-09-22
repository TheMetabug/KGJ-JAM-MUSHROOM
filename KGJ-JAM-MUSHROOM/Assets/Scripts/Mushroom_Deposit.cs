using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom_Deposit : MonoBehaviour {
    public float searchTimer = 240.1f;

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
        if (other.GetComponent<PlayerBehavior>().isPressedAction)
        {
            SearchingForMushrooms(other.gameObject);
        }

    }
    void SearchingForMushrooms(GameObject other)
    {
        while(searchTimer < 0)
        {

            if (prefab != null)
            {
                Instantiate(prefab, other.transform, false);
            }
            searchTimer = 0;
        }
        if (searchTimer > 0)
        searchTimer -= 1.0f;
        
    }

    
}
