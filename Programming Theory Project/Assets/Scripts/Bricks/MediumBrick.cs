using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumBrick : Brick
{
    private void Awake()
    {
        m_Health = 2;
        UpdateColor();
    }
}
