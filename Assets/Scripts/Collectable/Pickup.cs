using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public bool isGem, isHeal, isFruit;

    private bool isCollected;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            if (isGem)
            {
                LevelManager.instance.CountGems++;

                UIController.instance.UpdateGemCount();

                isCollected = true;
                GetComponent<SpriteRenderer>().enabled = false;
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                Destroy(gameObject, 0.5f);
            }

            if (isHeal)
            {
                if(PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth)
                {
                    PlayerHealthController.instance.HealPlayer();

                    isCollected = true;
                    GetComponent<SpriteRenderer>().enabled = false;
                    gameObject.transform.GetChild(0).gameObject.SetActive(true);
                    Destroy(gameObject, 0.5f);
                }
            }

            if (isFruit)
            {
                LevelManager.instance.CountFruits++;

                UIController.instance.UpdateFruitCount();

                isCollected = true;
                GetComponent<SpriteRenderer>().enabled = false;
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                Destroy(gameObject, 0.5f);
            }
        }
    }

}
