﻿using System.Diagnostics;

namespace SpaceInvaders
{
    public class BoxSprite : SpriteBase
    {
        public enum Name
        {
            Box1,
            Box2,
            Uninitialized
        }

        public float x;
        public float y;
        public float sx;
        public float sy;
        public float angle;
        public Name name;
        public Azul.Color poLineColor;
        private Azul.SpriteBox poAzulBoxSprite;
        static private Azul.Rect psTmpRect = new Azul.Rect();
        static private Azul.Color psTmpColor = new Azul.Color(1, 1, 1);

        public BoxSprite()
        : base()  
        {
            this.name = BoxSprite.Name.Uninitialized;

            Debug.Assert(BoxSprite.psTmpRect != null);
            BoxSprite.psTmpRect.Set(0, 0, 1, 1);
            Debug.Assert(BoxSprite.psTmpColor != null);
            BoxSprite.psTmpColor.Set(1, 1, 1);

            // Here is the actual new
            this.poAzulBoxSprite = new Azul.SpriteBox(psTmpRect, psTmpColor);
            Debug.Assert(this.poAzulBoxSprite != null);

            // Here is the actual new
            this.poLineColor = new Azul.Color(1, 1, 1);
            Debug.Assert(this.poLineColor != null);

            this.x = poAzulBoxSprite.x;
            this.y = poAzulBoxSprite.y;
            this.sx = poAzulBoxSprite.sx;
            this.sy = poAzulBoxSprite.sy;
            this.angle = poAzulBoxSprite.angle;
        }

        //---------------------------------------------------------------------------------------------------------
        // Methods
        //---------------------------------------------------------------------------------------------------------
        public void Set(BoxSprite.Name name, float x, float y, float width, float height, Azul.Color pLineColor)
        {
            Debug.Assert(this.poAzulBoxSprite != null);
            Debug.Assert(this.poLineColor != null);

            Debug.Assert(psTmpRect != null);
            BoxSprite.psTmpRect.Set(x, y, width, height);

            this.name = name;

            if (pLineColor == null)
            {
                this.poLineColor.Set(1, 1, 1);
            }
            else
            {
                this.poLineColor.Set(pLineColor);
            }

            this.poAzulBoxSprite.Swap(psTmpRect, this.poLineColor);

            this.x = poAzulBoxSprite.x;
            this.y = poAzulBoxSprite.y;
            this.sx = poAzulBoxSprite.sx;
            this.sy = poAzulBoxSprite.sy;
            this.angle = poAzulBoxSprite.angle;
        }
        private void ClearNode()
        {
            this.name = BoxSprite.Name.Uninitialized;

            // NOTE:
            // Do not null the poAzulBoxSprite it is created once in Default then reused
            // Do not null the poLineColor it is created once in Default then reused

            this.poLineColor.Set(1, 1, 1);

            this.x = 0.0f;
            this.y = 0.0f;
            this.sx = 1.0f;
            this.sy = 1.0f;
            this.angle = 0.0f;
        }
        public void SwapColor(Azul.Color _pColor)
        {
            Debug.Assert(_pColor != null);
            this.poAzulBoxSprite.SwapColor(_pColor);
        }
        public void Wash()
        {
            this.ClearNode();
        }
        public void SetName(BoxSprite.Name inName)
        {
            this.name = inName;
        }
        public BoxSprite.Name GetName()
        {
            return this.name;
        }
        public void Dump()
        {
            Debug.WriteLine("   Name: {0} ({1})", this.name, this.GetHashCode());
            Debug.WriteLine("      Color(r,b,g): {0},{1},{2} ({3})", this.poLineColor.red, this.poLineColor.green, this.poLineColor.blue, this.poLineColor.GetHashCode());
            Debug.WriteLine("        AzulSprite: ({0})", this.poAzulBoxSprite.GetHashCode());
            Debug.WriteLine("             (x,y): {0},{1}", this.x, this.y);
            Debug.WriteLine("           (sx,sy): {0},{1}", this.sx, this.sy);
            Debug.WriteLine("           (angle): {0}", this.angle);

            if (this.pNext == null)
            {
                Debug.WriteLine("              next: null");
            }
            else
            {
                BoxSprite pTmp = (BoxSprite)this.pNext;
                Debug.WriteLine("              next: {0} ({1})", pTmp.name, pTmp.GetHashCode());
            }

            if (this.pPrev == null)
            {
                Debug.WriteLine("              prev: null");
            }
            else
            {
                BoxSprite pTmp = (BoxSprite)this.pPrev;
                Debug.WriteLine("              prev: {0} ({1})", pTmp.name, pTmp.GetHashCode());
            }
        }

        //---------------------------------------------------------------------------------------------------------
        // Methods
        //---------------------------------------------------------------------------------------------------------
        public override void Update()
        {
            this.poAzulBoxSprite.x = this.x;
            this.poAzulBoxSprite.y = this.y;
            this.poAzulBoxSprite.sx = this.sx;
            this.poAzulBoxSprite.sy = this.sy;
            this.poAzulBoxSprite.angle = this.angle;

            this.poAzulBoxSprite.Update();
        }

        public override void Render()
        {
            this.poAzulBoxSprite.Render();
        }
    }
}



