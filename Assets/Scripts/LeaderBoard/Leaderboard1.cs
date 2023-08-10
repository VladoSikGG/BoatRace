using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard1 : MonoBehaviour
{
    [SerializeField] private string[] _names;
    [SerializeField] private int[] _scores;
    [SerializeField] private string _indexLvl;
    [SerializeField] private HighscoreTable _table;

    public void SSS()
    {
        string jsonString = PlayerPrefs.GetString(_indexLvl);
        Debug.Log(jsonString);
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        if (jsonString != string.Empty)
        {
            
            // highscores.highscoreEntryList = null;

            // _table.DeleteHighscoreEntry();

            // There's no stored table, initialize
            Debug.Log("Initializing table with default values...");
            for (int i = 0; i < 10; i++)
            {
                _table.AddHighscoreEntry(_scores[i], _names[i]);
            }
            // Reload
            jsonString = PlayerPrefs.GetString(_indexLvl);
            highscores = JsonUtility.FromJson<Highscores>(jsonString);
        }
        else
        {
            jsonString = string.Empty;

            Debug.Log("Initializing table with default values...");
            for (int i = 0; i < 10; i++)
            {
                _table.AddHighscoreEntry(_scores[i], _names[i]);
            }
           // Debug.Log(highscores);
            Debug.Log(highscores.highscoreEntryList);
            // Reload
            jsonString = PlayerPrefs.GetString(_indexLvl);
            highscores = JsonUtility.FromJson<Highscores>(jsonString);
        }
        
    }

    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }

    [System.Serializable]
    private class HighscoreEntry
    {
        public int score;
        public string name;
    }
}
