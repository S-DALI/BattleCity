using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BaseStrenght : Fragility
{
    [SerializeField] private TMP_Text strenghtText;
    public override void takeDamage(int damage)
    {
        currentStrength -= damage;
        strenghtText.text = currentStrength.ToString();
        if (currentStrength <= 0)
        {
            objectDestroy();
        }
    }
}
