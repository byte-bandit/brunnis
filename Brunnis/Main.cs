using System;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FirstGame
{
	public class Program : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		Texture2D tex;
		int po;
		
		public Program ()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
		}
		
		protected override void Initialize ()
		{
			// TODO: Add your won initialization logic here
			base.Initialize();
		}
		
		protected override void LoadContent ()
		{
			spriteBatch = new SpriteBatch(GraphicsDevice);
			
			base.LoadContent ();
		}
		
		protected override void UnloadContent ()
		{
			base.UnloadContent ();
		}
		
		protected override void Update (GameTime gameTime)
		{
			if (Keyboard.GetState().IsKeyDown(Keys.Escape))
			{
			this.Exit();
			}
			base.Update (gameTime);
			
			po ++;
			
		}
		
		protected override void Draw (GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);
			base.Draw (gameTime);
		}
		
		/// <summary>
		/// The entry point of the program, where the program control starts and ends.
		/// </summary>
		public static void Main()
		{
			var game = new Program();
			game.Run();
		}
	}
}

