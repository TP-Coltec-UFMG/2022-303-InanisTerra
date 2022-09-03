using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropdown : Daltonismo
{
    public void HandleInputData(int val)
    {
        if (val == 1)
        {
            colorBlindnessType = ColorBlindnessType.Tritanopia;
        }
        if (val == 2)
        {
            colorBlindnessType = ColorBlindnessType.Protanopia;
        }
        if (val == 3)
        {
            colorBlindnessType = ColorBlindnessType.Deuteranopia;
        }
        if (val == 0)
        {
            colorBlindnessType = ColorBlindnessType.NormalVision;
        }
    }
}
