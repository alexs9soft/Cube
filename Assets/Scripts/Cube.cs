using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _splitChance;

    public float GetSplitChance() => _splitChance;

    public void SetNewSplitChance(float value)
    { 
        _splitChance = value;
    }
}
