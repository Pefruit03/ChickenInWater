using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWave
{
    IWave NextWave();

    List<GameObject> GetEnemies();

    List<Vector2> GetPositions();
}