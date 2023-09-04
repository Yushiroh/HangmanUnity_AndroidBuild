using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class prefabScript : MonoBehaviour
{
    // Start is called before the first frame update


    public TMP_Text messageStatus;
    public Button retryPress;
    public TMP_Text wordHolder;


    public void retryButtonPressed()
    {


        SceneManager.LoadScene(0);
        Debug.Log("Retried");


    }

    void Start()
    {

      

        if (MainScript.isCorrect)
        {

            messageStatus.text = "You are Correct!";
            Debug.Log(MainScript.isCorrect);
        }
        else
        {

            messageStatus.text = "The man is Hanged!";
            wordHolder.text = "The word is: " + MainScript.theWord;
            Debug.Log(MainScript.isCorrect);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
