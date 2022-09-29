using System;
using System.Collections;
using System.Collections.Generic;
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
    private void OnDisable() 
    {
        OnUnScoped();
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
        yield return new WaitForSeconds(.15f);
    }

    private void OnUnScoped()
    {
        scopedOverlay.SetActive(false);
        guiReticle.SetActive(true);
        weaponCamera.SetActive(true);
        fpsCamera.fieldOfView = normalFOV;
    }
}