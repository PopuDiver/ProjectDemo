using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class YesCtrl : MonoBehaviour,IPointerDownHandler
{
    public InputField ui;
    public GameObject ui1;
    public GameObject ui2;
    public GameObject ui3;
    public GameObject door;
    public void OnPointerDown(PointerEventData eventData)
    {
        if(ui.text == "-6Alam24")
        {
            ui2.SetActive(false);
            ui1.SetActive(true);
            door.SetActive(false);
        }
        else
        {
            ui3.SetActive(true);
        }
    }
}
