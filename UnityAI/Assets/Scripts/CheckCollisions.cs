using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckCollisions : MonoBehaviour
{
	public GameObject RestartPanel;
	public PlayerController playerController;

	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	private void OnTriggerEnter(Collider other)
	{

		playerController.runningSpeed = 0f;
		//playerController.PlayerAnim.SetBool("win", true);
		transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self);
		RestartPanel.SetActive(true);
	
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag("Obstacle"))
		{
			//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

}
