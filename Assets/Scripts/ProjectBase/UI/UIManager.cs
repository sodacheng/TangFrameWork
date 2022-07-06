using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// UI层级枚举
/// </summary>
public enum E_UI_Layer
{
    Bot,
    Mid,
    Top,
    System
}

public class UIManager : BaseManager<UIManager>
{
    public Dictionary<string, BasePanel> panelDic = new Dictionary<string, BasePanel>();
    //private Transform canvas;

    // 为UI分层
    private Transform bot; // 底层
    private Transform mid; // 中层
    private Transform top; // 顶层
    private Transform system; // 系统层

    // 记录UI的Canvas父对象 方便以后外部可能会使用他
    public RectTransform canvas;

    public UIManager()
    {
        // 创建Canvas, 让其过场景不移除
        GameObject obj = ResMgr.GetInstance().Load<GameObject>("UI/Canvas");
        canvas = obj.transform as RectTransform;
        GameObject.DontDestroyOnLoad(obj);

        // 找到各层
        bot = canvas.Find("Bot");
        mid = canvas.Find("Mid");
        top = canvas.Find("Top");
        system = canvas.Find("System");

        // 创建EventSystem
        obj = ResMgr.GetInstance().Load<GameObject>("UI/EventSystem");
        GameObject.DontDestroyOnLoad(obj);
    }

    /// <summary>
    /// 显示面板
    /// </summary>
    /// <typeparam name="T">面板脚本类型</typeparam>
    /// <param name="panelName">面板名</param>
    /// <param name="layer">显示在哪一层</param>
    /// <param name="callBack">当面板预设体创建成功后, 想要做的事</param>
    public void ShowPanel<T>(string panelName, E_UI_Layer layer = E_UI_Layer.Mid, UnityAction<T> callBack = null) where T : BasePanel
    {
        // 面板已经存在
        if (panelDic.ContainsKey(panelName))
        {
            panelDic[panelName].ShowMe();
            if (callBack != null)
            {
                callBack(panelDic[panelName] as T);
            }
            //// 避免面板重复加载, 如果存在该面板则直接显示, 调用回调函数后, 直接Return, 不再处理后面的异步加载
            return;
        }

        // 异步加载面板
        ResMgr.GetInstance().LoadAsync<GameObject>("UI/" + panelName, (obj) =>
        {
            // 把他作为Canvas的子对象, 并且要设置他的相对位置

            // 找到父对象 , 显示在哪一层
            Transform father = bot;
            switch (layer)
            {
                case E_UI_Layer.Mid:
                    father = mid;
                    break;
                case E_UI_Layer.Top:
                    father = top;
                    break;
                case E_UI_Layer.System:
                    father = system;
                    break;
            }

            // 设置父对象, 相对位置和大小
            obj.transform.SetParent(father,false);

            obj.transform.localPosition = Vector3.zero;
            obj.transform.localScale = Vector3.one;

            (obj.transform as RectTransform).offsetMax = Vector2.zero;
            (obj.transform as RectTransform).offsetMin = Vector2.zero;

            // 得到预设体上的的面板脚本 
            T panel = obj.GetComponent<T>();
            // 处理面板创建完成后的逻辑 (因为是异步加载面板, 要做延时处理, 只有当面板真正加载完时, 才会做外面想要做的事情.)
            if (callBack != null)
            {
                callBack(panel);
            }

            panelDic[panelName].ShowMe();

            // 把面板存起来
            panelDic.Add(panelName, panel);
        });

    }

    /// <summary>
    /// 隐藏面板
    /// </summary>
    /// <param name="panelName">面板名</param>
    public void HidePanel(string panelName)
    {
        if (panelDic.ContainsKey(panelName))
        {
            panelDic[panelName].HideMe();
            GameObject.Destroy(panelDic[panelName].gameObject);
            panelDic.Remove(panelName);
        }
    }

    /// <summary>
    /// 得到某一个已经显示的面板
    /// </summary>
    /// <param name="panelName">面板名</param>
    public T GetPanel<T>(string panelName)where T:BasePanel
    {
        if(panelDic.ContainsKey(panelName))
        {
            return panelDic[panelName] as T;
        }
        return null;
    }
}
