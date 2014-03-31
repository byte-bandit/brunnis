/// <copyright file="GraphicsManager.cs" company="Brunnis Engine Team">
///     GPL 3
/// </copyright>
namespace Classes.Graphics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Graphics manager.
    /// </summary>
    public class GraphicsManager
    {
        /// <summary>
        /// The children.
        /// </summary>
        private static List<DrawableGameComponent> children = new List<DrawableGameComponent > ();

        /// <summary>
        /// The sprite batch.
        /// </summary>
        public static SpriteBatch spriteBatch;

        /// <summary>
        /// The font01.
        /// </summary>
        public static SpriteFont font01;

        /// <summary>
        /// The font02.
        /// </summary>
        public static SpriteFont font02;

        /// <summary>
        /// The font03.
        /// </summary>
        public static SpriteFont font03;

        /// <summary>
        /// The dummy texture.
        /// </summary>
        public static Texture2D dummyTexture;

        /// <summary>
        /// The gd.
        /// </summary>
        private static GraphicsDevice gd;

        /// <summary>
        /// Adds the child.
        /// </summary>
        /// <param name='item'>
        /// Item.
        /// </param>
        public static void addChild (DrawableGameComponent item)
        {
            children.Add (item);
        }

        /// <summary>
        /// Removes the child.
        /// </summary>
        /// <returns>
        /// True if removed successful.
        /// </returns>
        /// <param name='item'>
        /// The <see cref="DrawableGameComponent"/> to remove.
        /// </param>
        public static bool removeChild (DrawableGameComponent item)
        {
            return children.Remove (item);
        }

        /// <summary>
        /// Draws a line.
        /// </summary>
        /// <param name='width'>
        /// Width.
        /// </param>
        /// <param name='color'>
        /// Color.
        /// </param>
        /// <param name='point1'>
        /// Point1.
        /// </param>
        /// <param name='point2'>
        /// Point2.
        /// </param>
        public static void DrawLine (float width, Color color, Vector2 point1, Vector2 point2)
        {
            try {
                float angle = (float)Math.Atan2 (point2.Y - point1.Y, point2.X - point1.X);
                float length = Vector2.Distance (point1, point2);

                //GraphicsManager.spriteBatch.Begin();
                GraphicsManager.spriteBatch.Draw (dummyTexture, point1, null, color, angle, Vector2.Zero, new Vector2 (length, width), SpriteEffects.None, 0);
                //GraphicsManager.spriteBatch.End();
            } catch (Exception ex) {
                System.Diagnostics.Debug.Print (ex.ToString ());
            }
        }

        /// <summary>
        /// Draws the text.
        /// </summary>
        /// <param name='text'>
        /// Text.
        /// </param>
        /// <param name='position'>
        /// Position.
        /// </param>
        /// <param name='font'>
        /// Font.
        /// </param>
        /// <param name='color'>
        /// Color.
        /// </param>
        /// <param name='shadow'>
        /// Shadow.
        /// </param>
        public static void drawText (String text, Vector2 position, SpriteFont font, Color color, bool shadow=false)
        {
            if (text == null) {
                text = "";
            }

            Graphics.GraphicsManager.spriteBatch.Begin ();
            if (shadow) {
                drawShadowText (text, position, font);
            }

            Graphics.GraphicsManager.spriteBatch.DrawString (font, text, new Vector2 (position.X, position.Y), color);
            Graphics.GraphicsManager.spriteBatch.End ();
        }

        /// <summary>
        /// Draws the shadow text.
        /// </summary>
        /// <param name='text'>
        /// Text.
        /// </param>
        /// <param name='pos'>
        /// Position.
        /// </param>
        /// <param name='font'>
        /// Font.
        /// </param>
        private static void drawShadowText (String text, Vector2 pos, SpriteFont font)
        {
            Graphics.GraphicsManager.spriteBatch.DrawString (font, text, new Vector2 (pos.X - 1, pos.Y - 1), Color.Black);
            Graphics.GraphicsManager.spriteBatch.DrawString (font, text, new Vector2 (pos.X + 1, pos.Y - 1), Color.Black);
            Graphics.GraphicsManager.spriteBatch.DrawString (font, text, new Vector2 (pos.X - 1, pos.Y + 1), Color.Black);
            Graphics.GraphicsManager.spriteBatch.DrawString (font, text, new Vector2 (pos.X + 1, pos.Y + 1), Color.Black);

            Graphics.GraphicsManager.spriteBatch.DrawString (font, text, new Vector2 (pos.X, pos.Y + 1), Color.Black);
            Graphics.GraphicsManager.spriteBatch.DrawString (font, text, new Vector2 (pos.X, pos.Y - 1), Color.Black);
            Graphics.GraphicsManager.spriteBatch.DrawString (font, text, new Vector2 (pos.X - 1, pos.Y), Color.Black);
            Graphics.GraphicsManager.spriteBatch.DrawString (font, text, new Vector2 (pos.X + 1, pos.Y), Color.Black);
        }

        /// <summary>
        /// Initializes the fonts.
        /// </summary>
        /// <param name='Font01'>
        /// Font01.
        /// </param>
        /// <param name='Font02'>
        /// Font02.
        /// </param>
        /// <param name='Font03'>
        /// Font03.
        /// </param>
        /// <param name='gp'>
        /// Gp.
        /// </param>
        public static void initializeFonts (SpriteFont Font01, SpriteFont Font02, SpriteFont Font03, GraphicsDevice gp)
        {
            dummyTexture = new Texture2D (gp, 1, 1);
            dummyTexture.SetData (new Color[] { Color.White });
            font01 = Font01;
            font02 = Font02;
            font03 = Font03;
            gd = gp;
        }

        /// <summary>
        /// Gets the graphics device.
        /// </summary>
        /// <value>
        /// The graphics device.
        /// </value>
        public static GraphicsDevice GraphicsDevice {
            get {
                return gd;
            }
        }

        /// <summary>
        /// Draw the specified gameTime.
        /// </summary>
        /// <param name='gameTime'>
        /// Game time.
        /// </param>
        public static void Draw (GameTime gameTime)
        {
            foreach (DrawableGameComponent d in children) {
                try {
                    d.Draw (gameTime);
                } catch (Exception ex) {
                    System.Diagnostics.Debug.Print (ex.ToString ());
                }
            }

        }
    }
}
