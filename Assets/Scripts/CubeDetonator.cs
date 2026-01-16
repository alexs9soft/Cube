using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CubeDetonator : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
        
    public void Explosion(List<Cube> detonarotObject)
    {
        foreach (Rigidbody exploisionObjects in GetExplosionObjects(detonarotObject))
        {
            exploisionObjects.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }
    }

    private List<Rigidbody> GetExplosionObjects(List<Cube> detonarotObject)
    {
        return detonarotObject.Select(cube => cube.GetComponent<Rigidbody>()).ToList(); 
    }
}
