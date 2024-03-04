using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [SerializeField] TextMeshProUGUI scoreText;

    [SerializeField] TextMeshProUGUI livesText;
    [SerializeField] PlayerDeath playerDeath;

    private void Awake()
    {
        instance = this;

        scoreText.text = $"Score: {PlayerStats.score}";
        SetLivesText();
    }

    private void OnEnable()
    {
        playerDeath.OnTakePlayerLife += SetLivesText;
    }

    public void AddScore()
    {
        PlayerStats.score++;
        scoreText.text = $"Score: {PlayerStats.score}";
    }

    private void SetLivesText()
    {
        livesText.text = $"Lives: {PlayerStats.lives}";
    }

    private void OnDisable()
    {
        playerDeath.OnTakePlayerLife += SetLivesText;
    }
}
