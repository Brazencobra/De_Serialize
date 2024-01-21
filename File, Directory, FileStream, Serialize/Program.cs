using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace File__Directory__FileStream__Serialize
{
    internal class Program
    {
        /*
         List<string> yaradırsınız. Bunu names.json adlı jsona yazırsınız.
         void Add(string name)
         bool Search(stiring name)
         void Update(int index, string name)
         void Delete(int index)
         Metodlarını adlarına uyğun olaraq yazın
        */
        static void Main(string[] args)
        {
            string path = "C:\\Users\\user\\Desktop\\Projects\\File, Directory, FileStream, Serialize\\File, Directory, FileStream, Serialize\\Files";
            path = Path.Combine(path, "names.json");

            List<string> names = new List<string>();
            Add(names, path, "Elxan");
            Add(names, path, "Elxan");
            Console.WriteLine(Search(path, "Elxan"));
        }
        public static void Add(List<string> strings, string path, string str)
        {
            strings.Add(str);
            Helper.SaveToJson(strings, path);
        }
        public static bool Search(string path,string name)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                List<string> list = Helper.JsonToObject<List<string>>(sr.ReadToEnd());
                foreach (var item in list)
                {
                    if (item == name)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        public static void Update(List<string> strings,int index,string name,string path)
        {
            strings[index] = name;
            Helper.SaveToJson(strings,path);
        }
        public static void Delete(List<string> strings,string path,int index)
        {
            strings.RemoveAt(index);
            Helper.SaveToJson(strings,path);
        }
    }
}