using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController2 : MonoBehaviour
{
    public Transform car;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

  
    private void FixedUpdate()
    {
        //Debug.Log("ok");

        transform.position += new Vector3(Time.deltaTime * 0, 0, -1);
        if(transform.position.z < car.position.z)
        {
            Destroy(gameObject);
        }


    }
}
