using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProjectileController : MonoBehaviour
{


    public int score = 0;
    //public Text displayScore; //Was thinking u could have a popup like "+1 point" in middle of screen when u hit target, fades after 2 sec.


    private ProjectileShooter playerController;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = 0;

      /*  GameObject[] arrows = GameObject.FindGameObjectsWithTag("ArrowTag");

        foreach (GameObject arrow in arrows)
        {
            Physics.IgnoreCollision(arrow.transform.GetComponent<Collider>(), GetComponent<Collider>(), true);
        } */

        GameObject crossbow = GameObject.Find("Player");
        playerController = crossbow.GetComponent<ProjectileShooter>();
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Target")
        {
            generatePoints(5);
        }
        
    }

    void generatePoints(int areaBasedPoints)
    {
        Debug.Log("Ball just collided with the Target Wall!");
        int scoreScale = (int)((playerController.distToTarget)*3);

        score = areaBasedPoints * ((scoreScale) * 2);
        //score = 5;
        playerController.totalScore += score;
        playerController.displayTotalScore.text = "Total score: " + playerController.totalScore.ToString();

        rb.isKinematic = true;

        Collider arrowCol = GetComponent<Collider>(); 
        arrowCol.enabled = false;

        //bigShaqSound.Play ();
    }



}
