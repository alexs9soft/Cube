using UnityEngine;
using UnityEngine.PlayerLoop;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _splitChance;

    public void Initialize(Vector3 scale, Color color, float splitChance = 1.0f)
    {
        gameObject.GetComponent<Renderer>().material.color = color;
        gameObject.transform.localScale = scale;

        _splitChance = splitChance;
    }

    public float GetSplitChance() => _splitChance;

    public void SetNewSplitChance(float value)
    { 
        _splitChance = value;
    }
}
