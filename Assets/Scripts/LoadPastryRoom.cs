using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadPastryRoom : MonoBehaviour
{
    // Start is called before the first frame update
    public void loadPastry()
    {
        SceneManager.LoadSceneAsync(4); // the 4th scene is the pastry locked
    }
}
