using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Tile_Engine
{
    //Klasse som representerer hver plass i kartet. 
    //Hver plass har 3 lag (bakgrunn, interaktivt lag og forgrunn).
    [Serializable]
    public class MapSquare
    {
        //Deklarasjoner

        //Array som holder på bildet som vises i hvert lag. 
        public int[] LayerTiles = new int[3];
        //En string som viser hva slags bit dette er.
        public string CodeValue = "";
        //Indikerer om man kan bevege seg gjennom denne plassen (true) eller ikke (false).
        public bool Passable = false;


        //Konstruktør
        public MapSquare(int background, int interactive, int foreground, string code, bool passable)
        {
            LayerTiles[0] = background;
            LayerTiles[1] = interactive;
            LayerTiles[2] = foreground;
            CodeValue = code;
            Passable = passable;
        }


        //Metoder
        public void TogglePassable()
        {
            Passable = !Passable;
        }

        //Gjør blokken "solid"
        public void SetTileCollidable()
        {
            Passable = false;
        }
    }
}
