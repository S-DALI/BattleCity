using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroy : DestroyHandler
{
    [SerializeField] FinishGamePanelController finishGamePanel;
    public override void HandleDestroy()
    {
        ObjectDestroy?.Invoke();
        finishGamePanel.LoseGame();
        Destroy(gameObject);
    }
}
