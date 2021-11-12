using System.Collections;
using System.Collections.Generic;
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
    private bool _gameOver = false;


    private void Awake() 
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        //_rb.velocity = new Vector3(speed, 0, 0);
    }

    private void Update() 
    {
        Line();

        if(Input.GetMouseButtonDown(0))
        {
            ChangePosition();
        }    
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
        }
    }

    private void OnDrawGizmos() 
    {
        Gizmos.DrawRay(this.transform.position, Vector3.down * _size);  
    }

}
