using UnityEngine;
using System.Collections;
using System;

public class T03_enum_string 
{
    enum FooTypes
    {
        T1,
        T2,
        T3,
        T4,
        T5,
        T6,
        T7,
        T8,
        T9,
        T10,
        Max,
    }

    const int NUM = 10000;

    static string foo;

    public static string Execute()
    {
        SSUtil.Log("executing {0}", typeof(T03_enum_string).Name);

        using (SSTimer t = new SSTimer("_test_enum_to_string"))
        {
            for (int i = 0; i < NUM; i++)
            {
                for (int k = 0; k < (int)FooTypes.Max; k++)
                {
                    foo = ((FooTypes)k).ToString();
                }
            }
        }
        foo = "";

        using (SSTimer t = new SSTimer("_test_enum_get_name"))
        {
            for (int i = 0; i < NUM; i++)
            {
                for (int k = 0; k < (int)FooTypes.Max; k++)
                {
                    foo = Enum.GetName(typeof(FooTypes), (FooTypes)k);
                }
            }
        }
        foo = "";

        return foo; // prevent 'foo' from being optimized out
    }
}
