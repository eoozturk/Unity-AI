using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckCollisions : MonoBehaviour
{
	float speedBoost = 3.0f;
	Vector3 playerStartPos;
	public GameObject RestartPanel, sBoostController;
	public PlayerController playerController;

    private void Start()
    {
		playerStartPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	private void OnTriggerEnter(Collider other)
	{
        if (other.CompareTag("End"))
        {
			playerController.runningSpeed = 0f;
			//playerController.PlayerAnim.SetBool("win", true);
			transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self);
			RestartPanel.SetActive(true);
		}
		if (other.CompareTag("SpeedBoost"))
		{
			sBoostController.SetActive(true);
			playerController.runningSpeed = playerController.runningSpeed + speedBoost;
			StartCoroutine(SpeedBoostControl());
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag("Obstacle"))
		{
			transform.position = playerStartPos;
			//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}
	}

	private IEnumerator SpeedBoostControl()
    {
		yield return new WaitForSeconds(2.0f);
		sBoostController.SetActive(false);
		playerController.runningSpeed = playerController.runningSpeed - speedBoost;
    }
}
