using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NPCEmployee : MonoBehaviour
{
    public GameObject dialoguePanel;
    public GameObject indicator;

    public GameObject npcName;
    public Text dialogueText;
    public string[] dialogue;
    private int index;
    private bool  pressed;

    public float wordSpeed;
    public bool playerIsClose;

    public GameObject contButton;

    public SceneTransitions sceneFunc;
    // Update is called once per frame
    void Update()
    {
        //checks if the player is close and triggers the dialogue
        if (Input.GetKeyDown(KeyCode.Space) && playerIsClose)
        {
            Debug.Log("through one");
            pressed = true;
            //if our dialogue panel is already active in the hierarchy...
            if (dialoguePanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                //sets the dialogue panel to visible (the checkmark on Unity inspector)
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }
        else if (dialoguePanel.activeInHierarchy)
        {
            indicator.SetActive(false);
        }

        if (dialogueText.text == dialogue[index])
        {
            contButton.SetActive(true);
        }

    }


    public void zeroText()
    {
        if (dialogueText.text == "Well then, I think that is all. Goodbye!")
        {
            //changes to the next scene after the last dialogue line runs
            // SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
            sceneFunc.ProcessNext();
        }

        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
        pressed = false;    
    }


// typing function that adds the letters one by one
    IEnumerator Typing()
    {
        foreach(char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }

    }

    public void NextLine()
    {
        contButton.SetActive(false);
        // if its not over yet, move to the next line, so the dialogue will be reset to an empty string.
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            Debug.Log("Typing...");
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
            Debug.Log("player is close");
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            Debug.Log("player is NOT close");
            if (pressed == true)
            {
                zeroText();
            }
        }
    }
}

