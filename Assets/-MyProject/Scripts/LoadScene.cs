using UnityEngine;
using UnityEngine.SceneManagement;
using DentedPixel;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    #region Variables
    //============================
    //Public Variables
    //============================
    public string gameScene; //Scene to Load
    public GameObject fadeScreen;
    public Image screen;
 

    //==============================
    //Private Variables
    //==============================
    [SerializeField] private RectTransform _fadeScreenRectTransform;

    [Header("Fade Settings")]
    [SerializeField] [Range(0.1f, 3.0f)] private float _fadeInTime = 1.0f;
    //[SerializeField] [Range(0.1f, 3.0f)] private float _fadeOutTime = 1.0f;


    #endregion


    public void Start()
    {
        screen.canvasRenderer.SetAlpha (0.0f);
    }

    
    public void executeScene()
    {
        screen.CrossFadeAlpha(1.0f, 1.5f, false);
        var seq = LeanTween.sequence();
        seq.append(4f); //delay everything 6 second
        seq.append(() =>
        { //fire an event
            FadeOutCam();
        });
       seq.append(5f); //delay everything 5 second
        seq.append(() =>
        { //fire an event
            FadeInCam();
        });
    }

   


    //====================================================


    #region Own Method
    public void LoadNextScene()
    {
        
        Debug.Log("Loading...: " + gameScene);
        SceneManager.LoadScene(gameScene);
    }

    public void FadeInCam()
    {
           
            LeanTween.alpha(_fadeScreenRectTransform, to: 0f, _fadeInTime);

    }

    public void FadeOutCam()
    {
  
           // LeanTween.alpha(_fadeScreenRectTransform, to: 1f, _fadeOutTime);
            Invoke("LoadNextScene", 0.5f);

    }
    #endregion
}
