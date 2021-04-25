using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverviewCamera : MonoBehaviour
{
    Vector3 FirstPoint;
    Vector3 SecondPoint;
    public float xAngle;
    public float yAngle;
    float xAngleTemp;
    float yAngleTemp;
    public float perspectiveZoomSpeed = 0.5f;        // The rate of change of the field of view in perspective mode.
    public float orthoZoomSpeed = 0.5f;        // The rate of change of the orthographic size in orthographic mode.
    public GameManager gamemanager;
    public GameObject cameraOrbit;

    public float rotateSpeed;
    void Start () {
        // xAngle = 0;
        // yAngle = 90;
        // this.transform.rotation = Quaternion.Euler(yAngle, xAngle, 0);        
    }

    void Update () {
        if (Input.touchCount == 2)
        {
            print("its two touch");
            // Store both touches.
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            // Find the position in the previous frame of each touch.
            Vector2 touchZeroPrevPos = touchZero.position - touchZero.deltaPosition;
            Vector2 touchOnePrevPos = touchOne.position - touchOne.deltaPosition;

            // Find the magnitude of the vector (the distance) between the touches in each frame.
            float prevTouchDeltaMag = (touchZeroPrevPos - touchOnePrevPos).magnitude;
            float touchDeltaMag = (touchZero.position - touchOne.position).magnitude;

            // Find the difference in the distances between each frame.
            float deltaMagnitudeDiff = prevTouchDeltaMag - touchDeltaMag;

            // If the camera is orthographic...
            if (Camera.main.orthographic)
            {
                print("ortho");
                // ... change the orthographic size based on the change in distance between the touches.
                Camera.main.orthographicSize += deltaMagnitudeDiff * orthoZoomSpeed;

                // Make sure the orthographic size never drops below zero.
                Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize, 0.1f);
            }
            else
            {
                print("else");
                // Otherwise change the field of view based on the change in distance between the touches.
                Camera.main.fieldOfView += deltaMagnitudeDiff * perspectiveZoomSpeed;

                // Clamp the field of view to make sure it's between 0 and 180.
                Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView, 0.1f, 179.9f);
            }
        }        
        else if(Input.touchCount > 0 && !gamemanager.selected){
            print("it makes camera turn....");
            if (Slide.outind == false && Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                //    print("oh someone clickckck");
                Touch touchZero = Input.GetTouch(0);

                float h = rotateSpeed * touchZero.deltaPosition.x;
                float v = rotateSpeed * touchZero.deltaPosition.y;


                if (cameraOrbit.transform.eulerAngles.z + v <= 0.1f || cameraOrbit.transform.eulerAngles.z + v >= 179.9f)
                        v = 0;

                cameraOrbit.transform.eulerAngles = new Vector3(cameraOrbit.transform.eulerAngles.x, cameraOrbit.transform.eulerAngles.y + h, cameraOrbit.transform.eulerAngles.z + v);
            }            
            // if(Input.GetTouch(0).phase == TouchPhase.Began){
            //     FirstPoint = Input.GetTouch(0).position;
            //     xAngleTemp = xAngle;
            //     yAngleTemp = yAngle;
            // }
            // if(Input.GetTouch(0).phase == TouchPhase.Moved){
            //     SecondPoint = Input.GetTouch(0).position;
            //     // print(SecondPoint);
            //     GameObject room = GameObject.FindGameObjectWithTag("Room");
             
            //     // xAngle = xAngleTemp + (SecondPoint.x - FirstPoint.x) * 180 / Screen.width;
            //     // yAngle = yAngleTemp + (SecondPoint.y - FirstPoint.y) * 180 / Screen.height;
            //     // print("Xangletmp");
            //     // print(xAngleTemp);

            //     if(SecondPoint.y<=800)
            //         xAngle = xAngleTemp + (FirstPoint.x - SecondPoint.x) * 180 / Screen.width;
            //     else
            //         xAngle = xAngleTemp + (SecondPoint.x - FirstPoint.x) * 180 / Screen.width; 

            //     if(SecondPoint.x<=1280)
            //         yAngle = yAngleTemp + (FirstPoint.y - SecondPoint.y) * 180 / Screen.height;
            //     else
            //         yAngle = yAngleTemp + (SecondPoint.y - FirstPoint.y) * 180 / Screen.height;                          

            //     // print(xAngle);
            //     // print(yAngle);
            //         room.transform.rotation = Quaternion.Euler(0, xAngle-yAngle, 0.0f);



            // }
        }
        
    }  
}