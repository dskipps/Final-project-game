using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class player : MonoBehaviour
{
    //power stuff
    public bool invincibleEnabled = false;
    public float invincCooldown = 15.0f;

    public GameObject HealthBar;
    private static Image HealthBarImage;
    public static float health = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (HealthBar != null)
        {
            HealthBarImage = HealthBar.transform.GetComponent<Image>();
        }
        SetHealthBarValue(health);
        health = 100;
    }

    public static void SetHealthBarValue(float value)
    {
        HealthBarImage.fillAmount = value;
        if (HealthBarImage.fillAmount < 0.2f)
        {
            SetHealthBarColor(Color.red);
        }
        else if (HealthBarImage.fillAmount < 0.5f)
        {
            SetHealthBarColor(Color.yellow);
        }
        else
        {
            SetHealthBarColor(Color.green);
        }
    }

    public static void SetHealthBarColor(Color healthColor)
    {
        HealthBarImage.color = healthColor;
    }

    public static float GetHealthBarValue()
    {
        return HealthBarImage.fillAmount;
    }


    // Update is called once per frame
    void Update()
    {
        SetHealthBarValue(health / 100);
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Collision with " + other.gameObject.name);
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("Collision with Enemy");

            if (invincibleEnabled == false)
            {
                health -= 10.0f;
                if (health < 0) health = 0;
            }
            if (health <= 0)
            {
                //Debug.Log("end game?");

                EndGame();
            }
        }
        if (other.gameObject.CompareTag("APPLE"))
        {
            if (invincibleEnabled == false)
            {
                health += 5.0f;
            }
            else
            {
                health += 10.0f;
            }
        }
        else if (other.gameObject.CompareTag("ORANGE"))
        {

            if (invincibleEnabled == false)
            {
                health += 10.0f;
            }
            else
            {
                health += 20.0f;
            }
        }
        else if (other.gameObject.CompareTag("PEAR"))
        {
            if (invincibleEnabled == false)
            {
                health += 15.0f;
            }
            else
            {
                health += 30.0f;
            }
        }
        else if (other.gameObject.CompareTag("STRAWBERRY"))
        {
            if (invincibleEnabled == false)
            {
                health += 20.0f;
            }
            else
            {
                health += 40.0f;
            }
        }
        else if (other.gameObject.CompareTag("SHAKE"))
        {
            if (invincibleEnabled == false)
            {
                health -= 5.0f;
                if (health < 0) health = 0;
            }
            if (health <= 0)
            {
                EndGame();
            }
        }
        else if (other.gameObject.CompareTag("PIE"))
        {
            if (invincibleEnabled == false)
            {
                health -= 10.0f;
                if (health < 0) health = 0;
            }
            if (health <= 0)
            {
                EndGame();
            }
        }
        else if (other.gameObject.CompareTag("CAKE"))
        {
            if (invincibleEnabled == false)
            {
                health -= 15.0f;
                if (health < 0) health = 0;
            }
            if (health <= 0)
            {
                EndGame();
            }
        }
        else if (other.gameObject.CompareTag("SUPER"))
        {
            InvincEnabled();

        }
        else if (other.gameObject.CompareTag("healing"))
        {
            if(health < 100) 
            {
                health += 5;
            }
            else if (health >= 100)
            {
                health += 0;
            }
            


        }

    }
            //
    public void InvincEnabled()
    {
        invincibleEnabled = true;
        StartCoroutine(InvincDisableRoutine());
    }
    IEnumerator InvincDisableRoutine()
    {
        yield return new WaitForSeconds(invincCooldown);
        invincibleEnabled = false;
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (invincibleEnabled == false)
            {
                //Debug.Log("Collision (Stay) with Enemy");
                health -= 0.01f;
                if (health < 0) health = 0;
            }
            if (health <= 0)
            {
                //Debug.Log("end game?");

                EndGame();
            };
        }
    }
    void EndGame()
    {
        SceneManager.LoadScene("end");
    }
}
        


