using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAppear : MonoBehaviour
{
    public GameObject myButton;


    // Update is called once per frame
    void Update()
    {
        if (!myButton.activeInHierarchy)
        {
            StartCoroutine(Appear());
        }
    }

    IEnumerator Appear()
    {
        yield return new WaitForSeconds(1f);
        myButton.SetActive(true);
    }
}
