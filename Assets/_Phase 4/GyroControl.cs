using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gyro : MonoBehaviour {

    private bool gyroEnabled;
    private Gyroscope gyro; 

	// Use this for initialization
	void Start () {
        gyroEnabled = EnableGyro(); 		
	}
	
	// Update is called once per frame
	private bool EnableGyro () {

		if (SystemInfo.supportsGyroscope) {
            gyro = Input.gyro;
            gyro.enabled = true;
            return true; 
        }

        return false; 
	}
}
