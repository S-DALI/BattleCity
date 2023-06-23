using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStrength : Fragility
{
    [SerializeField] Transform pointRespawn;
    [SerializeField] private TMP_Text strenghtText;
    public override void takeDamage(int damage)
    {
        currentStrength -= damage;
        strenghtText.text = currentStrength.ToString();
        gameObject.transform.position = pointRespawn.position;
        if(currentStrength<=0)
        {
            objectDestroy();
        }
    }

}
