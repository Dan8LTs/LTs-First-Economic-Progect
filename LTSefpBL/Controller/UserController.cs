#region Libraries 
using LTSefpBL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;
#endregion

namespace LTSefpBL.Controller
{/// <summary>
 /// Контроллер пользователя.
 /// </summary>

    public class UserController : ControllerBase
    {
        /// <summary>
        /// Пользователь приложения.
        /// </summary>

        public List<User> Users { get; }

        public User CurrentUser { get; }

        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Создание контроллера.
        /// </summary>
        /// <param name="user"></param>

        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("UserName can't be empty", nameof(userName));
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
            }
        }


        /// <summary>
        /// Получить данные.
        /// </summary>
        /// <returns>Пользователь приложения.</returns>
        private List<User> GetUsersData()
        {
            return Load<User>() ?? new List<User>();
        }
        /// <summary>
        /// Получить список пользователей.
        /// </summary>
        /// <returns></returns>
        public void SetNewUserData(string type, DateTime birthdate, int earning)
        {
            CurrentUser.Type = new IncomeType(type);
            CurrentUser.BirthDate = birthdate;
            CurrentUser.Earning = earning;
            Save();
        }
        /// <summary>
        /// Сохранить данные.
        /// </summary>
        public void Save()
        {
            Save(Users);
        }
    }
}
