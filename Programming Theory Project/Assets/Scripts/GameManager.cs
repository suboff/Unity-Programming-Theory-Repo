using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Rigidbody ballRigidbody;
    [SerializeField]
    private GameObject[] m_BrickPrefabs;

    private bool m_GameRunning = false;
    private bool m_GameOver = false;
    private float m_InitialVelocity = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = GameObject.Find("Ball").GetComponent<Rigidbody>();

        SpawnBricks();
    }

    // Update is called once per frame
    void Update()
    {
        if(!m_GameRunning)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                m_GameRunning = true;

                LaunchBall();
            }
        }

        else if(m_GameOver)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Restart();
            }
        }
    }

    private void SpawnBricks()
    {
        float yStart = 4.0f;
        float yOffset = -0.5f;
        float xStart = -3.0f;
        float xOffset = 1.25f;

        int numberOfRows = 6;
        int bricksPerRow = 6;

        for(int row = 0; row < numberOfRows; row++)
        {
            int brickType = (m_BrickPrefabs.Length - 1) - (row % m_BrickPrefabs.Length);
            for(int col = 0; col < bricksPerRow; col++)
            {
                Vector3 position = new Vector3(xStart + (col * xOffset), yStart + (row * yOffset), 0);
                Instantiate(m_BrickPrefabs[brickType], position, m_BrickPrefabs[brickType].transform.rotation);
            }
        }
    }

    private void LaunchBall()
    {
        float randomDirection = Random.Range(-1.0f, 1.0f);
        Vector3 forceDir = new Vector3(randomDirection, 1, 0);
        forceDir.Normalize();

        ballRigidbody.transform.SetParent(null);
        ballRigidbody.AddForce(forceDir * m_InitialVelocity, ForceMode.VelocityChange);
    }

    public void GameOver()
    {
        m_GameOver = true;
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
