using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneSwitcher : MonoBehaviour
{
    string scene;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SceneSwitch(string scenename)
    {
        GameObject Canvas = GameObject.Find("Canvas");
        GameObject Panel = Canvas.transform.GetChild(0).gameObject;
        Panel.SetActive(true);
        scene = scenename;
        //SceneManager.LoadScene(scenename);
    }

    public void SceneGo(string scenename)
    {
        SceneManager.LoadScene(scenename);

    }

    public void Go()
    {
        SceneManager.LoadScene(scene);
    }


    public void DeleteIcon()
    {
        try
        {
            GameObject[] Icons = GameObject.FindGameObjectsWithTag("Icon");
            foreach (GameObject icon in Icons)
            {
                Destroy(icon);
            }
        }
        catch { Debug.Log("There is no icons..."); }
    }
}
