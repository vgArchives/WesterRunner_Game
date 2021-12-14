using UnityEngine;

public sealed class StartMusic : MonoBehaviour
{
    public delegate void StartMusicAction();
    public static event StartMusicAction OnStartMusic;
    
    private void Start() 
    {
        OnStartMusic?.Invoke();
    }
}
