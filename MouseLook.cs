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
    // public PostProcessEffectSettings PPES;
    //public Transform Obstruction;
    //float zoomSpeed = 2f;
    //public PostProcessVolume PPV;
    public PostProcessProfile PPP;
    public MotionBlur MB;

    void Start()
    {
        motionBlur = GameOver.MotionBlur;
        //PPP = PPV.Get
        MB = PPP.GetSetting<MotionBlur>();
        MB.shutterAngle.value = motionBlur;
        PPP.GetSetting<MotionBlur>().shutterAngle = MB.shutterAngle;
        // Target.transform.position = transform.position;
        //Obstruction = Target;
        //motionBlur = GameOver.MotionBlur;
        //Camera.main.GetComponent< MotionBlur > =
        //PPES.
        //shutterAngle.value = GameOver.MotionBlur;
        //.MotionBlur.shutterAngle.value = GameOver.MotionBlur;
        mouseSpeed = GameOver.MouseSens;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;


        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
    /*private void LateUpdate()
    {
        ViewObstructed();
    }
    void ViewObstructed()
    {
        RaycastHit hit;
        if(Physics.Raycast(playerBody.position, Target.position - playerBody.position, out hit, 4.5f)){
            if (hit.collider.gameObject.tag != "Player"){
                Obstruction = hit.transform;
                Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;
                if(Vector3.Distance(Obstruction.position, playerBody.position) >= 3f && Vector3.Distance(playerBody.position, Target.position) >= 1.5f)
                {
                    playerBody.Translate(Vector3.forward * zoomSpeed * Time.deltaTime);
                }
            }
            else
            {
                Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                if(Vector3.Distance(playerBody.position, Target.position) < 4.5f)
                {
                    playerBody.Translate(Vector3.back * zoomSpeed * Time.deltaTime);
                }
            }
        }
    }
    */
}
