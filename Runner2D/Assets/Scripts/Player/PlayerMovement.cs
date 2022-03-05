using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed; //Скорость движения игрока
    [SerializeField] private float _stepSize; // Шаг перемещения
    [SerializeField] private float _minHeigt; //Минимально ограничение движения по y
    [SerializeField] private float _maxHeigt; //Максимальное ограничение движения по y

    private Vector3 _targetPosition; //Позиция на которую перемешаться

    
    private void Start()
    {
        _targetPosition = transform.position; //Позиция на которую перемешаться присвоить позицию игрока
    }

    
    private void Update()
    {
        if (transform.position != _targetPosition)
        {
            transform.position=Vector3.MoveTowards(transform.position,_targetPosition,_moveSpeed * Time.deltaTime);
        }
    }

    //Подняться вверх
    public void TryMoveUp()
    {
        if (_targetPosition.y < _maxHeigt)
        {
            SetNextPosition(_stepSize);
        }
        
    }

    //Спуститься вниз
    public void TryMoveDown()
    {
        if (_targetPosition.y > _minHeigt)
        {
            SetNextPosition(-_stepSize);
        }
        
    }

    //Следущая позиция
    private void SetNextPosition(float stepSize)
    {
        _targetPosition = new Vector2(_targetPosition.x, _targetPosition.y + stepSize);
    }
}
