using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player; //обьект игрок
    [SerializeField] private Heart _heartPrefab; // обьект Сердце

    private List<Heart> _hearts=new List<Heart>(); //Список сердец

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged; //Подписка на событие изменения здоровья игрока
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged; //Отписка
    }


    private void OnHealthChanged(int value)
    {
        if (_hearts.Count < value)
        {
            int createHealth = value - _hearts.Count; //Сколько сердец создать
            for (int i = 0; i < createHealth; i++)
            {
                CreateHeart();
            }
        }
        else if (_hearts.Count > value && _hearts.Count !=0)
        {
            int deleteHeath = _hearts.Count - value; // //Сколько сердец удалить
            for (int i = 0; i < deleteHeath; i++)
            {
                DestroyHeart(_hearts[_hearts.Count-1]);
            }
        }
    }

    //Процедура создания сердец
    private void CreateHeart()
    {
        Heart newHeart=Instantiate(_heartPrefab,transform);
        _hearts.Add(newHeart.GetComponent<Heart>());
        newHeart.ToFill();

    }

    //Уничтожение сердца
    private void DestroyHeart(Heart heart)
    {
        _hearts.Remove(heart);
        heart.ToEmpty();
    }
}
