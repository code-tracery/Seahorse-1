using UnityEngine;

public class CoralCollision : MonoBehaviour
{
    public GameObject player;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == player)
        {
            Debug.Log("Игра окончена! Вы столкнулись с кораллом.");
            Time.timeScale = 0; // Останавливаем игру
        }
    }
}
