using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour {

    public GameObject projectile;
    public Transform gun;
    public float shootForce = 0f;
    public float shootRate = 0f;

    private float shootRateTimeStamp = 0f;
    private ScoreController sc;
    private bool active = false; // Maybe not usable

    // Use this for initialization
    void Start () {
        GameObject go = GameObject.Find("ScoreController");
        sc = go.GetComponent<ScoreController>();
    }

    // Instantiating a new projectile and shooting it away in the gun/camera direction + vibration
    public void Shoot() {
        Handheld.Vibrate();
        GameObject go = (GameObject)Instantiate(projectile, gun.position, gun.rotation);
        go.GetComponent<Rigidbody>().AddForce(gun.forward * shootForce);
        sc.updateAmmo();
    }

    // Update is called once per frame
    void Update () {
        // Space input on Computer
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (Time.time > shootRateTimeStamp) {
                Shoot();
                shootRateTimeStamp = Time.time + shootRate;
            }
        }
    }
}