using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeavePastry : MonoBehaviour
{
    public void leavePastry()
    {
        SceneManager.LoadSceneAsync(2);
    }
}
