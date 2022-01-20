// See https://aka.ms/new-console-template for more information
using BudgetAppClassLibrary;




class Program
{
    public static void Main(string[] args)
    {
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
