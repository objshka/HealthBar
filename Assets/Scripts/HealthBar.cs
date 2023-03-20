using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;

    private Coroutine Coroutine;

    private float _recoveryRate = 0.1f;

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float health)
    {
        if (Coroutine != null)
        {
            StopCoroutine(Coroutine);
            Coroutine = null;
        }

        Coroutine = StartCoroutine(Changing(health));
    }

    private IEnumerator Changing(float health)
    {
        while (Mathf.Abs(_slider.value - health) > .2f)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, health, _recoveryRate);

            yield return null;
        }
    }
}