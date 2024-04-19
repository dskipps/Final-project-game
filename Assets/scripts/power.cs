using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class power : MonoBehaviour
{
    AudioSource myaudio;

    ParticleSystem Effect;
    bool effectStarted = false;

    // Use this for initialization
    void Start()
    {
        myaudio = GetComponent<AudioSource>();
        Effect = transform.GetComponent<ParticleSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles += new Vector3(0, 1.0f, 0);
    }



    void OnTriggerEnter(Collider col)
    {
        player Player = col.transform.GetComponent<player>();

        if (col.gameObject.CompareTag("FOO"))
        {
                Player.InvincEnabled();

                Renderer[] allRenderers = gameObject.GetComponentsInChildren<Renderer>();
                foreach (Renderer c in allRenderers) c.enabled = false;
                Collider[] allColliders = gameObject.GetComponentsInChildren<Collider>();
                foreach (Collider c in allColliders) c.enabled = false;
                gameObject.GetComponent<ParticleSystemRenderer>().enabled = true;
                StartEffect();
                StartCoroutine(PlayAndDestroy(myaudio.clip.length));
            

        }

    }
    

    private IEnumerator PlayAndDestroy(float waitTime)
    {
        myaudio.Play();
        yield return new WaitForSeconds(waitTime);
        StopEffect();
        Destroy(gameObject);
    }
    private void StartEffect()
    {
        if (effectStarted == false)
        {
            Effect.Play();
            effectStarted = true;
        }

    }
    private void StopEffect()
    {
        effectStarted = false;
        Effect.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
    }
}

