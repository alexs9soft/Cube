using UnityEngine;

public class Spawner : MonoBehaviour
{ 
    [SerializeField] private Terrain _terrain;

    [SerializeField] private float _spawnHeight;
    [SerializeField] private float _spawnInterval;

    public float GetSpawnInterval () => _spawnInterval;

    public Vector3 GetRandomSpawnPosition()
    {
        float positionX = Random.Range(0f, _terrain.terrainData.size.x);
        float positionZ = Random.Range(0f, _terrain.terrainData.size.z);

        return new Vector3(positionX, _spawnHeight, positionZ);
    }
}
