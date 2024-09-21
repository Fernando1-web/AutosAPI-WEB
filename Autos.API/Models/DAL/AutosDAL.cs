namespace Autos.API.Models.DAL
{
    public class AutosDAL
    {
        readonly CRMContext _context;

        //Constructor que interactua con base de datos
        public CustomerDAL(CRMContext cRMContext)
        {
            _context = cRMContext;
        }

        //Task:Crear
        public async Task<int> Create(Auto auto)
        {
            _context.Add(customer);
            return await _context.SaveChangesAsync();
        }

        //Task: Obtener por Id
        public async Task<Customer> GetById(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            return customer != null ? customer : new Customer();
        }

        //Task: Editar
        public async Task<int> Edit(Customer customer)
        {
            int result = 0;
            var customerUpdate = await GetById(customer.Id);
            if (customerUpdate.Id != 0)
            {
                customerUpdate.Name = customer.Name;
                customerUpdate.LastName = customer.LastName;
                customerUpdate.Address = customer.Address;
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        //Task: Eliminar
        public async Task<int> Delete(int id)
        {
            int result = 0;
            var customerDelete = await GetById(id);
            if(customerDelete.Id > 0)
            {
                _context.Customers.Remove(customerDelete);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        //Busqueda con filtro
        private IQueryable<Customer> Query(Customer customer)
        {
            var query = _context.Customers.AsQueryable();
            if (!string.IsNullOrWhiteSpace(customer.Name))
                query = query.Where(s => s.Name == customer.Name);
            if (!string.IsNullOrWhiteSpace(customer.LastName))
                query = query.Where(s => s.LastName == customer.LastName);
            return query;
        }

        //Contador 
        public async Task<int> CountSearch(Customer customer)
        {
            return await Query(customer).CountAsync();
        }

        //Paginacion
        public async Task<List<Customer>> Search(Customer customer, int take = 10, int skip = 0)
        {
            take = take == 0 ? 10 : take;
            var query = Query(customer);
            query = query.OrderByDescending(s => s.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }
    }
}
