using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Score and Timer")]
    public int score = 0;
    public float roundTime = 30f;
    public bool gameRunning = true;

    [Header("UI")]
    public Text scoreText;
    public Text timerText;

    private float remainingTime;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        remainingTime = roundTime;
        UpdateUI();
    }

    private void Update()
    {
        if (!gameRunning)
            return;

        remainingTime -= Time.deltaTime;

        if (remainingTime <= 0f)
        {
            remainingTime = 0f;
            gameRunning = false;
        }

        UpdateUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    public void ResetGame()
    {
        score = 0;
        remainingTime = roundTime;
        gameRunning = true;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;

        if (timerText != null)
            timerText.text = "Time: " + Mathf.CeilToInt(remainingTime);
    }
}
