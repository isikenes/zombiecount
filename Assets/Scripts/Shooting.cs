using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] Transform firePoint2;
    [SerializeField] Transform firePoint3;
    [SerializeField] GameObject bulletPrefab;
    float bulletForce = 20f;
    [SerializeField] GameObject pauseScreen;
    public bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.DeleteKey("killCount");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isPaused)
        {
            Time.timeScale = 0f;
            isPaused = true;
            pauseScreen.SetActive(true);
            Cursor.visible = true;

        } else if(Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            
            Time.timeScale = 1f;
            isPaused = false;
            pauseScreen.SetActive(false);
            Cursor.visible = false;

        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && !isPaused)
        {
            Shoot();
            if(PlayerPrefs.GetInt("level", 1) == 1)
            {
                FindObjectOfType<AudioManager>().Play("Handgun");
            }
            else if(PlayerPrefs.GetInt("level",1)==2)
            {
                FindObjectOfType<AudioManager>().Play("Rifle");
                bulletForce = 30f;
                Invoke("Shoot", 0.1f);
                
            } else if(PlayerPrefs.GetInt("level",1)==3)
            {
                FindObjectOfType<AudioManager>().Play("Shotgun");
                ShootShotGun();
            }
        }
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
        
    }

    private void ShootShotGun()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint2.position, firePoint2.rotation);
        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        bulletRB.AddForce(firePoint2.up * bulletForce, ForceMode2D.Impulse);

        GameObject bullet2 = Instantiate(bulletPrefab, firePoint3.position, firePoint3.rotation);
        Rigidbody2D bulletRB2 = bullet2.GetComponent<Rigidbody2D>();
        bulletRB2.AddForce(firePoint3.up * bulletForce, ForceMode2D.Impulse);

    }

   
}
