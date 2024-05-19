using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFunction : MonoBehaviour
{

    [SerializeField] Vector3 lightAngle;
    [SerializeField] Camera mainCamera;

    bool followCamera = false;
    void Start()
    {
        mainCamera = Camera.main.GetComponent<Camera>();
        lightAngle = gameObject.transform.eulerAngles;
    }

    private void FixedUpdate()
    {
        if(followCamera)
        gameObject.transform.eulerAngles = new Vector3(mainCamera.transform.eulerAngles.x, mainCamera.transform.eulerAngles.y, 0);
    }

    public void SetLightToCameraDirection()
    {
        followCamera = true;
    }
    public void SetLightToFixedAngle()
    {
        gameObject.transform.eulerAngles = lightAngle;
        followCamera = false;
    }
}
