using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour {

    public GameObject projectile;
    public Transform gun;
    public float shootForce = 0f;
    public float shootRate = 0f;

    private float shootRateTimeStamp = 0f;

    public int arrows;
    public Text displayArrows;

    public int totalScore;
    public Text displayTotalScore;

    public Transform crossbow;
    public Transform target;
    public float distToTarget;

    // Use this for initialization
    void Start () {
        totalScore = 0;
        displayTotalScore.text = "Total score: " + totalScore.ToString();
        displayArrows.text = "Arrows left: " + arrows.ToString();

    }

    // Instantiating a new projectile and shooting it away in the gun/camera direction
    public void Shoot() {
        

        if (arrows > 0)
        {
            Handheld.Vibrate();
            //Vibrate(1000);
            distToTarget = Vector3.Distance(target.position, crossbow.position);
            GameObject go = (GameObject)Instantiate(projectile, gun.position, gun.rotation);

            //Physics.IgnoreCollision(go.GetComponent<Collider>(), projectile.GetComponent<Collider>());

            go.GetComponent<Rigidbody>().AddForce(gun.forward * shootForce);

            arrows = arrows - 1;
            displayArrows.text = "Arrows left: " + arrows.ToString();

        }
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



/* //vibrations
 private static readonly AndroidJavaObject Vibrator =
 new AndroidJavaClass("com.unity3d.player.UnityPlayer")// Get the Unity Player.
 .GetStatic<AndroidJavaObject>("currentActivity")// Get the Current Activity from the Unity Player.
 .Call<AndroidJavaObject>("getSystemService", "vibrator");// Then get the Vibration Service from the Current Activity. 

     static void KyVibrator()
     {
         // Trick Unity into giving the App vibration permission when it builds.
         // This check will always be false, but the compiler doesn't know that.
         if (Application.isEditor) Handheld.Vibrate();
     }

     public static void Vibrate(long milliseconds)
     {
         Vibrator.Call("vibrate", milliseconds);
     }

     public static void Vibrate(long[] pattern, int repeat)
     {
         Vibrator.Call("vibrate", pattern, repeat);
     } */
