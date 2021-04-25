using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;

public class Floor : MonoBehaviour
{
    public string name = "floor";
    public string materialname;

    void Start()
    {
        Renderer rend;
        rend = GetComponent<Renderer>();
        //materialname = rend.material.name;
        //Debug.Log(materialname);

    }

    public void SetData(string _name, string _material)
    {
        name = _name;
        materialname = _material;

    }

    public string SaveToString()
    {
        return JsonUtility.ToJson(this);
    }






}
