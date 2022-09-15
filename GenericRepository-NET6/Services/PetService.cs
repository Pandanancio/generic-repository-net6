using GenericRepository_NET6.Models;
using GenericRepository_NET6.Repositories;

namespace GenericRepository_NET6.Services
{
    public class PetService : IPetService
    {
        private readonly IBaseRepository<Pet> _repository;

        public PetService(IBaseRepository<Pet> repository)
        {
            _repository = repository;
        }

        public async Task<Pet> Create(Pet pet)
        {
            try
            {
                return await _repository.Add(pet);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<Pet>> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch
            {
                throw;
            }
        }

        public async Task<Pet> GetById(int id)
        {
            try
            {
                var pet = await _repository.GetById(id);
                return pet;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Pet> Update(int id, Pet request)
        {
            var petToUpdate = await GetById(id);
            try
            {
                petToUpdate.Name = request.Name;
                petToUpdate.Breed = request.Breed;

                return await _repository.Update(petToUpdate);
            }
            catch
            {
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var pet = await GetById(id);
                await _repository.Remove(pet);
            }
            catch
            {
                throw;
            }
        }
    }
}
