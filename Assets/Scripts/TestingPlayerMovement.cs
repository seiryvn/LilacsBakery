using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingPlayerMovement : MonoBehaviour
{
    public float speed;
    // public GameObject camera;
    private Rigidbody2D rb;
    // float playerHealth, playerMax = 10f;
    private float x;
    private float y;
    private Vector2 input;
    public Animator anim;
    public Transform Aim;
    bool isWalking = false;
    private Vector2 lastMoveDirection;
    public float damage = 1;
    public GameObject dialoguePanel;
    public GameObject dialoguePanel2;
    private int breadCounter = 0;
    private int fruitsCounter = 0;
    private int creamCounter = 0;
    public GameObject completePanel;


    private bool moving;
    // // Start is called before the first frame update
    void Start()
    {
        // playerHealth = playerMax;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame


    private void Update()
    {
        GetInput();
        Animate();
        if (dialoguePanel.activeInHierarchy || dialoguePanel2.activeInHierarchy)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        else
        {
            rb.constraints &= ~RigidbodyConstraints2D.FreezePosition;
        }
        
        //checks for item dropped
        if (breadCounter >= 2 && fruitsCounter >= 1 && creamCounter >= 1)
        {
            completePanel.SetActive(true);
        }
    }


    private void GetInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        if ((x == 0  && y == 0) && (input.x != 0 || input.y != 0))
        {
            isWalking = false;
            lastMoveDirection = input;
            Vector3 vector3 = Vector3.left * lastMoveDirection.x + Vector3.down * lastMoveDirection.y;
            Aim.rotation = Quaternion.LookRotation(Vector3.forward, vector3);
        }
        else if (x != 0 || y != 0)
        {
            isWalking = true;
        }

        input = new Vector2(x, y);
        input.Normalize();
    }

    private void FixedUpdate()
    {

        rb.velocity = input * speed;
        if (isWalking)
        {
            Vector3 vector3 = Vector3.left * input.x + Vector3.down * input.y;
            Aim.rotation = Quaternion.LookRotation(Vector3.forward, vector3);
        }
    }

    private void Animate()
    {
        if(input.magnitude > 0.1f || input.magnitude < -0.1f)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        if(moving)
        {
            anim.SetFloat("InputX", x);
            anim.SetFloat("InputY", y);
            anim.SetFloat("LastInputX", x);
            anim.SetFloat("LastInputY", y);
        }

        anim.SetBool("moving", moving);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Enemy enemy = collision.GetComponent<Enemy>();
        // if (enemy != null)
        // {
        //     PlayerTakeDamage(damage);
        //     Debug.Log("player entered method damage");
        // }
        if(collision.CompareTag("Bread"))
        {
            //bread code
            // collision.gameObject.SetActive(false);
            Debug.Log("bread");
            StartCoroutine(DropItem());
            collision.gameObject.SetActive(false);
            breadCounter += 1;
        }
        else if (collision.CompareTag("Fruits"))
        {
            Debug.Log("fruits");
            StartCoroutine(DropItem());
            collision.gameObject.SetActive(false);
            fruitsCounter += 1;
        }
        else if (collision.CompareTag("Cream"))
        {
            StartCoroutine(DropItem());
            collision.gameObject.SetActive(false);
            creamCounter += 1;
        }
        else if (collision.CompareTag("Icing") || collision.CompareTag("Dough") || collision.CompareTag("Sprinkles"))
        {
            StartCoroutine(DropItem());
            collision.gameObject.SetActive(false);
        }
        Debug.Log("b" + breadCounter.ToString());
        Debug.Log("f" + fruitsCounter.ToString());
        Debug.Log("c" + creamCounter.ToString());

    }
    // public void PlayerTakeDamage(float damage)
    // {
        
    //     Debug.Log("PLAYER taking damage....");
    //     playerHealth -= damage;
    //     if (playerHealth <= 0)
    //     {
    //         camera.SetActive(true);
    //         Destroy(gameObject);
    //     }
    // }
    IEnumerator DropItem()
    {
        Debug.Log("putting into inventory...");
        yield return new WaitForSeconds(3f);
    }
}
