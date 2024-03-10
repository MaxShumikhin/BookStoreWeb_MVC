﻿using System.Linq.Expressions;

namespace BookStore.DataAccess.Repository.IRepository;

public interface IRepository<T> where T : class
{
    //T-Category, Product
    IEnumerable<T> GetAll();
    T Get(Expression<Func<T, bool>> filter);
    void Add(T entity);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);
}