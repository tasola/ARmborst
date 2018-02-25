using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Comment
public class ProjectileScript : MonoBehaviour
{
    public float expiryTime = 0f;

    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, expiryTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log("Entered collision with " + collision.gameObject.name);
        if (collision.gameObject.tag == "Target")
        {
            GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        // Debug.Log("Still in contact with " + collision.gameObject.name);
    }

    private void OnCollisionExit(Collision collision)
    {
        //  Debug.Log("Left collision with object " + collision.gameObject.name);
    }
}


/*
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProjectileScripts : MonoBehaviour
{


    public int score = 0;
    //public Text displayScore; //Was thinking u could have a popup like "+1 point" in middle of screen when u hit target, fades after 2 sec.


    private ProjectileShooter playerController;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;

        GameObject crossbow = GameObject.Find("Player");
        playerController = crossbow.GetComponent<ProjectileShooter>();
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TargetBlue"))
        {
            generatePoints(1);
        }
        else if (other.gameObject.CompareTag("TargetRed"))
        {
            generatePoints(3);
        }
        else if (other.gameObject.CompareTag("Target"))
        {
            generatePoints(5);
        }

    }

    void generatePoints(int areaBasedPoints)
    {
        Debug.Log("Ball just collided with the Target Wall!");
        int scoreScale = (int)playerController.distToTarget;
        score = areaBasedPoints * ((scoreScale) / 4);

        playerController.totalScore += score;
        playerController.displayTotalScore.text = "Total score: " + playerController.totalScore.ToString();

        rb.isKinematic = true;
        //bigShaqSound.Play ();
    }



}
*/
