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
    public Mesh[] rocks;
    void Start ()
    {
        for (int i = 0; i < 10; i++)
        {
            Transform inst = Instantiate(
                Mushroom_deposit,
                new Vector3(Random.Range(-12, 12), 2, Random.Range(-5, 20)),
                new Quaternion(0, 0, 0, 0),
                transform
            );
            inst.GetComponent<MeshFilter>().mesh = rocks[Random.Range(0, 3)];
            inst.Rotate(-90, 0, 0);
            inst.transform.localScale = new Vector3(0.45f, 0.45f, 1.25f);
            int random = Random.Range(0, 3);
            if(random == 0)
            {
                inst.GetComponent<Mushroom_Deposit>().prefab = Amanita;
      
            }
            else if (random == 1)
            {
                inst.GetComponent<Mushroom_Deposit>().prefab = Speed;
       
            }
            else if(random >= 2)
            {
                inst.GetComponent<Mushroom_Deposit>().prefab = Poison;
            }
            


        }
        Mushroom_Deposit script = transform.GetComponentInChildren<Mushroom_Deposit>();
        script.prefab = Chantarelle;
        // script.transform.Rotate(20, 20, 20);
	}
	
	// Update is called once per frame
	void Update ()
    {

    }
}
