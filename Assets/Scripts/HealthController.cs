
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
     int health;

    public Image[] hearts;

    private void Start()
    {
        health = 3;
    }
    public void reduceHeart() {

        health -= 1;

        hearts[health].gameObject.SetActive(false);

        if (health == 0)
        {

            SceneManager.LoadScene("YouDied");
        }
        else {
            hearts[health].gameObject.SetActive(false);

        }

        
    
    }
}
