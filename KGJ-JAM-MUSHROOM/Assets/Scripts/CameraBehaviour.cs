using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour {

    public Transform transorm_a;
    public Transform transorm_b;

    private Vector3 lerpPoint;
    private Vector3 cameraStartPoint;
    private float offset = 5.0f;

    // Use this for initialization
    void Start ()
    {
        lerpPoint = transorm_a.position + (transorm_b.position - transorm_a.position) / 2;
        cameraStartPoint = transform.localPosition;
    }
	
	// Update is called once per frame
	void Update ()
    {
        // Rotate
        Vector3 midPoint = transorm_a.position + (transorm_b.position - transorm_a.position) / 2;
        lerpPoint = Vector3.Lerp(lerpPoint, midPoint, Time.deltaTime);
        transform.LookAt(lerpPoint);

        // Zoom
        transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            Mathf.Lerp(transform.position.z, -(Vector3.Distance(transorm_a.position, transorm_b.position) / 1.75f) - offset, Time.deltaTime)
        );
	}
}
