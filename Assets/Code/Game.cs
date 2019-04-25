using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    private Player player;

    private List<Enemy> enemies;

    private void Start()
    {
        player = new Player();

        enemies = new List<Enemy>();
        for(int i = 0; i < 1; ++i)
        {
            enemies.Add(new Enemy(new DevMath.Vector2(Random.Range(.0f, Screen.width), Random.Range(.0f, Screen.height))));
        }
    }

    private void OnGUI()
    {
        player.Render();

        enemies.ForEach(e => e.Render());
    }

    private void Update()
    {
        player.Update();

        enemies.ForEach(e => e.Update(player));
    }
}
