using Autos.API.Models.EN;

namespace Autos.API.Models.DAL
{
    public class AutosDAL
    {
        readonly AutosDBContext _context;

        //Constructor que interactua con base de datos
        public AutosDAL(AutosDBContext autosDBContext)
        {
            _context = autosDBContext;
        }

        //Task:Crear
        public async Task<int> Create(Auto auto)
        {
            _context.Add(auto);
            return await _context.SaveChangesAsync();
        }

        //Task: Obtener por Id
        public async Task<Auto> GetById(int id)
        {
            var auto = await _context.Autos.FirstOrDefaultAsync(x => x.Id == id);
            return auto != null ? auto : new Auto();
        }

        //Task: Editar
        public async Task<int> Edit(Auto auto)
        {
            int result = 0;
            var autoUpdate = await GetById(auto.Id);
            if (autoUpdate.Id != 0)
            {
                autoUpdate.Marca = auto.Marca;
                autoUpdate.Modelo = auto.Modelo;
                autoUpdate.Year = auto.Year;
                autoUpdate.Precio = auto.Precio;
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        //Task: Eliminar
        public async Task<int> Delete(int id)
        {
            int result = 0;
            var autoDelete = await GetById(id);
            if(autoDelete.Id > 0)
            {
                _context.Autos.Remove(autoDelete);
                result = await _context.SaveChangesAsync();
            }
            return result;
        }

        //Busqueda con filtro
        private IQueryable<Auto> Query(Auto auto)
        {
            var query = _context.Autos.AsQueryable();
            if (!string.IsNullOrWhiteSpace(auto.Marca))
                query = query.Where(s => s.Marca == auto.Marca);
            if (!string.IsNullOrWhiteSpace(auto.Modelo))
                query = query.Where(s => s.Modelo == auto.Modelo);
            return query;
        }

        //Contador 
        public async Task<int> CountSearch(Auto auto)
        {
            return await Query(auto).CountAsync();
        }

        //Paginacion
        public async Task<List<Auto>> Search(Auto auto, int take = 10, int skip = 0)
        {
            take = take == 0 ? 10 : take;
            var query = Query(auto);
            query = query.OrderByDescending(s => s.Id).Skip(skip).Take(take);
            return await query.ToListAsync();
        }
    }
}
