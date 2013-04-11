using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;
using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Tile_Engine
{
    public static class TileMap
    {
        /*Deklarasjoner*/
        public const int TileWidth = 48;
        public const int TileHeight = 48;
        public const int MapWidth = 40;
        public const int MapHeight = 12;
        public const int MapLayers = 3;
        private const int skyTile = 2;

        //2D-array som inneholder hver "celle" i kartet
        //der hver "celle" består av 3 lag
        private static MapSquare[,] mapCells = new MapSquare[MapWidth, MapHeight];

        public static bool EditorMode = true;

        public static SpriteFont spriteFont;
        private static Texture2D tileSheet;

        /*Initialisering*/
        public static void Initialize(Texture2D tileTexture)
        {
            tileSheet = tileTexture;
            //Sett alle lagene i hver "celle" standardbildet (skyTile).
            for (int x = 0; x < MapWidth; x++)
            {
                for (int y = 0; y < MapHeight; y++)
                {
                    for (int z = 0; z < MapLayers; z++)
                    {
                        mapCells[x, y] = new MapSquare(skyTile, 0, 0, "", true);
                    }
                }
            }
        }



        /*Nyttig info om kartet*/
        public static int TilesPerRow
        {
            get { return tileSheet.Width / TileWidth; }
        }

        public static Rectangle TileSourceRectangle(int tileIndex)
        {
            return new Rectangle(
                (tileIndex % TilesPerRow) * TileWidth,
                (tileIndex / TilesPerRow) * TileHeight,
                TileWidth,
                TileHeight);
        }



        /*Informasjon om cellene*/
        public static int GetCellByPixelX(int pixelX)
        {
            return pixelX / TileWidth;
        }

        public static int GetCellByPixelY(int pixelY)
        {
            return pixelY / TileHeight;
        }

        public static Vector2 GetCellByPixel(Vector2 pixelLocation)
        {
            return new Vector2(
                GetCellByPixelX((int)pixelLocation.X),
                GetCellByPixelY((int)pixelLocation.Y));
        }

        public static Vector2 GetCellCenter(int cellX, int cellY)
        {
            return new Vector2((cellX * TileWidth) + (TileWidth / 2), (cellY * TileHeight) + (TileHeight / 2));
        }

        public static Vector2 GetCellCenter(Vector2 cell)
        {
            return GetCellCenter(
                (int)cell.X,
                (int)cell.Y);
        }

        public static Rectangle CellWorldRectangle(int cellX, int cellY)
        {
            return new Rectangle(
                cellX * TileWidth,
                cellY * TileHeight,
                TileWidth,
                TileHeight);
        }

        public static Rectangle CellWorldRectangle(Vector2 cell)
        {
            return CellWorldRectangle((int)cell.X, (int)cell.Y);
        }

        public static Rectangle CellScreenRectangle(int cellX, int cellY)
        {
            return Camera.WorldToScreen(CellWorldRectangle(cellX, cellY));
        }

        public static Rectangle CellScreenRectangle(Vector2 cell)
        {
            return Camera.WorldToScreen(CellWorldRectangle((int)cell.X, (int)cell.Y));
        }

        public static bool CellIsPassable(int cellX, int cellY)
        {
            MapSquare square = GetMapSquareAtCell(cellX, cellY);
            if (square == null)
            {
                return false;
            }

            else
            {
                return square.Passable;
            }
        }

        public static bool CellIsPassable(Vector2 cell)
        {
            return CellIsPassable((int)cell.X, (int)cell.Y);
        }

        public static bool CellIsPassableByPixel(Vector2 pixelLocation)
        {
            return CellIsPassable(GetCellByPixelX((int)pixelLocation.X), GetCellByPixelY((int)pixelLocation.Y));
        }

        public static string CellCodeValue(int cellX, int cellY)
        {
            MapSquare square = GetMapSquareAtCell(cellX, cellY);
            if (square == null)
            {
                return "";
            }

            else
            {
                return square.CodeValue;
            }
        }

        public static string CellCodeValue(Vector2 cell)
        {
            return CellCodeValue((int)cell.X, ((int)cell.Y));
        }


        /*Informasjon om kartcelle-objektene*/

        //Henter ut et celle-objekt fra den oppgitte plassen i kartet
        public static MapSquare GetMapSquareAtCell(int tileX, int tileY)
        {
            if ((tileX >= 0) && (tileX < MapWidth) && (tileY >= 0) && (tileY < MapHeight))
            {
                return mapCells[tileX, tileY];
            }

            else
            {
                return null;
            }
        }

        public static void SetMapSquareAtCell(int tileX, int tileY, MapSquare tile)
        {
            if ((tileX >= 0) && (tileX < MapWidth) && (tileY >= 0) && (tileY < MapHeight))
            {
                mapCells[tileX, tileY] = tile;
            }
        }

        public static void SetTileAtCell(int tileX, int tileY, int layer, int tileIndex)
        {
            if ((tileX >= 0) && (tileX < MapWidth) && (tileY >= 0) && (tileY < MapHeight))
            {
                mapCells[tileX, tileY].LayerTiles[layer] = tileIndex;
            }
        }

        public static MapSquare GetMapSquareAtPixel(int pixelX, int pixelY)
        {
            return GetMapSquareAtCell(GetCellByPixelX(pixelX), GetCellByPixelY(pixelY));
        }

        public static MapSquare GetMapSquareAtPixel(Vector2 pixelLocation)
        {
            return GetMapSquareAtPixel((int)pixelLocation.X, (int)pixelLocation.Y);
        }


        /*Metoder for lagring og innlasting av kartfiler*/

        public static void SaveMap(FileStream filestream)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(filestream, mapCells);
            filestream.Close();
        }

        public static void LoadMap(FileStream filestream)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                mapCells = (MapSquare[,])formatter.Deserialize(filestream);
                filestream.Close();
            }

            catch
            {
                ClearMap();
            }
        }

        public static void ClearMap()
        {
            for (int x = 0; x < MapWidth; x++)
            {
                for (int y = 0; y < MapHeight; y++)
                {
                    for (int z = 0; z < MapLayers; z++)
                    {
                        mapCells[x, y] = new MapSquare(2, 0, 0, "", true);
                    }
                }
            }
        }


        /*Metoder som tegner kartcellene på skjermen*/

        public static void Draw(SpriteBatch spriteBatch)
        {
            int startX = GetCellByPixelX((int)Camera.Position.X);
            int endX = GetCellByPixelX((int)Camera.Position.X + Camera.ViewPortWidth);

            int startY = GetCellByPixelY((int)Camera.Position.Y);
            int endY = GetCellByPixelY((int)Camera.Position.Y + Camera.ViewPortHeight);

            //Løkke som kjører gjennom alle cellene og tegner bare de som er innenfor synsfeltet
            for (int x = startX; x <= endX; x++)
            {
                for (int y = startY; y <= endY; y++)
                {
                    //Alle lagene
                    for (int z = 0; z < MapLayers; z++)
                    {
                        if ((x >= 0) && (y >= 0) && (x < MapWidth) && (y < MapHeight))
                        {
                            spriteBatch.Draw(
                                tileSheet, 
                                CellScreenRectangle(x, y),
                                TileSourceRectangle(
                                    mapCells[x, y].LayerTiles[z]),
                                Color.White,
                                0.0f,
                                Vector2.Zero,
                                SpriteEffects.None,
                                1f - ((float)z * 0.1f));
                        }

                        //Tegn redigeringshjelp i applikasjonen
                        if (EditorMode)
                        {
                            DrawEditorModeItems(spriteBatch, x, y);
                        }
                    }
                }
            }
        }

        //Tegner ting som er relevante når man er i redigerings-modus
        public static void DrawEditorModeItems(SpriteBatch sb, int x, int y)
        {
            if ((x < 0) || (x >= MapWidth) || (y < 0) || (y >= MapHeight))
            {
                return;
            }

            //Hvis cellen ikke kan beveges gjennom, tegn en rød halvgjennomsiktig rektangel over
            if (!CellIsPassable(x, y))
            {
                sb.Draw(
                    tileSheet,
                    CellScreenRectangle(x, y),
                    TileSourceRectangle(1),
                    Color.FromNonPremultiplied(255, 0, 0, 20),
                    0.0f,
                    Vector2.Zero,
                    SpriteEffects.None,
                    0.0f);
            }

            //Hvis cellen har en kodeverdi, skrives den ut på cellen
            if (mapCells[x, y].CodeValue != "")
            {
                Rectangle screenRect = CellScreenRectangle(x, y);

                sb.DrawString(
                    spriteFont,
                    mapCells[x, y].CodeValue,
                    new Vector2(screenRect.X, screenRect.Y),
                    Color.White,
                    0.0f,
                    Vector2.Zero,
                    1.0f,
                    SpriteEffects.None,
                    0.0f);
            }
        }
    }
}
