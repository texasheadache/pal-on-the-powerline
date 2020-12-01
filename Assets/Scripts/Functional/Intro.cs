using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intro : MonoBehaviour
{

    public GameObject start;
    public GameObject start2;
    private bool changed = false; 
    
    // Start is called before the first frame update
    void Start()
    {
        start.SetActive(true);
        start2.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        Introduction1();
    }

    public void Introduction1()
    {
        if (Input.GetKeyDown(KeyCode.Space) && changed == false)
        {
            start.SetActive(false);
            start2.SetActive(true);
            changed = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            start2.SetActive(false);
            //Debug.Log("sdlfkjsjjj");
        }


    }
}
