using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTest
{
    public TestTest()
    {
        MonoMgr.GetInstance().StartCoroutine(Test123()); // 通过MonoMgr开启协程
    }

    IEnumerator Test123()
    {
        yield return new WaitForSeconds(1f);
        Debug.Log("123123123");
    }
    public void Update()
    {
        Debug.Log("TestTest");
    }
}

public class Test : MonoBehaviour
{
    void Start()
    {
        TestTest t = new TestTest();
        MonoMgr.GetInstance().AddUpdateListener(t.Update);
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PoolMgr.GetInstance().GetObj("Test/Cube");
        }
        if (Input.GetMouseButtonDown(1))
        {
            PoolMgr.GetInstance().GetObj("Test/Sphere");
        }
    }
}
