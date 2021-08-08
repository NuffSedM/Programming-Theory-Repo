using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuUI : MonoBehaviour
{
    [SerializeField] private Image playerColorSample;
    [SerializeField] private Slider redSlider;
    [SerializeField] private Slider greenSlider;
    [SerializeField] private Slider blueSlider;

    private void Start()
    {
        redSlider.value = SaveManager.Instance.playerColor.r;
        greenSlider.value = SaveManager.Instance.playerColor.g;
        blueSlider.value = SaveManager.Instance.playerColor.b;
    }

    private void Update()
    {
        playerColorSample.color = new Color(redSlider.value, greenSlider.value, blueSlider.value);
    }

    public void StartGame()
    {
        SaveManager.Instance.Save();
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        SaveManager.Instance.Save();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
