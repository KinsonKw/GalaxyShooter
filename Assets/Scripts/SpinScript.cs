using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SpinAxis { X, Y, Z}
public class SpinScript : MonoBehaviour
{
    [SerializeField] private bool _playOnStart = false;

    [Header("Rotation Settings")]
    [SerializeField] private GameObject _enemy = null;
    [SerializeField] private bool _clockwise = true;
    [SerializeField] private float _spinSpeed = 120f;
    [SerializeField] private SpinAxis _currSpin = SpinAxis.Y;

    private bool _activated = false;
    private Vector3 _dirVector = Vector3.up;
    private float _multiplier = 1f;

    // Start is called before the first frame update
    void Start()
    {
        switch (_currSpin)
        {
            case SpinAxis.X:
                _dirVector = _enemy.transform.right;
                break;

            case SpinAxis.Y:
                _dirVector = _enemy.transform.up;
                break;

            case SpinAxis.Z:
                _dirVector = _enemy.transform.forward;
                break;
        }
        _activated = _playOnStart;
    }

    // Update is called once per frame
    void Update()
    {
        if(_activated)
        {
            _multiplier = _clockwise ? 1f : -1f;
            _enemy.transform.Rotate(_dirVector, _multiplier * _spinSpeed * Time.deltaTime);
        }
    }
    public void Activate()
    {
        _activated = false;
    }
}
