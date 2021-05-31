using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameButtonScripts : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particleSystem;
    public void MouseOverEffects()
    {
        if (!particleSystem.isPlaying)
        {
            particleSystem.Play();
            Debug.Log("Sending sparkles!");
        }
    }
}
