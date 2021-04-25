using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Unity.Editor;
using Firebase.Database;
using System.IO;

public class User
{
    public string androidid;
    public string title;
    public string address;
    public string date;
    public string detail;
    public string update;

    public User()
    {
    }

    public User(string androidid, string title, string address, string date, string detail, string update)
    {
        this.androidid = androidid;
        this.title = title;
        this.address = address;
        this.date = date;
        this.detail = detail;
        this.update = update;
    }
}

public class FirebaseTest : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://ehu-interiorplay.firebaseio.com/");
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;

    }

    public void FirebaseSave()
    {
        Debug.Log("Firebase-SaveStart!");
        FirebaseApp.DefaultInstance.SetEditorDatabaseUrl("https://ehu-interiorplay.firebaseio.com/");
        Debug.Log("Firebase-URL!");
        DatabaseReference reference = FirebaseDatabase.DefaultInstance.RootReference;
        Debug.Log("Firebase-Reference!");
        //if(StartScript.start == true)
        //{
            string deviceid = SystemInfo.deviceUniqueIdentifier;
            string title = Strings.title;
            string address = Strings.address;
            string date = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            string detail = Strings.detail;
            string update = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Debug.Log("Firebase- " + deviceid + title + address + date + detail);
            User user = new User(deviceid, title, address, date, detail, update);
            string json = JsonUtility.ToJson(user);
            reference.Child(deviceid).Child(title).SetRawJsonValueAsync(json);
            Debug.Log("Firebase-Final!");
        //}
        /*else
        {
            Debug.Log("here~");
            string deviceid = SystemInfo.deviceUniqueIdentifier;
            string date = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            string update = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string title = File.ReadAllText(System.IO.Path.Combine(Application.persistentDataPath, "title.txt"));
            reference.Child("Designs").Child(deviceid).Child(title).Child("date").SetValueAsync(date);
            reference.Child("Designs").Child(deviceid).Child(title).Child("update").SetValueAsync(update);
        }*/
    }
}

