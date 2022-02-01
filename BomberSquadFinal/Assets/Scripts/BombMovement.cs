using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombMovement : MonoBehaviour
{
    private Rigidbody BombRb;
    private float movementForce = 8;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        BombRb = GetComponent<Rigidbody>();
        BombMovementForward();
    }

    void BombMovementForward()
    {

        /*       BombRb.AddForce(Vector3.forward * movementForce, ForceMode.Impulse);
               BombRb.AddForce(Vector3.up * movementForce, ForceMode.Impulse);*/

        StartCoroutine(BlastTiming());

        BombRb.AddRelativeForce(0, 400, 300);
        Destroy(gameObject, 3);

    }

    IEnumerator BlastTiming()
    {
        yield return new WaitForSeconds(2.5f);
        BombBlast();

    }

    void BombBlast()
    {
      //  Debug.Log("hussain You are great");
        Collider[] colliders = Physics.OverlapSphere(transform.position, 5f);
        foreach(Collider items in colliders)
        {
            if (items.gameObject.CompareTag("Enemy"))
                Destroy(items.gameObject);
            if(player!=null&& items.gameObject.CompareTag("Player"))
            {

                player.GetComponent<BombSpawner>().lives--;
                Debug.Log(player.GetComponent<BombSpawner>().lives);
            }

            
        }

    }

}
