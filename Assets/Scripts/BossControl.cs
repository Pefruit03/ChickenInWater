using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;


public enum BossState
{
    ENTER = 0,
    ATTACK = 1,
}

public class BossControl : MonoBehaviour
{
    float speed = 1.5f;
    BossState currentState = BossState.ENTER;
    public Vector2 bossPosition;
    public Vector3 playerPosition;
    public bool move = true;

    // Start is called before the first frame update
    void Start()
    {
        bossPosition = new Vector2(0, 0);
        InvokeRepeating("GetPlayerPosition", 10f, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == BossState.ENTER)
        {
            if (transform.position.y > bossPosition.y)
            {
                Vector2 position = transform.position;

                position = new Vector2(position.x, position.y - speed * Time.deltaTime);

                transform.position = position;

                Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
            }
            else
            {
                currentState = BossState.ATTACK;
            }
        }
        else if (currentState == BossState.ATTACK)
        {
            if (move)
            {
                StartCoroutine(BossAttack());
            }
        }
    }

    public IEnumerator BossAttack()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, Time.deltaTime * speed);
        yield return new WaitForEndOfFrame();
    }

    public void GetPlayerPosition()
    {
        GameObject player = GameObject.Find("Player");
        playerPosition = player.transform.position;
        move = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        move = false;
    }
}
