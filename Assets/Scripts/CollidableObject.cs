using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidableObject : MonoBehaviour
{
    //base attribute for things that are collidable (gameObject items)
    private Collider2D z_Collider;
    [SerializeField]
    private ContactFilter2D z_Filter;
    private List<Collider2D> z_CollidedObjects = new List<Collider2D>(1);
    protected virtual void Start()
    {
        z_Collider = GetComponent<Collider2D>();

    }

    protected virtual void Update()
    {
        z_Collider.OverlapCollider(z_Filter, z_CollidedObjects);
        foreach(var o in z_CollidedObjects)
        {
            OnCollided(o.gameObject);

        }
    }

    protected virtual void OnCollided(GameObject collidedObject)
    {
        Debug.Log("Collided with" + collidedObject.name);
    }
}
