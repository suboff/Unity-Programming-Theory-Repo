using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyBrick : Brick
{
    private void Awake()
    {
        m_Health = 1;
        UpdateColor();
    }
}
