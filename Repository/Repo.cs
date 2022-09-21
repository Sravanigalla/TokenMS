using Ecommerces_MS.Models;

namespace Ecommerces_MS.Repository
{
    public class Repo:IRepo
    {
        private readonly UserdbContext _dbcontext;

        public Repo(UserdbContext x)
        {
            _dbcontext = x;
        }

        public string createCustomers(UserRegister c)
        {
            _dbcontext.Customer2.Add (new Usermodel
            {
                
                username = c.username,
                email = c.email,
                name = c.name,
                password = c.password,
            
            });
            _dbcontext.SaveChanges();
            return "OK";
        }


    }
}
