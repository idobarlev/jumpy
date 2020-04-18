using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsText : MonoBehaviour
{
    public Text coinsText;          // coins text in UI.
    private static int coins;

    // Start is called before the first frame update
    void Start()
    {
        SetCoins(0);                        // init text to 0
        coinsText = GetComponent<Text>();   // get object text 
        coinsText.text = "" + GetCoins() + ""; // update coins text.
    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text = "" + GetCoins() + "";   // update coins text.
    }

    // -- get & set -- 
    public static int GetCoins()
    {
        return coins;
    }

    public static void SetCoins(int value)
    {
        coins = value;
    }
}
