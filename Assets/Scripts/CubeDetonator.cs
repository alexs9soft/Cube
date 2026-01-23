using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CubeDetonator : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
        
    public void Explosion(Cube explosionCube)
    {
        foreach (Rigidbody exploisionObjects in GetExplosionObjects(explosionCube))
        {
            exploisionObjects.AddExplosionForce(_explosionForce, explosionCube.transform.position, _explosionRadius);
        }
    }

    private List<Rigidbody> GetExplosionObjects(Cube cube)
    {
        Collider[] hits = Physics.OverlapSphere(cube.transform.position, _explosionRadius);

        List<Rigidbody> cubes = new List<Rigidbody>();

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
