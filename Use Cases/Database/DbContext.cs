using Models;
using Models.Database;
using Models.FinancialManager;
using Models.Receptionist;
using Models.SalesManager;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Use_Cases.Database
{
    public class DbContext : IDbContext
    {
        private static string adminPath = FileSettings.Default.UserSettings;
        private static string financialManagerPath = FileSettings.Default.FinancialManagerSettings;
        private static string receptionistPath = FileSettings.Default.ReceptionistSettings;
        private static string salesManagerPath = FileSettings.Default.SalesManagerSettings;

        public User ReadAdmin()
        {
            string jsonString = File.ReadAllText(adminPath);

            if (jsonString == string.Empty)
                return null;

            return JsonConvert.DeserializeObject<User>(jsonString);
        }

        public void WriteFinancialManager(List<FinancialManager> financialManagers)
        {
            string jsonString = JsonConvert.SerializeObject(financialManagers, Formatting.Indented);

            File.WriteAllText(financialManagerPath, jsonString);
        }

        public void WriteReceptionist(List<Receptionist> receptionists)
        {
            string jsonString = JsonConvert.SerializeObject(receptionists, Formatting.Indented);

            File.WriteAllText(receptionistPath, jsonString);
        }

        public void WriteSalesManager(List<SalesManager> salesManagers)
        {
            string jsonString = JsonConvert.SerializeObject(salesManagers, Formatting.Indented);

            File.WriteAllText(salesManagerPath, jsonString);
        }

        public void WriteUser(User user)
        {
            string jsonString = JsonConvert.SerializeObject(user, Formatting.Indented);

            File.WriteAllText(adminPath, jsonString);
        }
    }
}
