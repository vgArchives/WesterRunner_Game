using UnityEngine;

public sealed class MovementObject : MonoBehaviour
{
    [SerializeField] private LevelManagerSO _levelManager;

    public LevelManagerSO LevelManager { get => _levelManager; }

    public void Initialize(LevelManagerSO levelManager)
    {
        _levelManager = levelManager;
    }

    private void Update() 
    {
        transform.position += new Vector3(0f, 0f, -1 * LevelManager.MoveSpeed * Time.deltaTime);

        if(transform.position.z <= LevelManager.HideDistance)
        {
            gameObject.SetActive(false);
        }
    }
}
