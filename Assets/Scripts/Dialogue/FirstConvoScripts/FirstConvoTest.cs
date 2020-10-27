using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class FirstConvoTest : MonoBehaviour
{

    public GameObject panel;
    public FifthInk fifthInk;
    public bool playerInRange;
    bool once = false;
    public Story story;
    public List<string> tags;
    public bool tagAndGo = false;
    public Movement movement; 

    public AudioSource ringOneSound; 



    // Start is called before the first frame update
    void Start()
    {
        story = fifthInk.story;
        tags = fifthInk.tags;

    }

    // Update is called once per frame
    void Update()
    {
        convoOne();
    }


    public void convoOne()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            if (panel.activeInHierarchy == false)
            {
                panel.SetActive(true);
            }

            if (!once && tagAndGo == true)
            {
                fifthInk.firstCall();
               // fifthInk.refresh();
                once = true;
                movement.freeze();
                ringOneSound.Stop();
            }

            //  fourthInk.refresh();
        }
    }


    public void tagStart()
    {
      //  tagAndGo = true;
        Debug.Log("tagandgobaby");
        StartCoroutine(ringOne());
    }


    IEnumerator ringOne()
    {
        yield return new WaitForSeconds(10);
        Debug.Log("lkj");
        tagAndGo = true;
        ringOneSound.Play();

    }

    public void afterCallMove()
    {
        movement.unFreeze();
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

