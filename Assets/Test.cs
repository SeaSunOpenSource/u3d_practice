using UnityEngine;
using System.Collections;

using System.Diagnostics;
using System;
using System.Collections.Generic;

public class Test : MonoBehaviour 
{
	void Start () {
        SSUtil.Log("high-res: {0}, freq: {1}, timestamp: {2}", 
            Stopwatch.IsHighResolution, Stopwatch.Frequency, Stopwatch.GetTimestamp());

        T01_foreach.Execute();
        T03_enum_string.Execute();
        T04_typecast.Execute();
        T05_matrix.Execute();
        T06_matrix_caching.Execute();
    }

    void Update()
    {
        T02_closure.RunTests();
    }
}
