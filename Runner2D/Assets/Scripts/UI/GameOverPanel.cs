using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private Button _restartButton; //Кнопка Перезапуска
    [SerializeField] private Button _exitButton; // Кнопка выхода
    [SerializeField] private Player _player; // Компонент игрок

    private CanvasGroup _canvasGroup;


    //Подписка на событие смерти игрока
    private void OnEnable()
    {
        _player.Died += OnDied;
        _restartButton.onClick.AddListener(OnRestartButtonClick); 
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    //Отписка
    private void OnDisable()
    {
        _player.Died -= OnDied;
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0;
    }

    //Проигрыш
    private void OnDied()
    {
        _canvasGroup.alpha = 1;
        Time.timeScale = 0;
    }

    //Процедура перезапуска
    private void OnRestartButtonClick()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    //Выход из игры
    private void OnExitButtonClick()
    {
        Application.Quit();
    }
}
