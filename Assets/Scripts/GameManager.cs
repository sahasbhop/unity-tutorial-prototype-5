using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject titleScreen;
    public GameObject[] targets;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    private float _spawnRate = 1.0f;
    private int _score;
    private bool _isGameActive = true;

    private IEnumerator SpawnTargetRoutine()
    {
        while (_isGameActive)
        {
            yield return new WaitForSeconds(_spawnRate);
            Instantiate(targets[Random.Range(0, targets.Length)]);
        }
    }

    public bool IsGameActive()
    {
        return _isGameActive;
    }

    public void UpdateScore(int scoreToAdd)
    {
        _score += scoreToAdd;
        scoreText.SetText($"Score : {_score}");
    }

    public void GameOver()
    {
        _isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficultyLevel)
    {
        _spawnRate /= difficultyLevel;
        titleScreen.gameObject.SetActive(false);
        
        UpdateScore(0);
        StartCoroutine(SpawnTargetRoutine());
    }
}