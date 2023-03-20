using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Patroling : MonoBehaviour
{
    public Transform[] Positions;

    SpriteRenderer EnemySpriteRenderer;

    private int currentPosition = 0;

    private float speed = 3;

    
    void Start()
    {
        EnemySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        Patroling();
    }

    void Patroling()
    {
        Transform targetPosition = Positions[currentPosition];

        if (transform.position == targetPosition.position)
        {
            currentPosition++;

            if (currentPosition == Positions.Length)
            {
                currentPosition = 0;
            }

            if (transform.position.x > Positions[currentPosition].position.x)
            {
                EnemySpriteRenderer.flipX = true;
            }
            else
            {
                EnemySpriteRenderer.flipX = false;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, targetPosition.position, Time.deltaTime * speed);
    }
}
