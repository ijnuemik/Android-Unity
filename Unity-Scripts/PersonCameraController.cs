using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonCameraController : MonoBehaviour
{
    Vector3 FirstPoint;
    Vector3 SecondPoint;
    float xAngle;
    float yAngle;
    float xAngleTemp;
    float yAngleTemp;    
    public Joystick joystick;
    public GameObject player;
    public float move_speed=20;

    // Start is called before the first frame update
    void Start()
    {
        // print("oh my gosh");
        // player.transform.position=new Vector3(0,0,0);
        // print(player.transform.position);
        transform.position = player.transform.position;        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;

        if(joystick.Vertical>0.4) {
            transform.Rotate(new Vector3(0, Mathf.Atan2(joystick.Horizontal, joystick.Vertical) * Mathf.Rad2Deg, 0)*0.005f);
            player.transform.Translate(transform.forward*move_speed*0.01f);     
        } else if(joystick.Vertical<-0.4) {
            player.transform.Translate(-transform.forward*move_speed*0.01f);          
        } else {
            transform.Rotate(new Vector3(0, Mathf.Atan2(joystick.Horizontal, joystick.Vertical) * Mathf.Rad2Deg, 0)*0.005f);
        }


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
    }
}
