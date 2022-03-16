using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardBrick : Brick
{
    private void Awake()
    {
        m_Health = 3;
        UpdateColor();
    }
}
