using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private Rigidbody ballRigidbody;

    private bool gameRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        ballRigidbody = GameObject.Find("Ball").GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!gameRunning)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                gameRunning = true;

                ballRigidbody.transform.SetParent(null);
                ballRigidbody.AddForce(new Vector3(1, 1, 0), ForceMode.VelocityChange);
            }
        }
    }
}
