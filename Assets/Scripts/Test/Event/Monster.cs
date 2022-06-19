using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public string name = "123123";
    void Start()
    {
        Dead();
    }

    /// <summary>
    /// 死亡方法
    /// </summary>
    void Dead()
    {
        Debug.Log("怪物死亡");
        // // 其他对象想在怪物死亡时做点什么
        // // 比如
        // // 1.玩家 得奖励
        // GameObject.Find("Player").GetComponent<Player>().MonsterDeadDo();
        // // 2. 任务记录
        // GameObject.Find("Task").GetComponent<Task>().TaskWaitMonsterDeadDo();
        // // 3. 其他(比如 成就记录 比如 副本继续创建怪物等等)
        // GameObject.Find("Other").GetComponent<Other>().OtherWaitMonsterDeadDo();
        // // 加N个处理逻辑
        
        // 触发事件
        EventCenter.GetInstance().EventTrigger("MonsterDead", this);
    }
}
