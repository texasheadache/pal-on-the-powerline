using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] public GameObject pausePanel;
    //[SerializeField] public GameObject optionsPanel;
    [SerializeField] AudioSource playMusic;
    [SerializeField] AudioSource playPauseMusic;
   // [SerializeField] AudioSource playCompMusic;
    private GameObject player;

    void Start()
    {
        //pausePanel.SetActive(false);
        player = GameObject.Find("Player");
        Debug.Log("FoundIt");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("first");
            if (!pausePanel.activeInHierarchy)
            {
                Debug.Log("second");
                PauseGame();
            }

            else if (pausePanel.activeInHierarchy)
            {
                UnPauseGame();
                Debug.Log("third");
                playMusic.mute = false;
                player.GetComponent<Movement>().unFreeze();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        if (!pausePanel.activeInHierarchy)
        {
            pausePanel.SetActive(true);
        }
        playMusic.mute = true;
        playPauseMusic.mute = false;
        Debug.Log("Unmuted");
        player.GetComponent<Movement>().freeze();
    }

    public void UnPauseGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
      //  optionsPanel.SetActive(false);
        playMusic.mute = false;
        playPauseMusic.mute = true;
        player.GetComponent<Movement>().unFreeze();
    }


}