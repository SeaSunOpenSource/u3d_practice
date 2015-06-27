using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class T01_foreach
{
    const int NUM = 1000000;

    static List<int> _testList = new List<int>();
    static int[] _testArray = new int[NUM];
    static Dictionary<int, int> _testDict = new Dictionary<int, int>();

    public static void Execute()
    {
        SSUtil.Log("executing {0}", typeof(T01_foreach).Name);

        for (int i = 0; i < NUM; i++)
            _testArray[i] = i;

        for (int i = 0; i < NUM; i++)
            _testList.Add(i);

        for (int i = 0; i < NUM; i++)
            _testDict[i] = i;

        int sum = 0;
        using (SSTimer t = new SSTimer("_testArray"))
        {
            foreach (var item in _testArray)
            {
                sum += item;
            }
        }

        using (SSTimer t = new SSTimer("_testList"))
        {
            foreach (var item in _testList)
            {
                sum += item;
            }
        }

        using (SSTimer t = new SSTimer("_testDict"))
        {
            foreach (var item in _testList)
            {
                sum += item;
            }
        }
    }
}
