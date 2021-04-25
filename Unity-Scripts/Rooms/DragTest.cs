using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class DragTest : MonoBehaviour
{
    private Vector3 distance;
    public GameObject RotatePrefab;
    public GameObject DeletePrefab;
    public GameObject InfoPrefab;


    void OnMouseDown()
    {
        try
        {
            distance = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(transform.position).z)) - transform.position;
        }
        catch
        {
            Debug.Log("catch");
        }
    }

    void OnMouseDrag()
    {
        try
        {
            Vector3 distance_to_screen = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 pos_move = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance_to_screen.z));
            transform.position = new Vector3(pos_move.x - distance.x, transform.position.y, pos_move.z - distance.z);
            //GameObject.Find("OverviewCamera").GetComponent<GameManager>().DestroyBtn();
            DestroyBtn();
        }
        catch
        {
            //Debug.Log("catch");
        }


    }

    void OnMouseUp()
    {
        //GameObject.Find("OverviewCamera").GetComponent<GameManager>().CreateBtn();
        CreateBtn();
    }

    void CreateBtn()
    {
        try
        {
            Camera camera = GameObject.Find("OverviewCamera").GetComponent<Camera>();
            Transform current = GetComponent<Transform>();
            Vector3 screenposs = camera.WorldToScreenPoint(current.position);

            GameObject RotateButton = Instantiate(Resources.Load("Button-Rotate"), new Vector3(screenposs.x + 100, screenposs.y + 300, 0), Quaternion.identity) as GameObject;
            RotateButton.transform.SetParent(GameObject.Find("Canvas").transform, true);
            Button Rbtn = RotateButton.GetComponent<Button>();
            Rbtn.onClick.AddListener(RotateObj);

            GameObject InfoButton = Instantiate(Resources.Load("Button-Information"), new Vector3(screenposs.x - 100, screenposs.y + 300, 0), Quaternion.identity) as GameObject;
            InfoButton.transform.SetParent(GameObject.Find("Canvas").transform, true);
            Button Ibtn = InfoButton.GetComponent<Button>();
            Ibtn.onClick.AddListener(InforObj);

            GameObject DeleteButton = Instantiate(Resources.Load("Button-Delete"), new Vector3(screenposs.x, screenposs.y + 300, 0), Quaternion.identity) as GameObject;
            DeleteButton.transform.SetParent(GameObject.Find("Canvas").transform, true);
            Button Dbtn = DeleteButton.GetComponent<Button>();
            Dbtn.onClick.AddListener(DeleteObj);
        }
        catch
        {
            //Debug.Log("catch");
        }

    }

    void RotateObj()
    {

        //Debug.Log(GetComponent<Transform>().localRotation.x);
        GetComponent<Transform>().Rotate(0, 30, 0, Space.World); //Rotate
    }

    void DeleteObj()
    {
        Destroy(GameObject.Find("Button-Rotate(Clone)"));
        Destroy(GameObject.Find("Button-Delete(Clone)"));
        Destroy(GameObject.Find("Button-Information(Clone)"));
        Destroy(gameObject);


    }

    void InforObj()
    {

    }

    public void DestroyBtn()
    {
        Destroy(GameObject.Find("Button-Rotate(Clone)"));
        Destroy(GameObject.Find("Button-Delete(Clone)"));
        Destroy(GameObject.Find("Button-Information(Clone)"));

    }
}