using System;

namespace state_pattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Dog Asher = new Dog( "Asher" );
            Asher.Initialize();

            Console.WriteLine("Asher's current state: " + Asher.StateMachine.GetState().ToString());
        }
    }
}