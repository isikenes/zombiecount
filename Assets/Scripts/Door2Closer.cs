using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door2Closer : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] BoxCollider2D thisCollider;
    [SerializeField] Slider slider;
    [SerializeField] Image image;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("isOpenable", false);
            boxCollider.enabled = true;
            thisCollider.enabled = false;

            PlayerPrefs.SetInt("level", 3);
            FindObjectOfType<Spawner2>().StopAllCoroutines();
            FindObjectOfType<Spawner3>().StartCoroutine("spawnEnemy");
            FindObjectOfType<Health>().hp = 5;
            slider.value = 5;
            image.color = Color.green;
        }
    }
}
