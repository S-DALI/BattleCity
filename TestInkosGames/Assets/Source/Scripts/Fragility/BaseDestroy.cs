using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseDestroy : DestroyHandler
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject hitEffect;
    [SerializeField] FinishGamePanelController finishGamePanel;
    [SerializeField] private float timeLifeEffect = 2f;
    public override void HandleDestroy()
    {
        finishGamePanel.LoseGame();
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(player, timeLifeEffect);
        Destroy(effect, timeLifeEffect);
        Destroy(gameObject);
    }
}
