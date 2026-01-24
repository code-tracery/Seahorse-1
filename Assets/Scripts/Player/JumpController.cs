using UnityEngine;

public class JumpController : MonoBehaviour
{
    public float jumpForce = 5f; // ���� ������ � ��������� � ����������

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // �������� Rigidbody2D
    }

    private void Update()
    {
        // ���� ������ ������ � �������!
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce); // ��������� �����
        }
    }
}

