using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerRampController : MonoBehaviour
{
    [SerializeField] Collider ballCollider;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] float scoreRamp;

    void OnTriggerEnter(Collider collider)
    {
        if (collider == ballCollider)
        {
           scoreManager.AddToScore(scoreRamp);
        }
    }
}