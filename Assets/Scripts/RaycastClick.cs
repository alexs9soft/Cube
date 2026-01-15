using System;
using UnityEngine;

public class RaycastClick : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Ray _ray;
    [SerializeField] private float _maxDistance;

    public event Action<GameObject> RaycastObjectHit;

    void Update()
    {
        RaycastHit hit;

        _ray = _camera.ScreenPointToRay(Input.mousePosition);
        
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(_ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.TryGetComponent(out Cube cube))
                {
                    RaycastObjectHit?.Invoke(cube.gameObject);
                }
            }
        }
    }
}
