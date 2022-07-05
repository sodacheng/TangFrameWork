using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// 抽屉数据 池子中的一列容器
/// </summary>
public class PoolData
{
    // 抽屉中 对象挂载的父节点
    public GameObject fatherObj;
    // 对象的容器
    public List<GameObject> poolList;

    public PoolData(GameObject obj, GameObject poolObj)
    {
        // 给抽屉创建一个父对象 并且把它作为pool对象的子物体
        fatherObj = new GameObject(obj.name);
        fatherObj.transform.parent = poolObj.transform;

        poolList = new List<GameObject>(){};
        PushObj(obj);
    }

    /// <summary>
    /// 往抽屉里压东西
    /// </summary>
    /// <param name="obj"></param>
    public void PushObj(GameObject obj)
    {
        // 存起来
        poolList.Add(obj);
        // 设置父对象
        obj.transform.parent = fatherObj.transform;
        // 失活 隐藏
        obj.SetActive(false);
    }

    /// <summary>
    /// 从抽屉里面取东西
    /// </summary>
    /// <returns></returns>
    public GameObject GetObj()
    {
        GameObject obj = null;
        // 取出第一个
        obj = poolList[0];
        poolList.RemoveAt(0);
        obj.SetActive(true);
        obj.transform.parent = null;
        return obj;
    }
}

/// <summary>
/// 缓存池模块
/// </summary>
public class PoolMgr : BaseManager<PoolMgr>
{
    // 缓存池容器
    public Dictionary<string, PoolData> poolDic = new Dictionary<string, PoolData>();

    private GameObject poolObj;

    /// <summary>
    /// 往外拿东西
    /// </summary>
    public void GetObj(string name, UnityAction<GameObject> CallBack)
    {
        //GameObject obj = null;
        // 有抽屉, 并且抽屉里有东西
        if (poolDic.ContainsKey(name) && poolDic[name].poolList.Count > 0)
        {
            //obj = poolDic[name].GetObj();
            CallBack(poolDic[name].GetObj());
        }
        else
        {
            // 通过异步加载obj
            ResMgr.GetInstance().LoadAsync<GameObject>(name, (o) =>
            {
                o.name = name;
                CallBack(o);
            });

            //obj = GameObject.Instantiate(Resources.Load<GameObject>(name));
            //// 把对象名该为和池子名一样
            //obj.name = name;
        }
    }

    /// <summary>
    /// 还暂时不用的东西给我
    /// </summary>
    public void PushObj(string name, GameObject obj)
    {
        if (poolObj == null)
            poolObj = new GameObject("Pool");
        
        
        // 里面有抽屉
        if (poolDic.ContainsKey(name))
        {
            poolDic[name].PushObj(obj);
        }
        // 里面没有抽屉
        else
        {
            poolDic.Add(name,new PoolData(obj,poolObj));
        }
    }

    /// <summary>
    /// 清空缓存池, 主要用在场景切换时
    /// </summary>
    public void Clear()
    {
       poolDic.Clear();
       poolObj = null;
    }
}
