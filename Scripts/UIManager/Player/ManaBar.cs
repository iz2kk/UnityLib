using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBar : MonoBehaviour
{
    float Mana;
    float LerpTimer;
    public float maxMana = 500f;
    //
    HealBar healBar;
    //
    [SerializeField] float chipSpeed = 5f;
    [SerializeField] Image frontManaBar;
    [SerializeField] Image backManaBar;
    [SerializeField] Text txtManaAmount;
    // Start is called before the first frame update
    void Start()
    {
        Mana = maxMana;
        healBar =  GetComponent<HealBar>();
    }

    // Update is called once per frame
    void Update()
    {
        Mana = Mathf.Clamp(Mana, 0, maxMana);
        UpdateUI();
        ManaTest();
    }

    void ManaTest()
    {
        if (healBar == null) return;
        if (healBar.isTestMode())
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                TakeDownMana(Random.Range(5, 10));
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                RestoreMana(Random.Range(5, 10));

            }
        }
    }

    public void UpdateUI()
    {
        float ExpFront = frontManaBar.fillAmount;
        float ExpBack = backManaBar.fillAmount;
        float ExpFraction = Mana / maxMana;
        //Exp down
        if(ExpBack > ExpFraction)
        {
            frontManaBar.fillAmount = ExpFraction;
            backManaBar.color = new Color(0.6f, 1, 0.6921421f, 1);
            LerpTimer += Time.deltaTime;
            backManaBar.fillAmount = Mathf.Lerp(ExpBack, ExpFraction, LerpTimer);
        }
        //Exp Up
        if(ExpFront < ExpFraction)
        {
            Color color = new Color(0, 0.6490321f, 1, 1);
            backManaBar.fillAmount = ExpFraction;
            backManaBar.color = color;
            LerpTimer += Time.deltaTime;
            frontManaBar.fillAmount = Mathf.Lerp(ExpFront, backManaBar.fillAmount, LerpTimer);
        }
        //update text
        txtManaAmount.text = Mana.ToString("#,###0") + "/" + maxMana.ToString("#,###0");
    }

    public void TakeDownMana(float mana)
    {
        Mana -= mana;
        LerpTimer = 0;

    }

    public void RestoreMana(float mana)
    {
        Mana += mana;
        LerpTimer = 0;
    }

    
}
