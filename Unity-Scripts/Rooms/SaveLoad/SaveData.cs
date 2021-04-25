using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.IO;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;


public class SaveData
{

    public static ActorContainer actorContainer = new ActorContainer();

    public delegate void SerializeAction();
    public static event SerializeAction OnLoaded;
    public static event SerializeAction OnBeforeSave;

    public static void Load(string path)
    {
        try
        {
            actorContainer = LoadActors(path);
            foreach (ActorData data in actorContainer.actors)
            {
                GameController.CreateActor(data, data.path, data.pos, data.rot);
            }
            try
            {
                OnLoaded();
            }
            catch (System.Exception e)
            {
                Debug.Log("No Furniture!");
            }
            ClearActorList();
        }
        catch { }
    }

    public static void ARLoad(string path)
    {
        actorContainer = LoadActors(path);
        foreach (ActorData data in actorContainer.actors)
        {
            GameController.ARCreateActor(data, data.path+"ar", data.pos, data.rot);
        }
        try
        {
            OnLoaded();
        }
        catch (System.Exception e)
        {
            Debug.Log("No Furniture!");
        }
        ClearActorList();
    }

    public static void LoadWall(string wallpath)
    {
        try
        {
            string json = File.ReadAllText(wallpath);
            string[] arr = json.Split(',');
            int i = 0;
            GameObject[] examples = GameObject.FindGameObjectsWithTag("Wall");

            foreach (string s in arr)
            {
                Debug.Log("string " + s);
                if (s != "")
                {
                    string str = s;
                    int index = str.IndexOf(" (Instance)");
                    str = str.Substring(0, index);
                    Material newMat = Resources.Load("Artworks/" + str, typeof(Material)) as Material;
                    examples[i].GetComponent<Renderer>().material = newMat;
                    i++;
                    //Debug.Log("hoho");
                }

            }
        }
        catch { }
        
        //WallsContainer wall1 = new WallsContainer(); 
        //wall1 = JsonUtility.FromJson<WallsContainer>(json);
        //string materialname = wall1.materialname;
       // char sp = ' ';
        //string[] materialnames = materialname.Split(sp);

        //string currentwall = materialnames[0];

        //Material newMat = Resources.Load("Artworks/"+currentwall, typeof(Material)) as Material;
        //GameObject.Find("Wall").GetComponent<Renderer>().material = newMat;
        //Debug.Log(newMat);
    }

    public static void LoadFloor(string floorpath)
    {
        try
        {
            string json = File.ReadAllText(floorpath);
            int i = 0;
            GameObject[] examples = GameObject.FindGameObjectsWithTag("Floor");
            int index = json.IndexOf(" (Instance)");
            json = json.Substring(0, index);
            Debug.Log(json);
            Material newMat = Resources.Load("Artworks/" + json, typeof(Material)) as Material;
            Debug.Log(newMat);
            examples[i].GetComponent<Renderer>().material = newMat;
            i++;
        }
        catch { }

        
    }

    public static void Save(string path, ActorContainer actors)
    {
        try
        {
            OnBeforeSave();
        }
        catch(System.Exception e)
        {
            Debug.Log("No Furniture!");
        }
        //ClearSave(path);

        SaveActors(path, actors);

        ClearActorList();
    }

    public static void SaveWall (string wallpath)
    {
        GameObject[] examples = GameObject.FindGameObjectsWithTag("Wall");
        string wallcsv = "";
        foreach (GameObject example in examples)
        {
            string materialname = example.GetComponent<Renderer>().material.name;
            wallcsv += materialname;
            wallcsv += ",";
        }

        //walll.materialname = GameObject.Find("Wall").GetComponent<Renderer>().material.name;
        //string walljson = walll.SaveToString();


        StreamWriter sw1 = File.CreateText(wallpath);
        sw1.Close();
        File.WriteAllText(wallpath, wallcsv);
    }

    public static void SaveFloor (string floorpath)
    {
        GameObject[] examples = GameObject.FindGameObjectsWithTag("Floor");
        string floorcsv = "";
        foreach (GameObject example in examples)
        {
            string materialname = example.GetComponent<Renderer>().material.name;
            floorcsv += materialname;
        }

        //walll.materialname = GameObject.Find("Wall").GetComponent<Renderer>().material.name;
        //string walljson = walll.SaveToString();


        StreamWriter sw1 = File.CreateText(floorpath);
        sw1.Close();
        File.WriteAllText(floorpath, floorcsv);
    }

    public static void AddActorData(ActorData data)
    {
        actorContainer.actors.Add(data);
    }

    public static void ClearActorList()
    {
        actorContainer.actors.Clear();
    }

    private static ActorContainer LoadActors(string path)
    {
        //Debug.Log("load actors");

        //try
        //{
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<ActorContainer>(json);

        //}

        //catch { return JsonUtility.FromJson<ActorContainer>(""); }


    }

    private static void SaveActors(string path, ActorContainer actors)
    {
        try
        {
            string json = JsonUtility.ToJson(actors);
            Debug.Log("json " + json);
            StreamWriter sw = File.CreateText(path);
            sw.Close();

            File.WriteAllText(path, json);

            //밑은 AR을 위한 것

            foreach (ActorData data in actors.actors)
            {
                data.pos.x *= 0.01f;
                data.pos.y = 0;
                data.pos.z *= 0.01f;
            }

            string scenename = SceneManager.GetActiveScene().name;
            string title = Strings.title; //title 받아오기

            path = System.IO.Path.Combine(Application.persistentDataPath, scenename + title + "aractors.json");

            json = JsonUtility.ToJson(actors);

            sw = File.CreateText(path);
            sw.Close();

            File.WriteAllText(path, json);
        }
        catch { }
    }

}
