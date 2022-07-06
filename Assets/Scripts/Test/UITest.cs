using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITest : MonoBehaviour
{
    void Start()
    {
        UIManager.GetInstance().ShowPanel<LoginPanel>("LoginPanel", E_UI_Layer.Bot, showPanelOver);
    }
    private void showPanelOver(LoginPanel panel)
    {
        panel.IninInfo();
        Invoke("DelayHide", 1); 
    }

    private void DelayHide()
    {
        UIManager.GetInstance().HidePanel("LoginPanel");
    }
}
