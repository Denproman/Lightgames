using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardClick : MonoBehaviour
{
    [SerializeField] private ImageParse imgParse;
    [SerializeField] private ImageNumber imgNumber;
    [SerializeField] private ImageToCard imgTocard;

    [SerializeField] private int pairsDone;
    [SerializeField] private Text pairsNumber;

    [SerializeField] private Transform colLeftObj;
    [SerializeField] private Transform colRightObj;

    [SerializeField] private List<Transform> leftColBut;
    [SerializeField] private List<Transform> rightColBut;

    [SerializeField] private RawImage LeftImage;
    [SerializeField] private RawImage RightImage;

    [SerializeField] private bool isFirstStart;

    [SerializeField] private float invokeDelay;

    void Start()
    {
        GetLeftColButtons();
        GetRightColButtons();
        pairsDone = 0;
        isFirstStart = true;
    }

    private void Update()
    {
        if (isFirstStart && imgParse.image[imgParse.image.Length - 1] != null)
        {
            StartGame();
            isFirstStart = false;      
        }
        if (RightImage != null && RightImage.transform.parent.transform.rotation.y == 0)
        {
            OnCompareCards();
            OnPairDone();
            if (pairsDone == 3)
            {
                Invoke("StartGame", invokeDelay);
            }
        }
    }


    void GetLeftColButtons()
    {
        for (int i = 0; i < colLeftObj.childCount; i++)
        {
            leftColBut.Add(colLeftObj.GetChild(i).GetChild(0).transform);
        }
    }

    void GetRightColButtons()
    {
        for (int i = 0; i < colRightObj.childCount; i++)
        {
            rightColBut.Add(colRightObj.GetChild(i).GetChild(0).transform);
        }
    }

    public void OnLeftCardClick()
    {
       
        if (LeftImage == null)
        {
            LeftImage = EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponentInChildren<RawImage>();
            StartCoroutine(GenericAnimation(LeftImage.transform.parent.transform, new Vector3(0, 180, 0), new Vector3(0, 0, 0)));
        }
        else
            return;
    }

    public void OnRightCardClick()
    {
        if (RightImage == null && LeftImage != null)
        {
            RightImage = EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponentInChildren<RawImage>();
            StartCoroutine(GenericAnimation(RightImage.transform.parent.transform, new Vector3(0, 180, 0), new Vector3(0, 0, 0)));
        }
        else
            return;
    }

    private void OnCompareCards()
    {
        if (LeftImage != null && RightImage != null)
        {
            if (LeftImage.texture == RightImage.texture)
            {           
                LeftImage.transform.parent.parent.GetComponent<Button>().interactable = false;
                RightImage.transform.parent.parent.GetComponent<Button>().interactable = false;
            }
            else 
            {
                StartCoroutine(GenericAnimation(LeftImage.transform.parent.transform, new Vector3(0, 0, 0), new Vector3(0, 180, 0)));
                StartCoroutine(GenericAnimation(RightImage.transform.parent.transform, new Vector3(0, 0, 0), new Vector3(0, 180, 0)));   
            }
        }
    }

    private void OnPairDone()
    {
        if (LeftImage.texture == RightImage.texture)
        {
            pairsDone++;
            pairsNumber.text = pairsDone.ToString();
            
        }
        LeftImage = null;
        RightImage = null;
    }

   
    private void StartGame()
    {
        if (pairsNumber.text == 3.ToString())
        {
            pairsDone = 0;
            pairsNumber.text = pairsDone.ToString();

          
        }
        if (pairsDone == 0)
        {
            if(!isFirstStart)
            {
                imgNumber.cardContentLeft.Clear();
                imgNumber.cardContentRight.Clear();
                imgTocard.cardImageLeft.Clear();
                imgTocard.cardImageRight.Clear();
                imgNumber.RandomNumberLeft();
                imgNumber.RandomNumberRight();
                imgTocard.ImageElemLeft();
                imgTocard.ImageElemRight();
            }

           
            //imgTocard.SetImgToLeftCard();
            //imgTocard.SetImgToRightCard();

            Invoke("HideAnim", 5f);
            
            for (int i = 0; i < leftColBut.Count; i++)
            {              
                leftColBut[i].transform.parent.GetComponent<Button>().interactable = true;
            }
            for (int i = 0; i < rightColBut.Count; i++)
            {
                rightColBut[i].transform.parent.GetComponent<Button>().interactable = true;
            }
        }
    }

    public void HideAnim()
    {
        for (int i = 0; i < leftColBut.Count; i++)
        {
            StartCoroutine(GenericAnimation(leftColBut[i].transform, new Vector3(0, 0, 0), new Vector3(0, 180, 0)));
            StartCoroutine(GenericAnimation(rightColBut[i].transform, new Vector3(0, 0, 0), new Vector3(0, 180, 0)));
        }
    }


    public IEnumerator GenericAnimation(Transform img, Vector3 start, Vector3 end) 
    {
        
        Vector3 StartRot = start;
        Vector3 EndRot = end;

        float elapseTime = 0;
        float progress = 0;
        while (progress <= 1)
        {
            img.rotation = Quaternion.Euler(Vector3.Lerp(StartRot, EndRot, progress));
            elapseTime += Time.deltaTime;
            progress = elapseTime / 1f;
           
            yield return null;
        }
        img.rotation = Quaternion.Euler(EndRot);
        
    }
}
