using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental;

public class ClueCtrl : MonoBehaviour
{
    public GameObject ui;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Play"))
            ui.SetActive(true);
    }

    

    private void OnCollisionExit2D(Collision2D collision)
    {
        
        ui.SetActive(false);
    }

}
