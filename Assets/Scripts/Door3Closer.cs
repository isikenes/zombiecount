using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door3Closer : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] BoxCollider2D boxCollider;
    [SerializeField] BoxCollider2D thisCollider;
    [SerializeField] GameObject character;
    [SerializeField] Animator ship;
    [SerializeField] Cinemachine.CinemachineVirtualCamera cinemachine;
    [SerializeField] Animator credits;
    [SerializeField] GameObject mainButton;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("isOpenable", false);
            boxCollider.enabled = true;
            thisCollider.enabled = false;

            FindObjectOfType<Spawner3>().StopAllCoroutines();

            character.SetActive(false);
            ship.Play("ShipAnim");
            FindObjectOfType<AudioManager>().Play("Ship");
            cinemachine.m_Lens.OrthographicSize = 10;
            Invoke("MoveCam", 3);
            Invoke("EnableButton", 15);

        }
    }

    private void MoveCam()
    {
        character.transform.position = new Vector3(7.1f, 130f, 0f);
        credits.Play("CreditsAnim");
    }

    private void EnableButton()
    {
        mainButton.SetActive(true);
        Cursor.visible = true;
    }
}
