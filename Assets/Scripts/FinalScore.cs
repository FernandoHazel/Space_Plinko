using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(TextMeshProUGUI))]
public class FinalScore : MonoBehaviour
{
    public static bool restarted = false;
    private void OnEnable() {
        GetComponent<TextMeshProUGUI>().text = $"Final Score: {GameManager.gamePoints}";
    }

    public void ReturnToMenu()
    {
        restarted = false;
        SceneManager.LoadScene("Menu");
    }
    public void Restart()
    {
        restarted = true;
        SceneManager.LoadScene("Plinko");
    }
}
