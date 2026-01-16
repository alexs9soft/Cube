using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private float _splitScale;
    [SerializeField] private float _splitDivider;

    [SerializeField] private int _minAmountSpawnCube;
    [SerializeField] private int _maxAmountSpawnCube;

    [SerializeField] private Cube _cube;

    public List<Cube> Spawn(Cube spawnCube)
    {
        List<Cube> cubes = new List<Cube>();

        for (int i = UserUtils.GenerateRandomNumber(_minAmountSpawnCube, _maxAmountSpawnCube); i > 0; i--)
        {
            cubes.Add(Create(spawnCube));
        }

        return cubes;
    }

    public void Delete(Cube deleteCube)
    {
        Destroy(deleteCube.gameObject);
    }

    private void Start()
    {
        for (int i = 0; i < _maxAmountSpawnCube; i++)
        {
            Cube cube = Instantiate(_cube);

            cube.Initialize(_cube.gameObject.transform.localScale, Random.ColorHSV());
            cube.transform.position = new Vector3(i + _maxAmountSpawnCube, _minAmountSpawnCube, _maxAmountSpawnCube + i);
        }
    }

    private Cube Create(Cube createObject)
    {
        Color color = Random.ColorHSV();
        Vector3 scale = createObject.transform.localScale * _splitScale;

        float splitChance = createObject.GetSplitChance() / _splitDivider;

        Cube cube = Instantiate(createObject);
        cube.Initialize(scale, color, splitChance);

        return cube;
    }
}
