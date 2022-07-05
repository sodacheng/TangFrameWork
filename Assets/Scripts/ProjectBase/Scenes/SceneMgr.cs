using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class SceneMgr : BaseManager<SceneMgr>
{
    /// <summary>
    /// 同步加载场景
    /// </summary>
    /// <param name="name"></param>
    /// <param name="fun"></param>
    public void LoadScene(string name, UnityAction fun)
    {
        SceneManager.LoadScene(name);
        fun();
    }

    /// <summary>
    /// 提供给外部异步加载场景的接口方法
    /// </summary>
    /// <param name="name"></param>
    /// <param name="fun"></param>
    public void LoadSceneAsyn(string name, UnityAction fun)
    {
        MonoMgr.GetInstance().StartCoroutine(RellyLoadSceneAsyn(name,fun)); // 依赖MonoBehavior 使用MonoMgr
    }

    /// <summary>
    /// 异步加载场景
    /// </summary>
    /// <param name="name"></param>
    /// <param name="fun"></param>
    /// <returns></returns>
    private IEnumerator RellyLoadSceneAsyn(string name, UnityAction fun)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(name);
        while (!ao.isDone)
        {
            // 事件中心向外分发进度情况, 外面想用就用
            EventCenter.GetInstance().EventTrigger("进度条加载", ao.progress);
            yield return ao.progress; // ao.progress 返回加载进度
        }
        fun();
    }
}
