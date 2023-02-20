using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public int HP = 0;
    public int range = 0;
    public int bombCound = 1;

    private float speed = 0.1f;
    private Animator anim;
    private Rigidbody2D rig;
    private SpriteRenderer spriteRenderer;
    private Color color;
    /// <summary>
    /// 标记人物是否受伤
    /// </summary>
    private bool isInjured = false;
    
    private float bombBoomTime = 0;

    /// <summary>
    /// 增加速度
    /// </summary>
    /// <param name="value"></param>
    public void AddSpeed(float value = 0.03f)
    {
        speed += value;
        if (speed > 0.2f) speed = 0.2f;
    }
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        color = spriteRenderer.color;
    }

    /// <summary>
    /// 初始化方法
    /// </summary>
    /// <param name="range"></param>
    /// <param name="HP"></param>
    /// <param name="boomTime"></param>
    public void Init(int range,int HP,float boomTime)
    {
        this.range = range;
        this.HP = HP;
        this.bombBoomTime = boomTime;
    }
    private void Update()
    {
        Move();
        CreateBomd();
    }

    /// <summary>
    /// 移动方法和动画的变换
    /// <summary>
    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        //print("h:" + h + " v:" + v);
        anim.SetFloat("H", h);
        anim.SetFloat("V", v);

        rig.MovePosition(transform.position + new Vector3(h, v) * speed);
    }

    private void CreateBomd()
    {
        if (Input.GetKeyDown(KeyCode.Space)&& bombCound > 0)
        {
            bombCound--;
            GameObject bomb = ObjectPool.Instance.Get(ObjectType.Bomb, 
                new Vector3(Mathf.RoundToInt(transform.position.x),
                Mathf.RoundToInt(transform.position.y)));
            bomb.GetComponent<Bomb>().Init(range, bombBoomTime, () => { bombCound++; });
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isInjured) return;
        if (collision.CompareTag(Tags.Enemy) || collision.CompareTag(Tags.BombEffect))
        {
            HP--;
            StartCoroutine("Injured", 2f);
        }
    }

    IEnumerator Injured(float time)
    {
        isInjured = true;
        for (int i = 1; i <= time * 2; i++)
        {
            color.a = 0;
            spriteRenderer.color = color;
            yield return new WaitForSeconds(0.25f);

            color.a = 1;
            spriteRenderer.color = color;
            yield return new WaitForSeconds(0.25f);
        }
        isInjured = false;
    }
}
