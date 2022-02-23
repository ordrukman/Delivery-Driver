using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeen = 300f;
    [SerializeField] float moveSpeed = 15f;
    [SerializeField] float standardSpeed = 15f;
    [SerializeField] float slowSpeed = 8f;
    [SerializeField] float boostSpeed = 22f;
    [SerializeField] int numOfFramesUntilReturnToStandardSpeed = 100;
    int countingFrames = 0;


    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeen * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
        if(countingFrames >= numOfFramesUntilReturnToStandardSpeed) {
            moveSpeed = standardSpeed;
            countingFrames = 0;
        }
        if(moveSpeed != standardSpeed) {
            countingFrames++;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        moveSpeed = slowSpeed;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Boost") {
            moveSpeed = boostSpeed;
            Debug.Log("got boost");
        }
    }
}
