using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void Awake()
    {
        EventCenter.GetInstance().AddEventListener("MonsterDead",MonsterDeadDo);
    }

    /// <summary>
    /// 怪物死时要做什么
    /// </summary>
    /// <param name="info"></param>
    public void MonsterDeadDo(object info)
    {
        Debug.Log("玩家得奖励" + (info as Monster).name);
    }

    private void OnDestroy()
    {
        EventCenter.GetInstance().RemoveEventListener("MonsterDead",MonsterDeadDo);
    }
}
