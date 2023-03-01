using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player
{
    private string nickname;
    //private object avatar;
    private int level;
    private int experiencePoints;
    private int healthPoints;
    private Dictionary<string, int> protectionLevels;


    //private ArrayList backpack;
    //private ArrayList subpack;
    //private bool anomaly_detector;
    //private ArrayList clothing;
    //private ArrayList coordinates;
    //private int distance_traveled;
    //если защита 0, то это 100% урона
    //защита это коэфф для дамага
    //пускай допом к уроне к дельте будет передаваться тип изменения здоровья

    public Player(string nick, int lvl, int exp, int health, Dictionary<string, int> protections)
    {
        this.nickname = nick;
        this.level = lvl;
        this.experiencePoints = exp;
        this.healthPoints = health;
        this.protectionLevels = protections;
        //foreach(var protection in protections)
        //{
        //    this.protectionLevels.Add(protection.Key, protection.Value);
        //}
    }
    ~Player()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public string GetNickname()
    {
        return this.nickname;
    }

    public void UpdateHealth(int delta)
    {
        this.healthPoints += delta;
        if (this.healthPoints <= 0)
        {
            Die();
        }
        else if(this.healthPoints >= 100)
        {
            this.healthPoints = 100;
            return;
        }
    }

    public int GetHealth()
    {
        return this.healthPoints;
    }

    public void UpdateExperience(int delta)
    {
        this.experiencePoints += delta;
    }

    public int GetExperience()
    {
        return this.experiencePoints;
    }

    public int GetLevel()
    {
        return this.level;
    }

    public void Die()
    {
        //LoadScenes.DeathScreen();
        SceneManager.LoadScene("DeathScene", LoadSceneMode.Single);
        //SceneManager.LoadScene("MenuScene");
    }

    
}

public class Mainscr : MonoBehaviour
{
    Player player = new("NIKITA", 1, 0, 100, new Dictionary<string, int>()
    {
        ["termo"] = 1,
        ["bio"] = 1,
        ["gravity"] = 1,
        ["electro"] = 1,
        ["nuclear"] = 1
    }
);
   
    public int Points;
    public Text Score;
    public Text HealthPoints;
    public Slider HealthSlider;
    public Text Time;
    public int CurrentHealth;
    private IEnumerator coroutine;
    public List<System.Func<float>> speedOverrides = new();
    public int damage;

    //current_health - это текущее здоровье игрока
    //health_points - это то, что выводится в интерфейс в здоровье
    //points - это очки пойманных артефактов
    //score - это то, что выводится в интерфейс в очки
    //Time - текущее время

    
    private void Start()
    {
        this.PrintHealth();
        this.PrintScore();
        coroutine = WaitAndPrint(2.0f);
    }

    public void PrintHealth()
    {
        this.HealthPoints.text = this.player.GetHealth().ToString();
        this.HealthSlider.value = this.player.GetHealth();
    }

    public void PrintScore()
    {
        this.Score.text = this.player.GetExperience().ToString();
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        this.damage = -10;
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            this.player.UpdateHealth(this.damage);
            Handheld.Vibrate();
            this.PrintHealth();
        }
    }

    private void OnTriggerEnter(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Anomaly"))
        {
            StartCoroutine(coroutine);
        }
    }

    private void OnTriggerStay(Collider otherCollider)
    {
        if (Input.touchCount > 0)
        {
            if (otherCollider.gameObject.CompareTag("Artifact"))
            {
                this.player.UpdateExperience(1);
                otherCollider.gameObject.SetActive(false);
                this.Score.text = this.player.GetExperience().ToString();
            }
        }
    }
    
    private void OnTriggerExit(Collider otherCollider)
    {
        if (otherCollider.gameObject.CompareTag("Anomaly"))
        {
            StopCoroutine(coroutine);
        }
    }

    public void HealPlayer()
    {
        int pointsOfHealth = 20;
        this.player.UpdateHealth(pointsOfHealth);
        this.PrintHealth();
    }

    void FixedUpdate()
    {
        int currentHours = System.DateTime.Now.TimeOfDay.Hours;
        int currentMinutes = System.DateTime.Now.TimeOfDay.Minutes;
        Time.text = currentHours.ToString() + ":" + currentMinutes.ToString();
    }
}

