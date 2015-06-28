using UnityEngine;
using System.Collections;

public class T06_matrix_caching 
{
    const int NUM = 1000000;

    static Matrix4x4 _inputMat;

    public static void ResetRandomly()
    {
        for (int i = 0; i < 16; i++)
        {
            _inputMat[i] = UnityEngine.Random.value;
        }
    }

    public static void Execute()
    {
        SSUtil.Log("executing {0}", typeof(T06_matrix_caching).Name);

        Matrix4x4 ret = Matrix4x4.zero;

        ResetRandomly();
        using (SSTimer t = new SSTimer("_test_mat_caching: no caching_"))
        {
            for (int i = 0; i < NUM; i++)
            {
                ret = Camera.main.worldToCameraMatrix * _inputMat;
            }
        }

        ResetRandomly();
        using (SSTimer t = new SSTimer("_test_mat_caching: cached_"))
        {
            Matrix4x4 cached = Camera.main.worldToCameraMatrix;
            for (int i = 0; i < NUM; i++)
            {
                ret = cached * _inputMat;
            }
        }
    }
}
