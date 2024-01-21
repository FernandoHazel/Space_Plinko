using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SelfDestroy : MonoBehaviour
{
    [SerializeField] private float destroyTime = 1;
    private AudioSource pointsAudio;
    [SerializeField] private AudioClip collect;
    void Start()
    {
        
        pointsAudio = GetComponent<AudioSource>();
        pointsAudio.PlayOneShot(collect);
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }
}
