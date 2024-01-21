using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float initialPosition;
    [SerializeField] private float finalPosition;
    void Update()
    {
        transform.Translate(Vector3.forward * .3f * Time.deltaTime);
         if (transform.position.z > finalPosition)
         {
            transform.position = new Vector3(transform.position.x, transform.position.y, initialPosition);
         }
    }
}
