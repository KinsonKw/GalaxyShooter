using PathCreation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PathPlaneController : MonoBehaviour
{
    [SerializeField] private PathCreator _pathCreator = null;
    [SerializeField] private float _pathMoveSpeed = 4;

    [Header("Ship Settings")]
    [SerializeField] private Transform _ship = null;
    [SerializeField] private float _xMoveSpeed = 5f;
    [SerializeField] private float _yMoveSpeed = 5f;
    [SerializeField] private float _maxXDistance = 20f;
    [SerializeField] private float _maxYDistance = 20f;

    private float _currPathPoint = 0f;
    private bool _active = true;

    [SerializeField] private float speed;
    [SerializeField] private float boostTimer;
    [SerializeField] private bool boosting;

    [SerializeField] private float speedBoostFOV = 80f;
    [SerializeField] private Camera _camera;

    private bool _changingFOV = false;
    private bool _changingToBoost= false;
    private float _currChangeTime = 0f;
    private float _changeTime = 2f;
    

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;

        speed = 20f;
        boostTimer = 0f;
        boosting = false;
    }

    void Update()
    {
        if (_active)
        {
            // Calculate travel distance based on speed and total path length
            float toAdd = (_pathMoveSpeed / _pathCreator.path.length) * Time.deltaTime;
            _currPathPoint = Mathf.Clamp01(_currPathPoint + toAdd);

            if (_currPathPoint == 1f)
            {
                SceneManager.LoadScene("Victory Screen");
            }

            // Set position and rotation on the path at that point
            transform.position = _pathCreator.path.GetPointAtTime(_currPathPoint);
            transform.rotation = _pathCreator.path.GetRotation(_currPathPoint);

            Vector3 move = Vector3.zero;

            // Movement using "Horizontal" (A/D) and "Vertical" (W/S)
            move.x = _xMoveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime;
            move.y = _yMoveSpeed * Input.GetAxis("Vertical") * Time.deltaTime;

            _ship.localPosition += move;

            //Clamp to max distance away from the "base"
            _ship.localPosition = new Vector3(
                Mathf.Clamp(_ship.localPosition.x, -_maxXDistance, _maxXDistance),
                Mathf.Clamp(_ship.localPosition.y, -_maxYDistance, _maxYDistance), 
                _ship.localPosition.z);

         if(_changingFOV)
            {
                if (_changingToBoost)
                {
                    _camera.fieldOfView = Mathf.SmoothStep(65f, 80f, _currChangeTime / _changeTime);
                }
                else
                {
                    _camera.fieldOfView = Mathf.SmoothStep(80f, 65f, _currChangeTime / _changeTime);
                }

                _currChangeTime += Time.deltaTime;

                if(_currChangeTime > _changeTime)
                {
                    _changingFOV = false;
                    _currChangeTime = 0f;
                }
            }
        }
        if(boosting)
        {
            boostTimer += Time.deltaTime;
            if(boostTimer >= 3f)
            {
                _pathMoveSpeed = 20f;
                boostTimer = 0f;
                boosting = false;
                _changingFOV = true;
                _changingToBoost = false;

            }
        }
    }
    public void SpeedBoost()
    {
         boosting = true;
        _pathMoveSpeed = speed;
        _changingFOV = true;
        _changingToBoost = true;
    }

}
