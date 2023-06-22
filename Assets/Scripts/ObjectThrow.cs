using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.InputSystem.Interactions;

public class ObjectThrow : MonoBehaviour
{
    GameObject point;
    Rigidbody cube;
    [SerializeField] float throwForce = 20f;
    [HideInInspector] public bool isActive = true;


    void Start()
    {
        point = GameObject.FindGameObjectWithTag("Point");
        cube = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (isActive)
        {
            ObjectRotation();
            ObjThrow();
        }
    }

    void ObjThrow()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            float screenHalfWidth = Screen.width / 2f;
            float normalizedTouchX = touch.position.x / screenHalfWidth - 1f;

            float maxRotationAngle = 10f;
            float rotationSpeed = maxRotationAngle * normalizedTouchX;

            Vector3 newPointPosition = new Vector3(point.transform.position.x, point.transform.position.y,
                Mathf.Clamp(rotationSpeed, -maxRotationAngle, maxRotationAngle));
            point.transform.position = newPointPosition;

            if (touch.phase == TouchPhase.Ended)
            {
                Vector3 throwDirection = point.transform.position;
                cube.AddForce(throwDirection.normalized * throwForce, ForceMode.Impulse);
                point.transform.position = new Vector3(-10, 0.5f, 0);
                isActive = false;
            }

        }
    }

    void ObjectRotation()
    {
        Vector3 targetDirection = point.transform.position - cube.position;

        float singleStep = 2 * Time.deltaTime;

        Vector3 newRotate = Vector3.RotateTowards(cube.transform.forward, targetDirection, singleStep, 0.0f);
        cube.rotation = Quaternion.LookRotation(newRotate);
    }

}
