using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class character : MonoBehaviour
{
    RectTransform rect;
    Vector2 pos;

    public int health = 50;
    int mHealth;
    public int special = 20;
    int mSpecial;
    public int defence;
    public int speed;

    public Slider hBar;
    public Slider sBar;
    public Text hlt;
    public Text sp;

    public GameObject outline;
    public Texture selected;
    Texture nSelected;

    void Start(){
        rect = GetComponent<RectTransform>();
        pos = new Vector2(0, -250);
        nSelected = outline.GetComponent<RawImage>().texture;

        mHealth = health;
        hBar.maxValue = mHealth;
        mSpecial = special;
        sBar.maxValue = mSpecial;
    }

    void Update(){
        rect.anchoredPosition = pos;

        hBar.value = health;
        sBar.value = special;
        string healths = health.ToString();
        string mhealths = mHealth.ToString();
        hlt.text = healths + "/" + mhealths;
        string specials = special.ToString();
        string mspecials = mSpecial.ToString();
        sp.text = specials + "/" + mspecials;
    }


    public void attack(GameObject enemy){
        var damage = Random.Range(2, 8);
        enemy.GetComponent<enemyController>().health -= damage;

        if (special < mSpecial - 1){
            special += 2;
        }
        else{
            special = mSpecial;
        }
    }
    public void specialAttack(GameObject enemy){
        var damage = Random.Range(4, 16);
        enemy.GetComponent<enemyController>().health -= damage;
        special -= 5;
    }


    public void startTurn(){
        pos = new Vector2(pos.x, -250);
        outline.GetComponent<RawImage>().texture = selected;
    }
    public void endTurn(){
        pos = new Vector2(pos.x, -575);
        outline.GetComponent<RawImage>().texture = nSelected;
    }
}