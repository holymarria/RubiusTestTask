using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using DG.Tweening;
using UnityEngine.UI;
public class Pics : MonoBehaviour
{

    private string TextureURL = "https://picsum.photos/800/533";
    [SerializeField] private Sprite Pic;
    [SerializeField] private SpriteRenderer SpriteRenderer;
    [SerializeField] private Transform Card;
    public Button button;
    private Coroutine Loaded;

    public void Load()
    {
        Loaded = StartCoroutine(DownloadImage(TextureURL));
        Close();
    }
    public void EnableButton()
    {
        StartCoroutine(ButtonDelay(8.5f));
    }

    IEnumerator DownloadImage(string Link)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(Link);
        yield return request.SendWebRequest();
        if (request.isNetworkError || request.isHttpError)
        {

            Debug.Log("no signal");
        }
        else
        {
            Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
            Sprite newSprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            if (newSprite != Pic)
            {
               
                Debug.Log("Sprite has changed");
                Card.DORotate(new Vector3(0f, 180f, 0), 0.5f, RotateMode.Fast).SetEase(Ease.OutBounce).OnComplete(() =>
                {
                    StartCoroutine(Close());
                });
                Pic = newSprite; 
            }

            SpriteRenderer.sprite = newSprite;
        
        }
            
    }
    IEnumerator Close()
    {
        yield return new WaitForSeconds(3.5f);
        Card.DORotate(new Vector3(0f, 360f, 0), 0.5f, RotateMode.Fast).SetEase(Ease.OutBounce);
    }
    IEnumerator ButtonDelay(float delay)
    {
        Button btn = button.GetComponent<Button>();
        btn.interactable = false;
        yield return new WaitForSeconds(delay);
        btn.interactable = true;
    }
}