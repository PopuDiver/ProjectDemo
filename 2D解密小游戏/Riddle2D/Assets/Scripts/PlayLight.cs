using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class PlayLight : MonoBehaviour
{
    //public object o;
    public Light2D  l;
    public bool b;
    //private void Start()
    //{
    //    playLight = GetComponent<Light>();
    //}

    private void Start()
    {
        l = GetComponent<Light2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            //playLight.SetActive(false);
            b =false;
        }
    }

    private void Update()
    {
        if(b == true)
        {
            l.intensity = Mathf.Lerp(0,1,1);
        }
        else
        {
            l.intensity = Mathf.Lerp(1, 0, 1);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Light"))
        {
            //playLight.SetActive(true);
            b = true;
        }
    }

}
