using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ScoreController : MonoBehaviour {
    public int initialAmmo;
    public int totalScore;
    public Text displayAmmo;
    public Text displayTotalScore;
    public int distanceScale = 3;
    public int targetScore = 1;

	public GameObject fireBttn;
	public GameObject loadBttn;

    private float distToTarget;
    private int ammoLeft;
	private bool scoreOff = true;

	//private ProjectileShooter shootScript;

	// Use this for initialization
	void Start () {
		//Reset();
	}

	public void saveDistance(float distance) {
		distToTarget = distance;
	}

	public void updateAmmo() {
		ammoLeft -= 1;
		if (ammoLeft == 0) {
			displayAmmo.text = "Bolts left: " + ammoLeft.ToString ();

			displayTotalScore.text = "Final score: " + totalScore.ToString();
			print (Color.green);
		} 
		else {
			displayAmmo.text = "Bolts left: " + ammoLeft.ToString ();
		}
	}

	public void updateScore() {
		displayTotalScore.text = "UpdateScore";
		int distanceScore = (int)(distToTarget * distanceScale);
		int score = targetScore * distanceScore;
		totalScore += score;

		displayTotalScore.text = "Score: " + totalScore.ToString ();
	}

	public void Reset() {
		GameObject[] gos = GameObject.FindGameObjectsWithTag("ArrowTag");
		foreach (GameObject go in gos)
			Destroy(go);
		
		totalScore = 0;
		ammoLeft = initialAmmo;
		displayTotalScore.text = "Score: " + totalScore.ToString();
		displayAmmo.text = "Bolts left: " + ammoLeft.ToString();
	}

	public int getAmmoLeft() {
		return ammoLeft; 
	}

	// Switch off game mode and enter free mode (unlimited ammo & no target)
	public void switchOffScore(bool switchOff) {
		if (switchOff) {
			scoreOff = true;
		} else {
			scoreOff = false;
		}
	}

	public void changeText(string text) {
		displayTotalScore.text = "Score: " + totalScore.ToString ();
	} 
}
