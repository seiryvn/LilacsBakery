using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HousePlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    private float x;
    private float y;
    private Vector2 input;
    public Animator anim;
    public bool npcIsClose;
    private bool moving;
    public NPC speaking;
    public GameObject dialoguePanel;
    public GameObject dialoguePanel2;
    // // Start is called before the first frame update
    void Start()
    {
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
        
        // if (npcIsClose && Input.GetKeyDown(KeyCode.Space))
        // {
        //     rb.constraints = RigidbodyConstraints2D.FreezeAll;
        // }

        // if (!speaking)
        // {
        //     rb.constraints = RigidbodyConstraints2D.FreezeAll;
        // }
        // else
        // {
        //     // rb.constraints = RigidbodyConstraints2D.None;
        //     // rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        //     Debug.Log("npc done speaking...");
        //     rb.constraints &= ~RigidbodyConstraints2D.FreezePosition;
        // } 
        
    }

    private void GetInput()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        input = new Vector2(x, y);
        input.Normalize();
    }

    private void FixedUpdate()
    {

        rb.velocity = input * speed;
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
            anim.SetFloat("HInputX", x);
            anim.SetFloat("HInputY", y);
            anim.SetFloat("HLastInputX", x);
            anim.SetFloat("HLastInputY", y);
        }

        anim.SetBool("moving", moving);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
            npcIsClose = true;
            Debug.Log("NPC is close");
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("NPC"))
        {
            npcIsClose = false;
            Debug.Log("NPC is NOT close");
        }
    }
}
