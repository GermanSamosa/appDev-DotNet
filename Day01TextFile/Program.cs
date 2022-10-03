using System;
using System.IO;

namespace Day01TextFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
        //ask user and take info
                        string question = "Please Enter Your Name \n";
                        Console.Write(question);
                        string answer = Console.ReadLine();
                        int lines = 3;

                        string[] text;


                        //3 things
                        //create file
                        string folderName = @"c:\Users\School\Desktop\webDev-DotNet\appDev-DotNet";

                        string pathString = @"\Users\School\Desktop\webDev-DotNet\appDev-DotNet\FromCsharp"; //you can also specify by @"..\..\"

                        string fileName = "MyNewFile.txt";
            try
            { 
                pathString = System.IO.Path.Combine(pathString, fileName);
                Console.WriteLine("Path to my file: {0}\n", pathString);
                //verify it doesnt exist
                if (!System.IO.File.Exists(pathString))//dont forget to close the file!
                {
                    using (System.IO.FileStream fs = System.IO.File.Create(pathString))
                    {
                        for (byte i = 0; i < 100; i++)
                        {
                            fs.WriteByte(i);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("File \"{0}\" already exists.", fileName);
                    return;
                }
                //add to file



                File.WriteAllText(pathString, answer);



                //read back
                try
                {
                    byte[] readBuffer = System.IO.File.ReadAllBytes(pathString);
                    foreach (byte b in readBuffer)
                    {
                        Console.Write(b + " ");
                    }
                    Console.WriteLine();
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            catch
            {
                /** 
                 * exceptions
                 *  File IO
                 *  //system exception will catch most!
                 * **/
            }
            finally
            {
                //
                System.Console.WriteLine("Press any key to exit.");
                System.Console.ReadKey();
            }
        }
    }
}
