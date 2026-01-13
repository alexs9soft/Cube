using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    [SerializeField] private float _splitScale;
    [SerializeField] private float _splitChance;
    [SerializeField] private float _splitDivide;

    [SerializeField] private int _minAmountSpawpCube;
    [SerializeField] private int _maxAmountSpawpCube;
    

    private void OnEnable()
    {
        _cube.MouseClick += CalculateChanceSpawnObjects;
    }

    private void OnDisable()
    {
        _cube.MouseClick -= CalculateChanceSpawnObjects;
    }

    private void Create()
    {
        GameObject ñube = Instantiate(gameObject);
        ñube.transform.localScale = transform.localScale * _splitScale;
        ñube.GetComponent<Renderer>().material.color = Random.ColorHSV();
    }

    private void CalculateChanceSpawnObjects()
    {
        if (UserUtils.GenerateFloatRandomNumber() <= _splitChance)
        {
            _splitChance = _splitChance / _splitDivide;

            for (int i = UserUtils.GenerateRandomNumber(_minAmountSpawpCube, _maxAmountSpawpCube); i > 0; i--)
            {
                Create();
            }
        }
    }
}
