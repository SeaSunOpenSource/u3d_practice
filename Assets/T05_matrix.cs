using UnityEngine;
using System.Collections;
using System;

public class T05_matrix
{
    static Matrix4x4 _m1;
    static Matrix4x4 _m2;

    const int NUM = 1000000;

    public static void ResetRandomly()
    {
        for (int i = 0; i < 16; i++)
        {
            _m1[i] = UnityEngine.Random.value;
            _m2[i] = UnityEngine.Random.value;
        }
    }

    public static void Execute()
    {
        SSUtil.Log("executing {0}", typeof(T05_matrix).Name);

        // testing correctness

        ResetRandomly();
        Matrix4x4 r0 = _m1 * _m2;
        Matrix4x4 r1 = SSMatrix.Mul_v1_naive(_m1, _m2);
        Matrix4x4 r2 = SSMatrix.Mul_v2_naive_expanded(_m1, _m2);
        Matrix4x4 r3 = Matrix4x4.zero;
        SSMatrix.Mul_v3_ref(ref r3, ref _m1, ref _m2);
        SSUtil.Assert(r0 == r1, "matrix r1 bad result.");
        SSUtil.Assert(r0 == r2, "matrix r2 bad result.");
        SSUtil.Assert(r0 == r3, "matrix r3 bad result.");

        // 'Mul_v4_for_3d_trans' always produce the same 4th row
        Matrix4x4 r4 = Matrix4x4.zero;
        SSMatrix.Mul_v4_for_3d_trans(ref r4, ref _m1, ref _m2);
        Matrix4x4 r4_target = r0;
        r4_target.SetRow(3, new Vector4(0.0f, 0.0f, 0.0f, 1.0f));
        SSUtil.Assert(r4 == r4_target, "matrix r4 bad result.");

        // testing performances

        Matrix4x4 ret = Matrix4x4.zero;

        ResetRandomly();
        using (SSTimer t = new SSTimer("_test_mat_mul: Unity Built-In_"))
        {
            for (int i = 0; i < NUM; i++)
            {
                ret = _m1 * _m2;
            }
        }

        ResetRandomly();
        using (SSTimer t = new SSTimer("_test_mat_mul: v1 - Naive Implementation_"))
        {
            for (int i = 0; i < NUM; i++)
            {
                ret = SSMatrix.Mul_v1_naive(_m1, _m2);
            }
        }

        ResetRandomly();
        using (SSTimer t = new SSTimer("_test_mat_mul: v2 - Naive (Expanded)_"))
        {
            for (int i = 0; i < NUM; i++)
            {
                ret = SSMatrix.Mul_v2_naive_expanded(_m1, _m2);
            }
        }

        ResetRandomly();
        using (SSTimer t = new SSTimer("_test_mat_mul: v3 - ref passed & returned_"))
        {
            for (int i = 0; i < NUM; i++)
            {
                SSMatrix.Mul_v3_ref(ref ret, ref _m1, ref _m2);
            }
        }

        ResetRandomly();
        using (SSTimer t = new SSTimer("_test_mat_mul: v4 - for 3d transform only_"))
        {
            for (int i = 0; i < NUM; i++)
            {
                SSMatrix.Mul_v4_for_3d_trans(ref ret, ref _m1, ref _m2);
            }
        }
    }
}
