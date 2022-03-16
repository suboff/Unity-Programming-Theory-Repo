using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Rigidbody ballRigidbody;

    private bool m_GameRunning = false;
    private bool m_GameOver = false;
    private float m_InitialVelocity = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = GameObject.Find("Ball").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!m_GameRunning)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                m_GameRunning = true;

                float randomDirection = Random.Range(-1.0f, 1.0f);
                Vector3 forceDir = new Vector3(randomDirection, 1, 0);
                forceDir.Normalize();

                ballRigidbody.transform.SetParent(null);
                ballRigidbody.AddForce(forceDir * m_InitialVelocity, ForceMode.VelocityChange);
            }
        }

        else if(m_GameOver)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    public void GameOver()
    {
        m_GameOver = true;
    }
}
