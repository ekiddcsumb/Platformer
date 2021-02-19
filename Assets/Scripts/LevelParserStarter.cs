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
        string fileToParse = string.Format("{0}{1}{2}.txt", Application.dataPath, "/Resources/Test", filename);

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
                SpawnPrefab(letter, Vector3.zero);
            }

        }

        sr.Close();
    }

    // character to be parsed, position where it needs to be spawned
    private void SpawnPrefab(char spot, Vector3 positionToSpawn)
    {
        GameObject ToSpawn;

        switch (spot)
        {
            // Make cases instantiate objects rather than logging
            case 'b': Debug.Log("Spawn Brick"); break;
            case '?': Debug.Log("Spawn QuestionBox"); break;
            case 'x': Debug.Log("Spawn Rock"); break;
            case 's': Debug.Log("Spawn Rock"); break;
            //default: Debug.Log("Default Entered"); break;
            default: return;
                //ToSpawn = //Brick;       break;
        }

        //ToSpawn = GameObject.Instantiate(ToSpawn, parentTransform);
        //ToSpawn.transform.localPosition = positionToSpawn;
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
