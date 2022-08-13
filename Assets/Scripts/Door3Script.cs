using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door3Script : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] Animator animator2;
    

    bool isOpened = false;
    // Start is called before the first frame update
    void Start()
    {


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (PlayerPrefs.GetInt("killCount", 0) >= 50 && isOpened == false)
            {
                animator.SetBool("isOpenable", true);
                boxCollider.enabled = false;

                
                isOpened = true;

            }
            else if (PlayerPrefs.GetInt("killCount", 0) < 50)
            {
                animator2.Play("Need1Animation");
            }
        }
    }


}
