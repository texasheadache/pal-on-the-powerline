using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class StartTalk2 : MonoBehaviour
{

    public GameObject panel;
    public FourthInk fourthInk;
    public bool playerInRange;
    public Story story; 


    // Start is called before the first frame update
    void Start()
    {
        story = fourthInk.story;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (panel.activeInHierarchy == false)
            {
                panel.SetActive(true);
            }

           // fourthInk.refresh();


            
            if (fourthInk.story.canContinue == true)
            {
                fourthInk.refresh();
            }
            else if(fourthInk.story.canContinue == false)
            {
                fourthInk.clearUI();
            }
            
        }
    }
}
