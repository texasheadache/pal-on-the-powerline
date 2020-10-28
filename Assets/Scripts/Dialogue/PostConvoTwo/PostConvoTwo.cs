using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class PostConvoTwo : MonoBehaviour
{
    public GameObject panel;
    public FifthInk fifthInk;
    public Movement movement; 
    public Story story;
    bool once4 = false;
    bool once5 = false; 
    public List<string> tags;
    bool postConvoTwoStarts = false;
    bool postConvoTwoTwoStarts = false; 



    // Start is called before the first frame update
    void Start()
    {
        story = fifthInk.story;
        tags = fifthInk.tags; 
    }


    // Update is called once per frame
    void Update()
    {
        postNumberTwo();
        postNumberTwoTwo();
    }

    void postNumberTwo()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (panel.activeInHierarchy == false)
            {
                panel.SetActive(true);
            }

            if (!once4 && postConvoTwoStarts == true)
            {
                afterSecondConvo();
                once4 = true;
            }
        }
    }

    void postNumberTwoTwo()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (panel.activeInHierarchy == false)
            {
                panel.SetActive(true);
            }

            if (!once5 && postConvoTwoTwoStarts == true)
            {
                afterSecondConvoTwo();
                once5 = true;
            }
        }
    }

    public void postConvoTwoBegin()
    {
        Debug.Log("startPostTwo");
        postConvoTwoMove();
        StartCoroutine(beginning());
    }

    IEnumerator beginning()
    {
        yield return new WaitForSeconds(7);
        Debug.Log("waiting");
        postConvoTwoStarts = true; 
    }

    public void postConvoTwoTwoBegin()
    {
        StartCoroutine(beginningPostTwoTwo());
    }

    IEnumerator beginningPostTwoTwo()
    {
        yield return new WaitForSeconds(10);
        Debug.Log("waitingTwoTwo");
        postConvoTwoTwoStarts = true; 
    }


    public void postConvoTwoMove()
    {
        movement.unFreeze();
        Debug.Log("moving Again");
    }

    public void afterSecondConvo()
    {
        fifthInk.story.ChoosePathString("PostConvoTwo");
        Debug.Log("goToPostConvoTwoKnot");
    }

    public void afterSecondConvoTwo()
    {
        fifthInk.story.ChoosePathString("PostConvoTwoTwo");
        Debug.Log("startedTwoTwo");
    }
}
