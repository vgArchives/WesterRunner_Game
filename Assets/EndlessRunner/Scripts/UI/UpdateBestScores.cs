using UnityEngine;
using TMPro;

public class UpdateBestScores : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _bestScore;
    [SerializeField] private GameManagerSO _gameManager;

    public TextMeshProUGUI BestScore { get => _bestScore; }
    public GameManagerSO GameManager { get => _gameManager; }

    public void Initialize(TextMeshProUGUI bestScore, GameManagerSO gameManager) 
    {
        _bestScore = bestScore;
        _gameManager = gameManager;

        Awake();
    }

    private void Awake() 
    {
        UpdateText();
    }
    
    private void OnEnable() 
    {
        GameManagerSO.OnUpdateBest += UpdateText;
    }

    private void OnDisable() 
    {
        GameManagerSO.OnUpdateBest -= UpdateText;
    }
    
    private void UpdateText()
    {
       BestScore.text = GameManager.GameBestScore.ToString();
    }
}
