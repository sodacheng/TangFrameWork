using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    private void Awake()
    {
        EventCenter.GetInstance().AddEventListener("MonsterDead",TaskWaitMonsterDeadDo);
    }
    
    /// <summary>
    /// 怪物死时要做什么
    /// </summary>
    /// <param name="info"></param>
    public void TaskWaitMonsterDeadDo(object info)
    {
        Debug.Log("任务 记录");
    }
    
    private void OnDestroy()
    {
        EventCenter.GetInstance().RemoveEventListener("MonsterDead",TaskWaitMonsterDeadDo);
    }
}
