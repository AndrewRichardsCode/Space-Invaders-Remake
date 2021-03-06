﻿using System;


namespace SpaceInvaders
{
    class RemoveLifeObserver : CollisionObserver
    {
        private int count;

        public RemoveLifeObserver() {
            this.count = 1;
        }


        public override void Notify()
        {
            //-------RemoveLife-------
            ScenePlay.ShipLives--;
            this.count++;
            
            PlayerLivesComposite pNullObjs = (PlayerLivesComposite)GameObjectManager.Find(GameObject.Name.Null_Object);
            pNullObjs.RemoveLife(count);

            if (this.count > 2)
            {
                this.count = 1;
            }
        }
    }
}
