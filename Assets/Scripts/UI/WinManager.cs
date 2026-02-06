using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    public static WinManager Instance { get; private set; }

    public GameObject winScreen;
    public Button restartButton;
    public Button exitButton;

    private void Awake()
    {
        // Синглтон: убиваем дубликаты
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    private void Start()
    {
        // Скрываем экран при старте
        if (winScreen != null)
            winScreen.SetActive(false);
        Debug.Log("✅ WinManager initialized. Instance: " + (Instance != null));
        Debug.Log("✅ WinScreen reference: " + (winScreen != null));

        // Подписываем кнопки
        if (restartButton != null)
            restartButton.onClick.AddListener(RestartGame);

        if (exitButton != null)
            exitButton.onClick.AddListener(ExitGame);
    }

    // Показать экран победы
    //public void ShowWinScreen()
    //{
    //    if (winScreen != null)
    //        winScreen.SetActive(true);
    //}

    public void ShowWinScreen()
    {
        Debug.Log("🔥 ShowWinScreen() called! Trying to activate: " + winScreen.name);

        // Принудительно включаем ВСЁ дерево
        winScreen.SetActive(true);

        // Проверим, что он реально включился
        Debug.Log("✅ winScreen.activeSelf: " + winScreen.activeSelf);
        Debug.Log("✅ winScreen.activeInHierarchy: " + winScreen.activeInHierarchy);

        // Дополнительно: выведем цвет фона, если есть Image
        var image = winScreen.GetComponent<Image>();
        if (image != null)
        {
            Debug.Log("🎨 Image color: " + image.color);
        }
    }




    // Перезагрузить сцену
    private void RestartGame()
    {
        if (winScreen != null)
            winScreen.SetActive(false);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Выйти из игры
    private void ExitGame()
    {
#if UNITY_EDITOR
        // В редакторе Unity — остановить игру
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // В сборке — закрыть приложение
        Application.Quit();
#endif
    }

    // Очистка инстанса при уничтожении
    private void OnDestroy()
    {
        if (Instance == this)
            Instance = null;
    }
}
