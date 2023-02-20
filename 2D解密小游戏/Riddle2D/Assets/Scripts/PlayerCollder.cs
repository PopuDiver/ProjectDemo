using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollder : MonoBehaviour
{
    private Animator anim;
    private float speed = 0.1f;
    private Rigidbody2D rig;
    public GameObject ui;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        anim.SetFloat("H",h);
        anim.SetFloat("V", v);

        rig.MovePosition(transform.position + new Vector3(h, v) * speed);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ui.SetActive(true);
        }
    }
}
