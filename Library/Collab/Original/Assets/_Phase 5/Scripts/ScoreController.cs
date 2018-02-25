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
	private Vector3 startPos;


	public GameObject fireBttn;
	public GameObject loadBttn;

    private float distToTarget;
    private int ammoLeft;

	private ProjectileShooter shootScript;

    // Use this for initialization
    void Start () {
	/*	GameObject go = GameObject.Find("Gun");
		gun = go.GetComponent<Transform>();

		go = GameObject.Find("Player");
		shootScript = go.GetComponent<ProjectileShooter>(); */

		Reset();

    }

    public void updateAmmo() {
		distToTarget = Vector3.Distance(target.transform.position, gun.transform.position);
		ammoLeft -= 1;
		if (ammoLeft == 0) {
			loadBttn.SetActive (false);
			fireBttn.SetActive (false);
			displayAmmo.text = "Bolts left: " + ammoLeft.ToString () + ", go pick them up!";

			displayTotalScore.text = "Final score: " + totalScore.ToString();
			print (Color.green);
		} 
		else {
			displayAmmo.text = "Bolts left: " + ammoLeft.ToString ();
		}
	}

    public void updateScore() {
		int distanceScore = (int)(distToTarget * distanceScale);
		int score = targetScore * distanceScore;
		totalScore += score;

		displayTotalScore.text = "Total score: " + totalScore.ToString ();
	}

    public void Reset() {
        totalScore = 0;
        ammoLeft = initialAmmo;
        displayTotalScore.text = "Total score: " + totalScore.ToString();
        displayAmmo.text = "Bolts left: " + ammoLeft.ToString();
		loadBttn.SetActive(true);
		//shootScript.InstBolt();
    }

	public int getAmmoLeft() {
		return ammoLeft; 
	}
}
