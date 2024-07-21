using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RotatingCamera : MonoBehaviour
{
    public float RotateTime = 0.2f;
    private Transform player;
    private bool isRotating = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position;
        Rotate();
    }

    void Rotate()
    {
        if (Input.GetKeyDown(KeyCode.Q) && !isRotating)
        {
            StartCoroutine(RotationAround(-45, RotateTime));
        }
        if (Input.GetKeyDown(KeyCode.E) && !isRotating)
        {
            StartCoroutine(RotationAround(45, RotateTime));
        }
    }

    IEnumerator RotationAround(float angle, float time)
    {
        float number = 60 * time;
        float nextAngle = angle / number;
        isRotating = true;

        for (int i = 0; i < number; i++)
        { 
            transform.Rotate(new Vector3(0, 0, nextAngle));
            yield return new WaitForFixedUpdate();
        }
        isRotating = false;
    }
}
