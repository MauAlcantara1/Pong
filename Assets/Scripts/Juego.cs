using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.InputSystem;
using TMPro; // al inicio del script




using TMPro;
using UnityEngine;

public class Juego : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip sndSilbato, sndGameOver;
    private GameObject txtGameOver;
    private GameObject pelota;

    [SerializeField] private TextMeshProUGUI txtMarcador; // cambia el tipo aquí

    private static float velbola = 5.0f, velJugador = 4.5f;
    public int signoX, signoY, velocidad = 1;

    void Start()
    {
        if (txtGameOver != null)
            txtGameOver.SetActive(false);

        if (txtMarcador != null)
            txtMarcador.text = "0 - 0";

        audio = GetComponent<AudioSource>();
        pelota = GameObject.Find("pelota");

        signoX = Random.Range(0, 2) == 0 ? 1 : -1;

        StartCoroutine(ArbitroPitaInicio());
    }



    // Update is called once per frame
    void Update()
    {
        var keyboard = Keyboard.current;

        if (keyboard.escapeKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("Main");
        }

        if (Pelota.golesJugadorDer == 2 || Pelota.golesJugadorIzq == 2)
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
        txtMarcador.GetComponent<Text>().text = Pelota.golesJugadorIzq.ToString() + " - " + Pelota.golesJugadorDer.ToString();

        if (Pelota.golesJugadorDer == 2 || Pelota.golesJugadorIzq == 2)
        {
            txtGameOver.gameObject.SetActive(true);
            audio.clip = sndGameOver;
            audio.Play();
        }
        else
        {
            StartCoroutine(ArbitroPitaInicio());
        }

    }

    IEnumerator ArbitroPitaInicio()
    {
        yield return new WaitForSeconds(3.0f);
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
