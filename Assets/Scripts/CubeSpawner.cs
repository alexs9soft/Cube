using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private float _splitScale;
    [SerializeField] private float _splitDivider;

    [SerializeField] private int _minAmountSpawnCube;
    [SerializeField] private int _maxAmountSpawnCube;

    [SerializeField] private GameObject _cubePrefab;

    private List<GameObject> _cubes = new List<GameObject>();

    public void Spawn(GameObject spawnCube)
    {
        for (int i = UserUtils.GenerateRandomNumber(_minAmountSpawnCube, _maxAmountSpawnCube); i > 0; i--)
        {
            Create(spawnCube);
        }
    }

    public void Delete(GameObject deleteCube)
    {
        _cubes.Remove(deleteCube);
        Destroy(deleteCube);
    }

    private void Start()
    {
        for (int i = 0; i < _maxAmountSpawnCube; i++)
        {
            GameObject cube = Instantiate(_cubePrefab);
            cube.transform.position = new Vector3(i + _maxAmountSpawnCube, _minAmountSpawnCube, _maxAmountSpawnCube + i);
            cube.GetComponent<Renderer>().material.color = Random.ColorHSV();
            _cubes.Add(cube);
        }

        _cubes.Add(_cubePrefab);
    }

    private void Create(GameObject createObject)
    {
        GameObject cube = Instantiate(createObject);
        cube.transform.localScale = createObject.transform.localScale * _splitScale;
        cube.GetComponent<Cube>().SetNewSplitChance(createObject.GetComponent<Cube>().GetSplitChance() / _splitDivider);
        cube.GetComponent<Renderer>().material.color = Random.ColorHSV();

        _cubes.Add(cube);
    }
}
