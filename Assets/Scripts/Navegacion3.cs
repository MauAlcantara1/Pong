using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; // Importa el nuevo sistema

public class Navegacion3 : MonoBehaviour
{
    void Update()
    {
       // Detecta si se presionó la tecla Enter
if (Keyboard.current.enterKey.wasPressedThisFrame)

        {
            ConfigAConfig2();
        }
    }

    public void ConfigAConfig2()
    {
        SceneManager.LoadScene("Config2");
    }
}


