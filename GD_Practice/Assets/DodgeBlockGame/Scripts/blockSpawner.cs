using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class blockSpawner : MonoBehaviour {
	public Text waveScore;
	public Transform[] spawnPoints;
	public GameObject blockPrefab,coinsPrefab,scorePrefab,letterPrefab;


	private float timeToSpawn = 2f;
	public float timeBetweenWaves = 2f;
	public int slowTendencyPowerUps = 7;
	private float timeToSpawnLetters,timeBetweenLetters;

	private string wordToSolve = "";
	public static int currentLetterNumber = 0;
	public static string jumbledWord = "";


	[SpaceAttribute(10)]
	[HeaderAttribute("WORDS TO COLLECT")]
	public string[] randWords;


	void Awake(){
		if (randWords != null) {
			int r = Random.Range (0, randWords.Length);
			timeToSpawnLetters = Random.Range (5f, 9f);
			wordToSolve = randWords [r];
			jumbledWord = Shuffle (wordToSolve);
			Debug.Log (jumbledWord);
		}
	}
		
	void Update(){
		if (Time.time >= timeToSpawn) {
			spawnBlocks ();
			timeToSpawn = Time.time + timeBetweenWaves;
		}
		if(Player.x == 10 || Player.x == 20 || Player.x == 30)
		{
			slowTendencyPowerUps--;
		}
		if (Time.time >= timeToSpawnLetters && currentLetterNumber <= jumbledWord.Length) {
			
			/*Instantiate (letterPrefab, spawnPoints [Random.Range(0,spawnPoints.Length)].position, Quaternion.identity);
			currentLetterNumber++;
			timeBetweenLetters = Random.Range (5f, 9f);
			timeToSpawnLetters = Time.time + timeBetweenLetters;*/
		}
	}
	public static string Shuffle(string wordToSolve)
	{
		
		var list = new SortedList<int,char> ();
		foreach (var c in wordToSolve)
			list.Add(Random.Range(0,1000), c);
		return new string(list.Values.ToArray());

	}



	void spawnBlocks(){
		int randomIndex = Random.Range (0, 5);
		int coins = Random.Range (1, 3);
		for (int i = 0; i < 5; i++) {
			if (randomIndex != i) {
				Instantiate (blockPrefab, spawnPoints [i].position, Quaternion.identity);
			}
			else {
				if (coins == 1) {
					Instantiate (coinsPrefab, spawnPoints [i].position, Quaternion.identity);
				} 
			}
		}
		Instantiate (scorePrefab, spawnPoints [5].position, Quaternion.identity);
	}



}
