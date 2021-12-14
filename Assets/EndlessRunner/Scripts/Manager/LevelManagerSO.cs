using UnityEngine;

[CreateAssetMenu(menuName = "TrackManager")]
public sealed class LevelManagerSO : ScriptableObject
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _hideDistance;
    [SerializeField] private int _collectableMultiplier;
    [SerializeField] private Vector3 _spawnTrackPosition;

    public float MoveSpeed { get => _moveSpeed; private set => _moveSpeed = value; }
    public float HideDistance { get => _hideDistance; private set => _hideDistance = value; }
    public int CollectableMultiplier { get => _collectableMultiplier; private set => _collectableMultiplier = value; }
    public Vector3 SpawnTrackPosition { get => _spawnTrackPosition; private set => _spawnTrackPosition = value;}

    private void OnEnable() 
    {
        _moveSpeed = 10f;

        IncreaseSpeed.OnDifficultyUp += SpeedUp;
        PlayerController.OnDeath += ResetSpeed;
    }

    private void OnDisable() 
    {
        IncreaseSpeed.OnDifficultyUp -= SpeedUp;
        PlayerController.OnDeath -= ResetSpeed;
    }

    private void SpeedUp()
    {
        if(_moveSpeed < 70)
        {
            _moveSpeed ++;
        }
    }

    private void ResetSpeed() 
    {
        _moveSpeed = 10f;
    }
}
