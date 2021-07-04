﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncBreakfast
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //Coffee cup = PourCoffee();
            Coffee cup = await MakeCoffee();

            Console.WriteLine("coffee is ready");

            
            //var baconTask = FryBaconAsync(3);
            ////var eggsTask = FryEggsCollAsync(5);

            //var eggsTaskColl = await FryEggsCollAsync(5);

            //int o = 1;

            //foreach(Egg egg in eggsTaskColl)
            //{
            //    Console.WriteLine(o);
            //    ++o;
            //}

            //var toastTask = MakeToastWithButterAndJamAsync(2);

            //var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
            //while (breakfastTasks.Count > 0)
            //{
            //    Task finishedTask = await Task.WhenAny(breakfastTasks);
            //    if (finishedTask == eggsTask)
            //    {
            //        Console.WriteLine("eggs are ready");
            //    }
            //    else if (finishedTask == baconTask)
            //    {
            //        Console.WriteLine("bacon is ready");
            //    }
            //    else if (finishedTask == toastTask)
            //    {
            //        Console.WriteLine("toast is ready");
            //    }
            //    breakfastTasks.Remove(finishedTask);
            //}

            //Juice oj = PourOJ();
            //Console.WriteLine("oj is ready");
            Console.WriteLine("Breakfast is ready!");
        }

        static async Task<Toast> MakeToastWithButterAndJamAsync(int number)
        {
            var toast = await ToastBreadAsync(number);
            ApplyButter(toast);
            ApplyJam(toast);

            return toast;
        }

        private static Juice PourOJ()
        {
            Console.WriteLine("Pouring orange juice");
            return new Juice();
        }

        private static void ApplyJam(Toast toast) =>
            Console.WriteLine("Putting jam on the toast");

        private static void ApplyButter(Toast toast) =>
            Console.WriteLine("Putting butter on the toast");

        private static async Task<Toast> ToastBreadAsync(int slices)
        {
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("Putting a slice of bread in the toaster");
            }
            Console.WriteLine("Start toasting...");
            await Task.Delay(3000);
            Console.WriteLine("Remove toast from toaster");

            return new Toast();
        }

        private static async Task<Bacon> FryBaconAsync(int slices)
        {
            Console.WriteLine($"putting {slices} slices of bacon in the pan");
            Console.WriteLine("cooking first side of bacon...");
            //await Task.Delay(3000);
            for (int slice = 0; slice < slices; slice++)
            {
                Console.WriteLine("flipping a slice of bacon");
            }
            Console.WriteLine("cooking the second side of bacon...");
            //await Task.Delay(3000);
            Console.WriteLine("Put bacon on plate");

            return new Bacon();
        }

        private static async Task<List<Egg>> FryEggsCollAsync(int howMany)
        {
            return await Task.FromResult(GetList(howMany));
        }

        private static List<Egg> GetList(int howMany)
        {
            List<Egg> eggs = new List<Egg>();

            Console.WriteLine("Warming the egg pan...");
            for (int i = 0; i < howMany; i++)
            {
                Console.WriteLine("Cooking the egg {0}", i);
                Thread.Sleep(3000);
                eggs.Add(new Egg());
            }

            return eggs;
        }

        private static async Task<Egg> FryEggsAsync(int howMany)
        {
            Console.WriteLine("Warming the egg pan...");
            await Task.Delay(3000);
            Console.WriteLine($"cracking {howMany} eggs");
            Console.WriteLine("cooking the eggs ...");
            await Task.Delay(3000);
            Console.WriteLine("Put eggs on plate");

            return new Egg();
        }

        private static Coffee PourCoffee()
        {
            Console.WriteLine("Pouring coffee");
            return new Coffee();
        }

        private async static Task<Coffee> MakeCoffee()
        {
            Console.WriteLine("Starting boiling water");

            await Task.Delay(3000);
            Console.WriteLine("Put coffee to cup");
            await Task.Delay(3000);
            Console.WriteLine("Pull boiled water to cup with coffee");
       

            return new Coffee();
        }

    }
}