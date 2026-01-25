using UnityEngine;

public class ScrollingBackground_v1 : MonoBehaviour
{
    public float scrollSpeed = 2f; // Скорость прокрутки
    private float backgroundWidth; // Ширина всего фонового полотна
    private Vector3 startPosition; // Начальная позиция фона
    private Camera mainCamera;
    private float cameraHorizontalExtent;

    void Start()
    {
        mainCamera = Camera.main;

        // Получаем ширину всего фона
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        backgroundWidth = spriteRenderer.bounds.size.x;

        // Сохраняем начальную позицию
        startPosition = transform.position;

        // Рассчитываем половину ширины камеры
        cameraHorizontalExtent = mainCamera.orthographicSize * Screen.width / Screen.height;
    }

    void Update()
    {
        // Двигаем фон влево
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);

        // Проверяем, полностью ли фон ушел за левый край камеры
        float rightEdgePosition = transform.position.x + backgroundWidth / 2;
        float cameraLeftEdge = mainCamera.transform.position.x - cameraHorizontalExtent;

        if (rightEdgePosition < cameraLeftEdge)
        {
            // Возвращаем фон в начальную позицию
            transform.position = startPosition;
        }
    }
}
