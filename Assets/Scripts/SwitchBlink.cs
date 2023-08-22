using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class SwitchBlink : MonoBehaviour
{
    enum SwitchState
    {
        Off,
        On,
        Blink
    }

    [SerializeField] Collider ballCollider;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] Material onBlinkMaterial;
    [SerializeField] Material offBlinkMaterial;
    [SerializeField] float scoreSwitchBlink;

    SwitchState state;
    Renderer rendererMaterial;

    private void Start()
    {
        rendererMaterial = GetComponent<Renderer>();

        Set(false);

        StartCoroutine(BlinkTimerStart(5));
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider == ballCollider)
        {
            Toggle();
        }
    }

    private void Toggle()
    {
        if (state == SwitchState.On)
        {
            Set(false);
        }
        else
        {
            Set(true);
        }

        scoreManager.AddToScore(scoreSwitchBlink);
    }

    void Set(bool active)
    {
        if (active == true)
        {
            state = SwitchState.On;
            rendererMaterial.material = onBlinkMaterial;
            StopAllCoroutines();
        }
        else
        {
            state = SwitchState.Off;
            rendererMaterial.material = offBlinkMaterial;

            StartCoroutine(BlinkTimerStart(5));
        }
        // rendererMaterial.material = active ? onBlinkMaterial : offBlinkMaterial;
    }

    IEnumerator Blink(int times)
    {
        state = SwitchState.Blink;

        for (int i = 0; i < times; i++)
        {
            rendererMaterial.material = onBlinkMaterial;
            yield return new WaitForSeconds(.5f);

            rendererMaterial.material = offBlinkMaterial;
            yield return new WaitForSeconds(.5f);
        }

        state = SwitchState.Off;

        StartCoroutine(BlinkTimerStart(5));
    }

    IEnumerator BlinkTimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }
}