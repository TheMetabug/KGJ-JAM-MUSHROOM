using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomSuffler : MonoBehaviour {

    // Use this for initialization
    public Transform Mushroom_Deposit;
    public Transform Chantarelle;
    void Start ()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(Mushroom_Deposit, new Vector3(Random.Range(-12, 12), 2, Random.Range(-5, 20)), new Quaternion(0, 0, 0, 0), transform);
        }
        Mushroom_Deposit script = transform.GetComponentInChildren<Mushroom_Deposit>();
        script.prefab = Chantarelle;
        script.transform.Rotate(20, 20, 20);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
