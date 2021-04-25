using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class FloorSlot : MonoBehaviour
{


    // public Sprite Origanal;
    // public int Number;
    // public bool isAvailable = true;
    // public bool isSelected;
    //public Sprite SlectedSprite;

    private int index = 1;
    public Material materials; //material
    // public Renderer Rend; //material mesh (sabre CSG)
    // private Material selected_materials;
    // public static Material[] prev_materials = new Material[] {};


    Button m_Bt;
    private int a = 1;

    void Start()
    {
        m_Bt = this.transform.GetComponent<Button>();
        m_Bt.onClick.AddListener(OnClick);
    }

    void OnClick() // 클릭이벤트가 발생했을때 이 함수를 호출합니다.

    {        
        GameObject[] examples = GameObject.FindGameObjectsWithTag("Floor");
        // print(examples);
        int i=0;
        foreach(GameObject example in examples) {
            // Material newMaterial = (Material)Resources.Load("Artworks/Wall_blue", typeof(Material));            
            example.GetComponent<Renderer>().sharedMaterial = materials; 
        }


        // print(index);//used for debugging 

        // Rend.sharedMaterial = materials[index - 1]; //This sets the material color values inside the index
    }



}