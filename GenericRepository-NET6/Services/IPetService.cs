using GenericRepository_NET6.Models;

namespace GenericRepository_NET6.Services
{
    public interface IPetService
    {
        Task<Pet> Create(Pet pet);
        Task<List<Pet>> GetAll();
        Task<Pet> GetById(int id);
        Task<Pet> Update(int id, Pet request);
        Task Delete(int id);
    }
}