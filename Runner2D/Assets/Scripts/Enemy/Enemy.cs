using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage; // Урон который враг наносит игроку

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.TryGetComponent(out Player player)) //Проверка на столкновение с игроком
        {
            player.ApplyDamage(_damage); //Урон игроку
        }
        Die();
    }

    //Смерть врага
    private void Die()
    {
        gameObject.SetActive(false);
    }
}
