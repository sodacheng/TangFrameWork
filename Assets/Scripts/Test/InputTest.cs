using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 开启输入检测
        InputMgr.GetInstance().StartOrEndCheck(true); 
        // 添加事件监听 [玩家死亡的时候只需要移除监听,就不会再检测]
        EventCenter.GetInstance().AddEventListener<KeyCode>("某键按下", CheckInputDown);
        EventCenter.GetInstance().AddEventListener<KeyCode>("某键抬起", CheckInputUp);
    }
    private void CheckInputDown(KeyCode key)
    {
        KeyCode keyCode = (KeyCode)key;
        switch(keyCode)
        {
            case KeyCode.W:
                Debug.Log("W_Down");
                break;
            case KeyCode.S:
                Debug.Log("S_Down");
                break;
            case KeyCode.A:
                Debug.Log("A_Down");
                break;
            case KeyCode.D:
                Debug.Log("D_Down");
                break;
        }
    }

    private void CheckInputUp(KeyCode key)
    {
        KeyCode keyCode = (KeyCode)key;
        switch (keyCode)
        {
            case KeyCode.W:
                Debug.Log("W_UP");
                break;
            case KeyCode.S:
                Debug.Log("S_UP");
                break;
            case KeyCode.A:
                Debug.Log("A_UP");
                break;
            case KeyCode.D:
                Debug.Log("D_UP");
                break;
        }
    }
}
