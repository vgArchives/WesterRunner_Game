using UnityEngine;

public sealed class SoundListener : MonoBehaviour
{
    [SerializeField] private AudioManagerSO _audioManager;

    public AudioManagerSO AudioManager { get => _audioManager; }

    public void Initialize(AudioManagerSO audioManager)
    {
        _audioManager = audioManager;

        OnEnable();
    }

    private void OnEnable() 
    {
        foreach (Sound sound in AudioManager.Sounds)
        {
            sound.audioSource = gameObject.AddComponent<AudioSource>();
            sound.audioSource.clip = sound.clip;
            sound.audioSource.volume = sound.volume;
            sound.audioSource.pitch = sound.pitch;
            sound.audioSource.loop = sound.loop;
        }
    }
}
