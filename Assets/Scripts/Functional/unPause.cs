using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class unPause : MonoBehaviour
{

    public Pause paused;

    public void OnButtonPress()
    {
        paused.UnPauseGame();
    }

}