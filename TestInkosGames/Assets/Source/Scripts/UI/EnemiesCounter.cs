using EnemyWave;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemiesCounter:MonoBehaviour
{
    [SerializeField] TMP_Text text;

    private void Awake()
    {
        WaveSystem.Instance.ChangedEnemiesCount += UpdateCounter;
    }

    private void UpdateCounter(int count)
    {
        text.text = count.ToString();
    }
}

