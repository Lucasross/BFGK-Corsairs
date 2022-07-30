using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MasterCharacter : MonoBehaviour
{
	public float angriness = 0;
	public float maxAngriness = 4;

	public float wayLimit = 3;

	public bool gameOver;

    private void Start()
    {
        gameOver = false;
    }
    private void Update()
	{
		if (angriness >= maxAngriness)
        {
			gameOver = true;
			DoGameOver();
		}

		if (OutOfWay())
			angriness += 2 * Time.deltaTime;
	}
	private void OnCollisionEnter2D(Collision2D collision2D)
	{
		if (collision2D.gameObject.tag == "Obstacles")
			angriness++;
	}

	private bool OutOfWay()
	{
		return transform.position.x < -wayLimit || transform.position.x > wayLimit;
	}

	void DoGameOver()
	{
		//endPic.SetActive(true); //Activate endPicture picture
		//source.PlayOneShot(song, 0.1f);
		StartCoroutine(RestartGame());
	}
	IEnumerator RestartGame()
	{
		yield return new WaitForSeconds(3f); //time on the GameOver image before restart
		SceneManager.LoadScene(0);
	}
	
}
