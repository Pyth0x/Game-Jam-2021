using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeSliderScript : MonoBehaviour
{
    public AudioMixer audioMixer;
    public void setVolume (float volume)
    {
        Debug.Log(volume);
        audioMixer.SetFloat("volume", volume);
    }
}
