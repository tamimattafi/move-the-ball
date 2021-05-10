using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderLabel : MonoBehaviour
{

    public Slider slider;
    public string prefix;

    private TextMeshProUGUI _text;

    // Start is called before the first frame update
    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _text.SetText(prefix + slider.value);
    }

}
