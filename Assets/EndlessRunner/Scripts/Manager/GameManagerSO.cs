using UnityEngine;

[CreateAssetMenu(menuName = "GameManager")]
public sealed class GameManagerSO : ScriptableObject
{
    public delegate void ScoreUpAction();
    public static event ScoreUpAction OnScoreUp;

    public delegate void resetScoreAction();
    public static event resetScoreAction OnResetScore;

    public delegate void UpdateBestAction();
    public static event UpdateBestAction OnUpdateBest;

    public delegate void LoadSceneAction(string name);
    public static event LoadSceneAction OnLoadScene;
    
    [SerializeField] private int _gameScore;
    [SerializeField] private int _gameBestScore = 0;

    public int GameScore { get => _gameScore; private set => _gameScore = value; }
    public int GameBestScore { get => _gameBestScore; private set => _gameBestScore = value; }

    private void OnEnable() 
    {
        GameScore = 0;

        PlayerController.OnDeath += GameOver;
        PlayerController.OnDeath += UpdateBestScore;
    }    

    private void OnDisable()
    {
        PlayerController.OnDeath -= GameOver;
        PlayerController.OnDeath -= UpdateBestScore;
    }

    public void GainScore()
    {
        GameScore ++;
        OnScoreUp?.Invoke();
    }

    public void ResetScore() 
    {
        GameScore = 0;
        OnResetScore?.Invoke();
    }

    public void UpdateBestScore() 
    {
        if(GameScore > GameBestScore) 
        {
            GameBestScore = GameScore;
        }

        OnUpdateBest?.Invoke();
    }

    public void StartGame() 
    {
        OnLoadScene?.Invoke("Gameplay"); 
        ResetScore();
    }

    public void MainMenu() 
    {
       OnLoadScene?.Invoke("MainMenu");  
    }

    public void GameOver()
    {
        OnLoadScene?.Invoke("GameOver"); 
    }

    public void ExitGame() 
    {
        Application.Quit();
    }
}
