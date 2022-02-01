using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    public GameObject BombPF;
    public GameObject StickyBombPF;

    private Vector3 position;
    bool spawntime=true;
    private int hasPowerup = 0;
    private int spawnPositionTop = 2;

    public int lives = 3;
    bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(hasPowerup==0)
            NormalBombs();
        if (hasPowerup == 1)
            MultipleBomb();
        if (hasPowerup == 2)
            StickyBomb();

        if(!gameOver&&lives<=0)
        {
            gameOver = true;
            Debug.Log("Game Over");
        }

    }

    private void StickyBomb()
    {
        if (Input.GetKeyDown(KeyCode.Space) && spawntime)
        {
            StartCoroutine(SpawnAllowed());
            position = new Vector3(transform.position.x, transform.position.y + spawnPositionTop, transform.position.z);
            Instantiate(StickyBombPF, position, transform.rotation);
            spawntime = false;

        }
    }

    private void MultipleBomb()
    {
        if (Input.GetKeyDown(KeyCode.Space) && spawntime)
        {
            StartCoroutine(SpawnAllowed());
            position = new Vector3(transform.position.x, transform.position.y + spawnPositionTop, transform.position.z);
           for(int i=0;i<3;i++)
                Instantiate(BombPF, position, transform.rotation);
            spawntime = false;

        }
    }

    void NormalBombs()
    {
        if (Input.GetKeyDown(KeyCode.Space) && spawntime)
        {
            StartCoroutine(SpawnAllowed());
            position = new Vector3(transform.position.x, transform.position.y + spawnPositionTop, transform.position.z);
            Instantiate(BombPF, position, transform.rotation);
            spawntime = false;

        }

    }

    IEnumerator SpawnAllowed()
    {
        yield return new WaitForSeconds(3);
        spawntime = true;
    
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            Debug.Log("PowerUp selected");
            hasPowerup = 1;
            Destroy(other.gameObject);   
            StartCoroutine(PowerupCountDownRoutine());

        }
        if (other.CompareTag("StickyPowerup"))
        {
            Debug.Log("Sticky PowerUp selected");
            hasPowerup = 2;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountDownRoutine());

        }
    }

    IEnumerator PowerupCountDownRoutine()
    {
        yield return new WaitForSeconds(8);
        hasPowerup = 0;
       

    }
}
