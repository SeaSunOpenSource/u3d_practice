using UnityEngine;
using System.Collections;

public class SSUtil
{
    public static void Log(string fmt, params object[] args)
    {
#if UNITY_5_0
        Debug.LogFormat(fmt, args);
#else
        Debug.Log(string.Format(fmt, args));
#endif
    }

    // use this since System.Diagnostics.Debug.Assert() seems not working in Unity
    public static void Assert(bool expr, string msg)
    {
        if (!expr)
        {
            Log("Assert failed: {0}", msg);
        }
    }
}
