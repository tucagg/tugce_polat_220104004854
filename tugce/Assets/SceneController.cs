using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public Button previousButton;
    public Button nextButton;

    private void Start()
    {
        UpdateButtonStates();
    }

    // Bir sonraki sahneye geçiş
    public void NextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
    }

    // Önceki sahneye geçiş
    public void PreviousScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex > 0)
        {
            SceneManager.LoadScene(currentSceneIndex - 1);
        }
    }

    // Buton durumlarını güncelleme
    private void UpdateButtonStates()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // İlk sahne için
        if (currentSceneIndex == 0)
        {
            previousButton.interactable = false; // Önceki butonunu devre dışı bırak
        }
        else
        {
            previousButton.interactable = true; // Önceki butonunu aktif et
        }

        // Son sahne için
        if (currentSceneIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            nextButton.interactable = false; // Sonraki butonunu devre dışı bırak
        }
        else
        {
            nextButton.interactable = true; // Sonraki butonunu aktif et
        }
    }
}