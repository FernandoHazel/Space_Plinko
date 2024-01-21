using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Ball : MonoBehaviour
{
    public delegate void FallAction();
    public static event FallAction ballFell;
    public static bool inGame = false;
    [SerializeField] float Ylimit;
    [SerializeField] private AudioClip hit;
    private AudioSource ballAudio;

    private void Start() 
    {
        inGame = true;
        ballAudio = GetComponent<AudioSource>();
    }

    private void Update() 
    {
        if (transform.position.y < Ylimit)
        {
            inGame = false;
            if(ballFell != null)
            {
                ballFell();
            }
            
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        ballAudio.PlayOneShot(hit);
    }
}
