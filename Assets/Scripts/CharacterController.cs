using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CharacterController : MonoBehaviour
{
    public delegate void ShootAction();
    public static event ShootAction ballFired;
    private float horizontalInput;
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float boundary = 10f;
    [SerializeField] private GameObject projectile;
    [SerializeField] private AudioClip shot;
    private AudioSource spaceshipAudio;
    private void Start() {
        spaceshipAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        //Stop the player if out of bounds
        if(transform.position.x < -boundary)
        {
            transform.position = new Vector3(-boundary, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > boundary)
        {
            transform.position = new Vector3(boundary, transform.position.y, transform.position.z);
        }
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);

        //Fire projectile only when there is no proyectile active
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!Ball.inGame && GameManager.bulletsLeft > 0 && StartGame.inInstructions == false)
            {
                spaceshipAudio.PlayOneShot(shot);
                GameManager.bulletsLeft--;
                if (ballFired != null)
                {
                    ballFired();
                }

                Instantiate(projectile, transform.position, projectile.transform.rotation);
            }
        }
    }
}
