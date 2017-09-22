using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

    public float moveSpeed = 7;
    public float acceleration = 1f;
    public float friction = 0.5f;
    public float lerpMultiplier = 0.75f;
    public System.Collections.Generic.List<KeyCode> keyInputs = new System.Collections.Generic.List<KeyCode>();
    public bool isPressedAction = false;

    private Vector3 dirVel = new Vector3();
    private float m_speed = 0f;
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
        // Movement input

        // up & down
        if (Input.GetKey(keyInputs[0]))
        {
            dirVel.z = 1;
            m_moving = true;
        }
        else if (Input.GetKey(keyInputs[2]))
        {
            dirVel.z = -1;
            m_moving = true;
        }
        else
        {
            dirVel.z = Vector3.Lerp(new Vector3(0, 0, dirVel.z), Vector3.zero, Time.deltaTime * 5).z;
            if (Mathf.Abs(m_speed) < 0.15f)
            {
                dirVel.z = 0;
            }
        }
        // left & right
        if (Input.GetKey(keyInputs[3]))
        {
            dirVel.x = 1;
            m_moving = true;
        }
        else if (Input.GetKey(keyInputs[1]))
        {
            dirVel.x = -1;
            m_moving = true;
        }
        else
        {
            dirVel.x = Vector3.Lerp(new Vector3(dirVel.x, 0, 0), Vector3.zero, Time.deltaTime * 5).x;
            if (Mathf.Abs(m_speed) < 0.15f)
            {
                dirVel.x = 0;
            }
        }

        // Action key check
        isPressedAction = Input.GetKey(keyInputs[4]);

        // Apply movement
        Vector3 pos = transform.localPosition;
        Vector3 toPos = new Vector3(
            pos.x + (m_speed * dirVel.x),
            pos.y,
            pos.z + (m_speed * dirVel.z)
        );
        Vector3 lerpPos = Vector3.Lerp(pos, toPos, (Time.deltaTime * lerpMultiplier));
        GetComponent<Rigidbody>().MovePosition(lerpPos);
    }

    private void MovementHandler()
    {
        if (m_moving)
        {
            if (m_speed < moveSpeed)
            {
                m_speed += acceleration;
            }
        }
        else
        {
            if (m_speed > 0)
            {
                m_speed -= friction;
            }
        }
        
        // Map Borders
        if(transform.position.x >= 15)
        {
            transform.position = new Vector3(15, transform.position.y, transform.position.z);
        }
        if (transform.position.x <= -15)
        {
            transform.position = new Vector3(-15, transform.position.y, transform.position.z);
        }
        if (transform.position.z >= 18)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 18);
        }
        if (transform.position.z <= -10)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }
    }
}
