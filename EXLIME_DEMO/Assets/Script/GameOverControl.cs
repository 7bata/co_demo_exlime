using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverControl : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject text_gameover;
    void Start()
    {
        text_gameover.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.instance.slider.value <= 0)
        {
            text_gameover.SetActive(true);
        }
    }
}
