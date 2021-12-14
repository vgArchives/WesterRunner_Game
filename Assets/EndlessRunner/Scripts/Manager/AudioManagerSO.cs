using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AudioManager")]
public sealed class AudioManagerSO : ScriptableObject
{
    [SerializeField] private List<Sound> _sounds = new List<Sound>();

    public List<Sound> Sounds { get => _sounds; }

    private void OnEnable() 
    {
        PlayerController.OnJump += PlayJumpSound;
        PlayerController.OnSideMove += PlaySideMoveSound;

        GameManagerSO.OnScoreUp += PlayCollectSound;

        StartMusic.OnStartMusic += PlayThemeMusic;
    }

    private void OnDisable() 
    {
        PlayerController.OnJump -= PlayJumpSound;
        PlayerController.OnSideMove -= PlaySideMoveSound;

        GameManagerSO.OnScoreUp -= PlayCollectSound;

        StartMusic.OnStartMusic -= PlayThemeMusic;
    }

    public void PlaySound(string audioClip) 
    {
        foreach (Sound sound in Sounds)
        {
            if(sound.audioSource == null)
            {
                 return;
            }
            else
            {
                if(sound.name == audioClip)
                {
                    sound.audioSource.Play();
                }
            }
        }
    }

    private void PlayJumpSound()
    {
        if(Random.value > 0.5)
        {
            PlaySound("Jump01");
        }
        else
        {
            PlaySound("Jump02");
        }
    }

    private void PlaySideMoveSound()
    {
        PlaySound("SideMove");
    }

    private void PlayThemeMusic() 
    {
        PlaySound("ThemeSong");
    }

    private void PlayCollectSound() 
    {
        PlaySound("Collect");
    }
}
