using UnityEngine;

public class SimpleScrollingBackground : MonoBehaviour
{
    public float scrollSpeed = 1f;
    public bool moveRight = true;
    public float backgroundWidth = 10f;

    private Transform copy;
    private Vector3 startPosition;

    void Start()
    {
        // Получаем ширину спрайта
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            backgroundWidth = spriteRenderer.bounds.size.x;
        }

        startPosition = transform.position;

        // Создаём только одну копию
        GameObject copyObject = Instantiate(gameObject, transform.parent);

        // Удаляем компонент скрипта с копии
        SimpleScrollingBackground copyScript = copyObject.GetComponent<SimpleScrollingBackground>();
        if (copyScript != null) Destroy(copyScript);

        copy = copyObject.transform;
        copy.position = startPosition + Vector3.right * backgroundWidth;
        copy.name = gameObject.name + "_Copy";
    }

    void Update()
    {
        float direction = moveRight ? -1f : 1f;
        float movement = Time.deltaTime * scrollSpeed * direction;

        // Двигаем оригинал и копию
        transform.position += Vector3.right * movement;
        copy.position += Vector3.right * movement;

        // Проверяем, нужно ли переставить
        CheckResetPosition();
    }

    void CheckResetPosition()
    {
        float cameraWidth = Camera.main.orthographicSize * Camera.main.aspect;
        float resetThreshold = cameraWidth * 2f;

        // Если оригинал ушёл слишком далеко влево
        if (transform.position.x < startPosition.x - resetThreshold)
        {
            transform.position = copy.position + Vector3.right * backgroundWidth;
        }

        // Если копия ушла слишком далеко влево
        if (copy.position.x < startPosition.x - resetThreshold)
        {
            copy.position = transform.position + Vector3.right * backgroundWidth;
        }
    }
}

