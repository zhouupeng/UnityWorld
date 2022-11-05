using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PluginInit : MonoBehaviour
{
    AndroidJavaClass unityClass;
    AndroidJavaObject unityActivity;
    AndroidJavaObject _pluginInstance;


    // Start is called before the first frame update
    void Start()
    {
        InitializePlugin("orz.neptune.unityplugin.PluginInstance");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void InitializePlugin(string pluginName)
    {
        unityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        unityActivity = unityClass.GetStatic<AndroidJavaObject>("currentActivity");
        _pluginInstance = new AndroidJavaObject(pluginName);

        if(_pluginInstance == null)
        {
            Debug.Log("plugins instance error");
        }

        _pluginInstance.CallStatic("receiveUnityActivity", unityActivity);

    }

    public void Add()
    {
        if(_pluginInstance != null)
        {
            var result = _pluginInstance.Call<int>("Add", 6, 7);
            Debug.Log("Add result from unity: " + result);
        }
    }

    public void Toast()
    {
        if(_pluginInstance != null)
        {
            _pluginInstance.Call("Toast", "hi from unity");
        }
    }
}
