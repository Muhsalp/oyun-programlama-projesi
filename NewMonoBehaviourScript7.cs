using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript7 : MonoBehaviour
{
    public AudioMixer mixer;
    public Slider musicSlider;
    public Slider SFXSlider;

    private void Start()
    {
        mixer.GetFloat("MusicVolume", out float musicValue);
        mixer.GetFloat("SFXVolume", out float sfxValue);
        musicSlider.value = musicValue;
        SFXSlider.value = sfxValue;
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        SFXSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    public void SetMusicVolume(float value){
        mixer.SetFloat("MusicVolume", value);
    }

    public void SetSFXVolume(float value){
        mixer.SetFloat("SFXVolume", value);
    }

    public void StartGame(){
        SceneManager.LoadScene("SampleScene");
    }
}
