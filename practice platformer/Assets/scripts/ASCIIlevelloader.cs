using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ASCIIlevelloader : MonoBehaviour
{
    //varaibles

    public float xOffset;
    public float yOffset;

    public string FileName;
    public int CurrentLevel = 0;

    private GameObject CurrentPlayer;
    private Vector2 StartPOS;


    public int currentLevel
    {
      get {return CurrentLevel; }
      set
      {
        CurrentLevel = value;
        LoadLevel();
      }  
    }



    public GameObject square;
    public GameObject wall;
    public GameObject goal;


   

    // Start is called before the first frame update
    void Start()
    {
        LoadLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject levelhold;

    public void LoadLevel()
    {

         Destroy(levelhold);
        levelhold = new GameObject("level");

        string current_file_path = Application.dataPath + "/levels/" + FileName.Replace("Num", CurrentLevel + "");

        string[] fileLines = File.ReadAllLines(current_file_path);


        for(int y = 0; y < fileLines.Length; y++)
        {
            string lineText = fileLines[y];


            char[] characters = lineText.ToCharArray();

            for(int x = 0; x < characters.Length; x++)
            {
                char c = characters[x];

                GameObject newOBJ;

                switch (c)
                {
                        case 'p' :
                         newOBJ = Instantiate<GameObject>(square);

                          if(CurrentPlayer == null)
                             CurrentPlayer = newOBJ;


                          StartPOS = new Vector3(x + xOffset, -y + yOffset, 0);

                          break;

                          case 'w' :
                            newOBJ = Instantiate<GameObject>(wall);
                          break;
                        
                          case '!' : 
                          newOBJ = Instantiate<GameObject>(goal);
                          break;

                          default:
                          newOBJ = null;
                          break;
                }

                if(newOBJ != null)
                {
                    if(!newOBJ.name.Contains("Square"))
                    {
                        newOBJ.transform.parent = levelhold.transform;
                    }

                     newOBJ.transform.position = new Vector3(x + xOffset, -y + yOffset, 0);
                }
            }
        }
    }
}
