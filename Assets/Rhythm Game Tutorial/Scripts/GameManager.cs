using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using MidiPlayerTK;


public class GameManager : MonoBehaviour
{
    public AudioSource theMusic;
    public bool startPlaying;
    public BeatScroller theBS;
    public static GameManager instance;
    public int Puntos;
    public int scorePerNote = 100;
    public int scorePerGoodNote = 120;
    public int scorePerPerfectNote = 150;
    public Text Score;
    public Text ComboText;
    public Animator cameramove;
    public Animator RedFlash;
    public AudioSource audioSource;
    public AudioClip kick;
    public AudioClip missed;
    public shake shak3;
    public GameObject Ratings;
    public GameObject RatingsGood;
    public GameObject RatingsOk;
    public GameObject RatingsMiss;
    public Transform RatingsPos;
    public Transform RatingsPosMiss;
    public int combo = 0;
    public int multiplicador = 0;
    public MidiFilePlayer audPlayer;
    public float delay = 3;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        startPlaying = false;
        Puntos = 0;
        Score.text = "Score: n/a";

        

    }

    public void NoteHit()

    {
        if (combo > 0)
        {
            if (combo % 10 == 0)
            {
                multiplicador++;


            }
        }
        if (combo == 0)
            combo++;

        
        Debug.Log("Hit On Time");
        Debug.Log("Multiplicador = " + multiplicador);
       
        Score.text = "Score: " + Puntos;
        ComboText.text = "Combo: " + combo;
        Debug.Log("Points " + "= " + Puntos);
        audioSource.PlayOneShot(kick, 2F);
        combo++;
        
    }
    public void PerfectHit()

    {
        
        Puntos = scorePerPerfectNote * multiplicador + Puntos;
        Debug.Log("Was Perfect");
        NoteHit();
        Destroy(Instantiate(Ratings, RatingsPos.position, Quaternion.identity), 20);
        
        
    }
    public void GoodtHit()
    {
        Puntos = scorePerGoodNote * multiplicador + Puntos;
        Debug.Log("Was Good");
        NoteHit();
        Destroy(Instantiate(RatingsGood, RatingsPos.position, Quaternion.identity), 20);
    }
    public void NormaltHit()
    {
        Puntos = scorePerNote  * multiplicador + Puntos;
        Debug.Log("Was Normal");
       
        NoteHit();
        Destroy(Instantiate(RatingsOk, RatingsPos.position, Quaternion.identity), 20);
    }

    public void NoteMissed()
    {
        Debug.Log("Missed note");
        audioSource.PlayOneShot(missed, 2F);
        shak3.Shake(0.2f, 0.2f);
        RedFlash.SetTrigger("redflash");
        combo = combo - combo;
        multiplicador = 1;
        Destroy(Instantiate(RatingsMiss,RatingsPosMiss.position, Quaternion.identity), 20);
    }
    
    // Update is called once per frame
    void Update() 
    {
     if (!startPlaying)
        {
            
            
            if (Input.anyKeyDown)
            {
                startPlaying = true;
                theBS.hasStarted = true;
                
                //cameramove.Play("CameraMovement");
                //cameramove.SetTrigger("cameramove");
                Invoke("PlayAudioDelayed",delay);



            }
        }   
    }

    void PlayAudioDelayed()
    {
        //audPlayer.MPTK_Play();
        theMusic.Play();
    }

}
