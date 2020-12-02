using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class FifthInk : MonoBehaviour
{

    public TextAsset inkJSONAsset;
    public Story story;
    public Button buttonPrefab;
    public GameObject panel;
    public Text textPrefab;
    private Text storyText;
    // public GameObject firstPanel;
    public List<string> tags;
    public GameObject panel1;
    public Text textPanel;

    public bool storyGoing;


    public AudioSource mainMusic;
    public AudioSource firstSong;
    public AudioSource secondConvoSong;
    public AudioSource thirdConvoSong;


    //scripts called and related to this one within here and otherwise
    public FirstConvoTest firstConvoTest;
    public PostConvoOne postConvoOne;
    public SecondConvo secondConvo;
    public PostConvoTwo postConvoTwo;
    public ThirdConvo thirdConvo;
    public PostThirdConvo postThirdConvo;
    public PostPostThird postPostThird;
   // public ObjectTalk1 objectTalk1; 

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
            storyGoing = true; 

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
            storyGoing = false; 
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





    //***tag parser***///
    //in inky you can use tags which can be used to cue stuff in a game
    // this is just one way of doing it. not the only method to trigger events. 
    public void parseTags()
    {
        tags = story.currentTags;

        /*
        if (tags.Count != 0)
        {
            Debug.Log(tags[0]);

            if (tags.Count > 1)
            {
                Debug.Log(tags[1]);
            }
            if(tags.Count > 2)
            {
                Debug.Log(tags[2]);
            }

           
        }
        */

        
        if (tags.Contains("molly"))
        {
           Debug.Log("mollyChangeColors!");
           textPrefab.GetComponent<Text>().material.color = Color.black;
           panel1.transform.GetChild(0).GetComponent<RectTransform>().localPosition = new Vector3(-400f, -350f, 0f);
        }

        if (tags.Contains("phone"))
        {
            Debug.Log("phoneChangeColors!");
            panel1.transform.GetChild(0).GetComponent<RectTransform>().localPosition = new Vector3(200f, -280f, 0f);

            textPrefab.GetComponent<Text>().material.color = new Color32(123, 123, 123, 255);
        }

        if (tags.Contains("firstSong"))
        {
            mainMusic.mute = true;
            firstSong.mute = false;
            Debug.Log("newSong");
        }

        if (tags.Contains("endFirstSong"))
        {
            mainMusic.mute = false;
            firstSong.mute = true;
            Debug.Log("changedMusicpls");
        }

        if (tags.Contains("endFirstMonologue"))
        {
            firstConvoTest.tagStart();
        }

        if (tags.Contains("endConvoOne"))
        {
            postConvoOne.postConvoOneStart();
        }

        if (tags.Contains("a"))
        {
            postConvoOne.postConvoOneMove();
            Debug.Log("callfromFifth");
        }

        if (tags.Contains("postOneDone"))
        {
            Debug.Log("sdfs");
            secondConvo.secondConvoStartTrigger();
        }

        if (tags.Contains("secondConvoSong"))
        {
            Debug.Log("secConvoSong");
            mainMusic.mute = true; 
            secondConvoSong.mute = false;
        }

        if (tags.Contains("endSecondConvoSong"))
        {
            Debug.Log("EndsecConvoSong");
            mainMusic.mute = false;
            secondConvoSong.mute = true;
        }

        if (tags.Contains("endSecondConvo"))
        {
            Debug.Log("endedSecondConversation");
            postConvoTwo.postConvoTwoBegin();
            Debug.Log("EndsecConvoSong");
            mainMusic.mute = false;
            secondConvoSong.mute = true;
        }

        if (tags.Contains("endPostConvoTwo"))
        {
            Debug.Log("endedFirstPartofPostTwoo");
            postConvoTwo.postConvoTwoTwoBegin();
        }

        if (tags.Contains("g"))
        {
            Debug.Log("endedPostTwoTwo");
            thirdConvo.thirdConvoTrigger();
        }

        if (tags.Contains("thirdConvoStart"))
        {
            Debug.Log("thirdConvoStartingggg");
            mainMusic.mute = true;
            thirdConvoSong.mute = false;
        }

        if (tags.Contains("endThirdConvo"))
        {
            Debug.Log("endedNumberThree");
            postThirdConvo.postThirdConvoBegin();
           // mainMusic.mute = false;
           // thirdConvoSong.mute = true; 
        }

        if (tags.Contains("PostThirdConvoMove"))
        {
            Debug.Log("movinAgain");
            postThirdConvo.movingAgain();
        }

        if (tags.Contains("postThirdConvoStart"))
        {
            Debug.Log("postStartmusic");
            mainMusic.mute = false;
            thirdConvoSong.mute = true;
        }

        if (tags.Contains("endPostThirdConvo"))
        {
            Debug.Log("endjPostjThirjdConvjo");
            postPostThird.postPostThirdConvoBegin();
        }

        if (tags.Contains("endPostPostThird"))
        {
            Debug.Log("StopPostPostThird");
            postPostThird.secondRinging();
        }

    }


    public void firstCall()
    {
        story.ChoosePathString("ConvoOne");
        Debug.Log("testing2");
    }

    public void PostConvoOne()
    {
        story.ChoosePathString("PostConvoOne");
        Debug.Log("postConvoOneStarting");
        //postConvoOne.postConvoOneStart();
    }


}
