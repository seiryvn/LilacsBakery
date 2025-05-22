using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    Rigidbody2D rb;
    public Transform target;
    Vector2 moveDirection;
    public float health = 10f;
    private Color currentColor;
    public GameObject dropItem;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    
    // public List<GameObject> possibleDrops;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        //finds the name of the object
        target = GameObject.Find("Player(1)").transform;
        currentColor = gameObject.GetComponent<SpriteRenderer>().color;
        Debug.Log("start" + health.ToString());
        // currentColor = gameObject.GetComponent<SpriteRenderer>().color;
    }

    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            moveDirection = direction;

            // float angle = Math.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            // rb.rotation = angle;
            Debug.Log("current" + health.ToString());
        }
        
    }

    private void FixedUpdate()
    {
        if(target)
        {
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y) * moveSpeed;
        }
    }

    public void TakeDamage(float damage)
    {
        
        StartCoroutine(Blink());
        Debug.Log("bread taking damage....");
        health -= damage;
        Debug.Log(health.ToString());
        if (health <= 0)
        {
            originalPosition = transform.position;
            originalRotation = transform.rotation;
            // int randomIndex = Random.Range(0, possibleDrops.Count);
            Destroy(gameObject);
            // Instantiate(possibleDrops[randomIndex], originalPosition, originalRotation);
            Instantiate(dropItem, originalPosition, originalRotation);
        }
        // gameObject.GetComponent<SpriteRenderer>().color = currentColor;
    }

    IEnumerator Blink()
    {
        gameObject.GetComponent<SpriteRenderer>().color= new Color(1, 0, 0, 1); //changes the color to red
        yield return new WaitForSeconds(0.5f);
        gameObject.GetComponent<SpriteRenderer>().color=new Color(1, 1, 1, 1);
    }

}
