using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class GameManager : MonoBehaviour
{
    public AudioSource music;
    public bool startPlaying;
    public BeatScroller beatScroll;
    public static GameManager GMinstance;
    public int currentCount;
    public Text countText;

    public List<GameObject> notes;
    public Transform noteParent;
    public List<Vector3> spawnPositions;
    public float interval = 2;
    float timer;
    bool startedGenerating = false;
    float counter;
    bool activeGenerating = false;
    int lowerBound = 0;
    int upperBound = 4;

    // Start is called before the first frame update
    void Start()
    {
        interval = .5f;
        GMinstance = this;
        countText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if(!startPlaying)
        {
            if(Input.anyKeyDown)
            {
                startPlaying = true;
                beatScroll.hasStarted = true;

                music.Play();
            }
        }

        if(startPlaying)
        {
            if(!startedGenerating)
            {
                Debug.Log("starting");

                if(!activeGenerating)
                {
                    activeGenerating = true;
                }
                startedGenerating = true;
                counter = 0f;               
            }
        }

        if(activeGenerating)
        {
            timer += Time.deltaTime;
            if (timer >= interval)
            {
                int i = Random.Range(lowerBound,upperBound);
                int chordchance = Random.Range(0,100);                
                counter++;
                var newNote = Instantiate(notes[i], spawnPositions[i], Quaternion.identity);
                if(chordchance <=15) // 30% chance
                {
                    int j = Random.Range(lowerBound,upperBound);
                    if(j != i) // no doubles 
                    {
                        var comboNote = Instantiate(notes[j], spawnPositions[j], Quaternion.identity);
                        comboNote.transform.SetParent(noteParent.transform);
                    }

                } 
                Debug.Log(spawnPositions[i]);
                newNote.transform.SetParent(noteParent.transform);
                timer -= interval;   
            }

            if(counter > 100)
            {
                activeGenerating = false;
            }
        }
    }

    public void NoteHit()
    {
        Debug.Log("Hit on time");
        currentCount++;
        countText.text = $"{currentCount}";
    }

    public void NoteMissed()
    {
        Debug.Log("Missed");
        currentCount = 0;
        countText.text = $"{currentCount}";
    }
    
    public void BadPress()
    {
        Debug.Log("BadPress");
        currentCount = 0;
        countText.text = $"{currentCount}";
    }
}
