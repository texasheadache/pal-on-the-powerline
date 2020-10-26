using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam2D : MonoBehaviour
{

    private GameObject player;
    [SerializeField] float timeOffset;
    [SerializeField] Vector2 posOffset;
    private Vector3 velocity;

    [SerializeField] float leftLimit;
    [SerializeField] float rightLimit;
    [SerializeField] float bottomLimit;
    [SerializeField] float topLimit;

   // private static bool cameraExists; 

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //camera start position
        Vector3 startPos = transform.position;

        //players current position
        Vector3 endPos = player.transform.position;
        endPos.x += posOffset.x;
        endPos.y += posOffset.y;
        endPos.z = -10;

        //set camera transform to a combination of startPos & endPos using LERP which combines the two
        //transform.position = Vector3.Lerp(startPos, endPos, timeOffset * Time.deltaTime);

        //this is smooth dampening
        transform.position = Vector3.SmoothDamp(startPos, endPos, ref velocity, timeOffset);

        //creates boundaries for camera
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
            transform.position.z
            );

    }

    private void OnDrawGizmos()
    {
        //draw box around camera boundary
        Gizmos.color = Color.red;

        //top line
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rightLimit, topLimit));
        //right line
        Gizmos.DrawLine(new Vector2(rightLimit, topLimit), new Vector2(rightLimit, bottomLimit));
        //bottom line
        Gizmos.DrawLine(new Vector2(rightLimit, bottomLimit), new Vector2(leftLimit, bottomLimit));
        //left line
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(leftLimit, topLimit));

    }
}
