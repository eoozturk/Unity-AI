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

	public GameManager gameManager;
	private InGameRanking ig;

    private void Start()
    {
		playerStartPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
		ig = FindObjectOfType<InGameRanking>();
	}

    public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	private void OnTriggerEnter(Collider other)
	{
        if (other.CompareTag("End"))
        {
			PlayerFinished();
			if (ig.nameTexts[6].text == "Player")
			{
				playerController.PlayerAnim.SetBool("win", true);
				transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self);
			}
            else
            {
				playerController.PlayerAnim.SetBool("lose", true);
				transform.Rotate(transform.rotation.x, 180, transform.rotation.z, Space.Self);
			}
			
		}
		if (other.CompareTag("SpeedBoost"))
		{
			sBoostController.SetActive(true);
			playerController.runningSpeed = playerController.runningSpeed + speedBoost;
			StartCoroutine(SpeedBoostControl());
		}
	}

	void PlayerFinished()
    {
		playerController.runningSpeed = 0f;
		RestartPanel.SetActive(true);
		gameManager.isGameOver = true;
		
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
