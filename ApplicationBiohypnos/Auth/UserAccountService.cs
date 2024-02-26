using DAL;
using Entites;
using System.Data;

namespace ApplicationBiohypnos.Auth
{
    public class UserAccountService
    {
       // private ModelUserAccount _user;

         public EntRegistration? GetByUserName(EntRegistration model)
        {
            return DalCRUD.Auth(model);
        }
    }
}
