using UnityEngine;


public class WinZoneTrigger : MonoBehaviour
{
    public GameObject winScreen;
    public GameObject player;
    public float winDistance = 3f;

    void Start()
    {
        if (winScreen != null)
            winScreen.SetActive(false);

        // Автоматически находим игрока
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);

            if (distance < winDistance)
            {
                Debug.Log("Игрок близко к зоне победы! Дистанция: " + distance);
                winScreen.SetActive(true);
                Time.timeScale = 0f;
                this.enabled = false; // Выключаем скрипт
            }
        }
    }
}
