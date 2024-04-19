using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class count : MonoBehaviour
{
    public static int Collected = 100;
    public TextMeshProUGUI countText;

    public bool invincibleEnabled = false;
    public float invincCooldown = 15.0f;

    // Use this for initialization
    void Start()
    {
        Collected = 100;
        countText.text = "Health Score: " + Collected.ToString();
    }
    // Update is called once per frame
    void Update()
    {  
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("APPLE"))
        {
            if (invincibleEnabled == false)
            {
                Collected += 5;
                countText.text = "Health Score: " + Collected.ToString();
                //Debug.Log("Collected");
            }
            else
            {
                Collected += 10;
                countText.text = "Health Score: " + Collected.ToString() + " Invincible";
            }

            if (Collected >= 250)
            {
                WinGame();
            }
        }
        else if (other.gameObject.CompareTag("ORANGE"))
        {
            if (invincibleEnabled == false)
            {
                Collected += 10;
                countText.text = "Health Score: " + Collected.ToString();
                //Debug.Log("Collected");

            }
            else
            {
                Collected += 20;
                countText.text = "Health Score: " + Collected.ToString() + " Invincible";
            }

            if (Collected >= 250)
            {
                WinGame();
            }
        }
        else if (other.gameObject.CompareTag("PEAR"))
        {
            if (invincibleEnabled == false)
            {
                Collected += 15;
                countText.text = "Health Score: " + Collected.ToString();
                //Debug.Log("Collected");

            }

            else
            {
                Collected += 30;
                countText.text = "Health Score: " + Collected.ToString() + " Invincible";
            }
            if (Collected >= 250)
            {
                WinGame();
            }
        }
        else if (other.gameObject.CompareTag("STRAWBERRY"))
        {
            if (invincibleEnabled == false)
            {
                Collected += 20;
                countText.text = "Health Score: " + Collected.ToString();
                //Debug.Log("Collected");

            }
            else
            {
                Collected += 40;
                countText.text = "Health Score: " + Collected.ToString() + " Invincible";
            }
            if (Collected >= 250)
            {
                WinGame();
            }
        }
        else if (other.gameObject.CompareTag("SHAKE"))
        {
            if (invincibleEnabled == false)
            {
                Collected -= 5;
                countText.text = "Health Score: " + Collected.ToString();
            }
            
        }
        else if (other.gameObject.CompareTag("PIE"))
        {
            if (invincibleEnabled == false)
            {
                Collected -= 10;
                countText.text = "Health Score: " + Collected.ToString();
            }
            
        }
        else if (other.gameObject.CompareTag("CAKE"))
        {
            if (invincibleEnabled == false)
            {
                Collected -= 15;
                countText.text = "Health Score: " + Collected.ToString();
            }
           
        }
        else if (other.gameObject.CompareTag("SUPER"))
        {
            if (invincibleEnabled == false)
            {
                countText.text = "Health Score: " + Collected.ToString() + " Invincible";
                InvincEnabled(); 
                
            }

        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            if (invincibleEnabled == false)
            {
                Collected -= 10;
                countText.text = "Health Score: " + Collected.ToString();
            }
            else
            {
                countText.text = "Health Score: " + Collected.ToString() + " Invincible";

            }

        }
        else if (other.gameObject.CompareTag("healing"))
        {
            if (Collected < 100)
            {
                if (invincibleEnabled == true)
                {
                    Collected += 5;
                    countText.text = "Health Score: " + Collected.ToString() + " Invincible";
                }
                else
                {
                    Collected += 5;
                    countText.text = "Health Score: " + Collected.ToString();
                }
            }
            else if (Collected >= 100)
            {
                if (invincibleEnabled == true)
                {
                    Collected += 0;
                    countText.text = "Health Score: " + Collected.ToString() + " Invincible";
                }
                else
                {
                    Collected += 0;
                    countText.text = "Health Score: " + Collected.ToString();
                }

            }
            



        }

    }
    


    public void InvincEnabled()
    {
        //Debug.Log("invincible");

        invincibleEnabled = true;
        StartCoroutine(InvincDisableRoutine());
    }
    IEnumerator InvincDisableRoutine()
    {
        yield return new WaitForSeconds(invincCooldown);
        invincibleEnabled = false;

    }


    void WinGame()
    {
        SceneManager.LoadScene("Win");
    }
}
