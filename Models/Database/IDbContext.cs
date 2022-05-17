using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Database
{
    public interface IDbContext
    {
        void WriteUser(User user);
        void WriteFinancialManager(List<FinancialManager.FinancialManager> financialManagers);
        void WriteReceptionist(List<Receptionist.Receptionist> receptionists);
        void WriteSalesManager(List<SalesManager.SalesManager> salesManagers);
        User ReadAdmin();
    }
}
