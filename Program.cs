using System;
using System.Net.Http.Headers;
using System.Threading;

namespace ThiefAndPolice
{
    internal class Program
    {

        static void Main(string[] args)
        {
            
            //city size
            int SizeY = 100;
            int SizeX = 25;

            //prison size
            int prisonX=10;
            int prisonY=10;

            //poorhouse size
            int poorSizeX = 5;
            int poorSizeY = 20;

            //matrix size
            Person[,] poorMatrix = new Person[poorSizeX, poorSizeY];
            Person[,] matrix = new Person[SizeX, SizeY];
            Person[,] prisonMatrix = new Person[prisonX, prisonY];

            //amount of people
            int amountOfThives = 10;
            int amountOfPolice = 20;
            int amountOfCitizen = 20;
                    

            List<Person> personList = new List<Person>(); //ini list
            List<Person> prisonList = new List<Person>();
            List<Person> poorList = new List<Person>();

            //put persons in city
            //thief
            Person thief = new Thief(0, 0, 0, 0);
            Helper.AddPersonGrid(thief, matrix, personList, SizeX, SizeY, amountOfThives);
            //police
            Person police = new Police(0, 0, 0, 0);
            Helper.AddPersonGrid(police, matrix, personList, SizeX, SizeY, amountOfPolice);
            //citizen
            Person citizen = new Citizen(0, 0, 0, 0);
            Helper.AddPersonGrid(citizen, matrix, personList, SizeX, SizeY, amountOfCitizen);


            while (true)
            {
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine("\x1b[3J"); //fix for windows 11 bug console clear
                //print city
                
                Grid.Print(SizeX, SizeY, matrix);
                
                Console.WriteLine("PRISON");
                //print prison
                Grid.Print(prisonX, prisonY, prisonMatrix);

                //print poorhouse
                Console.WriteLine("POOR HOUSE");
                Grid.Print(poorSizeX, poorSizeY, poorMatrix);
             
                
                

                for (int i = 0; i < prisonList.Count; i++) //Prison movement
                {
                    Person person = prisonList[i];
                    if (person is Thief)
                    {
                        Thief thief1 = (Thief)person; // Cast to Thief type
                        if (thief1.PrisonTime > 0)
                        {
                            Helper.PrisonMovement(thief1, prisonMatrix, prisonX, prisonY);
                            thief1.PrisonTime--;
                            
                            if (thief1.PrisonTime <= 0)
                            {
                                Helper.MoveBackToCity(thief, personList, prisonList, prisonMatrix);
                            }
                        }

                    }
                }

                    for (int i = 0; i < personList.Count; i++) //city movement
                    {
                        Person person = personList[i];
                        if (person!= null)
                        {
                            Helper.Movement(person, matrix, SizeX, SizeY, personList, prisonList,poorList);
                        }
                    
                    }

                for (int i = 0; i < poorList.Count; i++) //poor movement
                {
                    Person person = poorList[i];
                    if (person != null)
                    {
                        Helper.PoorMovement(person, poorMatrix, poorSizeX, poorSizeY);
                    } 
                }

            }
        }


    }
    
}