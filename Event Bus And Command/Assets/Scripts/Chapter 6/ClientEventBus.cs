using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Chapter.EventBus
{
    public class ClientEventBus : MonoBehaviour
    {
        private bool _isButtonEnabled;

        private void Start()
        {
            gameObject.AddComponent<HudController>();
            gameObject.AddComponent<CountdownTimer>();
            gameObject.AddComponent<BikeController>();

            _isButtonEnabled = true;
        }

        private void OnEnable()
        {
            RaceEventBus.Subscribe(RaceEventType.Stop, Restart);
        }
        private void OnDisable()
        {
            RaceEventBus.Unsubscribe(RaceEventType.Stop, Restart);
        }

        private void Restart ()
        {
            _isButtonEnabled = true;
        }

        private void OnGUI()
        {
            if (_isButtonEnabled)
            {
                if (GUILayout.Button("Start Controller"))
                {
                    _isButtonEnabled = false;
                    RaceEventBus.Publish(RaceEventType.Countdown);
                }
            }
        }
    }
}