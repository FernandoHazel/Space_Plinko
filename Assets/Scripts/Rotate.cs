using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float rotateSpeed = .3f;
    [SerializeField] float MoveSpeed = .3f;
    void Update()
    {
        transform.Rotate( 0, 0,  rotateSpeed * Time.deltaTime);
        transform.Translate(Vector3.back * MoveSpeed * Time.deltaTime);
    }
}
