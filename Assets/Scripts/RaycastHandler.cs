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
        if (CalculateChanceSpawnObjects(objectHit))
        {
            _spawner.Spawn(objectHit);
            _spawner.Delete(objectHit);
        }
        else
        {
            _detonarot.Explosion(objectHit);
            _spawner.Delete(objectHit);
        }
    }

    private bool CalculateChanceSpawnObjects(Cube objectSpawn)
    {
        return UserUtils.GenerateFloatRandomNumber() <= objectSpawn.GetSplitChance();
    }
}
