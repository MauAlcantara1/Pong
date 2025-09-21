using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.InputSystem;
using TMPro;

public class JuegoIA : MonoBehaviour
{

    [SerializeField] private GameObject jugadorIzq;
    [SerializeField] private GameObject jugadorDer;
    [SerializeField] private GameObject IAIzq;
    [SerializeField] private GameObject IADer;

    public AudioSource audio;
    public AudioClip sndSilbato, sndGameOver;
    private GameObject txtGameOver;
    private GameObject pelota;

    [SerializeField] private TextMeshProUGUI txtMarcador;

    public int signoX, signoY, velocidad = 1;

    void Start()
    {
        
        if (txtMarcador == null)
        {
            Debug.LogError("txtMarcador no está asignado en el Inspector!");
        }

        int dificultad = OpcionesJuego.dificultad;
        string lado = OpcionesJuego.lado;

        Debug.Log("Dificultad: " + dificultad + " | Lado: " + lado);

        switch (dificultad)
        {
            case 1:
                jugadorIzq.transform.localScale = new Vector3(0.5f, 2.5f, 1); 
                jugadorDer.transform.localScale = new Vector3(0.5f, 2.5f, 1);
                break;  
            case 2:

                jugadorIzq.transform.localScale = new Vector3(0.5f, 2.0f, 1);
                jugadorDer.transform.localScale = new Vector3(0.5f, 2.0f, 1);
                break;   
            case 3:

                jugadorIzq.transform.localScale = new Vector3(0.5f, 1.2f, 1);
                jugadorDer.transform.localScale = new Vector3(0.5f, 1.2f, 1);
                break;  
        }

        if (lado == "I")
        {
            jugadorDer.SetActive(false);
            jugadorIzq.SetActive(true);
            IAIzq.SetActive(false);
            IADer.SetActive(true);
        }
        else if (lado == "D")
        {
            jugadorIzq.SetActive(false);
            IADer.SetActive(false);
            jugadorDer.SetActive(true);
            IAIzq.SetActive(true);
        }
        
        if (txtGameOver != null)
            txtGameOver.SetActive(false);

        if (txtMarcador != null)
            txtMarcador.text = "0 - 0";

        audio = GetComponent<AudioSource>();
        pelota = GameObject.Find("pelota");

        signoX = Random.Range(0, 2) == 0 ? 1 : -1;

        StartCoroutine(ArbitroPitaInicio());
    }



    void Update()
    {
        var keyboard = Keyboard.current;

        if (keyboard.escapeKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("Main");
        }

        if (Pelota.golesJugadorDer == 5 || Pelota.golesJugadorIzq == 5)
        {
            if (keyboard.anyKey.wasPressedThisFrame)
            {
                Pelota.golesJugadorDer = 0;
                Pelota.golesJugadorIzq = 0;
                SceneManager.LoadScene("Main");
            }
        }
    }

    public void EscribeMarcador()
    {
        if (txtMarcador != null)
        {
            Debug.Log("Gol anotado de parte del codigo de JuegoIA");
            txtMarcador.text = Pelota.golesJugadorIzq.ToString() + " - " + Pelota.golesJugadorDer.ToString();
        }

        if ((Pelota.golesJugadorDer == 5 || Pelota.golesJugadorIzq == 5) && txtGameOver != null)
        {
            txtGameOver.SetActive(true);
            if (audio != null)
            {
                audio.clip = sndGameOver;
                audio.Play();
            }
        }
        else
        {
            StartCoroutine(ArbitroPitaInicio());
        }
    }



    IEnumerator ArbitroPitaInicio()
    {
        yield return new WaitForSeconds(2.0f);
        LanzarPelota();
    }

    public void LanzarPelota()
    {
        audio.clip = sndSilbato;
        audio.Play();
        pelota.transform.position = gameObject.transform.position = new Vector3(0, 0, 0);
        signoY = Random.Range(0, 1) > 0.5f ? 1 : -1;
        pelota.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(signoX * velocidad, signoY * velocidad);
    }
}
