using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour {

    public float shootForce = 0f;
    public float shootRate = 0f;
	public GameObject prefab;
    public GameObject loadBttn;
    public GameObject fireBttn;
	public GameObject restartBttn; 
    public Transform spawn;
	//public GameObject ac;

	private float distToTarget;
	private Transform gun;
	public Transform target;
	private int ammoLeft;
	private GameObject projectile;

    
    private float shootRateTimeStamp = 0f;
    private ScoreController sc;
	private int shootSoundID;

    // Use this for initialization
    void Start () {
		projectile = GameObject.FindGameObjectWithTag ("LoadedArrow");

        GameObject go = GameObject.Find("ScoreController");
        sc = go.GetComponent<ScoreController>();

        go = GameObject.Find("Gun");
        gun = go.GetComponent<Transform>();

		shootSoundID = AudioCenter.loadSound ("fire_bow_sound-mike-koenig");
    }

	// Update is called once per frame
	void Update () {
		distToTarget = Vector3.Distance(target.transform.position, gun.transform.position);

		// Space input on Computer
		if (Input.GetKeyDown(KeyCode.Space)) {
			if (Time.time > shootRateTimeStamp) {
				Shoot();
				shootRateTimeStamp = Time.time + shootRate;
			}
		}
	}
    // Instantiating a new projectile and shooting it away in the gun/camera direction + vibration
    public void Shoot() {
		// Save distance to target from shoot position
		sc.saveDistance (distToTarget);

		// SOUND & VIBRATION
		AudioCenter.playSound(shootSoundID);
        Handheld.Vibrate();

        projectile.tag = "ArrowTag";
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.isKinematic = false;
        projectile.GetComponent<Transform>().parent = null;
        rb.AddForce(gun.forward * shootForce);
        fireBttn.SetActive(false);

		sc.updateAmmo();

		ammoLeft = sc.getAmmoLeft();
		if (ammoLeft != 0) {
			InstBolt ();
			loadBttn.SetActive(true);
		}

		else {
			restartBttn.SetActive(true);
		}
	}

	public void InstBolt() {
		projectile = (GameObject)Instantiate (prefab, spawn.position, gun.rotation);
		projectile.tag = "LoadedArrow";
		projectile.GetComponent<Transform> ().parent = gun;
		Rigidbody rb = projectile.GetComponent<Rigidbody> ();
		rb.isKinematic = true;
	}

	public void Restart() {
		restartBttn.SetActive(false);
		sc.Reset();
		InstBolt();
		loadBttn.SetActive(true);
	}

}