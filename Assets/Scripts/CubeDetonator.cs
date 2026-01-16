using System.Collections.Generic;
using UnityEngine;

public class CubeDetonator : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public void Explosion(Cube detonarotObject)
    {
        foreach (Rigidbody exploisionObjects in GetExplosionObjects(detonarotObject.gameObject))
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
