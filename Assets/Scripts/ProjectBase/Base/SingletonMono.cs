using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 继承了MonoBehavior的单例模式对象 需要我们自己保证它的唯一性
public class SingletonMono<T> : MonoBehaviour where T : MonoBehaviour // 里氏转换原则:父类装子类
{
    private static T instance;
    public static T GetInstance()
    {
        // 继承了Mono的脚本 不能够直接new
        // 只能通过拖动到对象上 或者 通过加脚本的api AddComponent去加脚本
        // U3D内部帮助我们实例化它
        return instance;
    }

    // 子类能够重写Awake
    protected virtual void Awake()
    {
        instance = this as T;
    }
}