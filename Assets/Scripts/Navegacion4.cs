using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; 

public class Navegacion4 : MonoBehaviour
{
    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            Config2AJuego();
        }
    }

    public void Config2AJuego()
    {
        SceneManager.LoadScene("JuegoIA");
    }
}