using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject enemyBullet;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootBullet());
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    void EnemyFireBullet()
    {
        GameObject player = GameObject.Find("Player");

        if (player != null)
        {
            GameObject bullet = (GameObject)Instantiate(enemyBullet);

            bullet.transform.position = transform.position;

            Vector2 direction = player.transform.position - bullet.transform.position;

            bullet.GetComponent<EnemyBullet>().SetDirection(direction);
        }
    }

    private IEnumerator ShootBullet ()
    {
        while (true)
        {
            EnemyFireBullet();
            yield return new WaitForSeconds(2f);
        }
    }
}
