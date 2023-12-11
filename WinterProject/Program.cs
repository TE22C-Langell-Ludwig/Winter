/*om david är snäll: 
 "du är snäll"
 annars om 
  "du är inte snäll"*/
using Raylib_cs;
using System.Data;
using System.Numerics;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
Raylib.InitWindow(1000, 1000, "amongus");
Raylib.SetTargetFPS(60);

bool BetterMovement = false;
bool BetterRadar = false;
bool FunnyRainbows = false;

int characterx = 146;
int charactery = 136;
int points =0;
int Score=0;
int Scorecubex = Random.Shared.Next(100,900);
int Scorecubey = Random.Shared.Next(100,900);


/*
List<int> numbers = new List<int>{3,6,45};

numbers.Add(89);

string[] names ={ "micke", "martin", "ludwig"};

Console.WriteLine(names[1]);
Console.ReadLine();
*/



string Scene = "start";

Texture2D Characterimage = Raylib.LoadTexture("Hevijak.png");
Texture2D Radarimage = Raylib.LoadTexture("Radar.png");
Vector2 RadarVector = new(70,70);
Vector2 Subterra = new(146,136);
Color radarColor = Color.RED;

while (!Raylib.WindowShouldClose())
{
   Starting();

   Rectangle Scorecube = new(Scorecubex, Scorecubey, 50, 50);
   Rectangle Characterect = new(characterx, charactery, 50, 50);
   Rectangle SubterraCube = new(146,136,Characterimage.width,Characterimage.height);
   Rectangle BubterraCube = new(characterx,charactery,Characterimage.width,Characterimage.height);
   Rectangle RadarRect = new(70,70,Radarimage.width,Radarimage.height);
   Vector2 Linecharacter = new(characterx,charactery);
   Vector2 linescore = new(Scorecubex,Scorecubey);
   Vector2 linedifference = linescore-Linecharacter;
   
   int radarline =(int)linedifference.Length();

   if (Scene == "level1")
   {
      
      Raylib.BeginDrawing();
      Raylib.ClearBackground(Color.DARKGRAY);
      Radar();
      Raylib.DrawLine((int)Linecharacter.X, (int)Linecharacter.Y, (int)linescore.X, (int)linescore.Y,Color.DARKGRAY);
      //Raylib.DrawRectangle(100,100,800,800,Color.BLUE);
      Raylib.DrawText($"{Score}",500,10,35,Color.RAYWHITE);
      movement();
      Raylib.DrawTextureRec(Radarimage,RadarRect,RadarVector,radarColor);
      Raylib.DrawRectangleRec(Scorecube, Color.DARKGRAY);
      Raylib.DrawRectangleRec(BubterraCube, Color.DARKGRAY);
      Raylib.DrawTextureRec(Characterimage,SubterraCube,Subterra,Color.WHITE);
      if(Raylib.CheckCollisionRecs(Scorecube,BubterraCube)){
        Score++;
        Scorecubex = Random.Shared.Next(100,900);
        Scorecubey = Random.Shared.Next(100,900);
        //characterx = 500;
        //charactery = 500;
        //Subterra.X = 500;
        //Subterra.Y = 500;

      }
            if(Score >= 5){
         Raylib.DrawText("Press Space if you want to win the game now", 300, 300, 25, Color.ORANGE);
         if(Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
      {
         Scene = "win";
      }
         Raylib.DrawText("Or Press Enter if you want to go to the shop now", 300, 600, 25, Color.ORANGE);
         if(Raylib.IsKeyDown(KeyboardKey.KEY_ENTER))
      {
         Scene = "store";
      }
         }

      Raylib.DrawFPS(0, 0);
      Raylib.EndDrawing();

   }

   //if (Scene== "level2"){
   //Starting();
   //movement();
   //Raylib.BeginDrawing();
   //Raylib.ClearBackground(Color.GRAY);
   //Raylib.DrawRectangleRec(SubterraCube,Color.WHITE);
  // Raylib.EndDrawing();
   //}



void Starting(){
   if (Scene=="start"){
      characterx = 146;
      charactery = 136;
      if(Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
      {
         Scene = "level1";
      }
      Raylib.BeginDrawing();
      Raylib.DrawText("press space to like start maybe", 400, 400, 20, Color.RED);
      Raylib.ClearBackground(Color.GRAY);
      Raylib.EndDrawing();
   }
   //if (Scene=="level2start"){
   //   Subterra.X = 900;
   //   Subterra.Y = 100;
   //   if(Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
   //   {
   //      Scene = "level2";
   //   }
   //   Raylib.BeginDrawing();
   //   Raylib.DrawText("press space to go to the next stage", 400, 400, 20, Color.YELLOW);
   //   Raylib.ClearBackground(Color.GRAY);
   //  Raylib.EndDrawing();
   //
   //}
   if (Scene =="store"){
      if(Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
      {
         Scene = "level1";
      }
      points = Score;
     Raylib.BeginDrawing();
      Raylib.DrawText("Welcome to the store", 130, 250, 35, Color.ORANGE);
      Raylib.DrawText("Press space to return to the game", 150, 650, 18, Color.GREEN);
      Raylib.DrawText($"You have {points} points", 550, 260, 20, Color.PURPLE);
      // the three upgrades Better radar,Faster walking,Actually functioning collision
      Raylib.ClearBackground(Color.BLACK);
      Raylib.EndDrawing();
      if  (Raylib.IsKeyPressed(KeyboardKey.KEY_A) && points >= 10){
         Score -=10;
         points -=10;
         BetterMovement=true;
      }
      if  (Raylib.IsKeyPressed(KeyboardKey.KEY_D) && points >= 30){
         Score -=30;
         points -=30;
         BetterMovement=true;
      }
      if  (Raylib.IsKeyPressed(KeyboardKey.KEY_G) && points >= 50){
         Score -=50;
         points -=50;
         BetterMovement=true;
      }

      for (int i = 1; i < 4; i++)
      {
         Raylib.DrawRectangle(200*i-50,370,150,150,Color.WHITE); 
      }
    }
   if (Scene =="win"){
      if(Raylib.IsKeyDown(KeyboardKey.KEY_P))
      {
         Scene = "level1";
      }
      Score=0;
     Raylib.BeginDrawing();
      Raylib.DrawText("Wow you won im so happy for you and i wish you luck in life", 150, 400, 25, Color.ORANGE);
      Raylib.DrawText("Press P to play the exact same game again", 300, 650, 18, Color.BLUE);
      Raylib.ClearBackground(Color.GRAY);
      Raylib.EndDrawing();
      BetterMovement = false;
      BetterRadar =false;
      FunnyRainbows = false;
    }
}



void movement()
{
   if (Subterra.X + Characterimage.width >= 1000)
      {
         Subterra.X = 1000-Characterimage.width;
      }

      if (Subterra.Y + Characterimage.height >= 1000)
      {
         Subterra.Y = 1000-Characterimage.height;
      }
      if (Subterra.X <= 0)
      {
         Subterra.X = 0;
      }

      if (Subterra.Y <= 0)
      {
         Subterra.Y = 0;
      }

   if (BubterraCube.x + Characterimage.width >= 1000)
      {
         characterx = (int)(1000-BubterraCube.width);
      }

      if (BubterraCube.y + Characterimage.height >= 1000)
      {
         charactery = (int)(1000-BubterraCube.height);
      }
      if (BubterraCube.x <= 0)
      {
         characterx = 0;
      }

      if (BubterraCube.y <= 0)
      {
         charactery = 0;
      }

      if (Raylib.IsKeyDown(KeyboardKey.KEY_D)  && BetterMovement==false)
      {
         Subterra.X+=5;
         SubterraCube.x+=5;
         characterx+=5;
      }
      if (Raylib.IsKeyDown(KeyboardKey.KEY_A)  && BetterMovement==false)
      {
         Subterra.X-=5;
         SubterraCube.x-=5;
         characterx-=5;
      }
      if (Raylib.IsKeyDown(KeyboardKey.KEY_S)  && BetterMovement==false)
      {
         Subterra.Y+=5;
         SubterraCube.y+=5;         
         charactery+=5;
      }
      if (Raylib.IsKeyDown(KeyboardKey.KEY_W)  && BetterMovement==false)
      {
         Subterra.Y-=5;
         SubterraCube.y-=5;
         charactery-=5;
      }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D)  && BetterMovement)
      {
         Subterra.X+=10;
         SubterraCube.x+=10;
         characterx+=10;
      }
      if (Raylib.IsKeyDown(KeyboardKey.KEY_A)  && BetterMovement)
      {
         Subterra.X-=10;
         SubterraCube.x-=10;
         characterx-=10;
      }
      if (Raylib.IsKeyDown(KeyboardKey.KEY_S)  && BetterMovement)
      {
         Subterra.Y+=10;
         SubterraCube.y+=10;         
         charactery+=10;
      }
      if (Raylib.IsKeyDown(KeyboardKey.KEY_W) && BetterMovement)
      {
         Subterra.Y-=10;
         SubterraCube.y-=10;
         charactery-=10;
      }
}
void Radar(){
if (radarline>= 500 && radarline<=1000){
      radarColor = Color.RED;
      }
      if (radarline>= 300 && radarline<=500){
      radarColor = Color.ORANGE;
      }
      if (radarline>= 100 && radarline<=300){
      radarColor = Color.GREEN;
      }




}
}
