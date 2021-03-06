using UnityEngine;
using System.Collections;
using System.Text;
using System.IO;
using System.Collections.Generic;

public class ReadWrite : MonoBehaviour {

	public string currentLevelData;
	public Level levelObject;
	public GridManager gmObject;
	public MenuManager menuInstance;
	public static string selection = "1";

	void Start() 
	{
		levelObject = FindObjectOfType<Level> ();
		gmObject = FindObjectOfType<GridManager> ();
		//selection = "1";
		GetLevel ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void SetSelection()
	{
		//selection = menuInstance.choice;
	}


	public void GetLevel()
	{
		//SetSelection ();
		Debug.Log ("Level " + selection);
		currentLevelData = Resources.Load("Level " + selection).ToString();
		Debug.Log (currentLevelData);
		LevelBuilder ();
	}

	public void LevelBuilder()
	{
		string value = "";
		bool nextIsValue = false;
		int counter = 0;
		foreach (char currentChar in currentLevelData) 
		{
			if (currentChar == ',')
			{
				levelObject.levelData.Add(value);
				value = "";
				nextIsValue =false;
				counter++;
			}
			if (currentChar == 'S')
			{
				levelObject.startNodeLoc = counter;
			}
			if (currentChar == 'E')
			{
				levelObject.endNodeLoc = counter;
			}
			if (nextIsValue == true)
			{
				value += currentChar;
				switch(currentChar)
				{
					case '1':
						levelObject.numOfStraight++;
						break;
					case '2':
						levelObject.numOfCorner++;
						break;
					case '3':
						levelObject.numOfThree++;
						break;
					case '4':
						levelObject.numOfFour++;
						break;
					case '5':
						levelObject.numOfBridge++;
						break;
					case '6':
						levelObject.numOfCornerBridge++;
						break;
					default:
						break;
				}

			}
			if (currentChar == ':')
			{
				nextIsValue = true; 
			}

		}

	}

}
