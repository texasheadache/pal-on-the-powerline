using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class PostThirdConvo : MonoBehaviour
{
    public GameObject panel;
    public FifthInk fifthInk;
    public Movement movement;
    public Story story;
    bool once7 = false;
    public List<string> tags;
    bool postConvoThreeStarts = false; 

    // Start is called before the first frame update
    void Start()
    {
        story = fifthInk.story;
        tags = fifthInk.tags; 
    }

    // Update is called once per frame
    void Update()
    {
        beginThirdConvo();
    }

    public void beginThirdConvo()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (panel.activeInHierarchy == false)
            {
                panel.SetActive(true);
            }

            if(!once7 && postConvoThreeStarts == true)
            {
                afterThirdConvo();
                once7 = true; 
            }
        }
    }

    public void postThirdConvoBegin()
    {
        Debug.Log("postpostpostThree");
        StartCoroutine(thirdConvoTrigger());
    }

    IEnumerator thirdConvoTrigger()
    {
        yield return new WaitForSeconds(4);
        postConvoThreeStarts = true; 
    }

    void afterThirdConvo()
    {
        fifthInk.story.ChoosePathString("PostThirdConvo");
        Debug.Log("gotPostThirdstory");
    }

    public void movingAgain()
    {
        movement.unFreeze();
        Debug.Log("unFrozen");
    }

}
