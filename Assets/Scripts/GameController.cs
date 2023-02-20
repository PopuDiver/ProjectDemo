using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instance;

    public GameObject playerPre;
    public int enemyCount = 0;
    private int levelCount = 0;
    private int time = 180;

    private MapController mapController;
    private GameObject player;
    private PlayerCtrl playerCtrl;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        mapController = GetComponent<MapController>();
        LevelCtrl();
    }

    private void Update()
    {
        UIContorlloer.Instance.Refresh(playerCtrl.HP,levelCount,time,enemyCount);
        if (Input.GetKeyDown(KeyCode.N))
        {
            LevelCtrl();
        }
    }

    /// <summary>
    /// 加载下一关卡
    /// </summary>
    public void LoadNextLevel()
    {
        if (enemyCount <= 0)
            LevelCtrl();
    }
    /// <summary>
    /// 关卡控制器
    /// </summary>
    private void LevelCtrl()
    {
        time = levelCount * 50 + 130;
        int x = 6 + 2 * (levelCount / 3);
        int y = 3 + 2 * (levelCount / 3);
        if (x > 18) x = 18;
        if (x > 15) y = 15;

        enemyCount = (int)(levelCount * 1.5f) + 1;
        if (enemyCount > 40) enemyCount = 40;
        mapController.InitMap(x, y, x * y, enemyCount);
        if (player == null)
            player = Instantiate(playerPre);
        
        player.transform.position = mapController.GetPlayerPos();
        playerCtrl = player.GetComponent<PlayerCtrl>();
        playerCtrl.Init(1, 3, 2);

        Camera.main.GetComponent<CameraFollow>().Init(player.transform,x,y);

        levelCount++;
    }
    public bool IsSuperWall(Vector2 pos)
    {
        return mapController.IsSuperWall(pos);
    }
}
