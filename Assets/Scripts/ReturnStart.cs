using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnStart : MonoBehaviour
{
    public void PlayAgain()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
