using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPlacementControl : MonoBehaviour {

    public GameObject m_target;
    public int numberOfTargets = 1;
	public float holdTime;
    public Button fireBttn;
	public Button loadBttn;
	public Button restBttn;

    private TangoPointCloud m_pointCloud;
    private Vector3 offSet = new Vector3(0, 1, 0);
	private RectTransform rectTransform;
	private float touchTime;
	private float startTime;
	private ScoreController scoreController;
	private ProjectileShooter psScript;

    void Start()
    {
        m_pointCloud = FindObjectOfType<TangoPointCloud>();
		scoreController = FindObjectOfType<ScoreController>();
		psScript = FindObjectOfType<ProjectileShooter> ();
    }

    void Update()
    {
        // If one touch or mousebutton
        if (Input.touchCount == 1) {
            Touch t = Input.GetTouch(0);
			if (IfOutsideOfButton (t)) {
				// When the finger touches the screen
				if (t.phase == TouchPhase.Began) {
					touchTime = Time.time;
				}
				// When the finger is held on screen for a time
				else if (Time.time-touchTime >= holdTime) {
					Handheld.Vibrate ();
					PlacementControl (t);
				}
			}
        }
    }

    // Check if the position of the touch is outside the button
    bool IfOutsideOfButton(Touch t) {
		// LOAD
		if (loadBttn.gameObject.activeSelf) {
			rectTransform = loadBttn.GetComponent<RectTransform> ();
		}
		// FIRE
		else if (fireBttn.gameObject.activeSelf) {
			rectTransform = fireBttn.GetComponent<RectTransform> ();
		}
		// RESTART
		else if (restBttn.gameObject.activeSelf) {
			rectTransform = restBttn.GetComponent<RectTransform> ();
		}
		// No button in the way
		else {
			return true;
		}

        Camera camera = null;
        if (!RectTransformUtility.RectangleContainsScreenPoint(rectTransform, t.position, camera)) {
            //Debug.Log("Outside of button!");
            return true;
        } else {
            //Debug.Log("Inside of button!");
            return false;
        }
    }

    void PlacementControl(Touch t) {
        // Trigger place target function when the touch ended.
		if (t.phase == TouchPhase.Ended)
        {
            // If not all targets are placed out
            if (numberOfTargets > 0)
            {
                numberOfTargets -= 1;
                PlaceTarget(t.position);
				scoreController.switchOffScore (false);
				psScript.Restart ();

				loadBttn.gameObject.SetActive(true);
            }
			// If there are no targets to place out
            else
            {
                GameObject[] gos = GameObject.FindGameObjectsWithTag("ArrowTag");
                foreach (GameObject go in gos)
                    Destroy(go);

				GameObject loadedArrow = GameObject.FindGameObjectWithTag("LoadedArrow");
				Destroy (loadedArrow);

                DestroyTarget();
                numberOfTargets += 1;
				scoreController.switchOffScore(true);

				loadBttn.gameObject.SetActive(false);
				fireBttn.gameObject.SetActive(false);
				restBttn.gameObject.SetActive (false);
            }
        }
    }

    void DestroyTarget() {
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
            Instantiate(m_target, planeCenter + offSet, Quaternion.LookRotation(-forward, up));
        }
        else
        {
            Debug.Log("surface is too steep for kitten to stand on.");
        }
    }
}
