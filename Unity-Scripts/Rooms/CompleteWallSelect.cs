using UnityEngine;
using System.Collections;
using UnityEngine.UI;
// public Material materials;

public class CompleteWallSelect : MonoBehaviour
{
    public void Complete() {
        GameObject[] examples = GameObject.FindGameObjectsWithTag("Wall");
        Material real_select_wall = Resources.Load("Artworks/Realselect_material", typeof(Material)) as Material;
        int i=0;
        foreach(GameObject example in examples) {
            if(example.GetComponent<Renderer>().sharedMaterial == real_select_wall) {
                example.GetComponent<Renderer>().sharedMaterial = WallSlot.save_materials;
            } else {
                // print(WallSlot.prev_materials[i]);
                example.GetComponent<Renderer>().sharedMaterial = WallSlot.prev_materials[i];
            }
            i++;
        }
        // foreach(GameObject example in WallSlot.prev_examples) {
        //     if()


        Text select_wall_text = GameObject.Find("select_wall_text").GetComponent<Text>();
        Image complete_btn = GameObject.Find("CompleteButton").GetComponent<Image>();
        complete_btn.enabled = false;
        select_wall_text.enabled = false;

    }

}