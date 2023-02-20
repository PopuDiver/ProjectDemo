using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIContorlloer : MonoBehaviour
{
    public static UIContorlloer Instance;
    public Text txt_HP, txt_Level, txt_Time, txt_Enemy;

    private void Awake()
    {
        Instance = this;
    }
    public void Refresh(int hp,int level,int time,int enemy)
    {
        txt_HP.text = "HP：" + hp.ToString();
        txt_Level.text = "Level：" + level.ToString();
        txt_Time.text = "Time：" + time.ToString();
        txt_Enemy.text = "Enemy：" + enemy.ToString();
    }
}
