# ProjectDemo
在校学习Unity练手项目，做的一些小Demo  

炸弹人，复刻当年经典小游戏炸弹人  
1.墙体分为可摧毁类和不可摧毁类墙体  
2.游戏关卡中的墙体是利用数学算法来生成的，在开发场景中是看不到墙体的，将两个墙体设置为预制体，使用算法生成，并且使用了对象池来对性能进行优化  
3.人物可以放炸弹在自己的身下来摧毁可摧毁的墙体  
4.炸弹可以摧毁一些墙体，并且炸弹的生成和销毁也使用了对象池来优化  
5.可摧毁的墙体中会有概率产出道具，道具会对炸弹的数量和爆炸距离产生强化，道具的数量是可摧毁的墙体数量的一定比例，道具分为炸弹数量加一，威力加一等。  
6.敌人使用了射线检测来进行路径的巡航，当碰到墙壁会自动转向，方向为剩余可通行方向的随机一个方向  
7.角色碰到敌人或者被炸弹炸到会受到伤害，体现为闪烁，同时拥有一段时间的无敌帧，闪烁功能使用协程来实现  
8.敌人被炸弹炸到会死亡  
9.当敌人被全部消灭，并且在隐藏的墙体中找到下一关的传送门时，可以进入下一关  
10.游戏关卡中有倒计时，设定为倒计时结束之前需要完成关卡  
11.此为演示demo，部分功能可能未开发完全，略有缺陷。  
12.如果打开是手机版，请在打包设置中改为PC端。
