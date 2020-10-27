using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class PostConvoOne : MonoBehaviour
{

    public GameObject panel;
    public FifthInk fifthInk;
    public bool playerInRange;
    public Story story;
    bool once = false;
    bool postConvoOneStarting = false;
    public Movement movement;


    // Start is called before the first frame update
    void Start()
    {
        story = fifthInk.story;
    }

    // Update is called once per frame
    void Update()
    {
        secondMonologue();
    }

    void secondMonologue()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (panel.activeInHierarchy == false)
            {
                panel.SetActive(true);
            }

            if (!once && postConvoOneStarting == true)
            {
                fifthInk.PostConvoOne();
                once = true;

            }
        }
    }


    public void postConvoOneStart()
    {
        //postConvoOneStarting = true;
        StartCoroutine(postConvoCoroutine());
    }

    IEnumerator postConvoCoroutine()
    {
        yield return new WaitForSeconds(5);
        postConvoOneStarting = true;
    }

    public void postConvoOneMove()
    {
        movement.unFreeze();
        Debug.Log("callfromPost");
    }
}
