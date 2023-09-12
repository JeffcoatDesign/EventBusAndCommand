using UnityEngine;

namespace Chapter.EventBus
{
    public class HudController : MonoBehaviour
    {
        private bool _isDisplayOn;

        private void OnEnable() {
            RaceEventBus.Subscribe(RaceEventType.Start, DisplayHUD);
        }
        private void OnDisable()
        {
            RaceEventBus.Unsubscribe(RaceEventType.Start, DisplayHUD);
        }
        private void DisplayHUD ()
        {
            _isDisplayOn = true;
        }

        private void OnGUI()
        {
            if (_isDisplayOn)
            {
                if (GUILayout.Button("Stop Race"))
                {
                    _isDisplayOn = false;
                    RaceEventBus.Publish(RaceEventType.Stop);
                }
            }
        }
    }
}