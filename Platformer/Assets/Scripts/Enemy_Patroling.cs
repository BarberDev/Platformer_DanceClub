using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Patroling : MonoBehaviour
{
    [SerializeField] private Transform[] _positions;

    private SpriteRenderer EnemySpriteRenderer;
    private int currentPosition = 0;
    private float speed = 3;

    private void Start()
    {
        EnemySpriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        Patroling();
    }

    private void Patroling()
    {
        Transform targetPosition = _positions[currentPosition];
        

        if (transform.position == targetPosition.position)
        {
             
            currentPosition++;

            if (currentPosition == _positions.Length)
            {
                currentPosition = 0;
            }
            
            EnemySpriteRenderer.flipX = transform.position.x > _positions[currentPosition].position.x;
        }
         
        transform.position = Vector2.MoveTowards(transform.position, targetPosition.position, Time.deltaTime * speed);
         
    }
}
