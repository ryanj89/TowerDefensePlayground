using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaveSpawner : MonoBehaviour 
{

	public Transform enemyPrefab;
	public float timeBetweenWaves = 5f;
	public Transform spawnPoint;
	public Text waveCountdownText;

	private float timer = 2f;
	private int waveIndex = 0;

	void Update() 
	{
		if (timer <= 0f)
		{
			StartCoroutine(SpawnWave());
			timer = timeBetweenWaves;
		}

		timer -= Time.deltaTime;    // Decrease timer every second
		waveCountdownText.text = Mathf.Round(timer).ToString();
	}

	IEnumerator SpawnWave()
	{
		waveIndex++;

		// NUMBER OF ENEMIES SPAWNED == WAVE NUMBER
		for (int i = 0; i < waveIndex; i++)
		{
			SpawnEnemy();
			yield return new WaitForSeconds(0.5f); 
		}
	}

	void SpawnEnemy()
	{
		Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
	}
}
