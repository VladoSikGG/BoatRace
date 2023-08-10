using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard8 : MonoBehaviour
{
    [SerializeField] private string[] _names;
    [SerializeField] private int[] _scores;
    [SerializeField] private string _indexLvl;
    [SerializeField] private HighscoreTable _table;

    private void Awake()
    {
        string jsonString = PlayerPrefs.GetString(_indexLvl);
        Debug.Log(jsonString);
        Highscores highscores = JsonUtility.FromJson<Highscores>(jsonString);
        if (highscores == null)
        {
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
