using AccessNowMTL.Api.Models;

namespace AccessNowMTL.Api.Data
{
    public static class ServiceRepository
    {
        private static List<Service> services = new()
        {
            new Service
            {
                Id = 1,
                Name = "CLSC",
                Category = "Santé",
                Borough = "Montréal",
                Address = "Montréal",
                Phone = "",
                Website = "https://www.quebec.ca/sante",
                IsFree = true
            },
            new Service
            {
                Id = 2,
                Name = "Aide au logement",
                Category = "Logement",
                Borough = "Montréal",
                Address = "Montréal",
                Phone = "",
                Website = "https://www.quebec.ca/habitation",
                IsFree = true
            },
            new Service
            {
                Id = 3,
                Name = "Aide aux nouveaux arrivants",
                Category = "Immigration",
                Borough = "Montréal",
                Address = "Montréal",
                Phone = "",
                Website = "",
                IsFree = true
            }
        };

        public static List<Service> GetAll()
        {
            return services;
        }

        public static Service? GetById(int id)
        {
            return services.FirstOrDefault(s => s.Id == id);
        }

        public static List<Service> Search(string? category, string? borough)
        {
            IEnumerable<Service> result = services;

            if (!string.IsNullOrWhiteSpace(category))
            {
                result = result.Where(s => s.Category != null &&
                    s.Category.ToLower().Contains(category.ToLower()));
            }

            if (!string.IsNullOrWhiteSpace(borough))
            {
                result = result.Where(s => s.Borough != null &&
                    s.Borough.ToLower().Contains(borough.ToLower()));
            }

            return result.ToList();
        }

        public static Service Add(Service service)
        {
            int nextId = services.Count == 0 ? 1 : services.Max(s => s.Id) + 1;
            service.Id = nextId;

            services.Add(service);
            return service;
        }

        public static bool Update(int id, Service updated)
        {
            var existing = GetById(id);
            if (existing == null) return false;

            existing.Name = updated.Name;
            existing.Category = updated.Category;
            existing.Borough = updated.Borough;
            existing.Address = updated.Address;
            existing.Phone = updated.Phone;
            existing.Website = updated.Website;
            existing.IsFree = updated.IsFree;

            return true;
        }

        public static bool Delete(int id)
        {
            var existing = GetById(id);
            if (existing == null) return false;

            services.Remove(existing);
            return true;
        }
    }
}
