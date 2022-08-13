using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner3 : MonoBehaviour
{
    [SerializeField] GameObject zombie;
    // Start is called before the first frame update
    void Start()
    {

    }

    IEnumerator spawnEnemy()
    {

        yield return new WaitForSeconds(2f);
        GameObject newZombie = Instantiate(zombie, new Vector3(Random.Range(-24, 13), Random.Range(65, 88), 0), Quaternion.identity);
        int x = Random.Range(1, 4);
        if (x==1)
        {
            FindObjectOfType<AudioManager>().Play("Zombie1");
        } else if(x==2)
        {
            FindObjectOfType<AudioManager>().Play("Zombie2");
        }
        else if (x == 3)
        {
            FindObjectOfType<AudioManager>().Play("Zombie3");
        }
        StartCoroutine(spawnEnemy());


    }

}
