using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public static class Extensions
{
    public static Vector2 ToUnity(this DevMath.Vector2 v)
    {
        return new Vector2(v.x, v.y);
    }

    public static DevMath.Vector2 ToDevMath(this Vector2 v)
    {
        return new DevMath.Vector2(v.x, v.y);
    }
}
