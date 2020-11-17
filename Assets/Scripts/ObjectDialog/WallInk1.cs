using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class WallInk1 : MonoBehaviour
{

    public TextAsset inkJSONAsset;
    public Story story;
    public Button buttonPrefab;
    public GameObject panel;
   // public Text textPrefab;
    private Text storyText;
    // public GameObject firstPanel;
    public List<string> tags;
    //public GameObject panel1;
    public Text textPanel;
    



    // Start is called before the first frame update
    void Start()
    {
        //load the next story block
        story = new Story(inkJSONAsset.text);

        //start the refresh cycle
        // refresh();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void refreshStory()
    {
        story = new Story(inkJSONAsset.text);
    }


    //refresh the UI elements
    // - clear any current elements
    // - show any text chunks
    // - iterate through any choices and create listeners on them

    public void refresh()
    {

        //clear the ui

        if (story.currentChoices.Count < 1)
        {
            clearUI();
        }


        if (story.canContinue)
        {

            clearUI();

            //  Text storyText = Instantiate(textPrefab) as Text;

            //load next block and save text (if any)
            string text = getNextStoryBlock();

            textPanel.text = text;
            //textPanel.transform.SetParent(panel.transform, true);
            // textPanel.transform.SetAsFirstSibling();


            parseTags();

            foreach (Choice choice in story.currentChoices)
            {
                Button choiceButton = Instantiate(buttonPrefab) as Button;
                choiceButton.transform.SetParent(this.transform, false);

                //gets the text from the button prefab
                Text choiceText = choiceButton.GetComponentInChildren<Text>();
                choiceText.text = choice.text;

                //set listener
                choiceButton.onClick.AddListener(delegate
                {
                    onClickChoiceButton(choice);
                });
            }
        }


        if (story.canContinue == false)
        {
            //panel.SetActive(false);
            Debug.Log("storyCantContinue");
            //  clearUI();
            // refreshStory();
            //  getNextStoryBlock();
        }


        if (panel.activeInHierarchy == false)
        {
            //  refreshStory();
            Debug.Log("paneInactive");
        }
    }


    //when we click the choice button, tell the story to choose that choice
    void onClickChoiceButton(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        refresh();
    }


    //clear out all of the UI, calling Destroy() in reverse
    public void clearUI()
    {
        textPanel.text = "";


        /*
        int childCount = panel.transform.childCount;

        for (int i = childCount - 1; i >= 0; --i)
        {
            GameObject.Destroy(panel.transform.GetChild(i).gameObject);
        }
        */
    }


    //load and potentially return the next story block
    string getNextStoryBlock()
    {
        string text = "";

        if (story.canContinue)
        {
            text = story.Continue();
            Debug.Log("storyCont.");
        }
        else
        {
            //  panel.SetActive(false);
            //refreshStory();
        }
        return text;
    }


    //***tag parser***///
    //in inky you can use tags which can be used to cue stuff in a game
    // this is just one way of doing it. not the only method to trigger events. 
    public void parseTags()
    {
        tags = story.currentTags;
        if (tags.Count != 0)
        {
            Debug.Log(tags[0]);

            if (tags.Count > 1)
            {
                Debug.Log(tags[1]);
            }
            if (tags.Count > 2)
            {
                Debug.Log(tags[2]);
            }
        }
    }
}
