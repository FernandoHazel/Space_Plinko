using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public PointsScriptable pointsScriptable;
    public static int gamePoints = 0;
    public static int bulletsLeft = 3;

    public TextMeshProUGUI PointsUI;
    public TextMeshProUGUI BulletsUI;

    [SerializeField] private GameObject instructionsPanel;
    [SerializeField] private GameObject finalScorePanel;

    private void Start() {
        if (FinalScore.restarted == false)
        {
            instructionsPanel.SetActive(true);
        }
        bulletsLeft = 3;
        gamePoints = 0;
        PointsUI.text = $"Points: {gamePoints}";
        BulletsUI.text = $"Bullets: {bulletsLeft}";

    }

    private void OnEnable() {
        Star.startCollected += UpdatePointsUI;
        CharacterController.ballFired += UpdateBullets;
        Ball.ballFell += CheckForEnGame;
    }
    private void OnDisable() {
        Star.startCollected -= UpdatePointsUI;
        CharacterController.ballFired -= UpdateBullets;
        Ball.ballFell -= CheckForEnGame;
    }

    private void UpdatePointsUI()
    {
        PointsUI.text = $"Points: {gamePoints}";
    }

    private void UpdateBullets()
    {
        BulletsUI.text = $"Bullets: {bulletsLeft}";
    }

    private void CheckForEnGame()
    {
        if (bulletsLeft <= 0)
        {
            //End of the game
            if (gamePoints > PointsScriptable.bestScore)
            {
                PointsScriptable.bestScore = gamePoints;
            }
            finalScorePanel.SetActive(true);
        }
    }
}
