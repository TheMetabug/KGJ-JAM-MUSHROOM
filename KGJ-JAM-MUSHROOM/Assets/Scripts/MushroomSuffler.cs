using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomSuffler : MonoBehaviour {

    // Use this for initialization
    public Transform Mushroom_deposit;
    public Transform Chantarelle;
    public Transform Amanita;
    public Transform Speed;
    public Transform Poison;
    void Start ()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(Mushroom_deposit, new Vector3(Random.Range(-12, 12), 2, Random.Range(-5, 20)), new Quaternion(0, 0, 0, 0), transform);
            int random = Random.Range(0, 3);
            if(random == 0)
            {
                Mushroom_deposit.GetComponent<Mushroom_Deposit>().prefab = Amanita;
      
            }
            else if (random == 1)
            {
                Mushroom_deposit.GetComponent<Mushroom_Deposit>().prefab = Speed;
       
            }
            else if(random >= 2)
            {
                Mushroom_deposit.GetComponent<Mushroom_Deposit>().prefab = Poison;
            }
            


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
