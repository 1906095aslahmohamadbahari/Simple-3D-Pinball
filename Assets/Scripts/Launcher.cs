using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    [SerializeField] Collider colliderBall;
    [SerializeField] KeyCode keyCodeLauncher;
    [SerializeField] float maxTimeHold;
    [SerializeField] float force;

    public Color originalMaterial;
    bool isHold = false;

    private void Start()
    {
        GetComponent<Renderer>().material.color = originalMaterial;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider == colliderBall)
        {
            RedInput(colliderBall);
        }
    }

    private void RedInput(Collider collider)
    {
        if (Input.GetKey(keyCodeLauncher) && !isHold)
        {
            StartCoroutine(StartHold(collider));
        }
    }

    IEnumerator StartHold(Collider collider)
    {
        isHold = true;

        float maxForce = .0f;
        float timeHold = .0f;

        while (Input.GetKey(keyCodeLauncher))
        {
            maxForce = Mathf.Lerp(0, maxForce, timeHold / maxTimeHold);

            yield return new WaitForEndOfFrame();
            timeHold += Time.deltaTime;
            GetComponent<Renderer>().material.color = Color.red;
        }

        collider.GetComponent<Rigidbody>().AddForce(Vector3.forward * force);
        GetComponent<Renderer>().material.color = originalMaterial;
        isHold = false;
    }
}
