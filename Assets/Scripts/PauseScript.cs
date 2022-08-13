using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{

    public void Resume()
    {
        Time.timeScale = 1f;
        FindObjectOfType<Shooting>().isPaused = false;
        this.gameObject.SetActive(false);
        Cursor.visible = false;
    }
}
