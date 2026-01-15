using System.Collections.Generic;
using UnityEngine;

public class CubeDetonarot : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public void Explosion(GameObject detonarotObject)
    {
        foreach (Rigidbody exploisionObjects in GetExplosionObjects(detonarotObject))
        {
            exploisionObjects.AddExplosionForce(_explosionForce, detonarotObject.transform.position, _explosionRadius);
        }
    }

    private List<Rigidbody> GetExplosionObjects(GameObject detonarotObject)
    {
        Collider[] hits = Physics.OverlapSphere(detonarotObject.transform.position, _explosionRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                cubes.Add(hit.attachedRigidbody);
            }
        }

        return cubes;
    }
}
