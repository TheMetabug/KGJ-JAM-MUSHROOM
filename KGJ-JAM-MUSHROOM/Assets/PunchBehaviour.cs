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
        float pos = transform.position.z + (Time.deltaTime * 10);
        transform.position = new Vector3(transform.position.x, transform.position.y, pos);
        lifeTime -= Time.deltaTime;
        if (lifeTime < 0)
        {
            Destroy(gameObject);
        }
	}

    void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.tag);
        Debug.Log(owner.tag);
        if (col.tag != owner.tag && !col.GetComponent<PlayerBehavior>().isInvinsible)
        {
            col.GetComponent<PlayerBehavior>().getHit(transform.position);
        }
    }
}
