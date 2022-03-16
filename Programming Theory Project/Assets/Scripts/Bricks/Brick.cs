using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    protected int m_Health;
    protected Color[] m_Colors =
    {
        Color.green, 
        Color.blue,
        Color.red
    };

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            TakeDamage();
        }
    }

    protected void TakeDamage()
    {
        m_Health--;

        if(m_Health <= 0)
        {
            Destroy(gameObject, 0.1f);
        }
        else 
        {
            UpdateColor();
        }
    }

    protected void UpdateColor()
    {
        Renderer renderer = GetComponentInChildren<Renderer>();
        MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
        renderer.GetPropertyBlock(materialPropertyBlock);
        materialPropertyBlock.SetColor("_Color", m_Colors[m_Health - 1]);
        renderer.SetPropertyBlock(materialPropertyBlock);
    }
}
