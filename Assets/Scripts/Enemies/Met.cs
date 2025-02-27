﻿using UnityEngine;
using Assets.Scripts.Grid;

namespace Assets.Scripts.Enemies
{
    class Met : Enemy
    {
        [SerializeField]
        private GameObject bullet;
        [SerializeField]
        private Transform barrel;

        private Player.Player player;
        private float turn = 0;

        protected override void Initialize()
        {
            player = FindObjectOfType<Player.Player>();
        }

        protected override void RunAI()
        {
            turn += Time.deltaTime;
            if(turn > 1f)
            {
                turn = 0;
                if(player.CurrentNode.Position.x < currentNode.Position.x)
                {
                    if (!currentNode.Up.Occupied)
                    {
                        currentNode.clearOccupied();
                        currentNode = currentNode.Up;
                        currentNode.Owner = (this);
                    }
                }
                else if (player.CurrentNode.Position.x > currentNode.Position.x)
                {
                    if (!currentNode.Down.Occupied)
                    {
                        currentNode.clearOccupied();
                        currentNode = currentNode.Down;
                        currentNode.Owner = (this);
                    }
                }
                else
                {
                    Weapons.Projectiles.Bullet b = Instantiate(bullet).GetComponent<Weapons.Projectiles.Bullet>();
                    b.transform.position = barrel.position;
                    b.Direction = Direction;
                }
            }
        }
    }
}
