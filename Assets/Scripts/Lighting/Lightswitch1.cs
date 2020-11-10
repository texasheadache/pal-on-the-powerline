using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lightswitch1 : MonoBehaviour
{
    public bool playerInRange;
    public GameObject lightsOffPanel; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        lightsOn();
    }

    private void lightsOn()
    {
        if (!lightsOffPanel.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
            {
                lightsOffPanel.SetActive(true);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
            {
                lightsOffPanel.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerInRange = true; 
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false; 
        }
    }
}
