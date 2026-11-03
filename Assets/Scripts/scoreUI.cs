using UnityEngine;
using TMPro;

public class scoreUI : MonoBehaviour
{
    private int score;
    private TMP_Text scoreCount;

    void Start()
    {
        score = 0;
        scoreCount = GetComponent<TMP_Text>();
        scoreCount.text = $"Cakes Eaten: {score}";
    }

    public void OnCakePickup()
    {
        score += 1;
        scoreCount.text = $"Cakes Eaten: {score}";
    }
}
