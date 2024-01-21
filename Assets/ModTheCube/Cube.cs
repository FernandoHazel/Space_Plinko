using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    [SerializeField] Vector3 cubePosition = new Vector3(3, 4, 1);
    [SerializeField] float cubeScale = 1.3f;
    [SerializeField] Color cubeColor = new Color(0.5f, 1.0f, 0.3f);
    [Range(0, 1)]
    [SerializeField] float cubeOpacity = 1;
    [SerializeField] float rotationAngle = 10.0f;
    
    private void Start()
    {
        //Get random values for position, scale, color and opacity.
        cubePosition = new Vector3(UnityEngine.Random.Range (0,10), UnityEngine.Random.Range (0,10), UnityEngine.Random.Range (0,10));
        cubeColor = new Color(UnityEngine.Random.Range (0,10), UnityEngine.Random.Range (0,10), UnityEngine.Random.Range (0,10));
        cubeScale = UnityEngine.Random.Range(0,10);
        cubeOpacity = UnityEngine.Random.Range(0,2);

        //Apply those values.
        transform.position = cubePosition;
        transform.localScale = Vector3.one * cubeScale;
        Material material = Renderer.material;
        material.color = new Color (cubeColor.r, cubeColor.g, cubeColor.b, cubeOpacity);
    }
    
    void Update()
    {
        //Change rotation over time.
        transform.Rotate(rotationAngle * Time.deltaTime, 0.0f, 0.0f);
    }
}
