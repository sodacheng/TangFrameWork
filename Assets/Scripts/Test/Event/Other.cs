using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Other : MonoBehaviour
{
    
    private void Awake()
    {
        EventCenter.GetInstance().AddEventListener("MonsterDead",OtherWaitMonsterDeadDo);
    }
    
    public void OtherWaitMonsterDeadDo(object info)
    {
        Debug.Log("其他 各个对象要做的事情");
    }
    
    private void OnDestroy()
    {
        EventCenter.GetInstance().RemoveEventListener("MonsterDead",OtherWaitMonsterDeadDo);
    }
}
