using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private Vector3 _rotation;
    [SerializeField] private GameManagerSO _gameManager;

    public Vector3 Rotation { get => _rotation; }
    public GameManagerSO GameManager { get => _gameManager; }

    public void Initialize(Vector3 rotation, GameManagerSO gameManager) 
    {
        _rotation = rotation;
        _gameManager = gameManager;
    }

    private void Update()
    {
        transform.Rotate(Rotation * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other) 
    {        
        if(other.CompareTag("Player"))
        {
            GameManager.GainScore();
        }    

        gameObject.SetActive(false);
    }
}
