using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class ObjectTalk1 : MonoBehaviour
{

    public GameObject object1;
    public WallInk1 wallInk1;
    public bool playerInRange;
    public Movement movement;
    public GameObject wallTalk1;
    private bool talkOn = false;
   // private bool talkOff = false; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        selfTalk();
    }

    public void selfTalk()
    {
        if (!talkOn)
        {
            if (Input.GetKeyDown(KeyCode.Space) && playerInRange && !talkOn)
            {
                Debug.Log("thinkin");
                wallTalk1.SetActive(true);
                talkOn = true;
                movement.freeze();
                selfTalking();
            }
        }

        else if (talkOn)
        {

            if (Input.GetKeyDown(KeyCode.Space) && playerInRange && talkOn)
            {
                Debug.Log("closingWorking");
                wallTalk1.SetActive(false);
                talkOn = false;
                movement.unFreeze();
                wallInk1.refreshStory();
            }
        }
    }

   

    public void selfTalking()
    {
        wallInk1.refresh();
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
