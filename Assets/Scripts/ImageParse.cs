using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft.Json;
using UnityEngine.Networking;


public class ImageParse : MonoBehaviour
{
    public CardImages _cardImages = new CardImages();
    string imageURL = "https://drive.google.com/uc?export=download&id=1sS2AAJczhoxKzpEyJxLU7HEJ34n8dzLD";
    public Texture[] image = new Texture[3];
    
   
    
    IEnumerator GetData(string url)
    {
        UnityWebRequest request = UnityWebRequest.Get (url);
        
        yield return request.Send();
        if (request.isNetworkError)
        {

        }
        else
        {
            _cardImages = JsonUtility.FromJson<CardImages>(request.downloadHandler.text);
            
            StartCoroutine(GetImage(_cardImages.ImageURL, 0));
            StartCoroutine(GetImage(_cardImages.ImageURL1, 1));
            StartCoroutine(GetImage(_cardImages.ImageURL2, 2));
        }
        request.Dispose();
    }

   
    
    
    IEnumerator GetImage(string url, int number)
    {
        yield return new WaitForSecondsRealtime(2);
        UnityWebRequest request = UnityWebRequestTexture.GetTexture (url);
        yield return request.Send();

        if (request.isNetworkError)
        {

        }
        else
        {
            image[number] = (((DownloadHandlerTexture)request.downloadHandler).texture);

        }
        
        request.Dispose();
        yield return new WaitForSecondsRealtime(2);

    }
    void Start()
    {
        image = new Texture[3];
        StartCoroutine(GetData(imageURL));
    }
}
