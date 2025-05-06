using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    public float gravity = -1.0f;
    public float flyingSpeed = 100.0f;

    private Rigidbody rbFlying;
    

    // Start is called before the first frame update
    void Start()
    {
        rbFlying = gameObject.GetComponent<Rigidbody>();
        rbFlying.AddForce(Vector3.forward * flyingSpeed);

        Physics.gravity = new Vector3(0.0f, gravity, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
