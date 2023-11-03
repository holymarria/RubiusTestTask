using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class Rotate : MonoBehaviour
{
    [SerializeField] private Transform Card1, Card2, Card3, Card4;
    private string TextureURL = "https://picsum.photos/800/533";
    //[SerializeField] private Sprite Pic;
    [SerializeField] private List< SpriteRenderer> SpriteRenderer;
    public Button button;
    public TMP_Dropdown dropdown;
    public GameObject Cards;
    public GameObject ByDownload;
    
    void Start()
    {
        ByDownload.SetActive(false);
        Cards.SetActive(true);

        transform.DOMove(new Vector3(333, 181.6017f, 0), 1.0f, false).SetEase(Ease.OutBounce);
    }
    public void Load()
    {
        StartCoroutine(DownloadImage(TextureURL));

    }

    public void Animation1Load()
    {
        
        StartCoroutine(Animation1());

    }
    public void Animation2Load()
    {
       
        StartCoroutine(Animation2());
    }
    public void EnableButton()
    {
        StartCoroutine(ButtonDelay(8.5f));
    }
    public void EnableDropDown() 
    {
        StartCoroutine(DropDownDelay(8.5f));
    }
    public void DropDown(int val) 
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(Load);
        btn.onClick.AddListener(EnableButton);
        if (val == 0)
        {
            Cards.SetActive(true);
            ByDownload.SetActive(false);
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(Load);
            btn.onClick.AddListener(EnableButton);
            btn.onClick.AddListener(EnableDropDown);
            btn.onClick.AddListener(Animation1Load);
        }
        if(val == 1)
        {
            Cards.SetActive(true);
            ByDownload.SetActive(false);
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(Load);
            btn.onClick.AddListener(EnableButton);
            btn.onClick.AddListener(EnableDropDown);
            btn.onClick.AddListener(Animation2Load);
            
        }
        if (val == 2) 
        {
            btn.onClick.RemoveAllListeners();
            Cards.SetActive(false);
            ByDownload.SetActive(true);
            ButtonFor3 buttonFor3 = button.GetComponent<ButtonFor3>();
            if (buttonFor3 != null) 
            {
                btn.onClick.AddListener(buttonFor3.ExecuteCodeOnObjects);
                btn.onClick.AddListener(buttonFor3.EnableButton);
                btn.onClick.AddListener(buttonFor3.EnableDropDown);

            }
        }
    }
    IEnumerator DownloadImage(string Link)
    {
        for(int i = 0; i < Mathf.Min(SpriteRenderer.Count); i++) 
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
                SpriteRenderer[i].sprite = newSprite;


            }
        }
        

    }
    
    IEnumerator Animation1()
    {
        yield return new WaitForSeconds(3);
    
        Card1.DORotate(new Vector3(0f, 180f, 0), 0.5f, RotateMode.Fast).SetEase(Ease.OutBounce);
        Card2.DORotate(new Vector3(0f, 180f, 0), 0.5f, RotateMode.Fast).SetEase(Ease.OutBounce);
        Card3.DORotate(new Vector3(0f, 180f, 0), 0.5f, RotateMode.Fast).SetEase(Ease.OutBounce);
        Card4.DORotate(new Vector3(0f, 180f, 0), 0.5f, RotateMode.Fast).SetEase(Ease.OutBounce).OnComplete(() => {
            StartCoroutine(Close());
        });
    }
    
    IEnumerator Animation2()
    {
        
        yield return new WaitForSeconds(3);
        Card1.DORotate(new Vector3(0f, 180f, 0), 0.5f, RotateMode.Fast).SetEase(Ease.OutBounce).OnComplete(() =>
        {
            Card2.DORotate(new Vector3(0f, 180f, 0), 0.5f, RotateMode.Fast).SetEase(Ease.OutBounce).OnComplete(() =>
            {
                Card3.DORotate(new Vector3(0f, 180f, 0), 0.5f, RotateMode.Fast).SetEase(Ease.OutBounce).OnComplete(() =>
                {
                    Card4.DORotate(new Vector3(0f, 180f, 0), 0.5f, RotateMode.Fast).SetEase(Ease.OutBounce).OnComplete(() => { 
                        StartCoroutine(Close()); 
                    }); 

                });
            });
        });
    }
    IEnumerator Close()
    {
        yield return new WaitForSeconds(3.5f);
        Card1.DORotate(new Vector3(0f, 360f, 0), 0.5f, RotateMode.Fast).SetEase(Ease.OutBounce);
        Card2.DORotate(new Vector3(0f, 360f, 0), 0.5f, RotateMode.Fast).SetEase(Ease.OutBounce);
        Card3.DORotate(new Vector3(0f, 360f, 0), 0.5f, RotateMode.Fast).SetEase(Ease.OutBounce);
        Card4.DORotate(new Vector3(0f, 360f, 0), 0.5f, RotateMode.Fast).SetEase(Ease.OutBounce);
    }
    IEnumerator ButtonDelay(float delay)
    {
        Button btn = button.GetComponent<Button>();
        btn.interactable = false;
        yield return new WaitForSeconds(delay);
        btn.interactable = true;
    }
    IEnumerator DropDownDelay(float delay)
    {
        dropdown.interactable = false;
        yield return new WaitForSeconds(delay);
        dropdown.interactable = true;
    }
}

    
