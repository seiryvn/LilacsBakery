using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public GameObject indicator;

    public GameObject npcName;
    public Text dialogueText;
    public string[] dialogue;
    private int index;

    public float wordSpeed;
    public bool playerIsClose;
    public bool speaking;
    public GameObject contButton;

    public GameObject orderOne;
    public GameObject orderTwo;
    public GameObject orderPanel;
    public GameObject infoButton;
    // Update is called once per frame
    void Update()
    {
        //checks if the player is close and triggers the dialogue
        if (Input.GetKeyDown(KeyCode.Space) && playerIsClose)
        {
            speaking = true;
            
            Debug.Log("through one");
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
        if (dialogueText.text == "Thank you!")
        {
            //last
            orderPanel.SetActive(true);
            infoButton.SetActive(true);
        
        }
        else if (dialogueText.text == ".....")
        {
            //load next scene
            SceneManager.LoadSceneAsync(6);
        }
        else if (dialogueText.text == "They are closed now it seems, but I am surprised bakeries even open this late....")
        {
            SceneManager.LoadSceneAsync(3);
        }
        else if (dialogueText.text == "Have a good night!")
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }
        // else if (dialogueText.text == "A hungry customer is waiting on me!")
        // {
        //     redJewel.SetActive(true);
        // }

        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
        speaking = false;
        
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
            
            Debug.Log("player is NOT close");
            zeroText();
            playerIsClose = false;
        }
    }
}
