using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ResMgr : BaseManager<ResMgr>
{
    /// <summary>
    /// 同步加载
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="name"></param>
    /// <returns></returns>
    public T Load<T>(string name) where T : Object
    {
        T res =  Resources.Load<T>(name);
        if(res is GameObject)
        {
            return GameObject.Instantiate(res); // 如果加载的对象是GameObject类型的, 直接实例化 再返回
        }
        else
        {
            return res;
        }
    }

    #region 异步加载资源
    // 提供给外部异步加载的接口方法
    public void LoadAsync<T>(string name, UnityAction<T> callback) where T : Object
    {
        MonoMgr.GetInstance().StartCoroutine(RellayLoadAsync(name,callback));
    }

    // 异步加载资源
    private IEnumerator RellayLoadAsync<T>(string name, UnityAction<T> callback) where T : Object
    {
        ResourceRequest r = Resources.LoadAsync(name);
        yield return r;
        if (r.asset is GameObject)
        {
            callback(GameObject.Instantiate(r.asset) as T);
        }
        else
        {
            callback(r.asset as T);
        }
    }

    #endregion
}
