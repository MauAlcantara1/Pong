using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; 

public class Navegacion3 : MonoBehaviour
{
    void Update()
    {
        if (Keyboard.current.digit1Key.wasPressedThisFrame) 
        {
            ConfigAConfig2();
        }

        if (Keyboard.current.digit2Key.wasPressedThisFrame) 
        {
            ConfigAConfig3();
        }
    }

    public void ConfigAConfig2()
    {
        SceneManager.LoadScene("Config2");
    }
    
    public void ConfigAConfig3()
    {
        SceneManager.LoadScene("JuegoJcJ");
    }
}
