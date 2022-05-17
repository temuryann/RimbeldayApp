using Models;
using Models.Custom_Exceptions;
using Models.Database;
using Models.FinancialManager;
using Models.Logger;
using Models.Receptionist;
using Models.SalesManager;
using System.Collections.Generic;
using System.Linq;
using Use_Cases.Database;
using Use_Cases.Logger_Logic;

namespace Use_Cases.User_Logic
{
    public class UserManager : IUserManager
    {
        private readonly IDbContext dbContext;
        private readonly ILogger logger;
        private readonly List<FinancialManager> financialManagers;
        private readonly List<Receptionist> receptionists;
        private readonly List<SalesManager> salesManagers;

        public UserManager()
        {
            dbContext = new DbContext();
            logger = new Logger();
            financialManagers = new List<FinancialManager>();
            receptionists = new List<Receptionist>();
            salesManagers = new List<SalesManager>();
        }

        public bool CanLogin(string username, string password)
        {
            try
            {
                IsValidLogin(username, password);
            }
            catch (InvalidAuthenticationException ex)
            {
                logger.WriteLogger("ERROR", ex.Message);
                return false;
            }

            logger.WriteLogger("INFO", "The admin was successfully login");
            return true;
        }

        public bool CanRegister(string username, string password)
        {
            try
            {
                IsValidRegister();
            }
            catch (InvalidRegisterException ex)
            {
                logger.WriteLogger("ERROR", ex.Message);
                return false;
            }

            User user = CreateUser(username, password);
            logger.WriteLogger("INFO", $"The admin was registered successfully");
            dbContext.WriteUser(user);

            return true;
        }

        public bool AddFinanceManager(string fullName, double salary, int overTime)
        {
            FinancialManager financialManager;
            try
            {
                financialManager = CreateFinancialManager(fullName, salary, overTime);
            }
            catch (InvalidEmployeerNameException ex)
            {
                logger.WriteLogger("ERROR", ex.Message);
                return false;
            }

            logger.WriteLogger("INFO", $"Admin was add financial manager {fullName}");
            financialManagers.Add(financialManager);
            dbContext.WriteFinancialManager(financialManagers);

            return true;
        }

        public bool AddSalesManager(string fullName, double salary, int overTime)
        {
            SalesManager salesManager;
            try
            {
                salesManager = CreateSalesManager(fullName, salary, overTime);
            }
            catch (InvalidEmployeerNameException ex)
            {
                logger.WriteLogger("ERROR", ex.Message);
                return false;
            }

            logger.WriteLogger("INFO", $"Admin was add Sales Manager {fullName}");
            salesManagers.Add(salesManager);
            dbContext.WriteSalesManager(salesManagers);

            return true;
        }

        public bool AddRecption(string fullName, decimal salary)
        {
            Receptionist receptionist;
            try
            {
                receptionist = CreateReceptionist(fullName, salary);
            }
            catch (InvalidEmployeerNameException ex)
            {
                logger.WriteLogger("ERROR", ex.Message);
                return false;
            }

            logger.WriteLogger("INFO", $"Admin was add Receptionist {fullName}");
            receptionists.Add(receptionist);
            dbContext.WriteReceptionist(receptionists);

            return true;
        }

        private void IsValidRegister()
        {
            if (dbContext.ReadAdmin() == null)
                return;

            throw new InvalidRegisterException("The admin is already exist !");
        }

        private void IsValidLogin(string username, string password)
        {
            User user = dbContext.ReadAdmin();

            if (user != null)
            {
                if (user.Username == username && user.Password == password)
                    return;
            }

            throw new InvalidAuthenticationException("Invalid authentication exception");
        }

        private User CreateUser(string username, string password)
        {
            return new User(username, password);
        }

        private Receptionist CreateReceptionist(string fullName, decimal salary)
        {
            var manager = receptionists.FirstOrDefault(f => f.FullName == fullName);

            if (manager == null)
                return new Receptionist(fullName, salary);

            throw new InvalidEmployeerNameException("Invalid employeer name exception");
        }

        private SalesManager CreateSalesManager(string fullName, double salary, int overTime)
        {
            var manager = salesManagers.FirstOrDefault(f => f.FullName == fullName);

            if (manager == null)
                return new SalesManager(fullName, salary, overTime);

            throw new InvalidEmployeerNameException("Invalid employeer name exception");
        }

        private FinancialManager CreateFinancialManager(string fullName, double salary, int overTime)
        {
            var manager = financialManagers.FirstOrDefault(f => f.FullName == fullName);
            
            if (manager == null)
                return new FinancialManager(fullName, salary, overTime);

            throw new InvalidEmployeerNameException("Invalid employeer name exception");
        }
    }
}
