using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Collider2D))]
public class Star : MonoBehaviour
{
    public delegate void CollectAction();
    public static event CollectAction startCollected;
    private Collider2D col2D;
    private GameManager gm;
    [SerializeField] private int points = 100;
    [SerializeField] private GameObject pointsPopup;



    private void Start() 
    {
        col2D = GetComponent<Collider2D>();
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ball"))
        { 
            //Start behavior after being touched by the ball
            pointsPopup.GetComponentInChildren<TextMeshProUGUI>().text = $"+{points.ToString()}";
            Instantiate(pointsPopup, transform.position, pointsPopup.transform.rotation);
            GameManager.gamePoints += points;

            if (startCollected != null)
            {
                startCollected();
            }

            Destroy(gameObject);
        }
    }

}
