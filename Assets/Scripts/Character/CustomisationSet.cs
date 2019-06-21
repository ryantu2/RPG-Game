using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CustomisationSet : MonoBehaviour
{


    #region Variables
    [Header("Texture List")]
    //Texture2D List for skin,hair, mouth, eyes
    public List<Texture2D> skin = new List<Texture2D>();
    public List<Texture2D> hair = new List<Texture2D>();
    public List<Texture2D> mouth = new List<Texture2D>();
    public List<Texture2D> eyes = new List<Texture2D>();
    public List<Texture2D> armour = new List<Texture2D>();
    public List<Texture2D> clothes = new List<Texture2D>();
    [Header("Index")]
    //index numbers for our current skin, hair, mouth, eyes textures
    public int skinIndex;
    public int hairIndex, mouthIndex, eyesIndex, armourIndex, clothesIndex;
    [Header("Renderer")]
    //renderer for our character mesh so we can reference a material list
    public Renderer character;
    [Header("Max Index")]
    //max amount of skin, hair, mouth, eyes textures that our lists are filling with
    public int skinMax;
    public int hairMax, mouthMax, eyesMax, armourMax, clothesMax;
    [Header("Character Name")]
    //name of our character that the user is making
    public string characterName = "Adventurer";
    [Header("Stats")]
    public CharacterClass charClass = CharacterClass.Barbarian;
    public CharacterRace charRace = CharacterRace.Dragonborn;
    public int[] tempStats = new int[6];
    public int[] stats = new int[6];
    public string[] statNames = new string[6];
    public int points = 10;
    public int selectedIndex = 0;
    public string[] selectedClass = new string[12];
    [Header("UI Canvas Stuff")]
    public Text[] lables;
    public Text classText;

    public GameObject[] leftButtons = new GameObject[6];
    public GameObject[] rightButtons = new GameObject[6];
    public Text pointsText;

    #endregion

    #region Start
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        statNames = new string[] { "Strength", "Dexterity", "Constitution", "Wisdom", "Intelligence", "Charisma" };
        selectedClass = new string[] { "Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", "Paladin", "Ranger", "Rogue", "Sorcerer", "Warlock", "Wizard" };
     
        #region for loop to pull textures from file
        //for loop looping from 0 to less than the max amount of skin textures we need
        for (int i = 0; i < skinMax; i++)
        {
            //creating a temp Texture2D that it grabs using Resources.Load from the Character File looking for Skin_#
            Texture2D temp = Resources.Load("Character/Skin_" + i.ToString()) as Texture2D;
            //add our temp texture that we just found to the skin List
            skin.Add(temp);
        }
        for (int i = 0; i < mouthMax; i++)
        {

            Texture2D temp = Resources.Load("Character/Mouth_" + i.ToString()) as Texture2D;
            mouth.Add(temp);
        }
        for (int i = 0; i < eyesMax; i++)
        {

            Texture2D temp = Resources.Load("Character/Eyes_" + i.ToString()) as Texture2D;
            eyes.Add(temp);
        }
        for (int i = 0; i < armourMax; i++)
        {
            Texture2D temp = Resources.Load("Character/Armour_" + i.ToString()) as Texture2D;
            armour.Add(temp);
        }
        for (int i = 0; i < hairMax; i++)
        {
            Texture2D temp = Resources.Load("Character/Hair_" + i.ToString()) as Texture2D;
            hair.Add(temp);
        }
        for (int i = 0; i < clothesMax; i++)
        {
            Texture2D temp = Resources.Load("Character/Clothes_" + i.ToString()) as Texture2D;
            clothes.Add(temp);
        }


        #endregion
        //connect and find the SkinnedMeshRenderer thats in the scene to the variable we made for Renderer
        character = GameObject.Find("Mesh").GetComponent<SkinnedMeshRenderer>();
        #region do this after making the function SetTexture
        //SetTexture skin, hair, mouth, eyes to the first texture 0
        SetTexture("Skin", skinIndex = 0);
        SetTexture("Hair", hairIndex = 0);
        SetTexture("Mouth", mouthIndex = 0);
        SetTexture("Eyes", eyesIndex = 0);
        SetTexture("Clothes", clothesIndex = 0);
        SetTexture("Armour", armourIndex = 0);
        #endregion


        //From this point the start section will have UI canvas stuff
        ShowButton();
        ChooseClass(0);

        DisplayStats();
        pointsText.text = "Points:" + points.ToString();

    }


    void DisplayStats()
    {
        for (int i = 0; i < statNames.Length; i++)
        {
            lables[i].text = statNames[i] + ": " + (stats[i] + tempStats[i]);
        }
    }

    #endregion

    #region Update
    private void Update()
    {
        //Set Update function to update textures on character

    }
    #endregion

    #region SetTexture
    void SetTexture(string type, int dir)
    {
        int index = 0, max = 0, matIndex = 0;
        Texture2D[] textures = new Texture2D[0];

        #region Switch Material
        switch (type)
        {
            case "Skin":
                index = skinIndex;
                max = skinMax;
                textures = skin.ToArray();
                matIndex = 1;
                break;

            case "Hair":
                index = skinIndex;
                max = hairMax;
                textures = hair.ToArray();
                matIndex = 4;
                break;

            case "Mouth":
                index = mouthIndex;
                max = mouthMax;
                textures = mouth.ToArray();
                matIndex = 3;
                break;

            case "Eyes":
                index = eyesIndex;
                max = eyesMax;
                textures = eyes.ToArray();
                matIndex = 2;
                break;

            case "Clothes":
                index = clothesIndex;
                max = clothesMax;
                textures = clothes.ToArray();
                matIndex = 5;
                break;

            case "Armour":
                index = armourIndex;
                max = armourMax;
                textures = armour.ToArray();
                matIndex = 6;
                break;
        }
        #endregion
        #region Outside Switch
        index += dir;
        if (index < 0)
        {
            index = max - 1;
        }
        if (index > max - 1)
        {
            index = 0;
        }
        Material[] mat = character.materials;
        mat[matIndex].mainTexture = textures[index];
        character.materials = mat;
        #endregion

        #region Set Material Switch
        switch (type)
        {
            case "Skin":
                skinIndex = index;
                break;
            case "Hair":
                hairIndex = index;
                break;
            case "Mouth":
                mouthIndex = index;
                break;
            case "Eyes":
                eyesIndex = index;
                break;
            case "Clothes":
                clothesIndex = index;
                break;
            case "Armour":
                armourIndex = index;
                break;



        }
        #endregion

    }
    #endregion

    #region Save
    void Save()
    {
        //Function called Save this will allow us to save our indexes 
        //SetInt for SkinIndex, HairIndex, MouthIndex, EyesIndex
        //SetString CharacterName
    }
    #endregion

    #region OnGUI
   /* private void OnGUI()
    {
        float scrW = Screen.width / 16;
        float scrH = Screen.height / 9;

        int i = 0;
        if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
        {
            SetTexture("Skin", -1);
        }
        GUI.Box(new Rect(0.75f * scrW, scrH + i * (0.5f * scrH), 1f * scrW, 0.5f * scrH), "Skin");
        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
        {
            SetTexture("Skin", 1);
        }
        i++;
        if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
        {
            SetTexture("Hair", -1);
        }
        GUI.Box(new Rect(0.75f * scrW, scrH + i * (0.5f * scrH), 1f * scrW, 0.5f * scrH), "Hair");
        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
        {
            SetTexture("Hair", 1);
        }
        i++;
        if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
        {
            SetTexture("Eyes", -1);
        }
        GUI.Box(new Rect(0.75f * scrW, scrH + i * (0.5f * scrH), 1f * scrW, 0.5f * scrH), "Eyes");
        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
        {
            SetTexture("Eyes", 1);
        }
        i++;
        if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
        {
            SetTexture("Mouth", -1);
        }
        GUI.Box(new Rect(0.75f * scrW, scrH + i * (0.5f * scrH), 1f * scrW, 0.5f * scrH), "Mouth");
        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
        {
            SetTexture("Mouth", 1);
        }
        i++;
        if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
        {
            SetTexture("Clothes", -1);
        }
        GUI.Box(new Rect(0.75f * scrW, scrH + i * (0.5f * scrH), 1f * scrW, 0.5f * scrH), "Clothes");
        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
        {
            SetTexture("Clothes", 1);
        }
        i++;
        if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
        {
            SetTexture("Armour", -1);
        }
        GUI.Box(new Rect(0.75f * scrW, scrH + i * (0.5f * scrH), 1f * scrW, 0.5f * scrH), "Armour");
        if (GUI.Button(new Rect(1.75f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
        {
            SetTexture("Armour", 1);
        }
        i++;
        if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), scrW, 0.5f * scrH), "Reset"))
        {
            SetTexture("Skin", skinIndex = 0);
            SetTexture("Hair", hairIndex = 0);
            SetTexture("Eyes", eyesIndex = 0);
            SetTexture("Mouth", mouthIndex = 0);
            SetTexture("Clothes", clothesIndex = 0);
            SetTexture("Armour", armourIndex = 0);
        }
        if (GUI.Button(new Rect(1.25f * scrW, scrH + i * (0.5f * scrH), scrW, 0.5f * scrH), "Random"))
        {
            SetTexture("Skin", Random.Range(0, skinMax - 1));
            SetTexture("Hair", Random.Range(0, hairMax - 1));
            SetTexture("Mouth", Random.Range(0, mouthMax - 1));
            SetTexture("Eyes", Random.Range(0, eyesMax - 1));
            SetTexture("Clothes", Random.Range(0, clothesMax - 1));
            SetTexture("Armour", Random.Range(0, armourMax - 1));
        }
        i++;
        characterName = GUI.TextField(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), 2 * scrW, 0.5f * scrH), characterName, 16);
        i++;
        if (GUI.Button(new Rect(0.25f * scrW, scrH + i * (0.5f * scrH), 2 * scrW, 0.5f * scrH), "Save and Play"))
        {
            Save();
            SceneManager.LoadScene(2);
        }
        i = 0;
        GUI.Box(new Rect(3.75f * scrW, scrH + i * (0.5f * scrH), 2 * scrW, 0.5f * scrH), "Class");
        i++;
        if (GUI.Button(new Rect(3.25f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "<"))
        {
            selectedIndex--;
            if (selectedIndex < 0)
            {
                selectedIndex = selectedClass.Length - 1;
            }
            ChooseClass(selectedIndex);
        }
        GUI.Box(new Rect(3.75f * scrW, scrH + i * (0.5f * scrH), 2 * scrW, 0.5f * scrH), selectedClass[selectedIndex]);
        if (GUI.Button(new Rect(5.75f * scrW, scrH + i * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), ">"))
        {
            selectedIndex++;
            if (selectedIndex > selectedClass.Length - 1)
            {
                selectedIndex = 0;
            }
            ChooseClass(selectedIndex);
        }
        GUI.Box(new Rect(3.75f * scrW, 2f * scrH, 2f * scrW, 0.5f * scrH), "Points: " + points);
        for (int s = 0; s < 6; s++)
        {
            if (points > 0)
            {
                if (GUI.Button(new Rect(5.75f * scrW, 2.5f * scrH + s * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "+"))
                {
                    points--;
                    tempStats[s]++;
                }
            }
            GUI.Box(new Rect(3.75f * scrW, 2.5f * scrH + s * (0.5f * scrH), 2f * scrW, 0.5f * scrH), statNames[s] + ": " + (tempStats[s] + stats[s]));
            if (points < 10 && tempStats[s] > 0)
            {
                if (GUI.Button(new Rect(3.25f * scrW, 2.5f * scrH + s * (0.5f * scrH), 0.5f * scrW, 0.5f * scrH), "-"))
                {
                    points++;
                    tempStats[s]--;
                }
            }
        }





    }*/
    #endregion



    public void ChooseClass(int className)
    {
        switch (className)
        {
            case 0:
                stats[0] = 10;
                stats[1] = 10;
                stats[2] = 10;
                stats[3] = 15;
                stats[4] = 10;
                stats[5] = 5;
                charClass = CharacterClass.Barbarian;
                break;
            case 1:
                stats[0] = 15;
                stats[1] = 10;
                stats[2] = 10;
                stats[3] = 10;
                stats[4] = 10;
                stats[5] = 5;
                charClass = CharacterClass.Bard;
                break;
            case 2:
                stats[0] = 10;
                stats[1] = 5;
                stats[2] = 15;
                stats[3] = 10;
                stats[4] = 10;
                stats[5] = 10;
                charClass = CharacterClass.Druid;
                break;
            case 3:
                stats[0] = 5;
                stats[1] = 15;
                stats[2] = 15;
                stats[3] = 10;
                stats[4] = 10;
                stats[5] = 5;
                charClass = CharacterClass.Monk;
                break;
            case 4:
                stats[0] = 15;
                stats[1] = 10;
                stats[2] = 15;
                stats[3] = 5;
                stats[4] = 5;
                stats[5] = 10;
                charClass = CharacterClass.Paladin;
                break;
            case 5:
                stats[0] = 5;
                stats[1] = 15;
                stats[2] = 10;
                stats[3] = 15;
                stats[4] = 10;
                stats[5] = 5;
                charClass = CharacterClass.Ranger;
                break;
            case 6:
                stats[0] = 10;
                stats[1] = 10;
                stats[2] = 10;
                stats[3] = 15;
                stats[4] = 10;
                stats[5] = 5;
                charClass = CharacterClass.Sorcerer;
                break;
            case 7:
                stats[0] = 5;
                stats[1] = 5;
                stats[2] = 5;
                stats[3] = 15;
                stats[4] = 15;
                stats[5] = 15;
                charClass = CharacterClass.Warlock;
                break;

        }

        DisplayStats();


    }


   //the function below is to set the visibility of the + and - buttons on the class categories section
    public void ShowButton()
    {
        for (int i = 0; i < rightButtons.Length; i++)
        {
            if (points > 0)
            {
                rightButtons[i].SetActive(true);
            }
            else
            {
                rightButtons[i].SetActive(false);
            }

            if (points < 10 && tempStats[i] > 0)
            {
                leftButtons[i].SetActive(true);
            }
            else
            {
                leftButtons[i].SetActive(false);
            }
        }
    }



    //this function is used to add a point when the player clicks +
    public void UsePoint(int i)
    {

         points--;
         tempStats[i]++;
        pointsText.text = "Points:" + points.ToString();
        ShowButton();
        DisplayStats();

    }

    //this function is used to minus a point when the player clicks -
    public void UnusePoint(int i)
    {

        points++;
        tempStats[i]--;
        pointsText.text = "Points:" + points.ToString();
        ShowButton();
        DisplayStats();


    }

    //set buttons to add or subtract points

    
  

    public void ChangeClassLeft()
    {
        selectedIndex--;
        if (selectedIndex < 0)
        {
            selectedIndex = selectedClass.Length - 1;
            
        }
        ChooseClass(selectedIndex);

        classText.text = selectedClass[selectedIndex];

    }

    public void ChangeClassRight()
    {
        selectedIndex++;
        if (selectedIndex > selectedClass.Length - 1)
        {
            selectedIndex = 0;

        }
        ChooseClass(selectedIndex);

        //change text box for the the class select
        //how to change the value of a text object?
        classText.text = selectedClass[selectedIndex];
    }

    public void DisplayClassStats()
    {

        //i think it is an if statement here
        //if the player selects a specific className index 
        //Display classstats
    }

    public void RandomSkins()
    {
        SetTexture("Skin", Random.Range(0, skinMax - 1));
        SetTexture("Hair", Random.Range(0, hairMax - 1));
        SetTexture("Mouth", Random.Range(0, mouthMax - 1));
        SetTexture("Eyes", Random.Range(0, eyesMax - 1));
        SetTexture("Clothes", Random.Range(0, clothesMax - 1));
        SetTexture("Armour", Random.Range(0, armourMax - 1));
    }
    
    public void Reset()
    {
        SetTexture("Skin", skinIndex = 0);
        SetTexture("Hair", hairIndex = 0);
        SetTexture("Eyes", eyesIndex = 0);
        SetTexture("Mouth", mouthIndex = 0);
        SetTexture("Clothes", clothesIndex = 0);
        SetTexture("Armour", armourIndex = 0);
    }

    public void Previous(string whatToChange)
    {
        SetTexture(whatToChange, -1);
    }

    public void Next(string whatToChange)
    {
        SetTexture(whatToChange, 1);
    }


}

public enum CharacterClass
{
    Barbarian,
    Bard,
    Cleric,
    Druid,
    Fighter,
    Monk,
    Paladin,
    Ranger,
    Rogue,
    Sorcerer,
    Warlock,
    Wizard
}

public enum CharacterRace
{
    Dragonborn,
    Dwarf,
    Elf,
    Gnome,
    Half_Elf,
    Half_Orc,
    Halfling,
    Human,
    Tiefling
}

