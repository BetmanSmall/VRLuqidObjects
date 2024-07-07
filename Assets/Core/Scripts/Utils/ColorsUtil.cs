using UnityEngine;

namespace Core.Scripts.Utils
{
    public class ColorsUtil
    {
        public static bool ColorEquals(Color color1, Color color2, float tolerance = 0.04f)
        {
            if (color1.r > color2.r + tolerance) return false;
            if (color1.g > color2.g + tolerance) return false;
            if (color1.b > color2.b + tolerance) return false;
            if (color1.r < color2.r - tolerance) return false;
            if (color1.g < color2.g - tolerance) return false;
            if (color1.b < color2.b - tolerance) return false;
            return true;
        }
    }
}