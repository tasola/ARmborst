using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_ObjectPlacement : MonoBehaviour {

    public GameObject m_target;
    public int numberOfTargets = 1;

    private TangoPointCloud m_pointCloud;

    void Start()
    {
        m_pointCloud = FindObjectOfType<TangoPointCloud>();
    }

    void Update()
    {
        if (Input.touchCount == 1)
        {
            // Trigger place target function when single touch ended.
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Ended)
            {
                // If not all targets are placed out
                if (numberOfTargets > 0)
                {
                    numberOfTargets -= 1;
                    PlaceTarget(t.position);
                }
                else
                {
                    DestroyTarget();
                    numberOfTargets += 1;
                }
            }
        }
    }

    void DestroyTarget()
    {
        GameObject placedTarget = GameObject.FindWithTag("Target");
        Destroy(placedTarget);
    }

    void PlaceTarget(Vector2 touchPosition)
    {
        // Find the plane.
        Camera cam = Camera.main;
        Vector3 planeCenter;
        Plane plane;
        if (!m_pointCloud.FindPlane(cam, touchPosition, out planeCenter, out plane))
        {
            Debug.Log("cannot find plane.");
            return;
        }

        // Place kitten on the surface, and make it always face the camera.
        if (Vector3.Angle(plane.normal, Vector3.up) < 30.0f)
        {
            Vector3 up = plane.normal;
            Vector3 right = Vector3.Cross(plane.normal, cam.transform.forward).normalized;
            Vector3 forward = Vector3.Cross(right, plane.normal).normalized;
            Instantiate(m_target, planeCenter, Quaternion.LookRotation(forward, up));
        }
        else
        {
            Debug.Log("surface is too steep for kitten to stand on.");
        }
    }
}
