using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalCoinsText : MonoBehaviour
{
    #region DM
    public Text coinsText;          // coins text in UI.
    private static int _coins = 0;
    #endregion

    // Start is called before the first frame update
    void Start() {
        coinsText = GetComponent<Text>();   // get object text 
        coinsText.text = "" + PlayerPrefs.GetInt("coins", 0) + ""; // update coins text.
    }

    // Update is called once per frame
    void Update() {
        coinsText.text = "" + PlayerPrefs.GetInt("coins", 0) + "";   // update coins text.
    }

    #region Get & Set
    public static int Coins { get => _coins; set => _coins = value; }
    #endregion
}
