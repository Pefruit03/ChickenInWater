using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class JellyControl : MonoBehaviour
{
    protected float speed = 2f;
    protected bool flying = true;
    protected bool timeout = false;
    protected float spawnY;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < spawnY && !timeout)
        {
            flying = false;
        }

        if (flying)
        {
            Vector2 position = transform.position;

            position = new Vector2(position.x, position.y - speed * Time.deltaTime);

            transform.position = position;

            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

            if (transform.position.y < min.y)
            {
                Destroy(gameObject);
            }
        }

    }

    public void StartTimeOut ()
    {
        StartCoroutine(WaveTimeout());
    }

    IEnumerator WaveTimeout()
    {
        yield return new WaitForSeconds (5f);
        this.flying = true;
        this.timeout = true;
    }

    public float SpawnY
    {
        get { return spawnY; }
        set { spawnY = value; }
    }
}
