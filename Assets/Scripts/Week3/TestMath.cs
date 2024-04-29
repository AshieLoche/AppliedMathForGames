using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestMath : MonoBehaviour
{
    public Slider lerpSlider;
    public Slider moveTowardsSlider;
    public Slider pingPongSlider;
    public float speed;

    // Update is called once per frame
    void Update()
    {
        lerpSlider.value = Mathf.Lerp(lerpSlider.value,lerpSlider.maxValue, speed * Time.deltaTime);
        moveTowardsSlider.value = Mathf.MoveTowards(moveTowardsSlider.value, moveTowardsSlider.maxValue, speed * Time.deltaTime);
        pingPongSlider.value = Mathf.PingPong(speed * Time.time, pingPongSlider.maxValue);
    }
}
