using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance { get; private set; }

    public GameObject gameOverScreen; 
    public Button restartButton;

    private void Awake()
    {
        // Если синглтон уже существует — убиваем этот (чтобы не было дублей)
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }



    private void Start()
    {
        // Скрываем панель при старте игры
        gameOverScreen.SetActive(false);

        // Добавляем обработчик нажатия на кнопку
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartGame);
        }
        Time.timeScale = 1;
    }

    // Вызывается, когда герой умирает
    public void ShowGameOver()
    {
        gameOverScreen.SetActive(true);
    }

    // Перезагружает сцену
    private void RestartGame()
    {
        gameOverScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }
}

