using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Image image;
    [SerializeField] GameObject loseScreen;
    public int hp = 5;
    // Start is called before the first frame update
    void Start()
    {
        image.color = Color.green;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Zombie")
        {
            hp--;
            slider.value = hp;
            if(hp==3)
            {
                image.color = Color.yellow;
            } else if(hp==1)
            {
                image.color = Color.red;
            } else if(hp==0)
            {
                FindObjectOfType<AudioManager>().Play("Death");
                loseScreen.SetActive(true);
                Cursor.visible = true;
                Time.timeScale=0f;
            }
        }
    }
}
