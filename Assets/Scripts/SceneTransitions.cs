using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{
    public Animator transitionAim;
    public string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // void Update()
    // {
    //     if(Input.GetKeyDown(KeyCode.Z))
    //     {
    //         StartCoroutine(LoadScene());
    //     }
    // }

    public void ProcessNext()
    {
        StartCoroutine(LoadScene());
    }
//Coroutine
    IEnumerator LoadScene(){
        transitionAim.SetTrigger("end");
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
    }
}
