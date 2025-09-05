using UnityEngine;

public class Quitarmusica : MonoBehaviour
{
    void Start()
    {
        var musicManager = FindObjectOfType<MusicManager>();
        if (musicManager != null)
        {
            Destroy(musicManager.gameObject);
        }
    }
}
