using UnityEngine;

public class CubeFactory : MonoBehaviour
{
    [SerializeField] private Cube _cube;

    [SerializeField] private float _splitScale;
    [SerializeField] private float _splitDivider;
    [SerializeField] private int _minStartSpawnCube;
    [SerializeField] private int _maxStartSpawnCube;

    public void Create(Cube createObject)
    {
        Cube cube = Instantiate(createObject);

        Color color = Random.ColorHSV();
        Vector3 scale = createObject.transform.localScale * _splitScale;
        float splitChance = createObject.GetSplitChance() / _splitDivider;

        cube.Initialize(scale, color, splitChance);
    }

    private void Start()
    {
        for (int i = 0; i < _maxStartSpawnCube; i++)
        {
            Cube cube = Instantiate(_cube);

            cube.transform.position = new Vector3(i + _maxStartSpawnCube, _minStartSpawnCube, _maxStartSpawnCube + i);

            cube.gameObject.GetComponent<Cube>().Initialize(_cube.gameObject.transform.localScale, Random.ColorHSV());
        }
    }
}
