using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericMonoSingleton<T> : MonoBehaviour where T :GenericMonoSingleton<T>
{
    private static T _instance;
    public static T Instance { get { return _instance; } }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
            
        }
    }
}
