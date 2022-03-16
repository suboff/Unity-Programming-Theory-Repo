using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10.0f;
    private float xRange = 3.75f;

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 newPosition = transform.position;
        newPosition += Vector3.right * speed * horizontalInput * Time.deltaTime;

        newPosition.x = Mathf.Clamp(newPosition.x, -xRange, xRange);

        transform.position = newPosition;
    }
}
