using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMgr : BaseManager<InputMgr>
{
    private bool isOpen = false;
    public InputMgr()
    {
        MonoMgr.GetInstance().AddUpdateListener(MyUpdate);
    }

    private void MyUpdate()
    {
        // 如果没开启检测则不检测
        if (!isOpen)
            return;
        CheckKeyCode(KeyCode.W);
        CheckKeyCode(KeyCode.S);
        CheckKeyCode(KeyCode.A);
        CheckKeyCode(KeyCode.D);
    }

    /// <summary>
    /// 用来检测按键按下抬起,分发事件
    /// </summary>
    /// <param name="key"></param>
    private void CheckKeyCode(KeyCode key)
    {
        if(Input.GetKeyDown(key))
        {
            EventCenter.GetInstance().EventTrigger("某键按下", key);
        }
        if(Input.GetKeyUp(key))
        {
            EventCenter.GetInstance().EventTrigger("某键抬起", key);
        }
    }

    // 控制输入检测的开关
    public void StartOrEndCheck(bool isOpen)
    {
        this.isOpen = isOpen;
    }
}
