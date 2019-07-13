using FluentValidation;
using ModeloDDDEstudo.Domain.Entities;
using System.Collections.Generic;

namespace ModeloDDDEstudo.Domain.Interfaces
{
    public interface IService<T> where T : BaseEntity
    {
        T Post<V>(T obj) where V : AbstractValidator<T>;
        T Put<V>(T obj) where V : AbstractValidator<T>;
        void Delete(int id);
        T Get(int id);
        IList<T> Get();
    }
}
