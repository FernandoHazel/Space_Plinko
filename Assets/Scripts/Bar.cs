using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bar : MonoBehaviour
{
    [SerializeField] private float boundary = 3.5f;
    
    [SerializeField] private float speed = 5.0f;

    private int direction = 1;
    void Update()
    {
        //Move the bar and change direction when touches the boundary

        transform.Translate(Vector3.right * speed * direction * Time.deltaTime);

        if(transform.position.x < -boundary || transform.position.x > boundary)
        {
            direction *= -1;
        }
    }
}
