using UnityEngine;
using TMPro;

public sealed class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreCount;
    [SerializeField] private GameManagerSO _gameManager;

    public TextMeshProUGUI ScoreCount { get => _scoreCount; }
    public GameManagerSO GameManager { get => _gameManager; }

    public void Initialize(TextMeshProUGUI scoreCount, GameManagerSO gameManager) 
    {
        _scoreCount = scoreCount;
        _gameManager = gameManager;

        Awake();
    }
    
    private void Awake() 
    {
        UpdateText();
    }
    
    private void OnEnable() 
    {
        GameManagerSO.OnScoreUp += UpdateText;
        GameManagerSO.OnResetScore += UpdateText;
    }

    private void OnDisable() 
    {
        GameManagerSO.OnScoreUp -= UpdateText;
        GameManagerSO.OnResetScore -= UpdateText;
    }
    
    private void UpdateText()
    {
        ScoreCount.text = GameManager.GameScore.ToString();
    }
}
