using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoomInTarget : MonoBehaviour
{
    [SerializeField] Collider ballCollider;
    [SerializeField] CameraController cameraController;
    [SerializeField] float length;

    void OnTriggerEnter(Collider collider)
    {
        if (collider == ballCollider)
        {
            cameraController.FollowTarget(ballCollider.transform, length);
        }
    }
}
