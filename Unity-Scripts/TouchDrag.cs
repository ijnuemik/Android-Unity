using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDrag : MonoBehaviour
{
	private Vector3 screenSpace;
	private Vector3 offset;    
    // public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.touchCount != 0) {
        //     // print("updatiafasdf");

        //     // Touch t = Input.GetTouch(0);
        //     // if(t.phase == TouchPhase.Moved) {
        //     //     float distanceToScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        //     //     Vector3 posMove = Camera.main.ScreenToWorldPoint(
        //     //                         new Vector3(t.position.x, t.position.y, distanceToScreen));


        //     //     float nextX = player.transform.position.x + posMove.x;
        //     //     print("====================");
        //     //     print(nextX);

        //     //     player.transform.position = new Vector3(posMove.x, transform.position.y, 0);
            
        //     //     // if(nextX <= 5.0 && nextX >= -5.0) {
        //     //     //     player.transform.position = new Vector3(posMove.x, transform.position.y, 0);

        //     //     // }
        //     // }  
        //     Touch t = Input.GetTouch(0);

        //     if(Input.GetTouch(0).phase == TouchPhase.Began){
        //         print("begin~!~!");
        //         //translate the cubes position from the world to Screen Point
        //         screenSpace = Camera.main.WorldToScreenPoint(transform.position);

        //         //calculate any difference between the cubes world position and the mouses Screen position converted to a world point  
        //         offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y, screenSpace.z));
        //     }
        //     if(Input.GetTouch(0).phase == TouchPhase.Moved){
        //         print("hihihi");
        //         //keep track of the mouse position
        //         var curScreenSpace = new Vector3(t.position.x, t.position.y, screenSpace.z);

        //         //convert the screen mouse position to world point and adjust with offset
        //         var curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;

        //         //update the position of the object in the world
        //         transform.position = curPosition;
        //     }            
        // }
    }

	// void OnMouseDrag()
	// {
    //     while(Input.GetMouseButton(0)) {
    //         Vector2 mouseDragPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
    //         Vector2 worldObjectPosition = Camera.main.ScreenToWorldPoint(mouseDragPosition);
    //         this.trnasform.position = worldObjectPosition;
        
    //     }
    // }    
}
