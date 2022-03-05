using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerInput : MonoBehaviour
{
    private PlayerMovement _mover;
    
    private void Start()
    {
        _mover = GetComponent<PlayerMovement>();
    }

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) //Если нажата клавиша "W" подняться выше
        {
            _mover.TryMoveUp();
        }

        if (Input.GetKeyDown(KeyCode.S)) //Если нажата клавиша "S" спутится ниже
        {
            _mover.TryMoveDown();
        }
    }
}
