using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField nameInput;




    public void StartNew()
    {
        MyData.Instance.playerName = nameInput.text;
        SceneManager.LoadScene(1);
        
    }


}
