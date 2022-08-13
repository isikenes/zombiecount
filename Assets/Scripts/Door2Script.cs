using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door2Script : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] Animator animator2;
    [SerializeField] Animator animator3;
    [SerializeField] Animator charAnimator;
    bool isOpened = false;
    // Start is called before the first frame update
    void Start()
    {


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (PlayerPrefs.GetInt("killCount", 0) >= 25 && isOpened == false)
            {
                animator.SetBool("isOpenable", true);
                boxCollider.enabled = false;
                animator3.Play("Need1Animation");
                charAnimator.SetBool("isLevel3", true);
                isOpened = true;

            }
            else if (PlayerPrefs.GetInt("killCount", 0) < 25)
            {
                animator2.Play("Need1Animation");
            }
        }
    }


}
