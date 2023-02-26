using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    private Slider noteBar;
    private float targetValue = 5;

    private void Awake()
    {
        noteBar = gameObject.GetComponent<Slider>();   
    }
    // Start is called before the first frame update
    void Start()
    {
        noteBar.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        noteBar.value = (int)Mathf.Min(GameManager.GMinstance.currentCount,5);
    }
}
