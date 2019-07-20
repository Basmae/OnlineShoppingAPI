﻿using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer
{
    public interface IUserService
    {
        bool IsAvailable(string userName);
        IEnumerable<Cart> getCart(Guid userId);
        void AddTOCart(Cart cart);
        void SubmitOrder(User user);
        IEnumerable<Order> getUserOrders(Guid userId);
        User getUser(Guid userId);
        User GetUserByName(string userName);
        void AddUser(User user);
        Cart DeleteCart(Cart cart);
        IEnumerable<User> getAllUsers();
    }
}