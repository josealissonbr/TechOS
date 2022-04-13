using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace TechOS
{
    public class Kernel : Sys.Kernel
    {

        private static Sys.FileSystem.CosmosVFS FS;
        public static string file;

        protected override void BeforeRun()
        {
            Console.WriteLine("Initializing MVI...");
            FS = new Sys.FileSystem.CosmosVFS(); 
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(FS); 
            FS.Initialize(false);
            Console.WriteLine("MVI Initialized");
            Console.Clear();
            Console.WriteLine("TechOS Initialized");
        }

        protected override void Run()
        {
            Console.Write("root@techos: ");
            string input = Console.ReadLine();

            HandleCommand(input);
        }

        private void HandleCommand(string input)
        {
            if (input.StartsWith("help"))
            {
                Console.WriteLine("List of commands");
                Console.WriteLine("help     -- Show this list of kernel commands");
                Console.WriteLine("info     -- Show TechOS information");
                Console.WriteLine("build    -- Show actual build information");
            }
            else if (input.StartsWith("shutdown"))
            {
                if (input.Contains("-r"))
                {
                    Console.WriteLine("Rebooting TechOS...");
                    Sys.Power.Reboot();
                }
                else
                {
                    Console.WriteLine("Shutting down TechOS...");
                    Sys.Power.Shutdown();
                }            
            }
            else if (input.StartsWith("mvi"))
            {
                MIV.StartMIV();
            }
            else if (input.StartsWith("clear"))
            {
                Console.Clear();
            }
            else if (input.StartsWith("Snake"))
            {
                Snake snakeGame = new Snake();
                snakeGame.SnakeGameStart();
            }
            else 
            {
                Console.WriteLine("Command not found!");
                Console.WriteLine("check if package is installed.");
            }

            //Add new line to make more organization;
           // Console.WriteLine(Environment.NewLine);
        }
    }
}
