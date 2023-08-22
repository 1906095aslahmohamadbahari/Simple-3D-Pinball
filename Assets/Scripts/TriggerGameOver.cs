using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerGameOver : MonoBehaviour
{
    [SerializeField] Collider ballCollider;

    void OnTriggerEnter(Collider collider)
    {
        if (collider == ballCollider)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}