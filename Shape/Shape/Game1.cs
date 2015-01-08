#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace Shape
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        public static float BLOCK_SPEED = 5.0f;
        public static float PLAYER_FALL_SPEED = 100.0f;
        public static float PLAYER_SPEED = 5.0f;
        public static float TIMESTEP = 1.0f / 60.0f;

        GraphicsContext context;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        VertexBuffer vertexBuffer;
        BasicEffect basicEffect;
        Player guy;
        Grid map;
        bool isDying;

        Matrix World;
        Matrix View;
        Matrix Projection;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";


            // full screen code
            var screen = System.Windows.Forms.Screen.AllScreens[0];
            Window.IsBorderless = true;
            System.Windows.Forms.Form form = (System.Windows.Forms.Form)System.Windows.Forms.Control.FromHandle(Window.Handle);
            form.Location = new System.Drawing.Point(0, 0);
            graphics.PreferredBackBufferWidth = screen.Bounds.Width;
            graphics.PreferredBackBufferHeight = screen.Bounds.Height;
            float AspectRatio = screen.Bounds.Width / screen.Bounds.Height;

            // camera code
            World = Matrix.CreateTranslation(0, 0, 0);
            View = Matrix.CreateLookAt(new Vector3(0, 0, 3), new Vector3(0, 0, 0), new Vector3(0, 1, 0));
            Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), AspectRatio, 0.01f, 100f);

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            isDying = false;
            guy = new Player();
            map = new Grid();
            context = new GraphicsContext(GraphicsDevice);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            basicEffect = new BasicEffect(GraphicsDevice);

            VertexPositionColor[] vertices = new VertexPositionColor[4];
            vertices[0] = new VertexPositionColor(new Vector3(-1, -1, 0), Color.Green);
            vertices[1] = new VertexPositionColor(new Vector3(-1, 1, 0), Color.Green);
            vertices[2] = new VertexPositionColor(new Vector3(1, -1, 0), Color.Green);
            vertices[3] = new VertexPositionColor(new Vector3(1, 1, 0), Color.Green);

            vertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), 4, BufferUsage.WriteOnly);
            vertexBuffer.SetData<VertexPositionColor>(vertices);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            Grid.Shape groundingShape;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            groundingShape = null;
            if (map.IsGrounded(guy.Position, ref groundingShape) || isDying)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    groundingShape.Move(BLOCK_SPEED);
                }
                else if(Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    groundingShape.Move(-BLOCK_SPEED);
                }
                guy.FloorVelocity = groundingShape.Velocity;
                guy.Velocity = new Vector3(0, 0, 0);


                if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    guy.Velocity += new Vector3(0, 0, PLAYER_SPEED);
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    guy.Velocity += new Vector3(0, 0, -PLAYER_SPEED);
                }
                if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    guy.Velocity += new Vector3(PLAYER_SPEED, 0, 0);
                }
                else if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    guy.Velocity += new Vector3(-PLAYER_SPEED, 0, 0);
                }
            }
            else
            {
                isDying = true;
                guy.FloorVelocity = new Vector3(0, 0, 0);
                guy.Velocity.X = 0;
                guy.Velocity.Z = 0;
                guy.Acceleration = new Vector3(0, -PLAYER_FALL_SPEED, 0);
             
            }
            
            // TODO: Add your update logic here

            map.Update(TIMESTEP);
            guy.Update(TIMESTEP);
            map.Draw(context);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            //basicEffect.World = World;
            //basicEffect.View = View;
            //basicEffect.Projection = Projection;
            //basicEffect.VertexColorEnabled = true;

            //GraphicsDevice.SetVertexBuffer(vertexBuffer);

            //RasterizerState rasterizerState = new RasterizerState();
            //rasterizerState.CullMode = CullMode.None;
            //GraphicsDevice.RasterizerState = rasterizerState;

            //foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
            //{
            //    pass.Apply();
            //    GraphicsDevice.DrawPrimitives(PrimitiveType.TriangleStrip, 0, 2);
            //}

            context.Draw();
            base.Draw(gameTime);
        }
    }
}


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Audio;
//using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.GamerServices;
//using Microsoft.Xna.Framework.Graphics;
//using Microsoft.Xna.Framework.Input;
//using Microsoft.Xna.Framework.Media;

