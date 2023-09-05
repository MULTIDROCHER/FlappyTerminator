using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private BirdMover _birdMover;
    [SerializeField] private BirdHealth _birdHealth;
    [SerializeField] private BirdScore _birdScore;
    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private GameOverScreen _gameOverScreen;

    private void OnEnable()
    {
        _startScreen.PlayButtonClick += OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick += OnRestartButtonClick;
        _birdHealth.GameOver += OnBirdDie;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClick -= OnPlayButtonClick;
        _gameOverScreen.RestartButtonClick -= OnRestartButtonClick;
        _birdHealth.GameOver -= OnBirdDie;
    }

    private void Start()
    {
        Time.timeScale = 0;
        _startScreen.Open();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        _startScreen.gameObject.SetActive(false);
        StartGame();
    }

    private void OnRestartButtonClick()
    {
        _gameOverScreen.Close();
        _spawner.Reset();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _birdScore.Reset();
        _birdHealth.Reset();
        _birdMover.Reset();
    }

    private void OnBirdDie()
    {
        Time.timeScale = 0;
        _gameOverScreen.Open();
    }
}