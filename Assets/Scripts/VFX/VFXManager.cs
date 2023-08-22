using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    [SerializeField] GameObject VFXBumper;

    public void playVFX(Vector3 spawnPosition)
    {
        GameObject.Instantiate(VFXBumper, spawnPosition, Quaternion.identity);
    }
}
