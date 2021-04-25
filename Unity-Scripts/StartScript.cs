using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class StartScript : MonoBehaviour
{
    public static bool start;
    public static string designname;
    public static string address;
    public static string detail;

    public GameObject Startpanel;
    public GameObject CSGModel;
    public GameObject Script;
    public InputField Designname_field;
    public InputField Addressname_field;
    public InputField Detailname_field;

    // Start is called before the first frame update
    void Start()
    {
        string text = File.ReadAllText(System.IO.Path.Combine(Application.persistentDataPath,"start.txt"));
        Debug.Log(text);
        if(text == "0")
        {
            start = true;
            Startpanel.SetActive(true);;
        }
        else if(text == "1")
        {
            start = false;
            CSGModel.SetActive(true);
            designname = File.ReadAllText(System.IO.Path.Combine(Application.persistentDataPath, "title.txt"));
            GameController.Load();
            //text 2으로  바꾸고
            FileStream f = new FileStream(System.IO.Path.Combine(Application.persistentDataPath, "start.txt"), FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(f, System.Text.Encoding.Unicode);
            writer.Write("2");
            writer.Close();
        }
        else if(text == "2")
        {
            //다른 Scene넘어갔다올 때
            start = false;
            CSGModel.SetActive(true);
            designname = File.ReadAllText(System.IO.Path.Combine(Application.persistentDataPath, "title.txt"));
            GameController.LoadScene();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButton()
    {
        designname = Designname_field.text.ToString();
        address = Addressname_field.text.ToString();
        detail = Detailname_field.text.ToString();
        Debug.Log(designname + address + detail);
        Startpanel.SetActive(false);
        CSGModel.SetActive(true);

        //text 2으로  바꾸고
        FileStream f = new FileStream(System.IO.Path.Combine(Application.persistentDataPath, "start.txt"), FileMode.Create, FileAccess.Write);
        StreamWriter writer = new StreamWriter(f, System.Text.Encoding.Unicode);
        writer.Write("2");
        writer.Close();
        //title에 이름 적기
        FileStream f2 = new FileStream(System.IO.Path.Combine(Application.persistentDataPath, "title.txt"), FileMode.Create, FileAccess.Write);
        StreamWriter writer2 = new StreamWriter(f2, System.Text.Encoding.Unicode);
        writer2.Write(designname);
        writer2.Close();

    }
}
