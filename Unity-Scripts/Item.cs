using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	public Sprite Image;
	public int Weight;
	// public GameObject UsedItem;
	// private GameObject Holder;
	// private GameObject InstantiatedObject;
	// public void Use()
	// {

	// 	this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
	// 	Holder = GameObject.Find("Holder").gameObject;
	// 	this.transform.position = Holder.transform.position;
	// 	if(UsedItem != null)
	// 	{
	// 		InstantiatedObject = Instantiate(UsedItem, this.transform.position, Holder.transform.rotation) as GameObject;
	// 		InstantiatedObject.transform.parent = this.transform.parent;
	// 		Destroy(this.gameObject);
	// 	}else
	// 	{
	// 		Debug.Log("Your Object you want me to make is null");
	// 	}
	
	// }
}