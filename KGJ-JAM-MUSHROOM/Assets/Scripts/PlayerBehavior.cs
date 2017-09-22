using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

    public float moveSpeed = 25.0f;
    public float lerpMultiplier = 0.5f;
    public System.Collections.Generic.List<KeyCode> keyInputs = new System.Collections.Generic.List<KeyCode>();

    private Vector3 dirForce = new Vector3();
    private bool m_moving = false;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        MovementControls();
        MovementHandler();
        m_moving = false;
    }

    private void MovementControls()
    {
        Vector3 dir = new Vector3();

        // Movement input
        if (Input.GetKey(keyInputs[0]))
        {
            dir.z = 1;
            m_moving = true;
        }
        if (Input.GetKey(keyInputs[1]))
        {
            dir.x = -1;
            m_moving = true;
        }
        if (Input.GetKey(keyInputs[2]))
        {
            dir.z = -1;
            m_moving = true;
        }
        if (Input.GetKey(keyInputs[3]))
        {
            dir.x = 1;
            m_moving = true;
        }

        // Apply force
        Vector3 pos = transform.localPosition;
        Vector3 toPos = new Vector3(
            pos.x + (moveSpeed * dir.x),
            pos.y,
            pos.z + (moveSpeed * dir.z)
        );
        Vector3 lerpPos = Vector3.Lerp(pos, toPos, (Time.deltaTime * lerpMultiplier));
        GetComponent<Rigidbody>().MovePosition(lerpPos);
    }

    private void MovementHandler()
    {
    }
}
