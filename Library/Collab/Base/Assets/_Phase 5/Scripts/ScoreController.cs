using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreController : MonoBehaviour {
    public int initialAmmo;
    public int totalScore;
    public Text displayAmmo;
    public Text displayTotalScore;
    public Transform gun;
    public Transform target;
    public int distanceScale = 3;
    public int targetScore = 5;

	public GameObject fireBttn;
	public GameObject loadBttn;

    private float distToTarget;
    private int ammoLeft;

    // Use this for initialization
    void Start () {
        Reset();
    }

    public void updateAmmo() {
		if (ammoLeft > 0) {
			distToTarget = Vector3.Distance (target.position, gun.position);
			ammoLeft -= 1;
			displayAmmo.text = "Bolts left: " + ammoLeft.ToString ();
		} 
		else {
			loadBttn.SetActive(false);
			fireBttn.SetActive (false);
			displayAmmo.text = "Bolts left: " + ammoLeft.ToString () + ", go pick them up!";
		}
    }

    public void updateScore() {
		if (ammoLeft > 0) {
			int distanceScore = (int)(distToTarget * distanceScale);
			int score = targetScore * distanceScore;
			totalScore += score;
			displayTotalScore.text = "Total score: " + totalScore.ToString ();
		} 
		else {
			displayTotalScore.text = "Final score: " + totalScore.ToString();
			print (Color.green);
		}
    }

    public void Reset() {
        totalScore = 0;
        ammoLeft = ammoLeft = initialAmmo;
        displayTotalScore.text = "Total score: " + totalScore.ToString();
        displayAmmo.text = "Bolts left: " + ammoLeft.ToString();
    }

	// Switch off game mode and enter free mode (unlimited ammo & no target)
	public void hideScore(bool switchOff) {
		if (switchOff) {
			
		} else {
			
		}
	}
}
