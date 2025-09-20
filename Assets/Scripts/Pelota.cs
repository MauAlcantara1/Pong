using UnityEngine;

public class Pelota : MonoBehaviour
{
    Juego miJuego;
    private AudioSource audioSource; // renombrado
    public AudioClip snd1, snd2, sndGol, sndPared;

    public static int numToques = 0, golesJugadorIzq = 0, golesJugadorDer = 0;
    public float speed = 5f;           
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        miJuego = GameObject.Find("Juego").GetComponent<Juego>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("gol"))
        {
            audioSource.clip = sndGol;
            audioSource.Play();
            numToques = 0;

            if (collision.name == "porteriaIzq")
                golesJugadorDer++;
            else if (collision.name == "porteriaDer")
                golesJugadorIzq++;

            miJuego.EscribeMarcador();
        }

        if (collision.CompareTag("pared"))
        {
            audioSource.clip = sndPared;
            audioSource.Play();
        }
    }

    float HitFactor(Vector2 pelotaPos, Vector2 playerPos, float playerHeight)
    {
        return (pelotaPos.y - playerPos.y) / playerHeight;
    }
}
