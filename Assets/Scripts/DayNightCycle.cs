using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public event System.EventHandler OnChanged;
    public float dayDuration = 10.0f;
    public bool isNight { get; private set; }
    public Color nightColor = Color.white * 0.1f;
    private Color dayColor;
    private Light lightComponent;

    // Start is called before the first frame update
    void Start()
    {
        lightComponent = GetComponent<Light>();
        dayColor = lightComponent.color;
    }

    // Update is called once per frame
    void Update()
    {
        float lightIntensity = 0.5f + Mathf.Sin(Time.time * 2.0f * Mathf.PI / dayDuration) / 2.0f;
        bool shouldBeNight = lightIntensity < 0.3f;

        if(isNight != shouldBeNight)
        {
            isNight = shouldBeNight;
            OnChanged?.Invoke(this, System.EventArgs.Empty);
        }
        lightComponent.color = Color.Lerp(nightColor, dayColor, lightIntensity);
    }
}
