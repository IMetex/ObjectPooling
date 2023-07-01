using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    QuestionSO currentQuestion;

    [Header("Buttons")]
    [SerializeField] GameObject[] answerButtons;
    int correctAnswerIndex;
    string correctAnswer;
    bool hasAnsweredEarly;


    [Header("Button Color")]
    [SerializeField] Sprite correctAnswerSprite;
    [SerializeField] Sprite defaultAnswerSprite;
    TextMeshProUGUI buttonText;
    Button button;
    Image buttonImage;


    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;

    [Header("Progress Bar")]
    [SerializeField] Slider progressBar;


    [Header("Scoreing")]
    [SerializeField] TextMeshProUGUI scoreText;
    Score score;


    public bool isComplote;


    void Start()
    {
        timer = FindObjectOfType<Timer>();
        score = FindObjectOfType<Score>();

        progressBar.maxValue = questions.Count;
        progressBar.value = 0;

    }

    private void Update()
    {
        timerImage.fillAmount = timer.fillFraction;
        if (timer.loadNextQuestion)
        {
            hasAnsweredEarly = false;
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if (!hasAnsweredEarly && !timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    public void OnAnswerSelected(int index)
    {
        hasAnsweredEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
        scoreText.text = "Score: " + score.CalculateScore() + "%";

        if (progressBar.value == progressBar.maxValue)
        {
            isComplote = true;
        }
    }

    private void DisplayAnswer(int index)
    {
        // True answer 
        if (index == currentQuestion.GetCorrectAnswerIndex())
        {
            // messeage 
            questionText.text = "Tekbrikler Doğru Cevap";

            // button change image
            buttonImage = answerButtons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;

            // score plus
            score.IncrementCorrectAnswers();
        }
        // False answer
        else
        {
            // true answer get
            correctAnswerIndex = currentQuestion.GetCorrectAnswerIndex();
            correctAnswer = currentQuestion.GetAnswer(correctAnswerIndex);
            // message
            questionText.text = ("Üzgünüm yanlış cevap verdiniz, doğru cevap;\n" + correctAnswer);

            // button change image
            buttonImage = answerButtons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;

        }
    }

    private void GetNextQuestion()
    {
        if (questions.Count > 0)
        {
            SetButtonState(true);
            SetButtonDefaultSprite();
            GetRandomNextQuestion();
            DisplayQuestion();

            // Slider Bar 
            progressBar.value++;
            // Score See Count Plus
            score.IncrementQuestionSeen();
        }
    }

    private void GetRandomNextQuestion()
    {
        // random question get
        int index = Random.Range(0, questions.Count);
        currentQuestion = questions[index];

        // question delete
        if (questions.Contains(currentQuestion))
        {
            questions.Remove(currentQuestion);
        }
    }

    private void DisplayQuestion()
    {
        // question get scriptable object
        questionText.text = currentQuestion.GetQuestion();

        // question button get scriptable object
        for (int i = 0; i < answerButtons.Length; i++)
        {
            buttonText = answerButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetAnswer(i);
        }
    }


    private void SetButtonState(bool state)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            // We check the clickability of the buttons
            button = answerButtons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    private void SetButtonDefaultSprite()
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            buttonImage = answerButtons[i].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }
}
