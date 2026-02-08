using System;
using System.Collections;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _minLifeTime;
    [SerializeField] private float _maxLifeTime;
    [SerializeField] private float _delay;
    [SerializeField] private Color _startColor;

    private Coroutine _coroutine;

    private bool _isColorChange = true;
    private float _timeDestroy;

    public event Action<Cube> OnDestroyTime;

    public void Initialize()
    {
        this.GetComponent<Renderer>().material.color = _startColor;
        _timeDestroy = UnityEngine.Random.Range(_minLifeTime, _maxLifeTime);
    }

    public void SetDefaultSettings()
    {
        _isColorChange = true;
        this.GetComponent<Renderer>().material.color = _startColor;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_isColorChange)
        {
            this.GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV();
            _isColorChange = false;
        }

        StartCount();
    }

    private void StartCount()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);

            _coroutine = null;
            return;
        }

        StartCoroutine(CountTimer());
    }

    private IEnumerator CountTimer()
    {
        var wait = new WaitForSeconds(_delay);

        for (int i = 0; i < _timeDestroy; i++)
        {
            yield return wait;
        }
        
        OnDestroyTime?.Invoke(this);
    }
}
