using UnityEngine;

public class PelotaIA : MonoBehaviour
{
    JuegoIA miJuego;
    private AudioSource audioSource; // renombrado
    public AudioClip snd1, snd2, sndGol, sndPared;

    public static int numToques = 0, golesJugadorIzq = 0, golesJugadorDer = 0;
    public float speed = 5f;           
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        miJuego = GameObject.Find("JuegoIA").GetComponent<JuegoIA>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("gol"))
        {
            audioSource.clip = sndGol;
            audioSource.Play();
            numToques = 0;
            Debug.Log("Colision gol");

            if (collision.name == "porteriaIzq")
            {
                golesJugadorDer++;
                Debug.Log(golesJugadorDer);
            }
            else if (collision.name == "porteriaDer")
            {
                golesJugadorIzq++;
                Debug.Log(golesJugadorIzq);
            }

            miJuego.EscribeMarcador();
            Debug.Log("GolmarcadoPelota");
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("pared"))
        {
            audioSource.clip = sndPared;
            audioSource.Play();
            Debug.Log("Colisionpared");
        }
        if (collision.gameObject.CompareTag("Jugadores"))
        {
            audioSource.clip = snd1;
            audioSource.Play();
            Debug.Log("jugadores");
        }
    }

    float HitFactor(Vector2 pelotaPos, Vector2 playerPos, float playerHeight)
    {
        return (pelotaPos.y - playerPos.y) / playerHeight;
    }
}
