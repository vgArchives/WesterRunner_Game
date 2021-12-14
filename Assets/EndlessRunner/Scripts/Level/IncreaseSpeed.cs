using UnityEngine;

public sealed class IncreaseSpeed : MonoBehaviour
{    
    public delegate void DifficultyUpAction();
    public static event DifficultyUpAction OnDifficultyUp;
    
    [SerializeField] private float _timeToIncrease;

    private float timer = 0f;

    public float TimeToIncrease { get => _timeToIncrease; }

    public void Initialize(float timeToIncrease) 
    {
        _timeToIncrease = timeToIncrease;

        Awake();
    }

    private void Awake() 
    {
        timer = TimeToIncrease;
    }
    
    void Update()
    {
        if(timer <= 0)
        {
            OnDifficultyUp?.Invoke();
            timer = TimeToIncrease;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
