﻿using UnityEditor;
using UnityEngine;

namespace EnemyWave
{
    [System.Serializable]
    public class EnemySettings
    {
        [SerializeField] private GameObject enemy;
        public GameObject Enemy { get => enemy; }
    }
}