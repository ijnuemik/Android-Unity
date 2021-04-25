using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    Vector3 FirstPoint;
    Vector3 SecondPoint;
    float xAngle;
    float yAngle;
    float xAngleTemp;
    float yAngleTemp;       
    public Joybutton joybutton;
    public Joystick joystick;

    // protected bool forward;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.eulerAngles = new Vector3(0, Mathf.Atan2(joystick.Horizontal, joystick.Vertical) * Mathf.Rad2Deg, 0); 
        // Player.eulerAngles = new Vector3(0, Mathf.Atan2(JoyVec.x, JoyVec.y) * Mathf.Rad2Deg, 0);                                
        // transform.Rotate(new Vector3(0, Mathf.Atan2(joystick.Horizontal, joystick.Vertical) * Mathf.Rad2Deg, 0)*0.01f);
        // if(Input.touchCount > 0){
        //     if(Input.GetTouch(0).phase == TouchPhase.Began){
        //         FirstPoint = Input.GetTouch(0).position;
        //         xAngleTemp = xAngle;
        //         yAngleTemp = yAngle;
        //     }
        //     if(Input.GetTouch(0).phase == TouchPhase.Moved){
        //         SecondPoint = Input.GetTouch(0).position;
        //         xAngle = xAngleTemp + (SecondPoint.x - FirstPoint.x) * 180 / Screen.width;
        //         yAngle = yAngleTemp + (SecondPoint.y - FirstPoint.y) * 90 / Screen.height;
        //         this.transform.rotation = Quaternion.Euler(yAngle, -xAngle, 0.0f);
        //     }
        // }         
        if(joybutton.Pressed) {
            transform.Translate(Vector3.forward * 0.1f);
        }
    }


}
