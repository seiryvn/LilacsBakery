using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyPlayerMovement : MonoBehaviour
{
    
    public float speed;
    private Rigidbody2D rb;

    private float x;
    private float y;
    private Vector2 input;
    public Animator anim;
    public GameObject dialoguePanel;
    public GameObject dialoguePanel2;

    private bool moving;
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
            anim.SetFloat("InputX", x);
            anim.SetFloat("InputY", y);
            anim.SetFloat("LastInputX", x);
            anim.SetFloat("LastInputY", y);
        }

        anim.SetBool("moving", moving);
    }
}
