using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ZombieScript : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] TextMeshProUGUI countText;
   
    Rigidbody2D rb;
    Vector2 movement;
    float speed = 2f;
    int hp = 5;
    int killCount;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if(PlayerPrefs.GetInt("level",1)==2)
        {
            speed = 3f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        rb.MovePosition((Vector2)transform.position + movement * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Bullet") {
            hp--;
        }
        if(hp<=0)
        {
            
            killCount = PlayerPrefs.GetInt("killCount", 0);
            killCount++;
            countText.text = "KILL COUNT:  " + killCount;
            PlayerPrefs.SetInt("killCount", killCount);
            countText.GetComponent<Animator>().Play("KillCountAnim");
            Destroy(gameObject);
        }
    }
}
