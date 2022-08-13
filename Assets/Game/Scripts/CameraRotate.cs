using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    private Transform _sun;

    private void Awake()
    {
       _sun = GameObject.FindWithTag("Sun").transform;
    }

    private void Start()
    {
        StartCoroutine(CameraRotationMovement());
    }

    private IEnumerator CameraRotationMovement()
    {
        yield return new WaitForEndOfFrame();
        transform.RotateAround(_sun.position,Vector3.up,2);
    }
}
