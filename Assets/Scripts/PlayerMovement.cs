using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    private bool isMoving;
    private Vector2 input;

    public LayerMask solidObjectsLayer;
    public LayerMask interactableLayer;
    private Animator animator;
    // Update is called once per frame

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input.x != 0) input.y = 0;

             //if the position is not (0, 0) meaning the keys moved.
            if (input != Vector2.zero)
            {
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if (isWalkable(targetPos))
                    StartCoroutine(Move(targetPos));
            }
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            Interact();
        }

        
    }

    void Interact()
    {
        var facingDir = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
        var interactPos = transform.position + facingDir;

// draws a line from my position to the interact position in red.
        Debug.DrawLine(transform.position, interactPos, Color.red, 1f);
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true; 

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;
    }

    private bool isWalkable(Vector3 targetPos)
    { //if ur target position is touching a solid object dont walk
        // 0.2 is the radius
        // | means OR.
        if (Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectsLayer | interactableLayer) != null)
        {
            return false;
        }
        return true;
    }
}



