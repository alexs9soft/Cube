using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private int _minAmountSpawnCube;
    [SerializeField] private int _maxAmountSpawnCube;

    [SerializeField] private CubeFactory _cubeFactory;

    public void Spawn(Cube spawnCube)
    {
        for (int i = UserUtils.GenerateRandomNumber(_minAmountSpawnCube, _maxAmountSpawnCube); i > 0; i--)
        {
            _cubeFactory.Create(spawnCube);
        }
    }

    public void Delete(Cube deleteCube)
    {
        Destroy(deleteCube.gameObject);
    }
}
