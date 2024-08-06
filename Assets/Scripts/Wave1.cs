using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave1 : MonoBehaviour, IWave
{
    [SerializeField]
    List<GameObject> enemies = new List<GameObject>();
    [SerializeField]
    List<Vector2> positions = new List<Vector2>(); 
    IWave nextWave;

    private void Awake()
    {
        nextWave = GetComponent<Wave2>();
    }
    public List<GameObject> GetEnemies()
    {
        return enemies;
    }

    public IWave NextWave()
    {
        return nextWave;
    }

    public List<Vector2> GetPositions()
    {
        return positions;
    }
}
