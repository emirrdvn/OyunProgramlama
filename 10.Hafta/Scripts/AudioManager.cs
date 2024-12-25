using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider; // Slider referansı
    //[SerializeField] private AudioSource audioSource; // Kontrol edilecek ses kaynağı

    private void Start()
    {
        // Kaydedilmiş ses seviyesini yükle (Varsayılan olarak %50)
        float savedVolume = PlayerPrefs.GetFloat("Volume", 0.5f);
        //audioSource.volume = savedVolume;
        volumeSlider.value = savedVolume;

        // Slider değişikliklerini dinle
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    private void SetVolume(float volume)
    {
        //audioSource.volume = volume; // Ses seviyesini güncelle
        PlayerPrefs.SetFloat("Volume", volume); // Kaydet
    }
    void Update()
    {
        //Debug.Log("Volume: " + volumeSlider.value);
    }
}
