// using UnityEngine;
// using TMPro;
// using System.Collections;
// using UnityEngine.UI;

// public class ScoreManager : MonoBehaviour
// {
//     public TextMeshProUGUI player1Text;
//     public TextMeshProUGUI player2Text;
//     public TextMeshProUGUI gameOverText;
//     public GameObject gameOverPanel;
//     public Button danceButton;
//     public Button playAgainButton;

//     private int player1Score = 0;
//     private int player2Score = 0;
//     private bool gameOver = false;

//     public int winningScore = 11;
//     public Color flashColor = Color.yellow;
//     public float animationDuration = 0.25f;

//     private void Start()
//     {
//         // Hook up button listeners
//         danceButton.onClick.AddListener(Dance);
//         playAgainButton.onClick.AddListener(ResetGame);

//         gameOverPanel.SetActive(false);
//         UpdateUI();
//     }

//     public void Player1Scored()
//     {
//         if (gameOver) return;

//         player1Score++;
//         UpdateUI();
//         StartCoroutine(AnimateScoreText(player1Text));
//         CheckWinCondition();
//     }

//     public void Player2Scored()
//     {
//         if (gameOver) return;

//         player2Score++;
//         UpdateUI();
//         StartCoroutine(AnimateScoreText(player2Text));
//         CheckWinCondition();
//     }

//     void CheckWinCondition()
//     {
//         if (player1Score >= winningScore || player2Score >= winningScore)
//         {
//             int scoreDiff = Mathf.Abs(player1Score - player2Score);
//             if (scoreDiff >= 2)
//             {
//                 gameOver = true;

//                 string winner = player1Score > player2Score ? "Player 1" : "Player 2";
//                 gameOverText.text = $"{winner} Wins!";
//                 gameOverPanel.SetActive(true);
//             }
//         }
//     }

//     void UpdateUI()
//     {
//         player1Text.text = $"Player 1: {player1Score}";
//         player2Text.text = $"Player 2: {player2Score}";
//     }

//     IEnumerator AnimateScoreText(TextMeshProUGUI text)
//     {
//         Vector3 originalScale = text.transform.localScale;
//         Color originalColor = text.color;

//         text.transform.localScale = originalScale * 1.2f;
//         text.color = flashColor;

//         float t = 0f;
//         while (t < animationDuration)
//         {
//             t += Time.deltaTime;
//             float lerp = t / animationDuration;

//             text.transform.localScale = Vector3.Lerp(text.transform.localScale, originalScale, lerp);
//             text.color = Color.Lerp(flashColor, originalColor, lerp);

//             yield return null;
//         }

//         text.transform.localScale = originalScale;
//         text.color = originalColor;
//     }

//     public void ResetGame()
//     {
//         player1Score = 0;
//         player2Score = 0;
//         gameOver = false;
//         gameOverPanel.SetActive(false);
//         UpdateUI();
//         FindFirstObjectByType<BallManager>()?.ResetBallToSide(true);
//     }

//     public void Dance()
//     {
//         Debug.Log("🎵 Time to dance! You can play an animation here.");
//         // Optional: trigger animation, effect, etc.
//     }
// }

using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI player1Text;
    public TextMeshProUGUI player2Text;
    public TextMeshProUGUI gameOverText;
    public GameObject gameOverPanel;
    public Button danceButton;
    public Button playAgainButton;

    private int player1Score = 0;
    private int player2Score = 0;
    private bool gameOver = false;

    public int winningScore = 11;
    public Color flashColor = Color.yellow;
    public float animationDuration = 0.25f;

    [Header("Audio")]
    public AudioSource gameplayMusicSource;
    public AudioClip celebrationSound;

    private void Start()
    {
        // Hook up button listeners
        danceButton.onClick.AddListener(Dance);
        playAgainButton.onClick.AddListener(ResetGame);

        gameOverPanel.SetActive(false);
        UpdateUI();

        // Play background music
        if (gameplayMusicSource != null)
        {
            gameplayMusicSource.loop = true;
            gameplayMusicSource.Play();
        }
    }

    public void Player1Scored()
    {
        if (gameOver) return;

        player1Score++;
        UpdateUI();
        StartCoroutine(AnimateScoreText(player1Text));
        CheckWinCondition();
    }

    public void Player2Scored()
    {
        if (gameOver) return;

        player2Score++;
        UpdateUI();
        StartCoroutine(AnimateScoreText(player2Text));
        CheckWinCondition();
    }

    void CheckWinCondition()
    {
        if (player1Score >= winningScore || player2Score >= winningScore)
        {
            int scoreDiff = Mathf.Abs(player1Score - player2Score);
            if (scoreDiff >= 2)
            {
                gameOver = true;

                string winner = player1Score > player2Score ? "Player 1" : "Player 2";
                gameOverText.text = $"{winner} Wins!";
                gameOverPanel.SetActive(true);

                // Stop gameplay music
                if (gameplayMusicSource != null)
                {
                    gameplayMusicSource.Stop();
                }

                // Play celebration sound
                if (celebrationSound != null)
                {
                    AudioSource.PlayClipAtPoint(celebrationSound, Camera.main.transform.position);
                }
            }
        }
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

        text.transform.localScale = originalScale * 1.2f;
        text.color = flashColor;

        float t = 0f;
        while (t < animationDuration)
        {
            t += Time.deltaTime;
            float lerp = t / animationDuration;

            text.transform.localScale = Vector3.Lerp(text.transform.localScale, originalScale, lerp);
            text.color = Color.Lerp(flashColor, originalColor, lerp);

            yield return null;
        }

        text.transform.localScale = originalScale;
        text.color = originalColor;
    }

    public void ResetGame()
    {
        player1Score = 0;
        player2Score = 0;
        gameOver = false;
        gameOverPanel.SetActive(false);
        UpdateUI();
        FindFirstObjectByType<BallManager>()?.ResetBallToSide(true);

        // Restart gameplay music
        if (gameplayMusicSource != null)
        {
            gameplayMusicSource.Play();
        }
    }

    public void Dance()
    {
        Debug.Log("🎵 Time to dance! You can trigger animations here.");
    }
}
