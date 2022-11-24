using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollectCoin : MonoBehaviour
{
	public int score;


	public void AddCoin()
	{
		score++;
		//CoinText.text = "Score: " + score.ToString();
	}
}
