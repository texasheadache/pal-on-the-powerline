using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class ThirdInk : MonoBehaviour
{

    public TextAsset inkJSONAsset;
    private Story story;
    public Button buttonPrefab;
    public GameObject panel;
    public Text textPrefab;

    // Start is called before the first frame update
    void Start()
    {
        //load the next story block
        story = new Story(inkJSONAsset.text);

        //start the refresh cycle
        refresh();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            refresh();
        }
        */

        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
           Debug.Log(getNextStoryBlock());


        foreach (Choice choice in story.currentChoices)
        {
            Debug.Log("The index is " + choice.index + " and its text is '" + choice.text + "'");
        }

            if (story.currentChoices.Count > 0)
            {
                story.ChooseChoiceIndex(0);
            }

          // Debug.Log(getNextStoryBlock());


        }
        */

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


        if (story.canContinue == true)
        {

            Text storyText = Instantiate(textPrefab) as Text;

            string text = getNextStoryBlock();

            storyText.text = text;
            storyText.transform.SetParent(this.transform, true);
            storyText.transform.SetAsFirstSibling();



            //create a new GameObject
          //  GameObject newGameObject = new GameObject("TextChunk");

            //set it's transform to the canvas (this)
          //  newGameObject.transform.SetParent(this.transform, false);


            //add a new text component to the new GameObject
           // Text newTextObject = newGameObject.AddComponent<Text>();

            //set the fontsize larger
          //  newTextObject.fontSize = 60;

            //access the global variable and change its value
            // story.EvaluateFunction("changeName", "Alva");


            /*
            //set the text from new story block
            newTextObject.text = getNextStoryBlock();
            */

            // Load the next block and save text (if any)
          //  string text = getNextStoryBlock();

            // Get the current tags (if any)
            List<string> tags = story.currentTags;

            // If there are tags, use the first one.
            // Otherwise, just show the text.
            /*
            if (tags.Count > 0)
            {
                newTextObject.text = "<color=grey>" + tags[0] + "</color> – " + text;
            }
            else
            {
                newTextObject.text = text;
            }

            //load arial from the built in resources
            newTextObject.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
            */


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
                    OnClickChoiceButton(choice);
                });

            }
        }


        if (story.canContinue == false)
        {
            panel.SetActive(false);
            // refreshStory();
            Debug.Log("donesi");
            // panel.SetActive(false);
            //  getNextStoryBlock();
        }



        if (panel.activeInHierarchy == false)
        {
            refreshStory();
            Debug.Log("refreshedStory");
        }


    }

    //when we click the choice button, tell the story to choose that choice
    void OnClickChoiceButton(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        refresh();
    }


    //clear out all of the UI, calling Destroy() in reverse
    void clearUI()
    {
        int childCount = this.transform.childCount;


        for (int i = childCount - 1; i >= 0; --i)
        {
            GameObject.Destroy(this.transform.GetChild(i).gameObject);
        }
    }

    //load and potentially return the next story block
    string getNextStoryBlock()
    {
        string text = "";

        if (story.canContinue)
        {
            text = story.Continue();
            Debug.Log("loged");
        }
        else
        {
            //  panel.SetActive(false);
            Debug.Log("done");
            //refreshStory();
        }
        return text;
    }

    public void refreshStory()
    {
        story = new Story(inkJSONAsset.text);
    }

}
