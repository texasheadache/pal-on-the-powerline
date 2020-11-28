using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    public Pause paused;
    private GameObject player;

    public void Start()
    {
        player = GameObject.Find("Player");

    }

    public void OnButtonPress()
    {
         Application.Quit();
  

    }

}