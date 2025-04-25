using UnityEngine;
using TMPro;
using System.Collections;

public class IntroMessage : MonoBehaviour
{
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI subtitleText;
    public float displayTime = 3f;
    public float fadeDuration = 1f;

    private Color titleOriginalColor;
    private Color subtitleOriginalColor;

    void Start()
    {
        titleOriginalColor = titleText.color;
        subtitleOriginalColor = subtitleText.color;

        StartCoroutine(ShowIntro());
    }

    IEnumerator ShowIntro()
    {
        // Enable the texts
        titleText.gameObject.SetActive(true);
        subtitleText.gameObject.SetActive(true);

        // Reset full opacity
        titleText.color = titleOriginalColor;
        subtitleText.color = subtitleOriginalColor;

        // Wait before fading
        yield return new WaitForSeconds(displayTime);

        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            float progress = t / fadeDuration;

            Color fadedTitle = Color.Lerp(titleOriginalColor, new Color(titleOriginalColor.r, titleOriginalColor.g, titleOriginalColor.b, 0f), progress);
            Color fadedSubtitle = Color.Lerp(subtitleOriginalColor, new Color(subtitleOriginalColor.r, subtitleOriginalColor.g, subtitleOriginalColor.b, 0f), progress);

            titleText.color = fadedTitle;
            subtitleText.color = fadedSubtitle;

            yield return null;
        }

        // Fully hide at the end
        titleText.gameObject.SetActive(false);
        subtitleText.gameObject.SetActive(false);
    }
}
