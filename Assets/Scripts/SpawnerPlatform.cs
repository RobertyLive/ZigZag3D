using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class SpawnerPlatform : MonoBehaviour
{   
    private BallController _ballController;
    [SerializeField] GameObject ground;

    [SerializeField] float sizeX;

    [SerializeField] Vector3 lastPos;

    private void Awake() {
        _ballController = GameObject.Find("Ball").GetComponent<BallController>();
    }
    private void Start() {

        Instantiate(ground);
        
        lastPos = ground.transform.position;
        sizeX = ground.transform.localScale.x;

        StartCoroutine(SpwnerTimeReal());
    }

    private void SpwnerX()
    {
        Vector3 pos = lastPos;

        pos.x += sizeX;

        lastPos = pos;

        Instantiate(ground, pos, Quaternion.identity);
    }

    private void SpwnerZ()
    {
        Vector3 pos = lastPos; 

        pos.z += sizeX;

        lastPos = pos;

        Instantiate(ground, pos, Quaternion.Euler(0, 90, 0));
    }

    void RandomValue()
    {
        int rand = Random.Range(0, 5);

        if(rand < 2)
        {
            SpwnerX();
        }
        else if(rand >= 2)
        {
            SpwnerZ();
        }
    }

    IEnumerator SpwnerTimeReal()
    {
        while(_ballController._gameOver != true)
        {
            yield return new WaitForSeconds(0.5f);

            RandomValue();
        }
    }
}
