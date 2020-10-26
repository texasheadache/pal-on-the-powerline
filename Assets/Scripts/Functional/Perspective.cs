using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perspective : MonoBehaviour
{

    private GameObject player;
    public SpriteRenderer sprite;
    public GameObject pivot; 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        ChangePerspective();
    }


    public void ChangePerspective()
    {
        if(player.transform.position.y > pivot.transform.position.y)
        {
            sprite.sortingOrder = 2; 
        }
        else
        {
            sprite.sortingOrder = 0; 
        }
    }

}
