using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScript : MonoBehaviour
{
    // Start is called before the first frame update

    public TMP_InputField playerIn;
    public GameObject eventCheck;
    public Transform parentUI;

    public Transform guessArea;
    public GameObject letterHolder;
    public GameObject letter;

    public Transform hangmanParent;
    public GameObject hangman_0;
    public GameObject hangman_1;
    public GameObject hangman_2;
    public GameObject hangman_3;
    public GameObject hangman_4;
    public GameObject hangman_5;
    public GameObject hangman_6;

    static public bool isCorrect;
    static public char currentLetter;
    static public string theWord;

    public char[] wordArray;
    public int wordLength;
    public char finalInput;
    public int errorCount = 0;
    public int correctCount = 0;
    


    void Start()
    {
        wordRandomizer(UnityEngine.Random.Range(0, 106));

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void wordRandomizer(int wordSelector)
    {

       string[] gameWords = { "MIGUEL", "NICO", "ALFRED", "VALENTIN", "HAROLD", "APPLE", "BANANA", "CHERRY", "DATE", "EGGPLANT", "FIG", "GRAPE", "HONEYDEW", "KIWI", "LEMON",
    "MANGO", "NECTARINE", "ORANGE", "PINEAPPLE", "QUINCE", "RASPBERRY", "STRAWBERRY", "TANGERINE", "WATERMELON",
    "APRICOT", "BLUEBERRY", "CANTALOUPE", "DRAGONFRUIT", "ELDERBERRY", "FRUIT", "GUAVA", "HUCKLEBERRY", "IRIS",
    "JACKFRUIT", "KUMQUAT", "LIME", "MANDARIN", "NUTMEG", "OLIVE", "PAPAYA", "QUINOA", "RAISIN", "SUGAR",
    "TOMATO", "UMAMI", "VANILLA", "WALNUT", "XYLOPHONE", "YELLOW", "ZEBRA", "ALMOND", "BROCCOLI", "CARROT",
    "DAIKON", "EDAMAME", "FENNEL", "GARLIC", "HORSERADISH", "ICEBERG", "JICAMA", "KALE", "LETTUCE", "MUSHROOM",
    "NECTARINE", "OKRA", "POTATO", "QUINOA", "RADISH", "SPINACH", "TURNIP", "UGLI", "VANILLA", "WATERCRESS",
    "XANTHAN", "YAM", "ZUCCHINI", "ANTELOPE", "BEAR", "COUGAR", "DOLPHIN", "EAGLE", "FOX", "GORILLA",
    "HUMMINGBIRD", "IGUANA", "JAGUAR", "KANGAROO", "LEMUR", "MANTIS", "NARWHAL", "OCTOPUS", "PENGUIN", "QUOKKA",
    "RACCOON", "SHARK", "TIGER", "UMA", "VULTURE", "WHALE", "XENOPHOBIA", "YAK", "ZEBRA", "NIGGA", "DUMMY"};
       
        
        
       string wordSelected = gameWords[wordSelector];
       wordLength = gameWords[wordSelector].Length;
       char[] guessWordArray = new char[wordLength];
        theWord = wordSelected;

        for (int i = 0; i < wordLength; i++) { 

            guessWordArray[i] = wordSelected[i];
            letter = Instantiate(letterHolder, guessArea);
            letter.name = i.ToString();
            letter.GetComponentInChildren<TMP_Text>().text = guessWordArray[i].ToString();
            letter.GetComponentInChildren<TMP_Text>().alpha = 0;
        }

        wordArray = guessWordArray;
    }


    public void inputChecker()
    {
    
        string upperInputCOnvert = playerIn.text.ToUpper();
        finalInput = upperInputCOnvert.ToCharArray()[0];
        Debug.Log("input is: " + finalInput);

        if (wordArray.Contains(finalInput))
        {

            indexGetter();
            correctCounter();


        }else {

            errorDetection(errorCount);
            errorCount++;

        }

        
    
    }

    public void indexGetter() {

        for (int i = 0; i < wordLength; i++)
        {


            if (wordArray[i] == finalInput)
            {

                if (GameObject.Find(i.ToString()).GetComponentInChildren<TMP_Text>().alpha == 0)
                {
                    Debug.Log(i);
                    GameObject.Find(i.ToString()).GetComponentInChildren<TMP_Text>().alpha = 1;
                    correctCount++;
                }
                else { 
                
                    Debug.Log("Word ALready Guessed!");
                }

            }


        }

    }

    public void errorDetection(int drawHangman) {

        Debug.Log(drawHangman);

        switch (drawHangman) {

            case 0:

                Instantiate(hangman_0, hangmanParent);
                break;

            case 1:

                Instantiate(hangman_1, hangmanParent);
                break;

            case 2:

                Instantiate(hangman_2, hangmanParent);
                break;

            case 3:

                Instantiate(hangman_3, hangmanParent);
                break;

            case 4:

                Instantiate(hangman_4, hangmanParent);
                break;

            case 5:

                Instantiate(hangman_5, hangmanParent);
                break;

            case 6:

                Instantiate(hangman_6, hangmanParent);
                isCorrect = false;
                Instantiate(eventCheck, parentUI);
                break;

        }

       
    }

    public void correctCounter(){

        for (int i = 0; i < wordLength; i++) {

            if (GameObject.Find(i.ToString()).GetComponentInChildren<TMP_Text>().alpha == 1) {

                Debug.Log(i + "Alpha is 1");

            }
            else if (GameObject.Find(i.ToString()).GetComponentInChildren<TMP_Text>().alpha == 0) {

                Debug.Log(i + "Alpha is 0");
            
            }
            
            

        }

        if (correctCount == wordLength) { 
            
            isCorrect = true;
            Instantiate(eventCheck, parentUI);

        }
    
    }


}
