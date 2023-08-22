using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Bumper : MonoBehaviour
{
    [SerializeField] AudioManager audioManager;
    [SerializeField] VFXManager vFXManager;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] Collider colliderBall;
    [SerializeField] Color bumperColor;
    [SerializeField] float bouncing;
    [SerializeField] float scoreBumper;

    Renderer rendererColor;
    Animator animatorBumper;

    private void Start()
    {
        GetComponent<Renderer>().material.color = bumperColor;
        animatorBumper = GetComponent<Animator>();
    }

    private void OnCollisionEnter(Collision collider)
    {
        if (collider.collider == colliderBall)
        {
            Rigidbody rigidbodyBall = colliderBall.GetComponent<Rigidbody>();
            rigidbodyBall.velocity *= bouncing;

            animatorBumper.SetTrigger("Hit");

            audioManager.playSFX(collider.transform.position);

            vFXManager.playVFX(collider.transform.position);

            scoreManager.AddToScore(scoreBumper);
        }
    }
}