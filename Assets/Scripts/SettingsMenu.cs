using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public Slider SliderButtonvolumen; // Asigna el slider de volumen desde el Inspector
    public Slider SliderButtonluminosidad; // Asigna el slider de luminosidad desde el Inspector
    public CanvasGroup brightnessOverlay; // Asigna un overlay para simular el cambio de brillo
    public Button ButtonGuardar; // Asigna el botón de guardar desde el Inspector
    public Button ButtonCancelar; // Asigna el botón de cancelar desde el Inspector

    void Start()
    {
        // Asignar listeners a los botones
        ButtonGuardar.onClick.AddListener(ApplySettings);
        ButtonCancelar.onClick.AddListener(CancelSettings);

        // Cargar configuraciones guardadas al iniciar la escena
        SliderButtonvolumen.value = PlayerPrefs.GetFloat("Volume", 1f);
        SliderButtonluminosidad.value = PlayerPrefs.GetFloat("Brightness", 1f);
        brightnessOverlay.alpha = 1 - SliderButtonluminosidad.value;
    }

    public void ApplySettings()
    {
        // Aplicar las configuraciones (volumen y brillo)
        AudioListener.volume = SliderButtonvolumen.value;

        float brightnessValue = SliderButtonluminosidad.value;
        brightnessOverlay.alpha = 1 - brightnessValue; // Ajuste de brillo simulando con transparencia

        // Puedes guardar las configuraciones en PlayerPrefs o un archivo para mantenerlas
        PlayerPrefs.SetFloat("Volume", SliderButtonvolumen.value);
        PlayerPrefs.SetFloat("Brightness", SliderButtonluminosidad.value);
        PlayerPrefs.Save();

        // Volver al menú principal
        SceneManager.LoadScene("MainMenu");
    }

    public void CancelSettings()
    {
        // Simplemente vuelve al menú principal sin aplicar cambios
        SceneManager.LoadScene("MainMenu");
    }
}
