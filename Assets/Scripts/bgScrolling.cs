using UnityEngine;

public class bgScrolling : MonoBehaviour
{
    public float scrollSpeed = 1.5f; 

    void Update()
    {
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
    }
}