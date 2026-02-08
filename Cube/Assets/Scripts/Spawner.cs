using System.Collections;
using UnityEngine;
using UnityEngine.Pool;

public class Spawner : MonoBehaviour
{ 
    [SerializeField] private Terrain _terrain;

    [SerializeField] private float _spawnHeight;
    [SerializeField] private float _spawnInterval;

    [SerializeField] private int _poolMaxSize;
    [SerializeField] private int _poolCapacity;

    [SerializeField] private Cube _prefab;

    private ObjectPool<Cube> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Cube>(
            createFunc: CreateCube,
            actionOnGet: (cube) => OnGet(cube),
            actionOnRelease: (cube) => cube.gameObject.SetActive(false),
            actionOnDestroy: (obj) => Destroy(obj.gameObject),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize
        );
    }

    private void Start()
    {
        StartCoroutine(SpawnTimer());
    }

    public Vector3 GetRandomSpawnPosition()
    {
        float positionX = Random.Range(0f, _terrain.terrainData.size.x);
        float positionZ = Random.Range(0f, _terrain.terrainData.size.z);

        return new Vector3(positionX, _spawnHeight, positionZ);
    }

    private Cube CreateCube()
    {
        Cube cube = Instantiate(_prefab);
        cube.Initialize();

        return cube;
    }

    private void SpawnCube()
    {
        Cube cube = _pool.Get();
    }

    private void OnGet(Cube cube)
    {
        cube.transform.position = GetRandomSpawnPosition();
        cube.gameObject.SetActive(true);

        cube.DestroyTime += OnRelease;
    }

    private void OnRelease(Cube cube)
    {
        cube.gameObject.SetActive(false);
        cube.SetDefaultSettings();

        ReturnToPool(cube);
    }

    private void ReturnToPool(Cube cube)
    {
        _pool.Release(cube);

        cube.DestroyTime -= OnRelease;
    }

    private IEnumerator SpawnTimer()
    {
        var wait = new WaitForSeconds(_spawnInterval);

        while (enabled)
        {
            SpawnCube();

            yield return wait;
        }
    }
}
