using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Button saveButton;
    public Button loadButton;

    public GameObject SavePanel;


    public const string playerPath = "Prefabs/Chair Variant";

    private static string dataPath = string.Empty;
    private static string wallPath = string.Empty;
    private static string floorPath = string.Empty;


    void Awake()
    {        
        dataPath = System.IO.Path.Combine(Application.persistentDataPath, "actors.json");
    }

    void Start()
    {
        //Debug.Log(Strings.title);
        GameObject[] obj = GameObject.FindGameObjectsWithTag("AR");
        Debug.Log(obj.Length); 
        if(obj.Length == 1)
        {
            Debug.Log("AR!");
            LoadScene();
            Destroy(obj[0]);
        }

        else
        {
            Load();
        }

    }

    public static Actor CreateActor(string path, Vector3 position, Quaternion rotation)
    {
        Vector3 vec = new Vector3(3, 3, 3);
        //Debug.Log("here"+position);
        GameObject prefab = Resources.Load<GameObject>(path);
        Debug.Log("path (no AR) " + path);
        GameObject go = Instantiate(prefab, position, rotation) as GameObject;
        Actor actor = go.GetComponent<Actor>() ?? go.AddComponent<Actor>();

        return actor;
    }

    public static Actor CreateActor(ActorData data, string path, Vector3 position, Quaternion rotation)
    {
        Actor actor = CreateActor(path, position, rotation);

        actor.data = data;

        return actor;
    }

    public static Actor ARCreateActor(string path, Vector3 position, Quaternion rotation)
    {
        Vector3 tmp = new Vector3(position.x, 0, position.z);
        //Debug.Log("here" + position);
        GameObject prefab = Resources.Load<GameObject>(path);
        GameObject go;
        Debug.Log("path" + path);
        go = Instantiate(prefab, position, rotation) as GameObject;
        go.GetComponent<Transform>().position.Set(position.x, 0, position.z);
        go.transform.parent = GameObject.Find("Ground Plane Stage").transform;
        Actor actor = go.GetComponent<Actor>() ?? go.AddComponent<Actor>();
        return actor;
    }

    public static Actor ARCreateActor(ActorData data, string path, Vector3 position, Quaternion rotation)
    {
        Actor actor = ARCreateActor(path, position, rotation);

        actor.data = data;

        return actor;
    }

    public void Save()
    {
        string scenename = SceneManager.GetActiveScene().name;
        string title = Strings.title; //title 받아오기
        dataPath = System.IO.Path.Combine(Application.persistentDataPath, scenename + title + "actors.json");
        wallPath = System.IO.Path.Combine(Application.persistentDataPath, scenename + title +"wall.csv");
        floorPath = System.IO.Path.Combine(Application.persistentDataPath, scenename + title + "floor.json");

        SaveData.Save(dataPath, SaveData.actorContainer);
        SaveData.SaveWall(wallPath);
        SaveData.SaveFloor(floorPath);
        SavePanel.SetActive(true);
    }

    public static void Load()
    {
        string scenename = SceneManager.GetActiveScene().name;
        string title = Strings.title; //title 받아오기
        dataPath = System.IO.Path.Combine(Application.persistentDataPath, scenename + title + "actors.json");
        wallPath = System.IO.Path.Combine(Application.persistentDataPath, scenename + title + "wall.csv");
        floorPath = System.IO.Path.Combine(Application.persistentDataPath, scenename + title + "floor.json");

        SaveData.Load(dataPath);
        SaveData.LoadWall(wallPath);
        SaveData.LoadFloor(floorPath);
    }

    public void SaveScene()
    {
        string scenename = SceneManager.GetActiveScene().name;
        string title = Strings.title; //title 받아오기
        dataPath = System.IO.Path.Combine(Application.persistentDataPath, scenename + title + "actors1.json");
        wallPath = System.IO.Path.Combine(Application.persistentDataPath, scenename + title + "wall1.json");
        floorPath = System.IO.Path.Combine(Application.persistentDataPath, scenename + title + "floor1.json");

        SaveData.Save(dataPath, SaveData.actorContainer);
        SaveData.SaveWall(wallPath);
        SaveData.SaveFloor(floorPath);
    }

    public static void LoadScene()
    {
        string scenename = SceneManager.GetActiveScene().name;
        string title = Strings.title; //title 받아오기
        dataPath = System.IO.Path.Combine(Application.persistentDataPath, scenename + title + "actors1.json");
        wallPath = System.IO.Path.Combine(Application.persistentDataPath, scenename + title + "wall1.json");
        floorPath = System.IO.Path.Combine(Application.persistentDataPath, scenename + title + "floor1.json");

        SaveData.Load(dataPath);
        SaveData.LoadWall(wallPath);
        SaveData.LoadFloor(floorPath);
    }

    void OnEnable()
    {
        //saveButton.onClick.AddListener(Save);
        //loadButton.onClick.AddListener(Load);
    }
    void OnDisable()
    {
        //saveButton.onClick.RemoveListener(Save);
        //loadButton.onClick.RemoveListener(Load);
    }
}
