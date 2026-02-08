using UnityEngine;
using UnityEngine.Pool;

public class PoolCube : MonoBehaviour
{
    [SerializeField] private int _poolMaxSize;
    [SerializeField] private int _poolCapacity;

    [SerializeField] private Cube _prefab;
    [SerializeField] private Spawner _spawner;

    [SerializeField] private float _timer;

    private ObjectPool<Cube> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Cube>(
            createFunc: CreateCube,
            actionOnGet: (cube) => OnGet(cube),
            actionOnRelease: (cube) => cube.gameObject.SetActive(false),
            actionOnDestroy: (obj) => Destroy(obj),
            collectionCheck: true,
            defaultCapacity: _poolCapacity,
            maxSize: _poolMaxSize
        );
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _spawner.GetSpawnInterval())
        {
            SpawnCube();
            _timer = 0f;
        }
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
        cube.transform.position = _spawner.GetRandomSpawnPosition();
        cube.gameObject.SetActive(true);

        cube.OnDestroyTime += OnRelease;
    }

    public void OnRelease(Cube cube)
    {
        cube.gameObject.SetActive(false);
        cube.SetDefaultSettings();

        ReturnToPool(cube);
    }

    private void ReturnToPool(Cube cube)
    {
        _pool.Release(cube);

        cube.OnDestroyTime -= OnRelease;
    }
}
