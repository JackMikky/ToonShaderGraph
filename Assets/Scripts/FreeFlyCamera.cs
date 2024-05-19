using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class FreeFlyCamera : MonoBehaviour
{
    Camera camera;
    [SerializeField] bool useFreeCamera = false;

    [Header("Mouse Movement")]

    [Range(0, 10)]
    [SerializeField] float speed = 2;
    float speedCash;
    [SerializeField] float boostSpeed = 15;
    [Space(10)]
    [Header("Mouse Rotation")]
    [Range(0, 10)]
    [SerializeField] float X_RotateSensity = 2;

    [Range(0, 10)]
    [SerializeField] float Y_RotateSensity = 2;
    float x, y;

    private Action<bool> OnChangeToFreeCamera;
    private void Awake()
    {
        speedCash = speed;
        boostSpeed = Mathf.Lerp(0, 50, speed * 2.5f);
        camera = GetComponent<Camera>();
        OnChangeToFreeCamera += MouseStateChange;
        OnChangeToFreeCamera += BoostSpeed;
        OnChangeToFreeCamera += MouseRotation;
        OnChangeToFreeCamera += CameraMovement;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ExitFreeCamera();
        }
        
        if (useFreeCamera)
            OnChangeToFreeCamera?.Invoke(useFreeCamera);
    }

    void MouseStateChange(bool useFreeCamera)
    {
        if (useFreeCamera)
            Cursor.lockState = CursorLockMode.Locked;
        else
            Cursor.lockState = CursorLockMode.Confined;
    }
    void MouseRotation(bool useFreeCamera)
    {
        if (!useFreeCamera)
        {
            return;
        }
         y = Input.GetAxis("Mouse X");
         x = Input.GetAxis("Mouse Y");
        var rotate = new Vector3(x * X_RotateSensity,-y*Y_RotateSensity,0);
        camera.transform.eulerAngles = camera.transform.eulerAngles - rotate;

    }
    void BoostSpeed(bool useFreeCammera)
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = boostSpeed;
        }
        else
        {
            speed = speedCash;
        }
    }
    void CameraMovement(bool useFreeCamera)
    {
        if (!useFreeCamera)
        {
            return;
        }

        var forward_back = 0f;
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            forward_back += 1;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            forward_back -= 1;
        }
        var lft_right = 0f;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            lft_right -= 1;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            lft_right += 1;
        }

        float Up_Down = 0f;
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Up_Down += 1;
        }
        else if (Input.GetKey(KeyCode.C))
        {
            Up_Down -= 1;
        }
        Vector3 delta = new Vector3(lft_right, Up_Down, forward_back) * speed * Time.deltaTime;
        camera.transform.localPosition += camera.transform.TransformDirection(delta);
    }

    void ExitFreeCamera()
    {
        useFreeCamera = !useFreeCamera;
        if (useFreeCamera == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
