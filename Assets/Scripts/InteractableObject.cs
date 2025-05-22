using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : CollidableObject
{
    public GameObject ClickedResponse;
    private bool z_Interacted = false;
    protected override void OnCollided(GameObject collidedObject)
    {
  
        if(Input.GetKey(KeyCode.Mouse0))
        {
            OnInteract();
            z_Interacted = false;
        }
    }

    protected virtual void OnInteract()
    {
        if (!z_Interacted)
        {
            z_Interacted = true;
            ClickedResponse.SetActive(true);
        }
    }
}