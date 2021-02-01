using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageToCard : MonoBehaviour
{

    public ImageParse imgParse;

    public ImageNumber text;

    public Transform colLeft;
    public Transform colRight;
    
    public List<Text> cardTextLeft;
    public List<Text> cardTextRight;

    public List<RawImage> cardImageLeft;
    public List<RawImage> cardImageRight;


    void Start()
    {
        /*TextElemLeft();
        TextElemRight();
        SetImageToLeftCard();
        SetImageToRightCard();*/

        ImageElemLeft();
        ImageElemRight();

    }

    void Update()
    {

        SetImgToLeftCard();
        SetImgToRightCard();
    }

    public void ImageElemLeft()
    {
        for (int i = 0; i < colLeft.childCount; i++)
        {
            cardImageLeft.Add(colLeft.GetChild(i).GetChild(0).GetComponentInChildren<RawImage>());
        }
    }
    public void ImageElemRight()
    {
        for (int i = 0; i < colRight.childCount; i++)
        {
            cardImageRight.Add(colRight.GetChild(i).GetChild(0).GetComponentInChildren<RawImage>());
        }
    }

    public void SetImgToLeftCard()
    {
        for (int i = 0; i < cardImageLeft.Count; i++)
        {
            int num = text.cardContentLeft[i];
            cardImageLeft[i].texture = imgParse.image[num];
        }
    }

    public void SetImgToRightCard()
    {
        for (int i = 0; i < cardImageRight.Count; i++)
        {
            int num = text.cardContentRight[i];
            cardImageRight[i].texture = imgParse.image[num];
        }
    }

}
