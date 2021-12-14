using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public sealed class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject _loadScreen;
    [SerializeField] private Slider _slider;

    public GameObject LoadScreen { get => _loadScreen; }
    public Slider Slider { get => _slider; set => _slider = value; }

    public void Initialize(GameObject loadScreen, Slider slider) 
    {
        _loadScreen = loadScreen;
        _slider = slider;

        OnEnable();
    }

    private void OnEnable() 
    {
        GameManagerSO.OnLoadScene += LoadLevel;    
    }

    private void OnDisable() 
    {
        GameManagerSO.OnLoadScene -= LoadLevel;    
    }

    public void LoadLevel(string sceneName) 
    {
        StartCoroutine(LoadingScreen(sceneName));
        LoadScreen.SetActive(true);
    }

    private IEnumerator LoadingScreen(string sceneName) 
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

        while(!operation.isDone) 
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            Slider.value = progress;

            yield return null;
        }
    }
}
