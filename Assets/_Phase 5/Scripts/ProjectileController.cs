using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ProjectileController : MonoBehaviour
{   // Comment
    //public Text displayScore; //Was thinking u could have a popup like "+1 point" in middle of screen when u hit target, fades after 2 sec.
    public bool dead = false;

    private int targetScore = 0;
    private Rigidbody rb;
    private ScoreController sc;

    void Start() {
        rb = GetComponent<Rigidbody>();
        GameObject go = GameObject.Find("ScoreController");
        sc = go.GetComponent<ScoreController>();
    }

    void OnCollisionEnter(Collision collision)
    {
		sc.changeText("Only Collision enter");
        if (collision.gameObject.tag == "Target") {
            // Play hit sound here

            rb.isKinematic = true;
            sc.updateScore();

			//Remove collider on impact
			Collider arrowCol = GetComponent<Collider>();
			arrowCol.enabled = false;
        }
    }
}
