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
}
