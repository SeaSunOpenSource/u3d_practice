using UnityEngine;
using System.Collections;

class Foo { public int dummy_base = 0; }

class Bar : Foo { public int dummy_derived = 0; }

class Bar2 : Foo { public int dummy_derived = 0; }

public class T04_typecast 
{
    const int NUM = 1000000;

    public static void Execute()
    {
        SSUtil.Log("executing {0}", typeof(T04_typecast).Name);

        Foo f = new Bar();

        using (SSTimer t = new SSTimer("_test_as_cast_"))
        {
            for (int i = 0; i < NUM; i++)
            {
                Bar b = f as Bar;
                b.dummy_derived = 1;
            }
        }

        using (SSTimer t = new SSTimer("_test_c_style_cast_"))
        {
            for (int i = 0; i < NUM; i++)
            {
                Bar b = (Bar)f;
                b.dummy_derived = 1;
            }
        }
    }
}
