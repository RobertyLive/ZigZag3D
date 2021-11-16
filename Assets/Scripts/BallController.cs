using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [Header("Controls")]
    [SerializeField] private float speed;

    [Header("References")]
    private Rigidbody _rb;
    [SerializeField] private LayerMask _layerGround;
    [SerializeField] private float _size;
    [SerializeField] private bool _ray;

    private CinemachineVirtualCamera _cam;

    [HideInInspector] public bool _gameOver = false;


    private void Awake() 
    {
        _rb = GetComponent<Rigidbody>();
        _cam = GameObject.Find("CMControlCamera").GetComponent<CinemachineVirtualCamera>();
    }

    private void Start()
    {
        //_rb.velocity = new Vector3(speed, 0, 0);
    }

    private void Update() 
    {
        //Challenge();

        if(Input.GetMouseButtonDown(0))
        {
            ChangePosition();
        }

        Line();
    }

    void ChangePosition()
    {
        if(_rb.velocity.x > 0)
        {
            _rb.velocity = new Vector3(0, 0, speed);
        }
        else if(_rb.velocity.z >= 0)
        {
            _rb.velocity = new Vector3(speed, 0, 0);
        }
    }

    private void Line()
    {
        _ray = Physics.Raycast(this.transform.position, Vector3.down * _size, _layerGround);

        if(_ray != true)
        {
            _rb.useGravity = true;
            _gameOver = true;
            _cam.Follow = null;
        }
    }

    private void OnDrawGizmos() 
    {
        Gizmos.DrawRay(this.transform.position, Vector3.down * _size);  
    }

    private void Challenge()
    {
        int i = (int) Time.time;

        switch (i)
        {
            case 10:
                speed = 0.7f;
                break;
            case 20:
                speed = 0.9f;
                break;
            case 30:
                speed = 1.1f;
                break;
            case 40:
                speed = 1.3f;
                break;
            case 50:
                speed = 1.5f;
                break;
            case 60:
                speed = 2.0f;
                break;
            case 70:
                speed = 2.5f;
                break;
            case 80:
                speed = 3.0f;
                break;
            case 90:
                speed = 4.0f;
                break;
            case 100:
                speed = 5f;
                break;
        }
    }

}
