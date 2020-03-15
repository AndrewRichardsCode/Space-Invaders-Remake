﻿using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class GameOverEvent : Command
    {
        public override void Execute(float deltaTime)
        {
            SpaceInvaders.pSceneContext.GetState().Handle();
        }

    }
}
