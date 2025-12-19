using System;
using System.IO;
using System.Diagnostics;

namespace Muggys.Mod.Manager
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=============================================================");
                Console.WriteLine("Run (V)anilla Cuphead or modded with (B)epInEx or (M)elonLoader?");
                Console.WriteLine("(V, B, M) Press ESC to end.");
                Console.WriteLine("=============================================================");

                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape) break;

                switch (key.Key)
                {
                    case ConsoleKey.V:
                        SetupVanilla();
                        LaunchGame();
                        return;
                    case ConsoleKey.B:
                        SetupBepInEx();
                        LaunchGame();
                        return;
                    case ConsoleKey.M:
                        SetupMelonLoader();
                        LaunchGame();
                        return;
                }
            }
        }

        static void SetupVanilla()
        {
            Console.WriteLine("Setting up Vanilla...");
            SafeRename("MelonLoader", "MelonLoader_bak");
            SafeRename("Mods", "Mods_bak");
            SafeRename("Plugins", "Plugins_bak");
            SafeRename("UserData", "UserData_bak");
            SafeRename("version.dll", "version.dll.bak");
            SafeRename("BepInEx", "BepInEx_bak");
            SafeRename("winhttp.dll", "winhttp.dll.bak");
        }

        static void SetupBepInEx()
        {
            Console.WriteLine("Setting up BepInEx...");
            SafeRename("MelonLoader", "MelonLoader_bak");
            SafeRename("Mods_bak", "Mods");
            SafeRename("Plugins", "Plugins_bak");
            SafeRename("UserData", "UserData_bak");
            SafeRename("version.dll", "version.dll.bak");
            SafeRename("BepInEx_bak", "BepInEx");
            SafeRename("winhttp.dll.bak", "winhttp.dll");
        }

        static void SetupMelonLoader()
        {
            Console.WriteLine("Setting up MelonLoader...");
            SafeRename("MelonLoader_bak", "MelonLoader");
            SafeRename("Mods_bak", "Mods");
            SafeRename("Plugins_bak", "Plugins");
            SafeRename("UserData_bak", "UserData");
            SafeRename("version.dll.bak", "version.dll");
            SafeRename("BepInEx", "BepInEx_bak");
            SafeRename("winhttp.dll", "winhttp.dll.bak");
        }

        static void SafeRename(string source, string destination)
        {
            try
            {
                if (File.Exists(source))
                {
                    if (File.Exists(destination)) File.Delete(destination);
                    File.Move(source, destination);
                }
                else if (Directory.Exists(source))
                {
                    if (Directory.Exists(destination)) Directory.Delete(destination, true);
                    Directory.Move(source, destination);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error handling {source}: {ex.Message}");
            }
        }

        static void LaunchGame()
        {
            Console.WriteLine("Launching Cuphead...");
            try { Process.Start("Cuphead_AHK.exe"); } catch { }
            try { Process.Start("Cuphead.exe"); } catch { }
            Environment.Exit(0);
        }
    }
}