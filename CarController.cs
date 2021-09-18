using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CarController : MonoBehaviour
{
    public Rigidbody rg;
    public float maxSpeed;
    public float fowardAccel, reverseAccel;
    public float turnStrength ;

    private float speedInput;
    private float turnInput;
   
    private int damageCount ;
    public Slider stamina;
    public FixedJoystick stick;
    int gauge;
    // Start is called before the first frame update
    void Start()
    {
        damageCount = 0;
        gauge = 6;
        rg = GetComponent<Rigidbody>();
        Debug.Log("car is worked");
    }

     void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.tag == "Load")
        {
            damageCount += 1;
            gauge--;
        }
        if(damageCount > 5)
        {
            Debug.Log("damageCount");
            Destroy(gameObject,1);
        }
    }

    void OnDestroy()
    {
        Debug.Log("OnDestroy");
       SceneManager.LoadScene("GameOver");
    }



    // Update is called once per frame
    void Update()
    {
        stamina.value = gauge;
        if (transform.rotation.z > 10 || transform.rotation.z < -10 || transform.rotation.x > 10 || transform.rotation.x < -10 || transform.position.y < 27)
        {
            Debug.Log("transform");
            Destroy(gameObject);

        }


            speedInput = 0f;
            if (stick.Vertical > 0)
            {
                speedInput = stick.Vertical * fowardAccel;
            }
            else if (stick.Vertical < 0)
            {
                speedInput = stick.Vertical * reverseAccel;
            }

            turnInput = stick.Horizontal;

        
    }

        private void FixedUpdate()
        {

            rg.AddForce(-Vector3.up * 300f);
            rg.AddForce(transform.forward * speedInput * 300f);
            if (rg.velocity.magnitude > maxSpeed)
            {
                rg.velocity = rg.velocity.normalized * maxSpeed;
            }
            if (speedInput != 0)
            {
                transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, turnInput * turnStrength * Time.deltaTime * (rg.velocity.magnitude / maxSpeed) * Mathf.Sign(speedInput), 0));
            }

        }
    
}
