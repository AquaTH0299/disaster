using System;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;

public class Scope : MonoBehaviour
{
    public Animator animator;
    public GameObject scopedOverlay;
    public GameObject weaponCamera;
    public GameObject guiReticle;
    private bool isScoped = false;
    public Camera fpsCamera;
    public float scopedFOV = 15f;
    private float normalFOV;
    private float zoomedOutSensitivity;
    private float zoomedInSensitivity = 0.75f;
    [SerializeField] RigidbodyFirstPersonController fpsController;

    // Update is called once per frame
    private void Start() 
    {
        fpsController = GameObject.Find("Player").GetComponent<RigidbodyFirstPersonController>();
    }
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            isScoped =!isScoped;
            animator.SetBool("Scoped", isScoped);
            if (isScoped)
            {
                StartCoroutine(OnScoped());
            }
            else
            {
                OnUnScoped();
            }
        } 
    }
    IEnumerator OnScoped()
    {
        scopedOverlay.SetActive(true);
        guiReticle.SetActive(false);
        weaponCamera.SetActive(false);
        normalFOV = fpsCamera.fieldOfView;
        fpsCamera.fieldOfView = scopedFOV;
        fpsController.mouseLook.XSensitivity = zoomedInSensitivity;
        fpsController.mouseLook.YSensitivity = zoomedInSensitivity;
        yield return new WaitForSeconds(.15f);
    }

    private void OnUnScoped()
    {
        scopedOverlay.SetActive(false);
        guiReticle.SetActive(true);
        weaponCamera.SetActive(true);
        fpsCamera.fieldOfView = normalFOV;
        fpsController.mouseLook.XSensitivity = zoomedOutSensitivity;
        fpsController.mouseLook.YSensitivity = zoomedOutSensitivity;
    }
}
