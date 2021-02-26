using System;
using System.Collections.ObjectModel;

namespace Hw_13
{
    class Fill
    {
        // Создаем список клиентов.
        public static ObservableCollection<Clients> client;

        // Создаем список счетов.
        public static ObservableCollection<Accounts> account;

        // Создаем рандом.
        static Random random;

        /// <summary>
        /// Инициализируем объекты.
        /// </summary>
        static Fill()
        {
            client = new ObservableCollection<Clients>();
            account = new ObservableCollection<Accounts>();
            random = new Random();
        }

        /// <summary>
        /// Метод для автоматического заполнения.
        /// </summary>
        public static void AutoFill()
        {
            // Записываем случайным образом кол-во клиентов.
            int clientCount = random.Next(10, 50);

            // Создаем переменную для кол-во счетов у клиента.
            int accountCount;

            // Добавляем в список новых клиентов.
            for(int i = 0; i < clientCount; i++)
            {
                client.Add(new Clients($"Клиент нр. {i + 1}", RandomClientsType(), RandomCreditType()));
            }

            // Создаем депозиты у всех клиентов.
            foreach(var cl in client)
            {
                // Случайным образом формируем кол-во счетов.
                accountCount = random.Next(1, 6);

                // Добавляем счета.
                for (int i = 0; i < accountCount; i++)
                {
                    account.Add(new Accounts(cl.Index, GetRandomDouble(), RandomDepositType()));
                }

            }
        }

        /// <summary>
        /// Метод для случайного типа клиента.
        /// </summary>
        /// <returns>Тип клиента.</returns>
        private static ClientsType RandomClientsType()
        {
            // Записываем случайную цифру.
            int clientType = random.Next(1, 4);

            switch(clientType)
            {
                case 1:
                    return ClientsType.Entity;
                case 2:
                    return ClientsType.Usual;
                default:
                    return ClientsType.Vip;
            }
        }

        /// <summary>
        /// Метод для случайного типа кредитной истории.
        /// </summary>
        /// <returns>Тип клиента.</returns>
        private static CreditHistoryType RandomCreditType()
        {
            // Записываем случайную цифру.
            int creditType = random.Next(1, 4);

            switch (creditType)
            {
                case 1:
                    return CreditHistoryType.Zero;
                case 2:
                    return CreditHistoryType.Good;
                default:
                    return CreditHistoryType.Bad;
            }
        }

        /// <summary>
        /// Метод для случайного типа депозита.
        /// </summary>
        /// <returns>Тип депозита</returns>
        private static DepositType RandomDepositType()
        {
            // Записываем случайную цифру.
            int clientType = random.Next(1, 3);

            switch (clientType)
            {
                case 1:
                    return DepositType.WithoutСapitalization;
                default:
                    return DepositType.WithСapitalization;
            }
        }

        /// <summary>
        /// Метод для получения случайной суммы на депозит.
        /// </summary>
        /// <returns>Сумма на депозит.</returns>
        private static double GetRandomDouble()
        {
            int amount = random.Next(100, 100000);

            return random.NextDouble() * amount;
        }

        /// <summary>
        /// Метод для удаления данных из коллекций.
        /// </summary>
        public static void RemoveDataFromCollection()
        {
            client.Clear();
            account.Clear();
        }
    }
}
