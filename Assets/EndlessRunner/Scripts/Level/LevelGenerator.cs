using UnityEngine;

public sealed class LevelGenerator : MonoBehaviour
{
    [SerializeField] private LevelManagerSO _trackManager;

    private ObjectPooler objectPooler;

    public LevelManagerSO TrackManager { get => _trackManager; }

    public void Initialize(LevelManagerSO trackManager)
    {
        _trackManager = trackManager;
    }

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("Player"))
        {
            SpawnTrack();
            SpawnCollectable();
            SpawnObstacle();
            SpawnEnviroment();
        }
    }

    private void SpawnTrack()
    {
        objectPooler.SpawnFromPool("Track", TrackManager.SpawnTrackPosition);
    }

    private void SpawnCollectable() 
    {
        for(int i = 0; i < TrackManager.CollectableMultiplier; i ++)
        {
            objectPooler.SpawnFromPool("Dynamite", new Vector3(2.9f, 1.5f, TrackManager.SpawnTrackPosition.z + Random.Range(45f, 60f)));
            objectPooler.SpawnFromPool("Dynamite", new Vector3(0f, 1.5f, TrackManager.SpawnTrackPosition.z + + Random.Range(15f, 35f)));
            objectPooler.SpawnFromPool("Dynamite", new Vector3(-2.9f, 1.5f, TrackManager.SpawnTrackPosition.z + Random.Range(-10f, 5f)));
        }
    }

    private void SpawnObstacle()
    {
        Vector3 leftLanePosition = new Vector3(-3.1f, 0f, TrackManager.SpawnTrackPosition.z + Random.Range(30f, 35f));
        Vector3 middleLanePosition = new Vector3(0f, 0f, TrackManager.SpawnTrackPosition.z + Random.Range(0f, 10f));
        Vector3 rightLanePosition = new Vector3(3.0f, 0f, TrackManager.SpawnTrackPosition.z + Random.Range(55f, 60f));

        string firstObstacle = RandomObstacleName();
        objectPooler.SpawnFromPool(firstObstacle, leftLanePosition);
    
        string secondObstacle = RandomObstacleName();
        objectPooler.SpawnFromPool(secondObstacle, middleLanePosition);

        string ThirdObstacle = RandomObstacleName();
        objectPooler.SpawnFromPool(ThirdObstacle, rightLanePosition);

        if(RandomSpawnChance() < 70)
        {
            objectPooler.SpawnFromPool("ObstacleType4", leftLanePosition + new Vector3(0f, 0f, Random.Range(10f, 15f)));
        }

        if(RandomSpawnChance() < 70)
        {
            objectPooler.SpawnFromPool("ObstacleType4", middleLanePosition + new Vector3(0f, 0f, Random.Range(10f, 15f)));
        }

        if(RandomSpawnChance() < 70)
        {
            objectPooler.SpawnFromPool("ObstacleType4", rightLanePosition + new Vector3(0f, 0f, Random.Range(10f, 15f)));
        }
    }

    private void SpawnEnviroment()
    {
        Vector3 leftPosition = new Vector3(0f, 0f, TrackManager.SpawnTrackPosition.z);
        Vector3 rightPosition = new Vector3(40f, 0f, TrackManager.SpawnTrackPosition.z);

        objectPooler.SpawnFromPool("EnviromentType1", leftPosition);
        objectPooler.SpawnFromPool("EnviromentType2", rightPosition);
    }

    private string RandomObstacleName()
    {
        int randomObstacle = Random.Range(1,5);
        string obstacleName = "";

        switch (randomObstacle)
        {
            case 1: 
            { 
                obstacleName = "ObstacleType1"; 
                break; 
                }
            case 2: 
            { 
                obstacleName = "ObstacleType2"; 
                break; 
            }
            case 3: 
            { 
                obstacleName = "ObstacleType3"; 
                break; 
            }
            case 4: 
            { 
                obstacleName = "ObstacleType4"; 
                break; 
            }
        }

        return obstacleName;
    }

    private int RandomSpawnChance()
    {
        int randomChance = Random.Range(0, 100);
        return randomChance;
    }
}
