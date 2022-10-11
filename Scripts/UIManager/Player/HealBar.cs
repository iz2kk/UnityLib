using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealBar : MonoBehaviour
{
    float heal;
    float lerpTimer;
    //
    [SerializeField] float maxHeal = 1000f;
    [SerializeField] float chipSpeed = 2f;
    [SerializeField] Image fontHealBar;
    [SerializeField] Image backHealBar;
    [SerializeField] Image frontHeart;
    [SerializeField] Text txtHeal;

    //
    void Start()
    {
        heal = maxHeal;
    }

    // Update is called once per frame
    void Update()
    {
        heal = Mathf.Clamp(heal, 0, maxHeal);
        UpdateHealUI();
        if (Input.GetKey(KeyCode.DownArrow))
        {
            TakeDamage(Random.Range(5, 10));
        }
        else if(Input.GetKey(KeyCode.UpArrow))
        {
            RestoreHealth(Random.Range(5, 10));
        }
    }

    // update heal bar
     void UpdateHealUI()
    {
        float fillFront = fontHealBar.fillAmount;
        float fillBack = backHealBar.fillAmount;
        float healFraction = heal / maxHeal;
        // if take damage
        if(fillBack > healFraction)
        {
            fontHealBar.fillAmount = healFraction;
            backHealBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backHealBar.fillAmount = Mathf.Lerp(fillBack, healFraction, percentComplete);
        }
        // restore health
        if (fillFront < healFraction)
        {
            backHealBar.color = Color.green;
            backHealBar.fillAmount = healFraction;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            fontHealBar.fillAmount = Mathf.Lerp(fillFront, backHealBar.fillAmount, percentComplete);
        }
        //update heart
        frontHeart.fillAmount = healFraction;
        txtHeal.text = healFraction .ToString("P");
    }
  
    public void TakeDamage(float damage)
    {
        //Debug.Log("TAKEN dmg");
        heal -= damage;
        lerpTimer = 0f;
    }
    public void RestoreHealth(float healAmount)
    {
        //Debug.Log("Restore Health");
        heal += healAmount;
        lerpTimer = 0f;
    }

   
}
