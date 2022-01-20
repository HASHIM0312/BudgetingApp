namespace BudgetAppClassLibrary
{
    public class UserAccount
    {
       
        

            //Declaring variables and list to keep track of everything
            public static List<UserAccount> accounts = new List<UserAccount>();
            static Random numberGen = new Random();

            public int currentBalance;
            public List<int> deposits = new List<int>();
            public List<int> transactions = new List<int>();
            public string accountName;
            public int accountID;



            //Constructor, refer below for details
            public UserAccount()
            {
                Console.Write("Account Name please: ");



            //Asks for account name
            Input:
                string _accountName = Console.ReadLine();

                //Checks for null value
                if (_accountName == null || _accountName == string.Empty)
                {
                    Console.WriteLine("Please enter in a valid name");
                    goto Input;
                }
                else
                {

                    accountName = _accountName;
                }

                //Asks for the initial amount of money

                Console.Write("Initial Balance for: ");

            //Label; to come back for any exception
            InputMoney:
                string _userMoney = Console.ReadLine();


                int actualUserMoney;
                if (Int32.TryParse(_userMoney, out actualUserMoney))
                {
                    //Checks if money is more than $0
                    if (actualUserMoney <= 0)
                    {
                        Console.Write("Please enter in a valid amount: ");
                        goto InputMoney;
                    }

                    //Makes the current balance of the account the money that was entered in the constructor
                    else
                    {
                        currentBalance = actualUserMoney;
                    }

                }
                else
                {
                    Console.Write("Please enter a valid amount of money: ");
                    goto InputMoney;
                }




            //Creates a random account ID
            RandomIDGen:
                accountID = numberGen.Next(1, 100);

                if (accounts.Count > 1)
                {

                    foreach (UserAccount account in accounts)
                    {
                        if (accountID == account.accountID)
                        {
                            goto RandomIDGen;

                        }

                    }

                }


                //END OF CONSTRUCTOR**
            }


            //Transaction() Method
            public static int Transaction(int userMoney, List<int> transactions)
            {
                //Asks for transaction
                Console.WriteLine("Enter how much you spent");

            Transaction:

                string _transaction = Console.ReadLine();

                int transaction;
                if (Int32.TryParse(_transaction, out transaction))
                {
                    //Checks if the user has the sufficient funds
                    if (transaction > userMoney)
                    {
                        Console.WriteLine("Sorry but your account does not have the sufficient funds. The transaction was cancelled");
                        return userMoney;


                    }

                    else
                    {

                        userMoney = userMoney - transaction;
                        transactions.Add(transaction);
                        Console.WriteLine("Remaining Balance: $" + userMoney);

                        return userMoney;

                    }
                }
                else
                {
                    Console.Write("Woah, please enter a valid amount: ");
                    goto Transaction;
                }







                //Checks if the user has the sufficient funds
                if (transaction > userMoney)
                {
                    Console.WriteLine("Sorry but your account does not have the sufficient funds. The transaction was cancelled");
                    return userMoney;


                }

                else
                {

                    userMoney = userMoney - transaction;
                    transactions.Add(transaction);
                    Console.WriteLine("Remaining Balance: $" + userMoney);

                    return userMoney;

                }





                //END OF TRANSACTION METHOD
            }


            public static int Deposit(int userMoney, List<int> deposits)
            {



                Console.Write("Wow, good job; Please enter how much you want to deposit: ");

            Deposit:
                int deposit = Convert.ToInt32(Console.ReadLine());

                if (deposit <= 0)
                {

                    Console.WriteLine("------------------------");

                    Console.Write("Please enter in a valid deposit: ");
                    goto Deposit;
                }

                else
                {

                    userMoney = userMoney + deposit;


                    Console.WriteLine("----------------");

                    Console.WriteLine("Current Balance: " + userMoney);

                    deposits.Add(deposit);

                    return userMoney;

                }







            }

            public static UserAccount AccountByID(int id, List<UserAccount> accounts)
            {

                foreach (UserAccount account in accounts)
                {
                    if (account.accountID == id)
                    {
                        return account;
                    }
                }

                return null;


            }



        

    }
}