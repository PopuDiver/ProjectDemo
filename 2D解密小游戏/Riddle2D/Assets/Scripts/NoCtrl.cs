using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class NoCtrl : MonoBehaviour, IPointerDownHandler
{
    public GameObject ui;
    public void OnPointerDown(PointerEventData eventData)
    {
        ui.SetActive(false);
    }
}
