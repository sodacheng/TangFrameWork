using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayPush : MonoBehaviour
{
    // 当对象激活时会进入的生命周期函数
    void OnEnable()
    {
        Invoke("Push",1);
    }

    void Push()
    {
        PoolMgr.GetInstance().PushObj(this.gameObject.name,this.gameObject);
    }
}
