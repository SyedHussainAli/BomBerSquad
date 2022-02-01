using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float playerSpeed=10f;
    private float verticalInput;
    private float horizontalInput;
    private float playerRotation=60;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput=Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * verticalInput * playerSpeed*Time.deltaTime);
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up * horizontalInput*playerRotation*Time.deltaTime);
    }
}
