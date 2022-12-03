using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameRanking : MonoBehaviour
{
    public Text[] nameTexts;
    public string a, b, c, d, e, f, g;

    // Update is called once per frame
    void Update()
    {
        nameTexts[0].text = a;
        nameTexts[1].text = b;
        nameTexts[2].text = c;
        nameTexts[3].text = d;
        nameTexts[4].text = e;
        nameTexts[5].text = f;
        nameTexts[6].text = g;
    }
}
