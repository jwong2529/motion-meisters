using UnityEngine;
using TMPro;
using System.Collections;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI player1Text;
    public TextMeshProUGUI player2Text;

    private int player1Score = 0;
    private int player2Score = 0;

    public Color flashColor = Color.yellow;  // The color to flash on update
    public float animationDuration = 0.25f;

    public void Player1Scored()
    {
        player1Score++;
        UpdateUI();
        StartCoroutine(AnimateScoreText(player1Text));
    }

    public void Player2Scored()
    {
        player2Score++;
        UpdateUI();
        StartCoroutine(AnimateScoreText(player2Text));
    }

    void UpdateUI()
    {
        player1Text.text = $"Player 1: {player1Score}";
        player2Text.text = $"Player 2: {player2Score}";
    }

    IEnumerator AnimateScoreText(TextMeshProUGUI text)
    {
        Vector3 originalScale = text.transform.localScale;
        Color originalColor = text.color;

        // Scale up and change color
        text.transform.localScale = originalScale * 1.2f;
        text.color = flashColor;

        float t = 0f;
        while (t < animationDuration)
        {
            t += Time.deltaTime;
            float lerp = t / animationDuration;

            // Smoothly scale back down
            text.transform.localScale = Vector3.Lerp(text.transform.localScale, originalScale, lerp);
            // Smoothly return to original color
            text.color = Color.Lerp(flashColor, originalColor, lerp);

            yield return null;
        }

        // Ensure it's fully reset
        text.transform.localScale = originalScale;
        text.color = originalColor;
    }
}
