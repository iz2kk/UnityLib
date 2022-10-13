using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealBar : MonoBehaviour
{
    [Header("Health bar")]
    float heal;
    float lerpTimer;
    //
        
    //
    [SerializeField] float maxHeal = 1000f;
    [SerializeField] float chipSpeed = 2f;
    [SerializeField] Image fontHealBar;
    [SerializeField] Image backHealBar;
    [SerializeField] Image frontHeart;
    [SerializeField] Text txtHeal;
    [SerializeField] Text txtHealAmount;
    [SerializeField] bool isTesting;

    //
    [Header("Damage Overlay")]
    public Image overlay; // game overlay game object
    public float Duration;
    public float fadeSpeed;// time image fade;
    //
    float durationTimer; //Timer to check against the duration
    void Start()
    {
        heal = maxHeal;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0);

    }

    // Update is called once per frame
    void Update()
    {
        heal = Mathf.Clamp(heal, 0, maxHeal);
        UpdateHealUI();
        Test();
        DamageOverlay();
    }
    //
    void Test()
    {
        if (isTesting)
        {
            if (Input.GetKey(KeyCode.DownArrow))
            {
                TakeDamage(Random.Range(5, 10));
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                RestoreHealth(Random.Range(5, 10));
            }
        }
       
    }
    //
   void DamageOverlay()
    {
        if(overlay.color.a > 0)
        {
            durationTimer += Time.deltaTime;
            if(durationTimer > Duration)
            {
                //fade image
                float tempAlpha = overlay.color.a;
                tempAlpha -= Time.deltaTime * fadeSpeed;
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, tempAlpha);
            }
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
        txtHealAmount.text = heal.ToString("#,##0") + "/" + maxHeal.ToString("#,###0");
    }
  
    public void TakeDamage(float damage)
    {
        //Debug.Log("TAKEN dmg");
        heal -= damage;
        lerpTimer = 0f;
        durationTimer = 0;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0.8509804f);

    }
    public void RestoreHealth(float healAmount)
    {
        //Debug.Log("Restore Health");
        heal += healAmount;
        lerpTimer = 0f;
    }

   public bool isTestMode()
    {
        return isTesting;
    }
   


}
