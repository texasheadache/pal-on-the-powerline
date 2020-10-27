using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class StartTalk3 : MonoBehaviour
{

    public GameObject panel;
    public FifthInk fifthInk;
    public bool playerInRange;
    public Story story;


    // Start is called before the first frame update
    void Start()
    {
        story = fifthInk.story;
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



            if (fifthInk.story.canContinue == true)
            {
                fifthInk.refresh();
            }
            else if (fifthInk.story.canContinue == false)
            {
                fifthInk.clearUI();
            }

        }
    }
}
