using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoDificultad : MonoBehaviour
{
    public Key teclaArriba = Key.W;
    public Key teclaAbajo = Key.S;

    public float speed = 5f;
    public float speedIA = 5f;


    private Rigidbody2D rb2d;

    void Start()
    {
        int dificultad = OpcionesJuego.dificultad;
        switch (dificultad)
        {
            case 1:
                speedIA = 4.0f;
                speed = 5.0f;
                break;
            case 2:
                speedIA = 4.5f;
                speed = 4.5f;
                break;
            case 3:
                speedIA = 5.0f;
                speed = 4.0f;
                break;
        }
        rb2d = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
         Vector2 movimiento = Vector2.zero;


        if (Keyboard.current[teclaArriba].isPressed && Pelota.numToques <= 20)
            {
                movimiento = Vector2.up + new Vector2(0, (float)Pelota.numToques / 100.0f);
            }
            else if (Keyboard.current[teclaAbajo].isPressed && Pelota.numToques <= 20)
            {
                movimiento = Vector2.down - new Vector2(0, (float)Pelota.numToques / 100.0f);
            }

        if (movimiento != Vector2.zero)
        {
            rb2d.MovePosition(rb2d.position + movimiento * speed * Time.fixedDeltaTime);
        }
    }
}
