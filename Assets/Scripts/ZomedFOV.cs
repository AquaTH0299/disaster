using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ZomedFOV : MonoBehaviour
{
    public Animator animator;
    [SerializeField] Camera fpsCamera;
    [SerializeField] float zoomedOutFov = 60f;
    [SerializeField] float zoomedInFOV =20f;
    private float zoomedOutSensitivity ;
    [SerializeField] float zoomedInSensitivity = 0.75f;
    RigidbodyFirstPersonController fpsController;

    bool zoomedInToggle = false;
    private void Start() 
    {
        fpsController = GameObject.Find("Player").GetComponent<RigidbodyFirstPersonController>();
    }
    private void Update() 
    {
        if(Input.GetMouseButtonDown(1))
        {
            zoomedInToggle = !zoomedInToggle;
            animator.SetBool("GoodView", zoomedInToggle);
            if(zoomedInToggle)
            {
                ZoomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }

    private void ZoomOut()
    {
        fpsCamera.fieldOfView = zoomedOutFov;
        fpsController.mouseLook.XSensitivity = zoomedOutSensitivity;
        fpsController.mouseLook.YSensitivity = zoomedOutSensitivity;
    }

    private void ZoomIn()
    {
        fpsCamera.fieldOfView = zoomedInFOV;
        fpsController.mouseLook.XSensitivity = zoomedInSensitivity;
        fpsController.mouseLook.YSensitivity = zoomedInSensitivity;
    }
}
