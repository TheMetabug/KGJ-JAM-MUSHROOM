using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchBehaviour : MonoBehaviour {

    public float lifeTime = 1.0f;
    public GameObject owner;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(0f, 0f, 0.65f);
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<PlayerBehavior>() != null)
        {
            if (col.tag != owner.tag && !col.GetComponent<PlayerBehavior>().isInvinsible)
            {
                col.GetComponent<PlayerBehavior>().getHit(transform.localPosition);
            }
        }
    }
}
