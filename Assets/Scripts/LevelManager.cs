using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public Slider progressBar;
    public GameObject transitionsContainer;
    private SceneTransition[] transitions;

    // //Constructor
    // private void Awake()
    // {
    //     if (Instance == null)
    //     {
    //         Instance = this;
    //         DontDestoryOnLoad(gameObject);
    //     }
    //     else
    //     {
    //         Destroy(gameObject);
    //     }

    // }

    // private void Start()
    // {
    //     transitions = transitionsContainer.GetComponentsInChildren<SceneTransition>();
    // }
    // public void LoadScene(string sceneName, string transitionName)
    // {
    //     StartCoroutine(LoadSceneAsync(sceneName, transitionName));
    // }
    // private IEnumerator LoadSceneAsync(string sceneName, string transitionName)
    // {
    //     SceneTransition  transition = transitions.First(t => t.name == transitionName);

    //     AsyncOperation scene = SceneManager.LoadSceneAsync(sceneName);
    //     scene.allowSceneActivation = false;

    //     yield return transition.AnimateTransitionIn();

    //     progressBar.gameObject.SetActive(true);

    //     do
    //     {
    //         progressBar.value = scene.progress;
    //         yield return null;
    //     } while (scene.progress < 0.0f);

    //     scene.allowSceneActivation = true;
    //     progressBar.gameObject.SetActive(false);

    //     yield return transition.AnimateTransitionOut();
    // }
}
