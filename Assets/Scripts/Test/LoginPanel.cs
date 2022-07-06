using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LoginPanel : BasePanel
{

    //public Button btnStart;
    //public Button btnQuit;

    protected override void Awake()
    {
        //一定不能少 因为需要执行父类的awake来初始化一些信息 比如找控件 加事件监听
        base.Awake();
        //在下面处理自己的一些初始化逻辑
    }

    // Use this for initialization
    void Start()
    {

        //GetControl<Button>("btnStart").onClick.AddListener(ClickStart);
        //GetControl<Button>("btnQuit").onClick.AddListener(ClickQuit);

        UIManager.AddCustomEventListener(GetControl<Button>("btnStart"), EventTriggerType.PointerEnter, (data) => {
            Debug.Log("进入");
        });
        UIManager.AddCustomEventListener(GetControl<Button>("btnStart"), EventTriggerType.PointerExit, (data) => {
            Debug.Log("离开");
        });
    }

    private void Drag(BaseEventData data)
    {

    }

    private void PointerDown(BaseEventData data)
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void ShowMe()
    {
        base.ShowMe();
        //显示面板时 想要执行的逻辑 这个函数 在UI管理器中 会自动帮我们调用
        //只要重写了它  就会执行里面的逻辑
    }

    protected override void OnClick(string btnName)
    {
        switch (btnName)
        {
            case "btnStart":
                Debug.Log("btnStart被点击");
                break;
            case "btnQuit":
                Debug.Log("btnQuit被点击");
                break;
        }
    }

    protected override void OnValueChanged(string toggleName, bool value)
    {
        //在这来根据名字判断 到底是那一个单选框或者多选框状态变化了 当前状态就是传入的value
    }


    public void InitInfo()
    {
        Debug.Log("初始化数据");
    }

    //点击开始按钮的处理
    public void ClickStart()
    {
    }

    //点击开始按钮的处理
    public void ClickQuit()
    {
        Debug.Log("S");
    }
}
