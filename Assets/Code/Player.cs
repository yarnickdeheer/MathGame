using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Player
{
    private Texture2D visual;
    public DevMath.Vector2 Position
    {
        get; private set;
    }

    public DevMath.Vector2 Direction => new DevMath.Vector2(Mathf.Cos(DevMath.DevMath.DegToRad(Rotation)), Mathf.Sin(DevMath.DevMath.DegToRad(Rotation)));
    
    public float Rotation
    {
        get; private set;
    }

    private readonly float moveSpeed = 500.0f;

    public Player()
    {
        visual = Resources.Load<Texture2D>("pacman");

        Position = new DevMath.Vector2(Screen.width * .5f - visual.width * .5f, Screen.height * .5f - visual.height * .5f);
    }

    public void Render()
    {
        GUIUtility.RotateAroundPivot(Rotation, (Position + new DevMath.Vector2(visual.width * .5f, visual.height * .5f)).ToUnity());

        GUI.DrawTexture(new Rect(Position.x, Position.y, visual.width, visual.height), visual);

        GUI.matrix = Matrix4x4.identity;
    }

    public void Update()
    {
        var moveDirection = new DevMath.Vector2(Input.GetAxis("Horizontal"), -Input.GetAxis("Vertical"));
        moveDirection = moveDirection.Normalized;

        Position += moveDirection * moveSpeed * Time.deltaTime;

        var mousePos = new DevMath.Vector2(Input.mousePosition.x, Screen.height - Input.mousePosition.y);
        var mouseDir = (mousePos - Position).Normalized;

        Rotation = DevMath.DevMath.RadToDeg(DevMath.Vector2.Angle(new DevMath.Vector2(.0f, .0f), mouseDir));
    }
}
