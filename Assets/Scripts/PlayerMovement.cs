using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float slowSpeed = 2f;
    public KeyCode slowKey = KeyCode.LeftShift;

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Movimiento horizontal
        float speed = Input.GetKey(slowKey) ? slowSpeed : moveSpeed;
        movement.x = Input.GetAxisRaw("Horizontal") * speed;
    }

    void FixedUpdate()
    {
        Vector2 newPosition = rb.position + movement * Time.fixedDeltaTime;

        // Obtener los bordes de la cámara
        Vector3 minScreenBounds = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector3 maxScreenBounds = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));

        // Limitar solo en eje X
        newPosition.x = Mathf.Clamp(newPosition.x, minScreenBounds.x, maxScreenBounds.x);

        rb.MovePosition(newPosition);
    }
}
