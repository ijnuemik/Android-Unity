using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;


public class Walls : MonoBehaviour
{

    public string materialname;

    
    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }






}
