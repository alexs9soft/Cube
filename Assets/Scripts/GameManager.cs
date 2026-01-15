using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CubeSpawner _spawner;
    [SerializeField] private CubeDetonarot _detonarot;
    [SerializeField] private RaycastClick _click;

    private void OnEnable()
    {
        _click.RaycastObjectHit += PullsStrings;
    }

    private void OnDisable()
    {
        _click.RaycastObjectHit += PullsStrings;
    }

    private void PullsStrings(GameObject objectHit)
    {
        if (CalculateChanceSpawnObjects(objectHit))
        {
            _spawner.Spawn(objectHit);
            _detonarot.Explosion(objectHit);
            _spawner.Delete(objectHit);
        }
        else
        {
            _spawner.Delete(objectHit);
        }
    }

    private bool CalculateChanceSpawnObjects(GameObject objectSpawn)
    {
        if (UserUtils.GenerateFloatRandomNumber() <= objectSpawn.GetComponent<Cube>().GetSplitChance())
            return true;
        
        return false;
    }
}
