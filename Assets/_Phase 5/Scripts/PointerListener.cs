using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerListener : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private bool _pressed = false;
    private LoadProjectile loadScript;

    // Use this for initialization
    void Start()
    {
        GameObject go = GameObject.Find("Player");
        loadScript = go.GetComponent<LoadProjectile>();
    }

    // When button is pressed down
    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("Button pressed");
        loadScript.resetDrawback();
        loadScript.drawbackSwitch();
    }

    // When button is released
    public void OnPointerUp(PointerEventData eventData)
    {
        //Debug.Log("Button released");
        loadScript.drawbackSwitch();
    }

    void Update()
    {
        if (!_pressed)
            return;

        // DO SOMETHING HERE
    }
}
