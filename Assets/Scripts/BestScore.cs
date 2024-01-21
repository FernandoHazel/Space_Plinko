using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class BestScore : MonoBehaviour
{
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = $"BEST SCORE: {PointsScriptable.bestScore}";
    }

}
