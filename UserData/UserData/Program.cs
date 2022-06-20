using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace UserData
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string filePath = @"C:\Monika\MGDocs\AvailityProj\UserData\UserData.csv";
           
            List<User> UserList = new List<User>();
            ProcessFile(ReadCSVFile(filePath));

        }

        public static List<User> ReadCSVFile(string filePath)
        {
            /*Read CSV file 
             * assumption : File Exists in the given file path*/
                string[] lines = System.IO.File.ReadAllLines(filePath);
                List<User> UserList = new List<User>();
                foreach (string line in lines)
                {
                    string[] columns = line.Split(',');
                    User user = new User();
                    user.UserID = columns[0];
                    user.FirstName = columns[1];
                    user.LastName = columns[2];
                    user.Version = Convert.ToInt16(columns[3].ToString());
                    user.Insurance = columns[4];
                    UserList.Add(user);
                }

            return UserList;
        }

        public static void ProcessFile(List<User> UserList)
        {
            // find the list of distinct insurance name in the data
            // assumption: All insurance name is spelled in the same way
            var distinctInsuranceList = UserList.Select(x => x.Insurance).Distinct().ToList();


            foreach (var insurance in distinctInsuranceList)
            {
                
                var insuranceUserList = UserList.Where(x => x.Insurance == insurance).ToList();
                List<User> finalUserList = new List<User>();
                // find the user with same insurance occured more than one
                foreach (var user in insuranceUserList)
                {
                    var filteredList = insuranceUserList.Where(x => x.UserID == user.UserID).ToList();

                    // select user with max version
                    User maxVersion = (from i in filteredList
                                    let maxId = filteredList.Max(m => m.Version)
                                    where i.Version == maxId
                                    select i).FirstOrDefault();
                    // remove duplicates 
                    if (!finalUserList.Any(x => x.UserID == maxVersion.UserID))
                    {

                        finalUserList.Add(maxVersion);
                    }

                }
                // sort the users with LAst Name then by First name ascending 
                var listtoWrite = finalUserList.OrderBy(x => x.LastName).ThenBy(x => x.FirstName).ToList();
                StringBuilder sw = new StringBuilder();
                foreach (var user in listtoWrite)
                {
                    
                    sw.AppendLine(string.Format("{0},{1},{2},{3},{4}", user.UserID, user.FirstName, user.LastName, user.Version, user.Insurance));
                }

                // write the file with particular insurance.

                WriteCSVFile(sw, insurance);

            }
        }

        public static void WriteCSVFile(StringBuilder sw, string insuranceName)
        {
            string path = @"C:\Monika\MGDocs\AvailityProj\UserData\UserData_" + insuranceName + ".csv";
            
                using (var w = new StreamWriter(path))
                {
                        w.WriteLine(sw.ToString());
                        w.Flush();  
                }
            
        }
    }

    public class User
    {
        public string UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Version { get; set; }
        public string Insurance { get; set; }
    }



    /* Future enhancements 
     * 
     Archive the existsing  files with date folder
     input file and outfile name can be configured in AppConfig
     */
}
