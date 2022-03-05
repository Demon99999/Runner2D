using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Heart : MonoBehaviour
{
    [SerializeField] private float _lerpDuration; //Скорость создания/удаления сердец
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.fillAmount = 1; //Заполнение 
    }

    //Публичная процедура заполнения сердца
    public void ToFill()
    {
        StartCoroutine(Filling(0, 1, _lerpDuration, Fill));
    }

    //Публичная процедура опустошения сердца
    public void ToEmpty()
    {
        StartCoroutine(Filling(1, 0, _lerpDuration, Destroy));
    }

    //Корутина заполнения/опустошения сердца
    private IEnumerator Filling(float startValue, float endValue, float duration, UnityAction<float> lerpingEnd)
    {
        float elapsed = 0;
        float nextValue;
        while (elapsed<duration)
        {
            nextValue = Mathf.Lerp(startValue, endValue, elapsed / duration);
            _image.fillAmount = nextValue;
            elapsed += Time.deltaTime;
            yield return null;
        }
        lerpingEnd?.Invoke(endValue);
    }

    //Опустошить сердце и уничтожить
    private void Destroy(float value)
    {
        _image.fillAmount = value;
        Destroy(gameObject);
    }

    //Заполнить сердце
    private void Fill(float value)
    {
        _image.fillAmount = value;
    }

}
