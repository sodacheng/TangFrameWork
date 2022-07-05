using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        MusicMgr.GetInstance().PlayBkMusic("ymca");
        MusicMgr.GetInstance().ChangeBkValue(0.1f);
        Invoke("Stop", 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Stop()
    {
        MusicMgr.GetInstance().StopBkMusic();
    }
}
