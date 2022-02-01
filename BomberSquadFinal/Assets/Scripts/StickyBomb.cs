using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyBomb : MonoBehaviour
{
    private Rigidbody bombRb;

    // Start is called before the first frame update
    void Start()
    {
        bombRb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            bombRb.isKinematic = true;
        if(collision.gameObject.CompareTag("Player")|| collision.gameObject.CompareTag("Enemy"))
        {
            bombRb.isKinematic = true;
            transform.parent=(collision.gameObject.transform);
        }

    }

}
