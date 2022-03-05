using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed; //Скорость движения врага

    
    private void Update()
    {
        transform.Translate(Vector2.left * _speed * Time.deltaTime);
    }
}
