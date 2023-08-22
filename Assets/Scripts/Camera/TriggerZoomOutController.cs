using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoomOutController : MonoBehaviour
{
    [SerializeField] Collider ballCollider;
    [SerializeField] CameraController cameraController;

    void OnTriggerEnter(Collider collider)
    {
        if (collider == ballCollider)
        {
            cameraController.GoToBackDefault();
        }
    }
}
