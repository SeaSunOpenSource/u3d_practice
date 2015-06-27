using UnityEngine;
using System.Collections;

public static class T02_closure 
{
    static void Test_lambda_01()
    {
        System.Func<int, int> func = (e) => e * e;
        int result = func(6);
        ++result;
    }

    static int _foo2 = 1;
    static void Test_lambda_02()
    {
        System.Func<int, int> func = (e) => e * e + _foo2;
        int result = func(6);
        ++result;
    }

    static int _foo3 = 1;
    static void Test_lambda_03()
    {
        System.Func<int, int> func = (e) => e * e + (++_foo3);
        int result = func(6);
        ++result;
    }

    static void Test_lambda_04()
    {
        int _foo4 = 1;

        System.Func<int, int> func = (e) => e * e + _foo4;
        int result = func(6);
        ++result;
    }

    static void Test_lambda_05()
    {
        int _foo5 = 1;

        System.Func<int, int> func = (e) => e * e + (++_foo5);
        int result = func(6);
        ++result;
    }

    public static void RunTests()
    {
        Test_lambda_01();
        Test_lambda_02();
        Test_lambda_03();
        Test_lambda_04();
        Test_lambda_05();
    }
}
