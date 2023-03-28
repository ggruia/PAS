using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    public GameObject retryButton;

    void Start()
    {
        gameObject.GetComponent<Canvas>().enabled = false;
    }

    public void Enable()
    {
        Time.timeScale = 0f;

        gameObject.GetComponent<Canvas>().enabled = true;
        retryButton.SetActive(true);
    }
}
