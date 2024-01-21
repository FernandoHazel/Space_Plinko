using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(TextMeshProUGUI))]
public class StartGame : MonoBehaviour
{
    [Tooltip("Time in seconds of the blink")]
    [SerializeField] private float blinkSpeed = .5f;
    [SerializeField] private GameObject InstructionsPanel;
    public static bool inInstructions;

    private void OnEnable() {
        inInstructions = true;
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
        if (Input.GetKeyDown(KeyCode.Space) && inInstructions)
        {
            InstructionsPanel.SetActive(false);
            Time.timeScale = 1;
            inInstructions = false;
        }
    }
}
