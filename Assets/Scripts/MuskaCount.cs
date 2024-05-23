using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MuskaCount : MonoBehaviour
{
    private int muskaCount = 0;
    [SerializeField] TextMeshProUGUI muskaText;

    public void increaseMuskaCount() {

        muskaCount++;
        muskaText.text = "Muska Sayisi: "+ muskaCount.ToString(); 
    }

    public void decreaseMuskaCount()
    {
        if (muskaCount > 0)
        {
            muskaCount--;
            muskaText.text = "Muska Sayisi: " + muskaCount.ToString();
        }
        else {

            Debug.Log("There is no more muska!");
        }
    }

    public bool checkMuskaCount() {

        if (muskaCount <= 0)
        {

            return false;
        }
        else {
            return true;
        }
    }

}
