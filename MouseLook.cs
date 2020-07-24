using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class MouseLook : MonoBehaviour
{
    public float mouseSpeed;
    public Transform playerBody;
    public Transform Target;
    float xRotation = 0f;
    public float motionBlur;

    public PostProcessProfile PPP;
    public MotionBlur MB;

    void Start()
    {
        motionBlur = GameOver.MotionBlur;
        MB = PPP.GetSetting<MotionBlur>();
        MB.shutterAngle.value = motionBlur;
        PPP.GetSetting<MotionBlur>().shutterAngle = MB.shutterAngle;
        mouseSpeed = GameOver.MouseSens;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {

	//Mouse rotates at certain speeds
        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;

	//rotate camera with respect to mouse
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
