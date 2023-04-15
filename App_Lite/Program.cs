using System;
using System.IO;

class crud
{
    public static void FileOperation(string option)
    {
        string rootFolder = @"D:\files\";
        string path = @"D:\files\first_file.txt";
        switch (option){

            //Create Operation
            //Create a file with an initial username

            case "C":
            Console.WriteLine("Create file operation.\n");
            if (!File.Exists(path))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        Console.WriteLine("Enter your username:");
                        string userName = Console.ReadLine();
                        sw.WriteLine(userName);
                        Console.WriteLine($"\nFile Created Successfully starting with your username { userName } !!! ");
                    }
                }
            else
            {
                Console.WriteLine("\nThe file already exist!!!");
            }
                break;


            //Update Operation
            //Append the new username to the existing file

            case "U":
            Console.WriteLine("Update file operation.\n");
            using (StreamWriter sw = File.AppendText(path))
            {
                Console.WriteLine("Enter your username:");
                string userName = Console.ReadLine();
                sw.WriteLine(userName);
                Console.WriteLine($"Your name { userName } is Successfully appended to the existing text file !!!");
            }
            break;

            //Read Operation
            //Display the text of the file

            case "R":
            Console.WriteLine("Read file Operation.\n");
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                Console.WriteLine("The text in the file is displayed below:");
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }
            break;

            //Delete Operation
            //Delete the given text file within the files directory if exist

            case "D":
            Console.WriteLine("Delete file operation:\n");
            Console.WriteLine("Enter the name of the text file you wish to delete.");
            string fileName = Console.ReadLine();
            try
            {
                // Check if file exists with its full path    
                if (File.Exists(Path.Combine(rootFolder, fileName)))      
                {
                    // If file found, delete it    
                    File.Delete(Path.Combine(rootFolder, fileName));
                    Console.WriteLine($"{ fileName } file is deleted !!!!");
                }
                else Console.WriteLine($"{fileName} file is not found!!!");
            }
            catch (IOException ioExp)
            {
                Console.WriteLine(ioExp.Message);
            }
            break;

            default:
                break;
        }

    }
}


class Program
{
static void Main(string[] args)
{
    bool endApp = false;

    Console.WriteLine("World's Simplest CRUD File Operations in C#");
    Console.WriteLine("------------------------\n");

    //Creators

    Console.WriteLine("Console Application Created By\n");
    Console.WriteLine("Bijay Basnet\n");
    Console.WriteLine("------------------------\n");
    Console.WriteLine("------------------------\n");

    //File operations
    Console.WriteLine("WHAT FILE OPERATION YOU WANT TO PERFORM???\n");
    Console.WriteLine("C  FOR CREATE OPERATION  \n");
    Console.WriteLine("R  FOR READ   OPERATION  \n");
    Console.WriteLine("U  FOR UPDATE OPERATION  \n");
    Console.WriteLine("D  FOR DELETE OPERATION  \n");
    Console.WriteLine("------------------------\n");


    while (!endApp)
    {
        Console.WriteLine("Enter the letter to perform respective operation.\n");
        string letter = Console.ReadLine();
        string x = letter.ToUpper();
        Console.WriteLine("\n");


        string[] valid_input = { "C", "R", "U", "D" };

        bool exists = Array.Exists(valid_input, element => element == x);
        if (exists)
        {
            crud.FileOperation(x);
        }
        else
        {
            Console.WriteLine("Enter the valid input");
        }
            
        Console.Write("\nPress 'n' and Enter to close the app, or press any other key and Enter to continue:\n ");
        if (Console.ReadLine() == "n") 
            endApp = true;
        Console.WriteLine("\n");
    }
}
}
