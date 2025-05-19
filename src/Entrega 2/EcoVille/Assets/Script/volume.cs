using UnityEngine;
using UnityEngine.UIElements;


public class MusicPlayer : MonoBehaviour
{
    private static MusicPlayer instance;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Persiste entre cenas
        }
        else
        {
            Destroy(gameObject); // Evita duplicatas
        }
    }
}
