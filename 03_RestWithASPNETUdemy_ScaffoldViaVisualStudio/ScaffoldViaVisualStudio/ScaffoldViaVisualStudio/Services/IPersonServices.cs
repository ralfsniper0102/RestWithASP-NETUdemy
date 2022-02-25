using ScaffoldViaVisualStudio.Controllers.Model;
using System.Collections.Generic;

namespace ScaffoldViaVisualStudio.Services
{
    public interface IPersonServices
    {
        Person Create(Person person);
        void Delete(long id);
        Person FindById(long id);
        List<Person> FindAll();
        Person Update(Person person);

    }
}
