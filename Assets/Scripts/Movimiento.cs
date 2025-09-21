using UnityEngine;
using UnityEngine.InputSystem;

public class Movimiento : MonoBehaviour
{
    public Key teclaArriba = Key.W;
    public Key teclaAbajo = Key.S;
    public float speed = 5f;

    private Rigidbody2D rb2d;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 movimiento = Vector2.zero;

        if (Keyboard.current[teclaArriba].isPressed && Pelota.numToques <=20)
        {
            movimiento = Vector2.up + new Vector2(0,(float)Pelota.numToques/100.0f);
        }
        else if (Keyboard.current[teclaAbajo].isPressed && Pelota.numToques <=20)
        {
            movimiento = Vector2.down - new Vector2(0,(float)Pelota.numToques/100.0f);
        }

        if (movimiento != Vector2.zero)
        {
            rb2d.MovePosition(rb2d.position + movimiento * speed * Time.fixedDeltaTime);
        }
    }
}
