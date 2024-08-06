using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject playerBullet;
    public GameObject shootingPoint;

    public float speed;
    public Rigidbody2D rb;
    private Vector2 moveDirection;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            GameObject shootingBullet = (GameObject)Instantiate(playerBullet);
            shootingBullet.transform.position = shootingPoint.transform.position;
        }
        InputsProcess();
    }

    void FixedUpdate()
    {
        Move();
    }

    void InputsProcess()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(x, y);
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }
}
