using UnityEngine;
using UnityEngine.Events;

public class BirdScore : MonoBehaviour
{
    private int _score;

    public event UnityAction<int> ScoreChanged;

    public int Score => _score;

    private void Awake()
    {
        Reset();
    }

    public void Reset()
    {
        _score = 0;
        ScoreChanged?.Invoke(Score);
    }
    
    public void AddScorePoint(int reward)
    {
        _score += reward;
        ScoreChanged?.Invoke(Score);
    }
}