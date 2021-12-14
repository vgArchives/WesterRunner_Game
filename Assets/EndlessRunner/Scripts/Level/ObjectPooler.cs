using System.Collections.Generic;
using UnityEngine;

public sealed class ObjectPooler : MonoBehaviour
{
    [SerializeField] private List<Pool> _pools;
    [SerializeField] private Dictionary<string, Queue<GameObject>> _poolDictionary;

    public static ObjectPooler Instance;

    public List<Pool> Pools { get => _pools; }
    public Dictionary<string, Queue<GameObject>> PoolDictionary { get => _poolDictionary; set => _poolDictionary = value; }

    public void Initialize(List<Pool> pools, Dictionary<string, Queue<GameObject>> poolDictionary) 
    {
        _pools = pools;
        _poolDictionary = poolDictionary;

        Awake();
    }
    
    private void Awake() 
    {
        Instance = this;    
    }

    private void Start() 
    {
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();   

        foreach( Pool pool in Pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
               GameObject obj = Instantiate(pool.sourcePrefab); 
               obj.SetActive(false);
               objectPool.Enqueue(obj);
               obj.transform.parent = transform;
            }

            PoolDictionary.Add(pool.tagName, objectPool);
        } 
    }

[System.Serializable]
    public class Pool
    {
        public string tagName;
        public GameObject sourcePrefab;
        public int size;
    }

    public GameObject SpawnFromPool(string tagName, Vector3 position)
    {
        GameObject objectoToSpawn = PoolDictionary[tagName].Dequeue();

        objectoToSpawn.SetActive(true);
        objectoToSpawn.transform.position = position;

        PoolDictionary[tagName].Enqueue(objectoToSpawn);

        return objectoToSpawn;
    }
}
