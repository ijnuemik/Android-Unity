using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;



public class ARController : MonoBehaviour
{


    private static string dataPath = string.Empty;
    private static string wallPath = string.Empty;
    private static string floorPath = string.Empty;

    // Start is called before the first frame update
    void Start()
    {
        string scenename = SceneManager.GetActiveScene().name;
        scenename = scenename.Substring(0, scenename.Length - 2);
        Debug.Log(scenename);
        string title = Strings.title; //title 받아오기
        dataPath = System.IO.Path.Combine(Application.persistentDataPath, scenename + title + "aractors.json");
        wallPath = System.IO.Path.Combine(Application.persistentDataPath, scenename + title + "wall1.json");
        floorPath = System.IO.Path.Combine(Application.persistentDataPath, scenename + title + "floor1.json");

        SaveData.ARLoad(dataPath);
        SaveData.LoadWall(wallPath);
        SaveData.LoadFloor(floorPath);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
