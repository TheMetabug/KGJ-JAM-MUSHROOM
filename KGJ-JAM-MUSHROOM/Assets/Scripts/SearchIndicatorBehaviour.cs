using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchIndicatorBehaviour : MonoBehaviour {

    public float timer = 4f;
    public float maxScale = 1f;
    public GameObject min;
    public GameObject max;

    // Use this for initialization
    void Start () {
        min.transform.localScale = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        timer -= Time.deltaTime;
        float curScale = Mathf.Lerp(min.transform.localScale.x, maxScale, Time.deltaTime);
        min.transform.localScale = new Vector3(curScale, curScale, curScale);
        if (timer <= 0)
        {
            Destroy(gameObject);
        }
	}
}
