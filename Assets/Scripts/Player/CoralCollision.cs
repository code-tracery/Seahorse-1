using UnityEngine;
using UnityEngine.SceneManagement;

public class CoralCollision : MonoBehaviour
{
    public GameObject player;
    public GameOverManager gameOverManager;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {   

            Debug.Log("Игра окончена! Вы столкнулись с кораллом.");
            Time.timeScale = 0; // Останавливаем игру
            GameOverManager.Instance.ShowGameOver();
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }
}