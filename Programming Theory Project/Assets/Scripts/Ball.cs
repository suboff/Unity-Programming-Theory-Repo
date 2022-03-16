using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody m_Rigidbody;
    private GameManager m_GameManager;

    private float m_MaxVelocity = 10.0f;
    private float m_VelocityIncrease = 0.01f;

    private void OnCollisionExit(Collision collision)
    {
        var velocity = m_Rigidbody.velocity;

        // Speed up the ball every collision
        velocity += velocity.normalized * m_VelocityIncrease;

        // Make sure ball isn't moving straight up and down
        if (Vector3.Dot(velocity.normalized, Vector3.up) < 0.1f)
        {
            if(velocity.y > 0)
            {
                velocity += Vector3.up * 0.5f;
            }
            else
            {
                velocity += Vector3.down * 0.5f;
            }
        }

        if (velocity.magnitude > m_MaxVelocity)
        {
            velocity = velocity.normalized * m_MaxVelocity;
        }

        m_Rigidbody.velocity = velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Destroy(gameObject);
            m_GameManager.GameOver();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
