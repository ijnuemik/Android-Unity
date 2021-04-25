using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class WallSlot : MonoBehaviour
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
    public static Material save_materials;
    // public static Material[] prev_materials = new Material[] {};
    public static List<Material> prev_materials = new List<Material>();


    Button m_Bt;
    private int a = 1;

    void Start()
    {
        m_Bt = this.transform.GetComponent<Button>();
        m_Bt.onClick.AddListener(OnClick);
    }

    void OnClick() // 클릭이벤트가 발생했을때 이 함수를 호출합니다.

    {
        prev_materials.Clear();
        Button wall_btn = GameObject.Find("WallButton").GetComponent<Button>();
        Material select_wall = Resources.Load("Artworks/Select_material", typeof(Material)) as Material;
        Text select_wall_text = GameObject.Find("select_wall_text").GetComponent<Text>();
        Image complete_btn = GameObject.Find("CompleteButton").GetComponent<Image>();
        complete_btn.enabled = true;
        select_wall_text.enabled = true;
        // selected_materials = materials;
        wall_btn.onClick.Invoke();
        save_materials = materials;
        
        GameObject[] examples = GameObject.FindGameObjectsWithTag("Wall");
        // print(examples);
        int i=0;
        foreach(GameObject example in examples) {
            prev_materials.Add(example.GetComponent<Renderer>().sharedMaterial);
            // Material newMaterial = (Material)Resources.Load("Artworks/Wall_blue", typeof(Material));            
            example.GetComponent<Renderer>().sharedMaterial = select_wall; 
        }


        // print(index);//used for debugging 

        // Rend.sharedMaterial = materials[index - 1]; //This sets the material color values inside the index
    }

    // public void Complete() {
    //     GameObject[] examples = GameObject.FindGameObjectsWithTag("Wall");
    //     Material real_select_wall = Resources.Load("Artworks/Realselect_material", typeof(Material)) as Material;

    //     foreach(GameObject example in examples) {
    //         if(example.GetComponent<Renderer>().sharedMaterial == real_select_wall) {
    //             example.GetComponent<Renderer>().sharedMaterial = save_materials;
    //         }
    //     }

    //     Text select_wall_text = GameObject.Find("select_wall_text").GetComponent<Text>();
    //     Image complete_btn = GameObject.Find("CompleteButton").GetComponent<Image>();
    //     complete_btn.enabled = false;
    //     select_wall_text.enabled = false;

    // }

    public void SlotFunction(Sprite Icon, int Weight)
    {
        // Number = GameObject.Find("Main Camera").gameObject.GetComponent<InventoryManager>().Items.Count - 1;
        this.gameObject.GetComponent<Image>().overrideSprite = Icon;
        //Change
        GameObject.Find("Main Camera").gameObject.GetComponent<InventoryManager>().NextSlot += 1;
        // isAvailable = false;
    }

}