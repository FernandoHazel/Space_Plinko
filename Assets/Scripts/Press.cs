using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(TextMeshProUGUI))]
public class Press : MonoBehaviour
{
    [Tooltip("Time in seconds of the blink")]
    [SerializeField] private float blinkSpeed = .5f;
    private void Start() {
        StartCoroutine(DisableText());
    }
    IEnumerator DisableText()
    {
        yield return new WaitForSeconds(blinkSpeed);
        gameObject.GetComponent<TextMeshProUGUI>().enabled = false;
        StartCoroutine(EnableText());
    }

    IEnumerator EnableText()
    {
        yield return new WaitForSeconds(blinkSpeed);
        gameObject.GetComponent<TextMeshProUGUI>().enabled = true;
        StartCoroutine(DisableText());
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("Plinko");
        }
    }
}
