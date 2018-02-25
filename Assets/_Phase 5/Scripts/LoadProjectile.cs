using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadProjectile : MonoBehaviour {

    public float loadDist = 1.0f;
    public GameObject fireBttn;
    public GameObject loadBttn;
    public AudioSource stringTensionSound;
	public AudioSource clickSound;

    private Transform gun;
    private ProjectileShooter shootScript;
    private bool isLoading = false;
    private Vector3 startPos;
	private GameObject bolt;
	private Vector3 boltSpawn;
	private float maxBoltDist = 0.3f;
	private float boltDist;

    // Use this for initialization
    void Start () {
        GameObject go = GameObject.Find("Gun");
        gun = go.GetComponent<Transform>();

        go = GameObject.Find("Player");
        shootScript = go.GetComponent<ProjectileShooter>();


		//Överlödig kod!?
		//bolt = GameObject.FindWithTag ("LoadedArrow");
		//boltSpawn = bolt.transform.position;

        resetDrawback();
    }

    public void drawbackSwitch() {
        isLoading = !isLoading;
        if (isLoading) {
            stringTensionSound.Play();
        }
    }

    // Set new start position for the drawback
    public void resetDrawback() {
        startPos = gun.position;
    }

	private void boltAnimation(float drawBackDist){
		float procent = drawBackDist / loadDist;
		boltDist = maxBoltDist * procent - boltDist;
		bolt.transform.Translate (0, 0, boltDist, gun);
	}
	
	// Update is called once per frame
	void Update () {
        float drawbackDist = Vector3.Distance(startPos, gun.position);
		//Vector3 drawbackVector = startPos - gun.position;
		//float drawbackDist = drawbackVector.z;	// Distance only in z-vector
        //Debug.Log("Drawback distance: " + drawbackDist);
        if (isLoading)
        {
			Handheld.Vibrate ();
			//boltAnimation (drawbackDist);

            if (drawbackDist >= loadDist)
            {
                isLoading = false;
                loadBttn.SetActive(false);
                fireBttn.SetActive(true);
				clickSound.Play();
            }
        }
        else {
            stringTensionSound.Stop();
        }
	}
}
