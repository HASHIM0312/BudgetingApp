// See https://aka.ms/new-console-template for more information
class UserAccount
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




class Program
{
    public static void Main(string[] args)
    {

        string DataFile = "data.txt";
        string Content = "[Empty File]";

        if (File.Exists(DataFile))
        {
            Content = File.ReadAllText(DataFile);
        }

        Console.WriteLine(Content);


        //Defining variables for calling methods
        string callTransaction = "transaction";
        string callDeposit = "Deposit";
        string Quit = "Quit";
        string search = "Search";

        //Self Explanatory
        Console.WriteLine("Input how many accounts you would like to input");
        int numberOfAccounts = Convert.ToInt32(Console.ReadLine());

        //According to the user input, creates account of the UserAccount class and stores the name, and balance of the account created (Creates a random ID for reference later). Stores the accounts in the account list
        for (int i = 0; i < numberOfAccounts; i++)
        {
            UserAccount userAccount1 = new UserAccount();
            UserAccount.accounts.Add(userAccount1);

        }
        Console.WriteLine("You have opened " + UserAccount.accounts.Count + " account(s)");


        //Prints all the accounts to the console
        foreach (UserAccount _account in UserAccount.accounts)
        {
            Console.WriteLine("Account name: " + _account.accountName + " | ID: " + _account.accountID + " | Balance: $" + _account.currentBalance);
        }


        //**THIS IS THE MAIN MENU** (Asks the user for the account ID to access an account, refer below for access details)
        Console.WriteLine("Enter the account ID to access it");
    //Label; to come back to it due to any exception or error
    MainMenu:
        //User inputs the account ID that they wish to access
        int userSearch = Convert.ToInt32(Console.ReadLine());

        //Calls the method to search for the account and access it
        UserAccount account = UserAccount.AccountByID(userSearch, UserAccount.accounts);
        if (account == null)
        {

            Console.WriteLine("Please type in a valid ID number: ");
            goto MainMenu;
        }

        //Prints out the name and balance of the account
        Console.WriteLine("Account Name: " + account.accountName + " | balance: $" + account.currentBalance);

        //Waits for user to input a command to either make a transaction, deposit, go back to search for another account, or quit the program
        Console.WriteLine("Type " + callTransaction + " to input a transaction; " + callDeposit + " to deposit; " + search + " to access another account; " + Quit + " to quit the program");
        string userInput = Console.ReadLine();

        //These if statements check for the different inputs
        if (userInput == callTransaction)
        {
        //Label; to repeat the transaction process
        Transaction:
            int balance = UserAccount.Transaction(account.currentBalance, account.transactions);
            account.currentBalance = balance;

            Console.WriteLine("Press ENTER to go back to the menu, type " + callTransaction + " to enter another transaction, or type " + Quit + " to exit out of the program");
            string anotherUserInput = Console.ReadLine();
            if (anotherUserInput == callTransaction)
            {
                goto Transaction;
            }
            else if (anotherUserInput == Quit)
            {
                goto Quit;
            }
            else
            {

                Console.Write("Enter an account ID: ");
                goto MainMenu;
            }

        }

        //Another check
        else if (userInput == callDeposit)
        {
            int newBalance = UserAccount.Deposit(account.currentBalance, account.deposits);

            account.currentBalance = newBalance;


        }

        //Another check
        else if (userInput == search)
        {

            Console.WriteLine("Here are the accounts again");
            Console.WriteLine("----------------------------");

            foreach (UserAccount account1 in UserAccount.accounts)
            {

                Console.WriteLine("Account name: " + account1.accountName + " | ID: " + account1.accountID + " | Balance: $" + account1.currentBalance);
            }

            Console.WriteLine("----------------------------");


            Console.Write("Please enter an ID number: ");
            goto MainMenu;
        }
        else if (userInput == Quit)
        {
            goto Quit;
        }


        //Checks if nothing is done, goes back to Main Menu
        else
        {
            Console.Write("Enter a valid ID number: ");
            goto MainMenu;
        }
    //**END OF MAIN MENU**

    Quit:

        Console.WriteLine("Press Enter to quit the program");
        //Press enter before closing*/
        Console.ReadKey();

    }
}
