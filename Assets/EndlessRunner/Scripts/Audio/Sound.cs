using UnityEngine;

[System.Serializable]
public sealed class Sound
{
    public string name;
    
    [HideInInspector]
    public AudioSource audioSource;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 1f;
    [Range(0.1f, 3f)]
    public float pitch = 1f;

    public bool loop = false;
}
