using System;
using System.IO;
//Auther:khalid alzahrani
//email: khalidalzhrani76@gmail.com
namespace rainbowSchoolsDatabase
{
    
    public class RainbowSchoolDatabaseToRead
    {
        
        StreamReader rainbowDatabaseToRead ;

        public RainbowSchoolDatabaseToRead()
        {
        }
        public void retrieveAllTeachersInfo()
        {
            this.rainbowDatabaseToRead = new StreamReader(@"C:\Users\iikha\Desktop\rainbow school database.txt");
            Console.WriteLine(this.rainbowDatabaseToRead.ReadToEnd());
            this.rainbowDatabaseToRead.Close();
        }

        public void retrieveTeacherInfoById(int id)
        {
            this.rainbowDatabaseToRead = new StreamReader(@"C:\Users\iikha\Desktop\rainbow school database.txt");
            string line = rainbowDatabaseToRead.ReadLine();
            int idFromLine = 0;
            try
            {

                do
                {
                    idFromLine = Convert.ToInt32(line.Substring(0, 2));
                    if(id == idFromLine)
                    {
                        Console.WriteLine("\nhere is teacher information: " + line+ "\n");
                        break;
                    }
                    line = rainbowDatabaseToRead.ReadLine();
                } while (id != idFromLine);
            }
            catch(System.NullReferenceException e) 
            {
                Console.WriteLine("\nthis id is not recorded in our database. try another id\n");
            }
            catch (Exception e)
            {
                Console.WriteLine("\nsomething went wrong here is the error\n");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            this.rainbowDatabaseToRead.Close();

        }


    }

    public class RainbowSchoolDatabaseToWrite
    {
        StreamReader rainbowDatabaseToRead;
        StreamWriter rainbowDatabaseToWrite;

        public RainbowSchoolDatabaseToWrite()
        {
        }
       

        public void UpdateTeacherInfoById(int id,RainbowSchoolTeacher teacher)
        {
            this.rainbowDatabaseToRead = new StreamReader(@"C:\Users\iikha\Desktop\rainbow school database.txt");
            string line = rainbowDatabaseToRead.ReadLine();
            int idFromLine = 0;
            try
            {

                do
                {
                    idFromLine = Convert.ToInt32(line.Substring(0, 2));
                    if (id == idFromLine)
                    {
                        this.rainbowDatabaseToRead.Close();
                        break;
                    }
                    line = rainbowDatabaseToRead.ReadLine();
                } while (id != idFromLine);
            }
            catch (System.NullReferenceException e)
            {
                Console.WriteLine("\nthis id is not recorded in our database. try another id");
                this.rainbowDatabaseToRead.Close();
                return;
            }
            catch (Exception e)
            {
                Console.WriteLine("\nsomething went wrong here is the error\n");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
                this.rainbowDatabaseToRead.Close();
                return;
            }
            


            string path = @"C:\Users\iikha\Desktop\rainbow school database.txt";
            this.rainbowDatabaseToWrite = new StreamWriter(path, true);
            rainbowDatabaseToWrite.WriteLine(idFromLine + "_"+ teacher.getName() + "_"+ teacher.getClass() + "_"+
                teacher.getSection() + "_Updated");

            this.rainbowDatabaseToWrite.Close();

        }

        public void addNewTeacher(RainbowSchoolTeacher teacher)
        {
            string path = @"C:\Users\iikha\Desktop\rainbow school database.txt";
            this.rainbowDatabaseToWrite = new StreamWriter(path, true);
            rainbowDatabaseToWrite.WriteLine(teacher.getId() + "_" + teacher.getName() + "_" + teacher.getClass() + "_" +
                teacher.getSection() + "_New");

            this.rainbowDatabaseToWrite.Close();
        }
    }
    public class RainbowSchoolTeacher
    {
        private int id;
        private string name;
        private string _class;
        private string section;

        public RainbowSchoolTeacher(int id, string name, string @class, string section)
        {
            this.id = id;
            this.name = name;
            this._class = @class;
            this.section = section;

        }

        public RainbowSchoolTeacher()
        {
        }
        public void setId(int id)
        {
            this.id = id;
        }
        public void setName(string name)
        {
            this.name = name;

        }
        public void setClass(string @class)
        {
            this._class = @class;
        }
        public void setSection(string section)
        {
            this.section = section;
        }
        public int getId()
        {
            return this.id;
        }
        public string getName()
        {
            return this.name;
        }
        public string getClass()
        {
            return this._class;
        }
        public string getSection()
        {
            return this.section;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
    
    class Program
    {
        static void Main(string[] args)  
        {
            RainbowSchoolDatabaseToRead  rainbowSchoolDatabase = new RainbowSchoolDatabaseToRead(); ;
            Console.WriteLine("-------------------------  Welcome to Rainbow database  --------------------------");
            string input = "";
            while (true)
            {
                Console.WriteLine("\noptions:");
                Console.WriteLine("Retrieve all teachers information enter 1.");
                Console.WriteLine("Retrieve teacher information by ID enter 2.");
                Console.WriteLine("Update teacher information press 3.");
                Console.WriteLine("Add new teacher information press 4.");
                Console.WriteLine("Exit enter 0.\n");
                input = Console.ReadLine();
                if (input.Equals("0"))
                {

                    Console.WriteLine("\ngoodbye!\n");
                    break;
                }else if (input.Equals("1"))
                {
                    rainbowSchoolDatabase.retrieveAllTeachersInfo();
                }
                else if (input.Equals("2"))
                {
                    Console.WriteLine("\nPlease enter teacher id: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    rainbowSchoolDatabase.retrieveTeacherInfoById(id);
                }
                else if (input.Equals("3"))
                {
                    Console.WriteLine("please enter teacher id you want to update:");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("enter teacher name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("enter teacher class: ");
                    string _class = Console.ReadLine();
                    Console.WriteLine("enter teacher section: ");
                    string section = Console.ReadLine();
                    RainbowSchoolTeacher teacher = new RainbowSchoolTeacher(id, name, _class, section);
                    RainbowSchoolDatabaseToWrite rDatabase = new RainbowSchoolDatabaseToWrite();
                    rDatabase.UpdateTeacherInfoById(id,teacher);
                }
                else if (input.Equals("4"))
                {
                    Console.WriteLine("please enter new teacher id :");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("enter new teacher name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("enter new teacher class: ");
                    string _class = Console.ReadLine();
                    Console.WriteLine("enter new teacher section: ");
                    string section = Console.ReadLine();
                    RainbowSchoolTeacher teacher = new RainbowSchoolTeacher(id, name, _class, section);
                    RainbowSchoolDatabaseToWrite rDatabase = new RainbowSchoolDatabaseToWrite();
                    rDatabase.addNewTeacher(teacher);
                }
                else { Console.WriteLine("\nWrong entery try again !!\n"); }
            }            
        }
    }
}
