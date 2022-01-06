using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SoundsVolumeController : MonoBehaviour
{   [Header("Components")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Slider slider;
    [SerializeField] private TextMeshProUGUI text;

    [Header("Keys")]
    [SerializeField] private string saveVolumeKey;

    [Header("Tags")]
    [SerializeField] private string sliderTag;
    [SerializeField] private string textVolumeTag;

    [Header("Parameters")]
    [SerializeField] private float Volume;


    private void Awake()
    {
        if(PlayerPrefs.HasKey(this.saveVolumeKey))
        {
            this.Volume = PlayerPrefs.GetFloat(this.saveVolumeKey);
            this.audioSource.volume = this.Volume;
            GameObject sliderObj = GameObject.FindWithTag(this.sliderTag);
            if(sliderObj!=null)
            {
                this.slider = sliderObj.GetComponent<Slider>();
                this.slider.value = this.Volume;
            }
            else
            {
                this.Volume = 0.5f;
                PlayerPrefs.SetFloat(this.saveVolumeKey,this.Volume);
                this.audioSource.volume = this.Volume;
            }
        }
    }
    private void LateUpdate()
    {
        GameObject sliderobj = GameObject.FindWithTag(this.sliderTag);
        if(sliderobj!=null)
        {
            this.slider = sliderobj.GetComponent<Slider>();
            this.Volume = slider.value;
            if(this.audioSource.volume!=this.Volume)
            {
                PlayerPrefs.SetFloat(this.saveVolumeKey, this.Volume);
            }
            GameObject textObj = GameObject.FindWithTag(this.textVolumeTag);
            if(textObj!=null)
            {
                this.text = textObj.GetComponent<TextMeshProUGUI>();
                this.text.text = Mathf.Round(this.Volume * 100) + "%";
            }
        }
        this.audioSource.volume = this.Volume;
    }
}
