using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LevelParserStarter : MonoBehaviour
{
    public string filename;

    public GameObject Rock;

    public GameObject Brick;

    public GameObject QuestionBox;

    public GameObject Stone;

    public Transform parentTransform;
    // Start is called before the first frame update
    void Start()
    {
        RefreshParse();
    }


    private void FileParser()
    {
        string fileToParse = string.Format("{0}{1}{2}.txt", Application.dataPath, "/Resources/", filename);

        using StreamReader sr = new StreamReader(fileToParse);
        string line = "";
        int row = 0;

        while ((line = sr.ReadLine()) != null)
        {
            int column = 0;
            char[] letters = line.ToCharArray();
            foreach (var letter in letters)
            {
                //Call SpawnPrefab
                // Vector3 (update) - only x and y change, z stays at 0.
                SpawnPrefab(letter, new Vector3(row, column, 0));
                
                column++;
            }
            row++;
            Debug.Log("Row: " + row + ", Column: " + column);
        }

        sr.Close();
    }

    // character to be parsed, position where it needs to be spawned
    private void SpawnPrefab(char spot, Vector3 positionToSpawn)
    {
        GameObject toSpawn;

        switch (spot)
        {
            // if letter equals x or ? or b or s,
            // instantiate the corresponding prefab.
            
            // Make cases instantiate objects rather than logging
            case 'b':
                toSpawn = Brick;
                // Debug.Log("Spawn Brick"); 
                break;
            case '?':
                toSpawn = QuestionBox;
                // Debug.Log("Spawn QuestionBox"); 
                break;
            case 'x':
                toSpawn = Rock;
                // Debug.Log("Spawn Rock"); 
                break;
            case 's':
                toSpawn = Stone;
                // Debug.Log("Spawn Rock"); 
                break;
            //default: Debug.Log("Default Entered"); break;
            default: return;
                //ToSpawn = //Brick;       break;
        }

        toSpawn = GameObject.Instantiate(toSpawn, parentTransform);
        toSpawn.transform.localPosition = positionToSpawn;
    }
    
    public void RefreshParse()
    {
        GameObject newParent = new GameObject();
        newParent.name = "Environment";
        newParent.transform.position = parentTransform.position;
        newParent.transform.parent = this.transform;
        
        if (parentTransform) Destroy(parentTransform.gameObject);

        parentTransform = newParent.transform;
        FileParser();
    }
}
