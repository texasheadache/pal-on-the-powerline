using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class SecondConvo : MonoBehaviour
{

    public GameObject panel;
    public FifthInk fifthInk;
    public bool playerInRange;
    public Story story;
    bool once3 = false;
    public List<string> tags;

    bool secondConvoStarts = false;
    public Movement movement;
    public AudioSource ringTwoSound;



    // Start is called before the first frame update
    void Start()
    {
        story = fifthInk.story;
        tags = fifthInk.tags; 
    }

    // Update is called once per frame
    void Update()
    {
        convoTwo();
    }

    public void convoTwo()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (panel.activeInHierarchy == false)
            {
                panel.SetActive(true);
            }

            if (!once3 && secondConvoStarts == true)
            {
                Debug.Log("tellingyouSecondConvo");
                secondCall();
                //fifthInk.firstCall();
                // fifthInk.refresh();
                once3 = true;
                movement.freeze();
                ringTwoSound.Stop();
            }

            //  fourthInk.refresh();
        }
    }



    public void secondConvoStartTrigger()
    {
        Debug.Log("secondConvoTriggered");
        StartCoroutine(secondTalk());
    }

    IEnumerator secondTalk()
    {
        yield return new WaitForSeconds(7);
        ringTwoSound.Play();
        secondConvoStarts = true; 

    }


    public void secondCall()
    {
        fifthInk.story.ChoosePathString("SecondConvo");
        Debug.Log("secondConvostartingNow");
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("inRange");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("notInRange");
        }
    }

}
