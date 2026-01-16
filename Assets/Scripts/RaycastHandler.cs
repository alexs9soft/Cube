using System.Collections.Generic;
using UnityEngine;

public class RaycastHandler : MonoBehaviour
{
    [SerializeField] private CubeSpawner _spawner;
    [SerializeField] private CubeDetonator _detonarot;
    [SerializeField] private RaycastClick _click;

    private void OnEnable()
    {
        _click.RaycastObjectHit += PullsStrings;
    }

    private void OnDisable()
    {
        _click.RaycastObjectHit += PullsStrings;
    }

    private void PullsStrings(Cube objectHit)
    {
        List<Cube> cubes = new List<Cube>();

        if (CalculateChanceSpawnObjects(objectHit))
        {
            cubes = _spawner.Spawn(objectHit);
            _detonarot.Explosion(cubes);
            _spawner.Delete(objectHit);
        }
        else
        {
            _spawner.Delete(objectHit);
        }
    }

    private bool CalculateChanceSpawnObjects(Cube objectSpawn)
    {
        return UserUtils.GenerateFloatRandomNumber() <= objectSpawn.GetSplitChance();
    }
}
