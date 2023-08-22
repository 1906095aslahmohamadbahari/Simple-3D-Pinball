using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform targetingCamera;
    [SerializeField] float returnTime;
    [SerializeField] float followSpeed;
    [SerializeField] float length;

    Vector3 defaultPositionCamera;

    bool hasTarget { get { return targetingCamera != null; } }

    void Start()
    {
        defaultPositionCamera = transform.position;
        targetingCamera = null;
    }

    void Update()
    {
        if (hasTarget)
        {
            Vector3 targetToDirectionCamera = transform.rotation * -Vector3.forward;
            Vector3 targetPosition = targetingCamera.position + (targetToDirectionCamera * length);

            transform.position = Vector3.Lerp (transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
    }

    public void FollowTarget (Transform targetTransform, float targetLength)
    {
        StopAllCoroutines();
        targetingCamera = targetTransform;
        length = targetLength;
    }

    public void GoToBackDefault()
    {
        targetingCamera = null;

        StopAllCoroutines();
        StartCoroutine(MovePosition(defaultPositionCamera, returnTime));
    }

    IEnumerator MovePosition(Vector3 target, float time)
    {
        float timer = 0f;

        Vector3 start = transform.position;

        while (timer < time)
        {
            transform.position = Vector3.Lerp(start, target, Mathf.SmoothStep(.0f, 1.0f, timer / time));

            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        transform.position = target;
    }
}