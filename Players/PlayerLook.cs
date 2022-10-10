using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    float XRotation = 0;
    public float xSensitivity = 30f;
    public float ySensitivity = 30f;

    public void ProcessLook(Vector2 input)
    {
        float MouseX = input.x;
        float MouseY = input.y;
        //vertical Look (up down)
        XRotation = (MouseY * Time.deltaTime) * xSensitivity;
        XRotation = Mathf.Clamp(XRotation, -80f, 80f);
        cam.transform.localRotation = Quaternion.Euler(XRotation,0,0);
        //Horizontal Look (left right)
        transform.Rotate(Vector3.up * (MouseX * Time.deltaTime) * xSensitivity);

    }
}
