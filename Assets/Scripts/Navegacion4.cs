using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Navegacion4 : MonoBehaviour
{
    [SerializeField] private RectTransform barraDificultad;
    [SerializeField] private RectTransform barraLado;
    private int dificultad = 1;
    private string lado = "I";
    private bool confirmado = false;

    void Update()
    {
        if (confirmado) return;

        var kb = Keyboard.current;

        // Dificultad
        if (kb.digit1Key.wasPressedThisFrame) dificultad = 1;
        if (kb.digit2Key.wasPressedThisFrame) dificultad = 2;
        if (kb.digit3Key.wasPressedThisFrame) dificultad = 3;

        // Lado
        if (kb.iKey.wasPressedThisFrame) lado = "I";
        if (kb.dKey.wasPressedThisFrame) lado = "D";

        // Confirmar
        if (kb.spaceKey.wasPressedThisFrame)
        {
            confirmado = true;
            OpcionesJuego.dificultad = dificultad;
            OpcionesJuego.lado = lado;
            Config2AJuego();
        }

        ActualizarBarra();
    }

    public void Config2AJuego()
    {
        SceneManager.LoadScene("JuegoIA");
    }

    private void ActualizarBarra()
    {
        // Barra de dificultad
        if (dificultad == 1) barraDificultad.anchoredPosition = new Vector2(-400, barraDificultad.anchoredPosition.y);
        if (dificultad == 2) barraDificultad.anchoredPosition = new Vector2(0, barraDificultad.anchoredPosition.y);
        if (dificultad == 3) barraDificultad.anchoredPosition = new Vector2(400, barraDificultad.anchoredPosition.y);

        // Barra del lado
        if (lado == "I") barraLado.anchoredPosition = new Vector2(-370, barraLado.anchoredPosition.y);
        if (lado == "D") barraLado.anchoredPosition = new Vector2(330, barraLado.anchoredPosition.y);
    }
}
