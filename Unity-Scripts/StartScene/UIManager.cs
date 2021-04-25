using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject none;
    public GameObject list;
    public GameObject start;
    public GameObject apartment;

    // Start is called before the first frame update
    
    public void none_active()
    {
        none.SetActive(true);
    }

    public void list_active()
    {
        list.SetActive(true);
    }

    public void start_active()
    {
        start.SetActive(true);
    }

    public void apartment_active()
    {
        apartment.SetActive(true);
    }

    public void none_active_false()
    {
        none.SetActive(false);
    }

    public void list_active_false()
    {
        list.SetActive(false);
    }

    public void start_active_false()
    {
        start.SetActive(false);
    }

    public void apartment_active_false()
    {
        apartment.SetActive(false);
    }
}
