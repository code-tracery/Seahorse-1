using UnityEngine;

public class ScrollingBackground_v2 : MonoBehaviour
{
    public float scrollSpeed = 2f;
    public bool pixelPerfect = false; // Включите для пиксель-арта

    private float backgroundWidth;
    private Vector3 startPosition;
    private Camera mainCamera;
    private float cameraHorizontalExtent;
    private float totalOffset; // Накопленное смещение для плавности

    void Start()
    {
        mainCamera = Camera.main;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        backgroundWidth = spriteRenderer.bounds.size.x;
        startPosition = transform.position;
        cameraHorizontalExtent = mainCamera.orthographicSize * Screen.width / Screen.height;
        totalOffset = 0f;
    }

    void Update()
    {
        // Накопление смещения для плавности
        totalOffset += scrollSpeed * Time.deltaTime;

        if (pixelPerfect)
        {
            // Для пиксель-арта: округляем до целых пикселей
            float pixelSize = 1f / mainCamera.orthographicSize * Screen.height * 0.5f;
            float roundedOffset = Mathf.Round(totalOffset * pixelSize) / pixelSize;
            transform.position = startPosition + Vector3.left * roundedOffset;
        }
        else
        {
            // Плавное движение для обычной графики
            transform.position = startPosition + Vector3.left * totalOffset;
        }

        // Проверка необходимости сброса
        float currentPositionX = transform.position.x;
        float resetThreshold = startPosition.x - backgroundWidth;

        if (currentPositionX <= resetThreshold)
        {
            // Возвращаем на одну ширину вперед (плавный цикл)
            transform.position += Vector3.right * backgroundWidth;
            startPosition += Vector3.right * backgroundWidth;
            totalOffset -= backgroundWidth;
        }
    }
}
