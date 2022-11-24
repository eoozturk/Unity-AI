using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckCollisions : MonoBehaviour
{
    public CollectCoin collectCoin;
	public PlayerController playerController;
	public GameObject RestartPanel;

	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("coin"))
		{
            collectCoin.AddCoin();
            Destroy(other.gameObject);
		}
		if (other.CompareTag("finish"))
		{
			if (collectCoin.score >= 54)
			{
				playerController.runningSpeed = 0f;
				playerController.PlayerAnim.SetBool("win", true);
				transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self);
				RestartPanel.SetActive(true);
			}
			else
			{
				playerController.runningSpeed = 0f;
				playerController.PlayerAnim.SetBool("lose", true);
				transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self);
				RestartPanel.SetActive(true);
			}
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag("obstacle"))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

}
