using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class AccelerometerControl : MonoBehaviour {

    public Text accelerometerTextX;
    public Text accelerometerTextY;
    public Text accelerometerTextZ;

    public AudioSource bigShaqSound;

    public bool isVisible = false; 



    void Update()
    {
        accelerometerTextX.text = "Accelerometer, X-axis:  " + Input.acceleration.x;
        accelerometerTextY.text = "Accelerometer, Y-axis:  " + Input.acceleration.y;
        accelerometerTextZ.text = "Accelerometer, Z-axis:  " + Input.acceleration.z;


        if (Input.acceleration.z > 0.75f && Input.acceleration.y < -0.95f && isVisible == false)
        {
            bigShaqSound.Play();
        }

    }
}




    /*    void Example() {
            transform.GetComponent<Cloth>().randomAcceleration = new Vector3(10, 0, 0);
        }

        // Use this for initialization
        void Start () {

        }

        // Update is called once per frame
        void Update () {

           //Input acceleration to object 
            transform.Translate(0, 0, Input.acceleration.y);

            //Returns list of acceleration measurements which occurred during the last frame 
            Vector3 acceleration = Vector3.zero;
            foreach (AccelerationEvent accEvent in Input.accelerationEvents)
            {
                acceleration += accEvent.acceleration * accEvent.deltaTime;
            }
            print(acceleration); */
