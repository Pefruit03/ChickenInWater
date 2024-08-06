using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    IWave currentWave;

    // Start is called before the first frame update
    void Start()
    {
        currentWave = GetComponent<Wave1>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextWave()
    {
        if (currentWave != null)
        {
            IWave nextWave = currentWave.NextWave();
            if (nextWave != null)
            {
                currentWave = nextWave;
            }
            else
                currentWave = null;
        }
    }

    public List<GameObject> GetEnemies()
    {
        if (currentWave != null)
        {
            return currentWave.GetEnemies();
        }
        return new List<GameObject>();
    }

    public List<Vector2> GetPositions()
    {
        return currentWave.GetPositions();
    }
}
