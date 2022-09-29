using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ZomedFOV : MonoBehaviour
{
    public Animator animator;
    [SerializeField] Camera fpsCamera;
    [SerializeField] float zoomedOutFov = 60f;
    [SerializeField] float zoomedInFOV =20f;
    bool zoomedInToggle = false;
    private void OnDisable() 
    {
        ZoomOut();
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
    }
    private void ZoomIn()
    {
        fpsCamera.fieldOfView = zoomedInFOV;
    }
}
