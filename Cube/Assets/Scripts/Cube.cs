using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Renderer), typeof(Rigidbody))]
public class Cube : MonoBehaviour
{
    [SerializeField] private float _minLifeTime;
    [SerializeField] private float _maxLifeTime;
    [SerializeField] private float _delay;
    [SerializeField] private Color _startColor;

    private Renderer _renderer;
    private Rigidbody _rigidbody;

    private bool _isColorChange = true;
    private float _timeDestroy;

    public event Action<Cube> DestroyTime;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Initialize()
    {
        _renderer.material.color = _startColor;
        _timeDestroy = UnityEngine.Random.Range(_minLifeTime, _maxLifeTime);
    }

    public void SetDefaultSettings()
    {
        _isColorChange = true;
        _renderer.material.color = _startColor;

        transform.position = Vector3.zero;
        transform.rotation = Quaternion.identity;

        _rigidbody.angularVelocity = Vector3.zero;
        _rigidbody.linearVelocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Platform>(out _) && _isColorChange == true)
        {
            _renderer.material.color = UnityEngine.Random.ColorHSV();
            _isColorChange = false;
        }

        StartCoroutine(CountTimer());
    }

    private IEnumerator CountTimer()
    {
        var wait = new WaitForSeconds(_delay);

        yield return wait;
        
        DestroyTime?.Invoke(this);
    }
}
