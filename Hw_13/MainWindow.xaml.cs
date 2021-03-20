using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Hw_13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Создаем клиента.
        Clients client;

        // Создаем список активностей.
        ActionsMessage actionMessage = new ActionsMessage();

        public MainWindow()
        {
            #region Задание.
            // Создать прототип банковской системы, позвляющей управлять клиентами и клиентскими счетами.
            // В информационной системе есть возможность 
            /// Ok! =   перевода денежных средств между счетами пользователей 
            /// Ок! =   Открывать вклады, 1) с капитализацией!!!! и 2) без!!!!
            #region Пример про капитализацию.
            // 100 12%
            // 12 ме - 112
            // 100 12%
            // 101 12%
            // 102.01 12%

            //     100
            // 1   101
            // 2   102,01
            // 3   103,0301
            // 4   104,060401
            // 5   105,101005
            // 6   106,1520151
            // 7   107,2135352
            // 8   108,2856706
            // 9   109,3685273
            // 10  110,4622125
            // 11  111,5668347
            // 12  112,682503
            #endregion
            /// Ok! =   * Продумать возможность выдачи кредитов
            //
            /// Ok! =   Продумать использование обобщений

            /// Ok! =   Продемонстрировать работу созданной системы

            /// Банк
            /// ├── Отдел работы с обычными клиентами
            /// ├── Отдел работы с VIP клиентами
            /// └── Отдел работы с юридическими лицами

            /// Ok! =   Дополнительно: клиентам с хорошей кредитной историей предлагать пониженую ставку по кредиту и 
            ///         повышенную ставку по вкладам
            /// Ok! =   Добавить механизмы оповещений используя делегаты и события
            /// Ok! =   Реализовать журнал действий, который будет хранить записи всех транзакций по 
            ///         счетам / вкладам / кредитам
            //
            // Задание 15.
            /// Ok! =   Создать собственные исключения и добавить их обработку в предыдущий проект
            /// Ok! =   Подумать над использованием методов-расширений и
            // перегрузках операций
            /// Ok! =   Вынести основную логику в отдельную(ые) библиотеку 
            #endregion
            InitializeComponent();

            this.listActions.ItemsSource = ActionsMessage.actionList;
        }

        /// <summary>
        /// Метод для автоматического заполнения.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAutoFill_Click(object sender, RoutedEventArgs e)
        {
            this.listClients.ItemsSource = null;

            Fill.RemoveDataFromCollection();

            Fill.AutoFill();

            this.listClients.ItemsSource = Fill.client;
        }

        /// <summary>
        /// Метод для заполнения списка с вкладами.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Обнуляем данные в списках.
            this.listAccounts.ItemsSource = null;
            this.listAccountsCredit.ItemsSource = null;

            // Записываем выделенную запись.
            client = (Clients)listClients.SelectedItem;

            // Проверяем, чтобы выделили запись.
            if (client == null)
                return;

            // Заполняем список со счетами.
            this.listAccounts.ItemsSource = Fill.account.Where(x => x.СlientsIndex == client.Index
                                                                && x.TypeOfDeposit != DepositType.Credit);
            // Заполняем список с кредитами.
            this.listAccountsCredit.ItemsSource = Fill.account.Where(x => x.СlientsIndex == client.Index
                                                                && x.TypeOfDeposit == DepositType.Credit);
        }

        /// <summary>
        /// Метод для открытия нового вклада.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            // Записываем выделенную запись.
            client = (Clients)listClients.SelectedItem;
            
            // Проверяем, чтобы выделили запись.
            if(client == null)
            {
                MessageBox.Show("Необходимо выбрать клиента!");
                return;
            }
            
            // Создаем форму.
            FNewDeposit newDeposit = new FNewDeposit();

            // Устанавлиеваем значения в переменных формы.
            newDeposit.name = client.Name;

            // Если нажали "Ок", тогда добавляем новый вклад.
            if(newDeposit.ShowDialog() == true)
            {
                Fill.account.Add(new Accounts(client.Index, newDeposit.amount, newDeposit.type));
                actionMessage.Message(client.Name, "Открыл новый вчет", newDeposit.amount);
            }

            // Обновляем список с вкладами.
            this.listAccounts.ItemsSource = Fill.account.Where(x => x.СlientsIndex == client.Index
                                                               && x.TypeOfDeposit != DepositType.Credit);
        }

        /// <summary>
        /// Метод для перевода вкладов.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTransfer_Click(object sender, RoutedEventArgs e)
        {
            // Записываем выделенную запись.
            client = (Clients)listClients.SelectedItem;

            // Проверяем, чтобы выделили запись.
            if (client == null)
            {
                MessageBox.Show("Необходимо выбрать, кто будет переводить деньги.");
                return;
            }

            // Создаем новую форму.
            FMoneyTransfer mt = new FMoneyTransfer();

            // Передаем индекс клиента в форму.
            mt.clientIndex = client.Index;

            if (mt.ShowDialog() == true)
            {
                // Отнимает от счета.
                foreach (var acc in Fill.account)
                {
                    if (acc.Index == mt.accountIndex)
                    {
                        acc.Amount = Math.Round(acc.Amount - mt.amount,2);
                        
                        actionMessage.Message(client.Name, "Отправил деньги", mt.amount);

                        if (acc.Amount == 0) 
                        {
                            
                            Fill.account.Remove(acc);
                            break;
                        }

                        break;
                    }
                }

                // Прибавляем к счету.
                foreach(var acc in Fill.account)
                {
                    if(acc.СlientsIndex == mt.clientIndex && acc.TypeOfDeposit != DepositType.Credit)
                    {
                        acc.Amount = Math.Round(acc.Amount += mt.amount, 2);

                        foreach (var client in Fill.client)
                            if (acc.СlientsIndex == client.Index)
                            {
                                actionMessage.Message(client.Name, "Получил деньги", mt.amount);
                                break;
                            }

                        break;
                    }
                }

                // Заполняем список со счетами.
                this.listAccounts.ItemsSource = Fill.account.Where(x => x.СlientsIndex == client.Index
                                                                   && x.TypeOfDeposit != DepositType.Credit);
            }
        }

        /// <summary>
        /// Метод для выдачи кредита.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoan_Click(object sender, RoutedEventArgs e)
        {
            // Записываем выделенную запись.
            client = (Clients)listClients.SelectedItem;

            // Проверяем, чтобы выделили запись.
            if (client == null)
            {
                MessageBox.Show("Необходимо выбрать, кому выдается кредит.");
                return;
            }

            // Создаем форму.
            FLoan loan = new FLoan();

            // Устанавлиеваем значения в переменных формы.
            loan.name = client.Name;
            loan.creditHistory = client.CreditType;

            // Если нажали "Ок", тогда выдаем кредит.
            if (loan.ShowDialog() == true)
            {
                Fill.account.Add(new Accounts(client.Index, loan.credit, DepositType.Credit));
                actionMessage.Message(client.Name, "Взял кредит", loan.credit);
            }

            // Заполняем список с кредитами.
            this.listAccountsCredit.ItemsSource = Fill.account.Where(x => x.СlientsIndex == client.Index
                                                                && x.TypeOfDeposit == DepositType.Credit);
        }

        /// <summary>
        /// Метод для подписки при загрузке формы.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listActions_Loaded(object sender, RoutedEventArgs e)
        {
            // Подписываем на обновления.
            ActionsMessage actionMessageList = new ActionsMessage();
            actionMessage.Post += actionMessageList.ClientsActions;
        }
    }
}
