using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

    public GameObject punchPrefab;
    public GameObject searchIndicator;
    public float moveSpeed = 7;
    public float acceleration = 1f;
    public float friction = 0.5f;
    public float lerpMultiplier = 0.75f;
    public System.Collections.Generic.List<KeyCode> keyInputs = new System.Collections.Generic.List<KeyCode>();
    public bool isPressedAction = false;
    public bool isStunned = false;
    public bool isInvinsible = false;
    public bool hasPunched = false;
    public bool isSearching = false;
    public bool isTouchingBush = false;
    private Vector3 dirVel = new Vector3();
    private float m_speed = 0f;
    public float m_moveSpeedModifier = 1;
    private bool m_moving = false;
    private Vector3 lookdirection = new Vector3(1, 0, 1);
    public float gatheringSpeedModifier;
    public float m_defaultMoveSpeedModifier;
    public bool m_canSearch = true;
    public Animator anim;
    public bool hasWon = false;
    // Use this for initialization
    void Start ()
    {
       anim  = gameObject.GetComponentInChildren<Animator>();

        if (gameObject.tag == "Player1")
        {
            gatheringSpeedModifier = 1.0f;
            m_defaultMoveSpeedModifier = 1.0f;
        }
        else if(gameObject.tag == "Player2")
        {
            gatheringSpeedModifier = 1.5f;
            m_defaultMoveSpeedModifier = 0.8f;
        }
        m_moveSpeedModifier = m_defaultMoveSpeedModifier;
	}
	
	// Update is called once per frame
	void Update ()
    {

        if (hasWon)
        {
            anim.Play("Samba Dancing");
        }
        else
        {
            if (!isStunned)
            {
                MovementControls();
            }
            MovementHandler();
            m_moving = false;
        }
    }

    private void MovementControls()
    {
        if(dirVel == new Vector3(0,0,0))
        {
            anim.Play("Idle");
        }
        const float minDirToLook = 0.25f;
        // Movement input

        // up & down
        if (Input.GetKey(keyInputs[0]))
        {
            anim.Play("Walking (2)");
            //anim.SetBool(1, true);

            dirVel.z += Time.deltaTime * 2;
            if (dirVel.z >= 1)
            {
                dirVel.z = 1;
            }
            m_moving = true;
            if (dirVel.z > minDirToLook)
            {
                lookdirection = new Vector3(dirVel.x * 10, transform.position.y - 1.5f, dirVel.z * 10);
            }
        }
        else if (Input.GetKey(keyInputs[2]))
        {
            anim.Play("Walking (2)");

            dirVel.z -= Time.deltaTime * 2;
            if (dirVel.z <= -1)
            {
                dirVel.z = -1;
            }
            m_moving = true;
            if (dirVel.z < -minDirToLook)
            {
                lookdirection = new Vector3(dirVel.x * 10, transform.position.y - 1.5f, dirVel.z * 10);
            }
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
            anim.Play("Walking (2)");

            dirVel.x += Time.deltaTime * 2;
            if (dirVel.x >= 1)
            {
                dirVel.x = 1;
            }
            m_moving = true;
            if (dirVel.x > minDirToLook)
            {
                lookdirection = new Vector3(dirVel.x * 10, transform.position.y - 1.5f, dirVel.z * 10);
            }
        }
        else if (Input.GetKey(keyInputs[1]))
        {
            anim.Play("Walking (2)");

            dirVel.x -= Time.deltaTime * 2;
            if (dirVel.x <= -1)
            {
                dirVel.x = -1;
            }
            m_moving = true;
            if (dirVel.x < -minDirToLook)
            {
                lookdirection = new Vector3(dirVel.x * 10, transform.position.y - 1.5f, dirVel.z * 10);
            }
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
        if (isPressedAction)
        {
            if (!hasPunched && !isSearching && !isTouchingBush)
            {
                GameObject punch = Instantiate(punchPrefab, transform.position, transform.rotation);
                punch.GetComponent<PunchBehaviour>().owner = gameObject;
                StartCoroutine("punchCooldown");
            }
            // bush touching / searching
            if (!isTouchingBush)
            {
                isSearching = false;
            }
            else if (!isSearching && isTouchingBush && m_canSearch)
            {
                GameObject indi = Instantiate(searchIndicator, transform.position + new Vector3(0, 2, 0), new Quaternion(0, 0, 0, 0));
                indi.transform.SetParent(transform);
                isSearching = true;
            }
        }
        else
        {
            isSearching = false;
        }

        if (!isSearching)
        {
            if(transform.GetComponentInChildren<SearchIndicatorBehaviour>())
            {
                Destroy(transform.GetComponentInChildren<SearchIndicatorBehaviour>().gameObject);
            }
        }

        // Apply movement
        if (!isSearching)
        {
            Vector3 pos = GetComponent<Rigidbody>().position;
            Vector3 toPos = new Vector3(
                pos.x + (m_speed * dirVel.x * m_moveSpeedModifier),
                pos.y,
                pos.z + (m_speed * dirVel.z * m_moveSpeedModifier)
            );
            Vector3 lerpPos = Vector3.Lerp(pos, toPos, (Time.deltaTime * lerpMultiplier));
            GetComponent<Rigidbody>().MovePosition(lerpPos);

            // look direction
            transform.rotation = Quaternion.LookRotation(lookdirection);
        }
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
        if (transform.position.z >= 20)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 20);
        }
        if (transform.position.z <= -10)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }
    }

    public void getHit(Vector3 hitPos)
    {
        GetComponent<Rigidbody>().AddForce(new Vector3(Random.Range(3f, -3f), 0f, Random.Range(3f, -3f)), ForceMode.Impulse);
        GetComponent<AudioSource>().Play();
        StartCoroutine("hitStun");
    }
    public void getShroom(Transform mushroom)
    {
        if(mushroom.tag == "Chantarelle")
        {
            m_moveSpeedModifier = m_defaultMoveSpeedModifier * 0.8f;
            m_canSearch = false;
        }
        if(mushroom.tag == "Amanita")
        {
            StartCoroutine("Amanita");
        }
        else if(mushroom.tag == "Speed")
        {
            StartCoroutine("SpeedShroom");
        }
        else if(mushroom.tag == "Poison")
        {
            StartCoroutine("PoisonShroom");
        }
    }
    IEnumerator Amanita()
    {
        m_moveSpeedModifier = 0.5f * m_defaultMoveSpeedModifier;
        yield return new WaitForSeconds(3);
        m_moveSpeedModifier = m_defaultMoveSpeedModifier;
        yield return null;
    }
    IEnumerator SpeedShroom()
    {
        m_moveSpeedModifier = 1.5f * m_defaultMoveSpeedModifier;
        yield return new WaitForSeconds(3);
        m_moveSpeedModifier = m_defaultMoveSpeedModifier;
        yield return null;
    }
    IEnumerator PoisonShroom()
    {
        m_moveSpeedModifier = -1;
        yield return new WaitForSeconds(3);
        m_moveSpeedModifier = m_defaultMoveSpeedModifier;
        yield return null;
    }
    IEnumerator hitStun()
    {
        Color color = GetComponent<Renderer>().material.color;

        isStunned = true;
        isInvinsible = true;
        GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, 0.5f);
        yield return new WaitForSeconds(0.5f);
        isStunned = false;
        isInvinsible = true;
        yield return new WaitForSeconds(1.0f);
        isStunned = false;
        isInvinsible = false;
        GetComponent<Renderer>().material.color = new Color(color.r, color.g, color.b, 1f);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 0);
        GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        yield return null;
    }

    IEnumerator punchCooldown()
    {
        hasPunched = true;
        yield return new WaitForSeconds(0.5f);
        hasPunched = false;
    }

    void OnTriggerStay(Collider other)
    {
        if (other.tag == "ShroomBush")
        {
            isTouchingBush = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "ShroomBush")
        {
            isTouchingBush = false;
        }
    }
}
