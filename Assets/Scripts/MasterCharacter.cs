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

	public GameObject particle;

	private SpriteRenderer sprite;
	private AudioSource audio;
	public AudioClip angryMan;
	public GameObject endPicture;

	private void Start()
	{
		audio = GetComponent<AudioSource>();
		sprite = GetComponent<SpriteRenderer>();

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
			ModAngriness(2 * Time.deltaTime);

		if (angriness > 0)
			angriness -= 0.04f * Time.deltaTime;

		sprite.color = new Color(1, Mathf.InverseLerp(maxAngriness, 0, angriness), Mathf.InverseLerp(maxAngriness, 0, angriness));
	}
	private void OnCollisionEnter2D(Collision2D collision2D)
	{
		MeetObstacles(collision2D.gameObject);
	}

	private void OnTriggerEnter2D(Collider2D collision2D)
	{
		MeetObstacles(collision2D.gameObject);
	}

	private void MeetObstacles(GameObject collision2D)
	{
		if (collision2D.tag == "Obstacles")
			ModAngriness(1);
	}

	public void ModAngriness(float value)
	{
		Debug.Log("StackTrace");
		Instantiate(particle, transform);
		audio.PlayOneShot(angryMan, 0.1f);
		angriness += value;
	}

	private bool OutOfWay()
	{
		return transform.position.x < -wayLimit || transform.position.x > wayLimit;
	}

	void DoGameOver()
	{
		//source.PlayOneShot(endsong, 0.1f);
		StartCoroutine(RestartGame());
	}
	IEnumerator RestartGame()
	{
		yield return new WaitForSeconds(3f); //time on the GameOver image before restart
		SceneManager.LoadScene(0);
	}

}
