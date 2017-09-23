using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom_Deposit : MonoBehaviour {
    public float searchTimer = 4f;

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
        if (other.GetComponent<PlayerBehavior>())
        {
            if (other.GetComponent<PlayerBehavior>().isPressedAction)
            {
                SearchingForMushrooms(other.gameObject);
            }
        }
    }

    void SearchingForMushrooms(GameObject other)
    {
        while(searchTimer < 0)
        {
            if (prefab != null)
            {
                other.GetComponent<PlayerBehavior>().getShroom(prefab);
                Instantiate(prefab,other.transform.position + new Vector3(0,2,0),new Quaternion(0,0,0,0),other.transform);
            }
            searchTimer = 0;
        }
        if (searchTimer > 0)
            searchTimer -= Time.deltaTime * other.GetComponent<PlayerBehavior>().gatheringSpeedModifier;
        
    }

    
}
