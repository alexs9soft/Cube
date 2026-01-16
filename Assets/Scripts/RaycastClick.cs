using System;
using UnityEngine;

public class RaycastClick : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Ray _ray;
    [SerializeField] private float _maxDistance;
    [SerializeField] private InputReader _reader;

    public event Action<Cube> RaycastObjectHit;

    private void OnEnable()
    {
        _reader.MouseClick += ClickUser;
    }

    private void OnDisable()
    {
        _reader.MouseClick -= ClickUser;
    }

    private void ClickUser()
    {
        RaycastHit hit;

        _ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.TryGetComponent(out Cube cube))
            {
                RaycastObjectHit?.Invoke(cube);
            }
        }
    }
}
