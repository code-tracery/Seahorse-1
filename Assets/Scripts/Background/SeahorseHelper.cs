using UnityEngine;
using UnityEngine.InputSystem;

public class SeahorseHelper : MonoBehaviour
{

    public float force;
    private new Rigidbody2D rigidbody;
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)

            rigidbody.AddForce(Vector2.up * (force - rigidbody.linearVelocity.y), ForceMode2D.Impulse);

        rigidbody.MoveRotation(rigidbody.linearVelocity.y * 2.0F);
    }
}