//namespace Shape
//{
//    /// <summary>
//    /// This is the main type for your game
//    /// </summary>
//    public class Game1 : Microsoft.Xna.Framework.Game
//    {
//        GraphicsDeviceManager graphics;
//        SpriteBatch spriteBatch;

//        VertexBuffer vertexBuffer;

//        BasicEffect basicEffect;
//        Matrix world = Matrix.CreateTranslation(0, 0, 0);
//        Matrix view = Matrix.CreateLookAt(new Vector3(0, 0, 3), new Vector3(0, 0, 0), new Vector3(0, 1, 0));
//        Matrix projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800f / 480f, 0.01f, 100f);

//        public Game1()
//        {
//            graphics = new GraphicsDeviceManager(this);
//            Content.RootDirectory = "Content";
//        }

//        /// <summary>
//        /// Allows the game to perform any initialization it needs to before starting to run.
//        /// This is where it can query for any required services and load any non-graphic
//        /// related content.  Calling base.Initialize will enumerate through any components
//        /// and initialize them as well.
//        /// </summary>
//        protected override void Initialize()
//        {
//            base.Initialize();
//        }

//        /// <summary>
//        /// LoadContent will be called once per game and is the place to load
//        /// all of your content.
//        /// </summary>
//        protected override void LoadContent()
//        {
//            // Create a new SpriteBatch, which can be used to draw textures.
//            spriteBatch = new SpriteBatch(GraphicsDevice);

//            basicEffect = new BasicEffect(GraphicsDevice);

//            VertexPositionColor[] vertices = new VertexPositionColor[3];
//            vertices[0] = new VertexPositionColor(new Vector3(0, 1, 0), Color.Green);
//            vertices[1] = new VertexPositionColor(new Vector3(1, 0, 0), Color.Green);
//            vertices[2] = new VertexPositionColor(new Vector3(-1, 0, 0), Color.Green);

//            vertexBuffer = new VertexBuffer(GraphicsDevice, typeof(VertexPositionColor), 3, BufferUsage.WriteOnly);
//            vertexBuffer.SetData<VertexPositionColor>(vertices);
//        }

//        /// <summary>
//        /// UnloadContent will be called once per game and is the place to unload
//        /// all content.
//        /// </summary>
//        protected override void UnloadContent()
//        {
//        }

//        /// <summary>
//        /// Allows the game to run logic such as updating the world,
//        /// checking for collisions, gathering input, and playing audio.
//        /// </summary>
//        /// <param name="gameTime">Provides a snapshot of timing values.</param>
//        protected override void Update(GameTime gameTime)
//        {
//            // Allows the game to exit
//            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
//                this.Exit();

//            base.Update(gameTime);
//        }

//        /// <summary>
//        /// This is called when the game should draw itself.
//        /// </summary>
//        /// <param name="gameTime">Provides a snapshot of timing values.</param>
//        protected override void Draw(GameTime gameTime)
//        {
//            GraphicsDevice.Clear(Color.Black);

//            basicEffect.World = world;
//            basicEffect.View = view;
//            basicEffect.Projection = projection;
//            basicEffect.VertexColorEnabled = true;

//            GraphicsDevice.SetVertexBuffer(vertexBuffer);

//            RasterizerState rasterizerState = new RasterizerState();
//            rasterizerState.CullMode = CullMode.None;
//            GraphicsDevice.RasterizerState = rasterizerState;

//            foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
//            {
//                pass.Apply();
//                GraphicsDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, 1);
//            }

//            base.Draw(gameTime);
//        }
//    }
//}