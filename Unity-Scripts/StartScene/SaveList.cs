using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveList : MonoBehaviour
{

    public GameObject ButtonPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Text[] lists;
        lists = ButtonPrefab.GetComponentsInChildren<Text>();
        lists[0].text = Strings.detail; //설명
        lists[1].text = Strings.address; //주소
        lists[2].text = Strings.date; //날짜
        lists[3].text = Strings.title; //제목
  
        GameObject enemy = Instantiate(ButtonPrefab, new Vector3(0, 0, 0), Quaternion.identity) as GameObject;
        enemy.transform.SetParent(GameObject.FindGameObjectWithTag("Content").transform, false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
