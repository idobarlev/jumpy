using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CoinController : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // TODO - 1. add audio 
    //        2. add score script
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == PlayerLogic.Instance.gameObject)
        {
            CoinsText.SetCoins(CoinsText.GetCoins() + 1);
            Destroy(gameObject);
        }
    }
}
