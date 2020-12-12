using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class PostPostThird : MonoBehaviour
{

    public GameObject panel;
    public FifthInk fifthInk;
    public Movement movement;
    public Story story;
    bool once8 = false;
    public List<string> tags;
    bool postPostConvoThreeStarts = false;
    public AudioSource dial;
    public AudioSource secondRing;
    public AudioSource thirdRing;

    // Start is called before the first frame update
    void Start()
    {
        story = fifthInk.story;
        tags = fifthInk.tags;
    }

    // Update is called once per frame
    void Update()
    {
        postPostConvoThreeTalk();
    }

    public void postPostConvoThreeTalk()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
           if(postPostConvoThreeStarts && !once8)
            {
                afterAfterThirdConvo();
                once8 = true; 
            }
        }
    }


    public void postPostThirdConvoBegin()
    {
        Debug.Log("postpostpostThree");
        StartCoroutine(postPostThirdTrigger());
    }

    IEnumerator postPostThirdTrigger()
    {
        yield return new WaitForSeconds(7);
       // postPostConvoThreeStarts = true;
        dial.Play();
        postPostConvoThreeStarts = true; 
    }

    public void afterAfterThirdConvo()
    {
        fifthInk.story.ChoosePathString("PostPostThird");
        Debug.Log("gotPostPostThirdstory");
    }

    public void secondRinging()
    {
        StartCoroutine(secondingRinging());
        Debug.Log("secondRinging");
    }

    IEnumerator secondingRinging()
    {
        Debug.Log("secondingggRinginggg");
        secondRing.Play();
        yield return new WaitForSeconds(4);
        secondRing.Stop();
        thirdRing.Play();
        
    }
}
