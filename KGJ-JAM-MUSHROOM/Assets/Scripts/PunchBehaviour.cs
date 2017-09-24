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

        float scale = transform.localScale.x + 0.05f;
        transform.localScale = new Vector3(scale, transform.localScale.y, transform.localScale.z);
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<PlayerBehavior>() != null)
        {
            if (col.tag != owner.tag && !col.GetComponent<PlayerBehavior>().isInvinsible)
            {
                col.GetComponent<PlayerBehavior>().getHit(transform.localPosition);
                col.GetComponent<PlayerBehavior>().m_moveSpeedModifier = col.GetComponent<PlayerBehavior>().m_defaultMoveSpeedModifier;
                if (GameObject.FindGameObjectsWithTag("Chantarelle").Length > 0)
                {
                    col.GetComponent<PlayerBehavior>().m_canSearch = true;
                    GameObject chantarelle = GameObject.FindGameObjectsWithTag("Chantarelle")[0];
                    chantarelle.transform.position = owner.transform.position + new Vector3(0, 2f, 0);
                    chantarelle.transform.SetParent(owner.transform);
                    owner.GetComponent<PlayerBehavior>().m_moveSpeedModifier = owner.GetComponent<PlayerBehavior>().m_defaultMoveSpeedModifier * 0.8f;
                    owner.GetComponent<PlayerBehavior>().m_canSearch = false;
                }
            }
        }
    }
}
