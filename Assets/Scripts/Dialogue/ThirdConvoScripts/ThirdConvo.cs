using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class ThirdConvo : MonoBehaviour
{

    public GameObject panel;
    public FifthInk fifthInk;
    public bool playerInRange;
    public Story story;
    bool once6 = false;
    public List<string> tags;
    bool thirdConvoStarts = false;
    public Movement movement;
    public AudioSource ringing; 

    // Start is called before the first frame update
    void Start()
    {
        story = fifthInk.story;
        tags = fifthInk.tags; 
    }

    // Update is called once per frame
    void Update()
    {
        thirdConversationing();
    }

    void thirdConversationing()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (panel.activeInHierarchy == false)
            {
                panel.SetActive(true);
            }

            if (!once6 && thirdConvoStarts == true)
            {
                Debug.Log("thirdconversationing");
                once6 = true;
                movement.freeze();
                ringing.Stop();
            }
        }
    }

    public void thirdConvoTrigger()
    {
        StartCoroutine(triggerThirdConvo());
    }

    IEnumerator triggerThirdConvo()
    {
        yield return new WaitForSeconds(7);
        ringing.Play();
        thirdConvoStarts = true; 
    }

    public void thirdCall()
    {
        fifthInk.story.ChoosePathString("ThirdConvo");
    }

}
