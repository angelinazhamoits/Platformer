using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerSpace
{
    public class GameController : MonoBehaviour
    {
        public static GameController Y;
        [SerializeField] private MovingEnemy _enemy;
            
        [Header("Fruits")] private int _points;
        [SerializeField] private int _kiwiPrice;
        [SerializeField] private int _applePrice;
        [SerializeField] private TextMeshProUGUI _summ;

        [Header("Enemies")] [SerializeField] private int _killedEnemies;
        [SerializeField] private TextMeshProUGUI _enemies;

        [Header("Health")] private int _health = 3;
        public Image[] hearts;
        public Sprite fullHeart;
        public Sprite emptyHeart;
        

        private void Awake() => Y = this;

        public void PointCounter(FruitType fruitType)
        {
            switch (fruitType)
            {
                case FruitType.Kiwi:
                    _points += _kiwiPrice;
                    break;
                case FruitType.Apple:
                    _points += _applePrice;
                    break;
            }
            Summ();
        }

        private void Summ()
        {
            _summ.text = $"{_points}";
        }

        internal void Health()
        {
            _health -= 1;
            if (_health <= 0)
            {
                Menu.Z.GameOver();
            }

            for (int i = 0; i < hearts.Length; i++)
            {
                if (i < _health)
                {
                    hearts[i].sprite = fullHeart;
                }
                else
                {
                    hearts[i].sprite = emptyHeart;
                }
            }
        }
    }
}
