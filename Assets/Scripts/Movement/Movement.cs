using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    private Rigidbody2D myRigidbody;
    public float speed;
    public Vector3 change;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        UpdateAnimationAndMove();
        if (change != Vector3.zero)
            {
            anim.SetFloat("movex", change.x);
            anim.SetFloat("movey", change.y);
             }
    }




    void MoveCharacter()
    {
        myRigidbody.MovePosition(
            transform.position + change.normalized * speed * Time.deltaTime);
    }

    void UpdateAnimationAndMove()
    {
        if(change != Vector3.zero)
        {
            MoveCharacter();
        }
    }

    public void freeze()
    {
        speed = 0; 
    }

    public void unFreeze()
    {
        speed = 2.5f; 
    }
}
