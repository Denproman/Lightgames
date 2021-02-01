using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageNumber : MonoBehaviour
{
   
    public List<Text> card;  
    public List<int> cardContentLeft;
    public List<int> cardContentRight;
    public int cardNumber = 3;

    private void Start()
    {
        RandomNumberLeft();
        RandomNumberRight();
    }


    public void RandomNumberLeft()
    {
        for (int i = 0; i < cardNumber; i++)
        {
            int a = Random.Range(0, cardNumber);
            if (!cardContentLeft.Contains(a))
            {
                cardContentLeft.Add(a);
            }
            else
            {
                i--;
            }

        }
    }

    public void RandomNumberRight()
    {
        for (int i = 0; i < cardNumber; i++)
        {
            int a = Random.Range(0, cardNumber);
            if (!cardContentRight.Contains(a) && cardContentLeft[i] != a)
            {
                cardContentRight.Add(a);
            }
            else
            {
                i--;
            }

        }
    }
}
