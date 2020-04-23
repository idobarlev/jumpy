using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PageCountDown : MonoBehaviour
{
    public delegate void CountDownFinished();
    public static event CountDownFinished OnCountDownFinished;
    public int countDownFrom = 3;
    public Text countDown;

    void OnEnable() {
        countDown.text = " " + countDownFrom + " ";
        StartCoroutine("CountDown");
    }

    IEnumerator CountDown() {
        int count = countDownFrom;
        for (int i = 0; i < count; i++) {
            countDown.text = (count - i).ToString();
            yield return new WaitForSeconds(1);
        }
        OnCountDownFinished();
    }
}
