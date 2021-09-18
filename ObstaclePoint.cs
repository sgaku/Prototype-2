using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePoint : MonoBehaviour
{

    public GameObject[] obstacles;
    public Transform car;

    private float pX;
  public float interval;
    private int number;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartObstacle());
    }

    IEnumerator StartObstacle()
    {
        while (true)
        {
            number = Random.Range(0, obstacles.Length);
            pX = Random.Range(-30, 30);

            Instantiate(obstacles[number], new Vector3(pX, 52, car.position.z + 150), Quaternion.Euler(0, 90, 0));
            yield return new WaitForSeconds(interval);
        }

    }




}
