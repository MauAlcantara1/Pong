using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; // Importa el nuevo sistema

public class Navegacion2 : MonoBehaviour
{
    void Update()
    {
        // Detecta si se presionó la barra espaciadora
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            MainAConfig();
        }
    }

    public void MainAConfig()
    {
        SceneManager.LoadScene("Config");
    }
}