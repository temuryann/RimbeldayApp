namespace Use_Cases.User_Logic
{
    public interface IUserManager
    {
        bool AddFinanceManager(string fullName, double salary, int overTime);
        bool AddSalesManager(string fullName, double salary, int overTime);
        bool AddRecption(string fullName, decimal salary);
        bool CanLogin(string username, string password);
        bool CanRegister(string username, string password);
    }
}
