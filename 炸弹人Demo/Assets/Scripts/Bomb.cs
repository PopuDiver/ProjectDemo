using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bomb : MonoBehaviour
{
    public GameObject boomEffect;
    private int range;
    private Action aniFinAction;
    public void Init(int range,float dealyTime,Action action)
    {
        this.range = range;
        StartCoroutine("DealyBoom", dealyTime);
        aniFinAction = action;
    }

    IEnumerator DealyBoom(float time)
    {
        yield return new WaitForSeconds(time);
        if (aniFinAction != null) aniFinAction();
        ObjectPool.Instance.Get(ObjectType.BombEffect, transform.position);
        Boom(Vector2.left);
        Boom(Vector2.right);
        Boom(Vector2.up);
        Boom(Vector2.down);
        ObjectPool.Instance.Add(ObjectType.Bomb, gameObject);
    }

    private void Boom(Vector2 dir)
    {
        for (int i = 1; i <= range; i++)
        {
            Vector2 pos = (Vector2)transform.position + dir * i;
            if (GameController.Instance.IsSuperWall(pos)) 
                break;
            ObjectPool.Instance.Get(ObjectType.BombEffect, pos);
        }
    }
}
