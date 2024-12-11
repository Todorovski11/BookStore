﻿using Domain.Domain;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;



namespace Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;
        private readonly DbSet<Order> entities;

        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Order>();
        }

        public List<Order> GetAllOrders()
        {
            List<Order> tmp = entities
                .Include("BooksInOrder") // Include BooksInOrder
                .Include("Owner") // Include Owner
                .Include("BooksInOrder.Book") // Include Book related to BooksInOrder
                .ToList();
            return entities
                .Include("BooksInOrder") // Include BooksInOrder
                .Include("Owner") // Include Owner
                .Include("BooksInOrder.Book") // Include Book related to BooksInOrder
                .ToList();
        }

        public Order GetDetailsForOrder(BaseEntity id)
        {
            return entities
                .Include("BooksInOrder") // Include BooksInOrder
                .Include("Owner") // Include Owner
                .Include("BooksInOrder.Book") // Include Book related to BooksInOrder
                .SingleOrDefault(z => z.Id == id.Id);
        }
    }
}