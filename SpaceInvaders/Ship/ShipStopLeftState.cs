﻿using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ShipStopLeftState : ShipState
    {
        public override void Handle(Ship pShip)
        {
            
            pShip.SetState(ShipManager.State.Ready);
         
        }

        public override void MoveRight(Ship pShip)
        {
            pShip.x += pShip.shipSpeed;
            this.Handle(pShip);
        }

        public override void MoveLeft(Ship pShip)
        {
            
        }

        public override void ShootMissile(Ship pShip)
        {
            Missile pMissile = ShipManager.ActivateMissile();

            pMissile.SetPos(pShip.x, pShip.y + 20);
            pMissile.SetActive(true);

            // switch states
            //this.Handle(pShip);
            pShip.SetState(ShipManager.State.StopLeftMissileFlying);
        }
    }
}