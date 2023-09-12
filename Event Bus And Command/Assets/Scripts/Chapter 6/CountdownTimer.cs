using System.Collections;
using UnityEngine;

namespace Chapter.EventBus
{
    public class CountdownTimer : MonoBehaviour
    {
        private float _currentTime;
        private float _duration = 3.0f;

        private void OnEnable()
        {
            RaceEventBus.Subscribe(RaceEventType.Countdown, StartTimer);
        }
        private void OnDisable()
        {
            RaceEventBus.Unsubscribe(RaceEventType.Countdown, StartTimer);
        }
        private void StartTimer()
        {
            StartCoroutine(Countdown());
        }
        private IEnumerator Countdown()
        {
            _currentTime = _duration;
            while (_currentTime > 0)
            {
                yield return new WaitForSeconds(1f);
                _currentTime --;
            }

            RaceEventBus.Publish(RaceEventType.Start);
        }

        private void OnGUI()
        {
            GUI.color = Color.blue;
            GUI.Label(new Rect(125, 0, 120, 20), ("COUNTDOWN: " + _currentTime));
        }
    }
}