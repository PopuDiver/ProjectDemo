using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Passworld : MonoBehaviour
{
    public GameObject ui;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ui.SetActive(false);
        
    }


}
