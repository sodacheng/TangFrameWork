using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginPanel : BasePanel
{
    private void Start()
    {
        GetControl<Button>("btnStart").onClick.AddListener(ClickStart);
        GetControl<Button>("btnQuit").onClick.AddListener(ClickEnd);
    }

    public void IninInfo()
    {
        print("初始化面板");
    }

    public void ClickStart()
    {
        print("ClickStart");
    }

    public void ClickEnd()
    {
        print("ClickEnd");
    }


}
