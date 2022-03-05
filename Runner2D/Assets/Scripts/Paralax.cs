using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Paralax : MonoBehaviour
{

    [SerializeField] private RawImage _image; //Задиний фон
    [SerializeField] private float _speed; //Скорость движения заднего фона

    private float _imageUIPosX; //Движение заденго фона по Х
    
    private void Start()
    {
        _imageUIPosX = _image.uvRect.x;
    }

    
    private void Update()
    {
        _imageUIPosX += _speed * Time.deltaTime;

        if (_imageUIPosX > 1)
        {
            _imageUIPosX = 0;
        }

        _image.uvRect=new Rect(_imageUIPosX,0,_image.uvRect.width,_image.uvRect.height);
    }
}
