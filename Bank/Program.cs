using System;
using System.Data.SQLite;
using System.Text.RegularExpressions;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {

            Database databaseObject = new Database();

            /*
            Console.ReadKey();

            var d = "ty";
            string query = $"INSERT INTO PersonalAccount (FullName,Email,PhoneNumber,Password,SavingAmount,CurrentAmount) VALUES ({d})";

            */

            /*
            string query = $"INSERT INTO PersonalAccount (FullName,Email,PhoneNumber,Password,SavingAmount,CurrentAmount) VALUES ('Blessings','bb@gmail.com','8342687','2345','50000','50000')";
            databaseObject.OpenConnection();
            SQLiteCommand myCommand = new SQLiteCommand(query, databaseObject.myConnection);
            var result = myCommand.ExecuteNonQuery();
            databaseObject.CloseConnection();
            Console.WriteLine("Rows Added : {0}", result);

            //
            string query = $"SELECT * FROM PersonalAccount)";
            SQLiteCommand myCommand = new SQLiteCommand(query, databaseObject.myConnection);
            databaseObject.OpenConnection();
            SQLiteReader result = myCommand.ExecuteReader();
            if (result.HasRows)
            {
                while (result.Read())
                {
                    ConsoleWriteLine("Full Name : {0} has {1}", result["FullName"], result["SavingAmount"]);   
                }
            }
            databaseObject.CloseConnection();
            //Console.WriteLine("Rows Added : {0}", result);

            Console.ReadKey();
            */

            /*Console.WriteLine("Do You Want To Perform Another Operation??");
                                Console.WriteLine("1. YES");
                                Console.WriteLine("2. NO");
                                dec = int.Parse(Console.ReadLine());
                                if (dec == 1)
                                {
                                    goto back;
                                }
                                else if (dec == 2)
                                {
                                    goto cancel;
                                }
                                else
                                {
                                    goto exit;
                                }
            */
            string ReguEx = "^[0-9a-zA-Z]+[.+-_]{0,1}[0-9a-zA-Z]+[@][a-zA-Z]+[.][a-zA-Z]{2-3}([a-zA-Z{2,3}){0,1}";


            int amount = 50000, deposit, withdraw, decision, userpin = 1234, count = 0, dec, pins;
            int choice;
            string query;
            //Console.WriteLine("Hello World!");

            while (true)
            {
                exit:
                    Console.WriteLine("");
                int pick;
                Console.WriteLine("WELCOME TO THIS BANK SERVICE");
                Console.WriteLine("Do You Have An Account?");
                Console.WriteLine("1. YES");
                Console.WriteLine("2. NO");
                Console.WriteLine("***************");
                Console.WriteLine("ENTER YOUR CHOICE : ");
                pick = int.Parse(Console.ReadLine());
                if (pick == 1)
                {
                    Console.WriteLine("Enter Your 4 Digit Pin ");
                    string pin = Console.ReadLine();

                    if (pin.Length == 4 && !String.IsNullOrEmpty(pin) && int.TryParse(pin, out pins))
                    {
                        Console.WriteLine("Valid Pin");
                    }
                    else
                    {
                        Console.WriteLine("Invalid Pin");
                    }

                    cancel:
                        Console.WriteLine(" ");
                    Console.WriteLine("What Account Do You Want To Access?");
                    Console.WriteLine("1. Savings");
                    Console.WriteLine("2. Current");
                    Console.WriteLine("3. Back");
                    Console.WriteLine("***************");
                    Console.WriteLine("ENTER YOUR CHOICE : ");
                    decision = int.Parse(Console.ReadLine());

                    if (decision == 1)
                    {
                        back:
                            Console.WriteLine(" ");
                        Console.WriteLine("You Chose The 'Savings' Option \n");
                        Console.WriteLine("1. Current Balance");
                        Console.WriteLine("2. Withdraw ");
                        Console.WriteLine("3. Deposit ");
                        Console.WriteLine("4. Back To Main Menu ");
                        Console.WriteLine("5. Cancel ");
                        Console.WriteLine("***************\n");
                        Console.WriteLine("ENTER YOUR CHOICE : ");
                        choice = int.Parse(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("\n YOUR CURRENT BALANCE IS {0} Naira", amount);

                                Console.WriteLine("Do You Want To Perform Another Operation??");
                                Console.WriteLine("1. YES");
                                Console.WriteLine("2. NO");
                                Console.WriteLine("***************");
                                Console.WriteLine("ENTER YOUR CHOICE : \n");
                                dec = int.Parse(Console.ReadLine());
                                if (dec == 1)
                                {
                                    goto back;
                                }
                                else if (dec == 2)
                                {
                                    goto cancel;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Input");
                                    goto exit;
                                }

                            case 2:
                                Console.WriteLine("\n ENTER THE WITHDRAW AMOUNT : ");
                                withdraw = int.Parse(Console.ReadLine());
                                if (withdraw % 10 != 0)
                                {
                                    Console.WriteLine("\n PLEASE ENTER THE AMOUNT IN ABOVE 10");
                                }
                                else if (withdraw > (amount - 5000))
                                {
                                    Console.WriteLine("\n SORRY! INSUFFICENT BALANCE");
                                }
                                else
                                {
                                    amount -= withdraw;
                                    Console.WriteLine("\n\n PLEASE COLLECT YOUR CASH");
                                    Console.WriteLine("\n CURRENT BALANCE IS {0} Naira", amount);
                                }

                                Console.WriteLine("Do You Want To Perform Another Operation??");
                                Console.WriteLine("1. YES");
                                Console.WriteLine("2. NO");
                                Console.WriteLine("***************");
                                Console.WriteLine("ENTER YOUR CHOICE : \n");
                                dec = int.Parse(Console.ReadLine());
                                if (dec == 1)
                                {
                                    goto back;
                                }
                                else if (dec == 2)
                                {
                                    goto cancel;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Input");
                                    goto exit;
                                }

                            case 3:
                                Console.WriteLine("\n ENTER THE DEPOSIT AMOUNT");
                                deposit = int.Parse(Console.ReadLine());
                                amount += deposit;
                                Console.WriteLine("YOUR AMOUNT HAS BEEN DEPOSITED SUCCESSFULLY..");
                                Console.WriteLine("YOUR TOTAL BALANCE IS {0} Naira", amount);

                                Console.WriteLine("Do You Want To Perform Another Operation??");
                                Console.WriteLine("1. YES");
                                Console.WriteLine("2. NO");
                                Console.WriteLine("***************");
                                Console.WriteLine("ENTER YOUR CHOICE : \n");
                                dec = int.Parse(Console.ReadLine());
                                if (dec == 1)
                                {
                                    goto back;
                                }
                                else if (dec == 2)
                                {
                                    goto cancel;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Input");
                                    goto exit;
                                }

                            case 4:
                                Console.WriteLine("\n THANK YOU…");
                                goto back;

                            case 5:
                                Console.WriteLine("\n THANK YOU…");
                                goto back;

                        }
                    }
                    else if (decision == 2)
                    {
                        back:
                            Console.WriteLine(" ");
                        Console.WriteLine("You Chose The 'Current' Option \n");
                        Console.WriteLine("1. Current Balance");
                        Console.WriteLine("2. Withdraw ");
                        Console.WriteLine("3. Deposit ");
                        Console.WriteLine("4. Cancel ");
                        Console.WriteLine("***************\n");
                        Console.WriteLine("ENTER YOUR CHOICE : ");
                        choice = int.Parse(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("\n YOUR CURRENT BALANCE IS {0} Naira", amount);

                                Console.WriteLine("Do You Want To Perform Another Operation??");
                                Console.WriteLine("1. YES");
                                Console.WriteLine("2. NO");
                                Console.WriteLine("***************");
                                Console.WriteLine("ENTER YOUR CHOICE : \n");
                                dec = int.Parse(Console.ReadLine());
                                if (dec == 1)
                                {
                                    goto back;
                                }
                                else if (dec == 2)
                                {
                                    goto cancel;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Input");
                                    goto exit;
                                }

                            case 2:
                                Console.WriteLine("\n ENTER THE WITHDRAW AMOUNT : ");
                                withdraw = int.Parse(Console.ReadLine());
                                if (withdraw % 10 != 0)
                                {
                                    Console.WriteLine("\n PLEASE ENTER THE AMOUNT IN ABOVE 10");
                                }
                                else if (withdraw > (amount - 1000))
                                {
                                    Console.WriteLine("\n SORRY! INSUFFICENT BALANCE");
                                }
                                else
                                {
                                    amount -= withdraw;
                                    Console.WriteLine("\n\n YOU HAVE COLLECTED {0} NAIRA", withdraw);
                                    Console.WriteLine("\n CURRENT BALANCE IS {0} Naira", amount);
                                    count += 1;
                                    if (count > 3)
                                    {
                                        Console.WriteLine("YOU HAVE RUN OUT OF WITHDRAWAL TIMES");
                                    }
                                    else if (count <= 3)
                                    {
                                        count += 1;
                                    }
                                }

                                Console.WriteLine("Do You Want To Perform Another Operation??");
                                Console.WriteLine("1. YES");
                                Console.WriteLine("2. NO");
                                Console.WriteLine("***************");
                                Console.WriteLine("ENTER YOUR CHOICE : \n");
                                dec = int.Parse(Console.ReadLine());
                                if (dec == 1)
                                {
                                    goto back;
                                }
                                else if (dec == 2)
                                {
                                    goto cancel;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Input");
                                    goto exit;
                                }

                            case 3:
                                Console.WriteLine("\n ENTER THE DEPOSIT AMOUNT");
                                deposit = int.Parse(Console.ReadLine());
                                amount += deposit;
                                Console.WriteLine("YOUR AMOUNT HAS BEEN DEPOSITED SUCCESSFULLY..");
                                Console.WriteLine("YOUR TOTAL BALANCE IS {0} Naira", amount);

                                Console.WriteLine("Do You Want To Perform Another Operation??");
                                Console.WriteLine("1. YES");
                                Console.WriteLine("2. NO");
                                Console.WriteLine("***************");
                                Console.WriteLine("ENTER YOUR CHOICE : \n");
                                dec = int.Parse(Console.ReadLine());
                                if (dec == 1)
                                {
                                    goto back;
                                }
                                else if (dec == 2)
                                {
                                    goto cancel;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Input");
                                    goto exit;
                                }

                            case 4:
                                Console.WriteLine("\n THANK YOU…");
                                goto back;

                            case 5:
                                Console.WriteLine("\n THANK YOU…");
                                goto cancel;

                        }
                    }
                    else if (decision == 3)
                    {
                        goto exit;
                    }

                    else
                    {
                        Console.WriteLine("Invalid input ");
                    }
                }
                else if (pick == 2)
                {
                    int sav_amount = 0, curr_amount = 0;
                    Console.WriteLine("Enter Your Full Name");
                    string fname = Console.ReadLine();
                    Console.WriteLine("Enter Your E-mail");
                    string email = Console.ReadLine();

                    //Verify E-mail
                    do
                    {
                        Console.WriteLine("Invalid E-mail");
                    }
                    while 
                        (!Regex.IsMatch(email, ReguEx));
                    Console.WriteLine("Valid E-mail");
                    string Email = email;
                    //

                    Console.WriteLine("Enter Your Phone Number");
                    string phoneno = Console.ReadLine();
                    Console.WriteLine("Enter Your Pin");
                    string passw = Console.ReadLine();

                    //Verify Pin
                    do
                        Console.WriteLine("Invalid Pin.\n Enter 4-Digit Pin");
                    while
                        (passw.Length != 4 && String.IsNullOrEmpty(passw) && !int.TryParse(passw, out pins));   
                    Console.WriteLine("Valid Pin");
                    //
                    
                    query = $"INSERT INTO PersonalAccount (FullName,Email,PhoneNumber,Password,SavingAmount,CurrentAmount) VALUES ( {fname} , {Email} , {phoneno} , {passw} , {sav_amount} , {curr_amount} )";
                    Console.WriteLine("SUCCESSFULLY ADDED");

                    Console.WriteLine("Enter Your 4 Digit Pin ");
                    int pin = int.Parse(Console.ReadLine());

                    //Verify Pin
                    do
                        Console.WriteLine("Invalid Pin.\n Enter 4-Digit Pin");
                    while
                        (passw.Length != 4 && String.IsNullOrEmpty(passw) && !int.TryParse(passw, out pins));
                    Console.WriteLine("Valid Pin");
                    //

                cancel:
                        Console.WriteLine(" ");
                    Console.WriteLine("What Account Do You Want To Access?");
                    Console.WriteLine("1. Savings");
                    Console.WriteLine("2. Current");
                    Console.WriteLine("3. Back");
                    Console.WriteLine("***************");
                    Console.WriteLine("ENTER YOUR CHOICE : ");
                    decision = int.Parse(Console.ReadLine());

                    if (decision == 1)
                    {
                        back:
                            Console.WriteLine(" ");
                        Console.WriteLine("You Chose The 'Savings' Option \n");
                        Console.WriteLine("1. Current Balance");
                        Console.WriteLine("2. Withdraw ");
                        Console.WriteLine("3. Deposit ");
                        Console.WriteLine("4. Back To Main Menu ");
                        Console.WriteLine("5. Cancel ");
                        Console.WriteLine("***************\n");
                        Console.WriteLine("ENTER YOUR CHOICE : ");
                        choice = int.Parse(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("\n YOUR CURRENT BALANCE IS {0} Naira", sav_amount);

                                Console.WriteLine("Do You Want To Perform Another Operation??");
                                Console.WriteLine("1. YES");
                                Console.WriteLine("2. NO");
                                Console.WriteLine("***************");
                                Console.WriteLine("ENTER YOUR CHOICE : \n");
                                dec = int.Parse(Console.ReadLine());
                                if (dec == 1)
                                {
                                    goto back;
                                }
                                else if (dec == 2)
                                {
                                    goto cancel;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Input");
                                    goto exit;
                                }

                            case 2:
                                Console.WriteLine("\n ENTER THE WITHDRAW AMOUNT : ");
                                withdraw = int.Parse(Console.ReadLine());
                                if (withdraw % 10 != 0)
                                {
                                    Console.WriteLine("\n PLEASE ENTER THE AMOUNT IN 10s");
                                }
                                else if (withdraw > (sav_amount - 5000))
                                {
                                    Console.WriteLine("\n SORRY! INSUFFICENT BALANCE");
                                }
                                else
                                {
                                    sav_amount -= withdraw;
                                    Console.WriteLine("\n\n PLEASE COLLECT YOUR CASH");
                                    Console.WriteLine("\n CURRENT BALANCE IS {0} Naira", sav_amount);
                                }

                                Console.WriteLine("Do You Want To Perform Another Operation??");
                                Console.WriteLine("1. YES");
                                Console.WriteLine("2. NO");
                                Console.WriteLine("***************");
                                Console.WriteLine("ENTER YOUR CHOICE : \n");
                                dec = int.Parse(Console.ReadLine());
                                if (dec == 1)
                                {
                                    goto back;
                                }
                                else if (dec == 2)
                                {
                                    goto cancel;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Input");
                                    goto exit;
                                }

                            case 3:
                                Console.WriteLine("\n ENTER THE DEPOSIT AMOUNT");
                                deposit = int.Parse(Console.ReadLine());
                                amount += deposit;
                                Console.WriteLine("YOUR AMOUNT HAS BEEN DEPOSITED SUCCESSFULLY..");
                                Console.WriteLine("YOUR TOTAL BALANCE IS {0} Naira", sav_amount);

                                Console.WriteLine("Do You Want To Perform Another Operation??");
                                Console.WriteLine("1. YES");
                                Console.WriteLine("2. NO");
                                Console.WriteLine("***************");
                                Console.WriteLine("ENTER YOUR CHOICE : \n");
                                dec = int.Parse(Console.ReadLine());
                                if (dec == 1)
                                {
                                    goto back;
                                }
                                else if (dec == 2)
                                {
                                    goto cancel;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Input");
                                    goto exit;
                                }

                            case 4:
                                Console.WriteLine("\n THANK YOU…");
                                goto back;

                            case 5:
                                Console.WriteLine("\n THANK YOU…");
                                goto cancel;
                        }
                    }
                    else if (decision == 2)
                    {
                        back:
                            Console.WriteLine(" ");
                        Console.WriteLine("You Chose The 'Current' Option \n");
                        Console.WriteLine("1. Current Balance");
                        Console.WriteLine("2. Withdraw ");
                        Console.WriteLine("3. Deposit ");
                        Console.WriteLine("4. Back To Main Menu ");
                        Console.WriteLine("5. Cancel ");
                        Console.WriteLine("***************\n");
                        Console.WriteLine("ENTER YOUR CHOICE : ");
                        choice = int.Parse(Console.ReadLine());
                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("\n YOUR CURRENT BALANCE IS {0} Naira", curr_amount);

                                Console.WriteLine("Do You Want To Perform Another Operation??");
                                Console.WriteLine("1. YES");
                                Console.WriteLine("2. NO");
                                Console.WriteLine("***************");
                                Console.WriteLine("ENTER YOUR CHOICE : \n");
                                dec = int.Parse(Console.ReadLine());
                                if (dec == 1)
                                {
                                    goto back;
                                }
                                else if (dec == 2)
                                {
                                    goto cancel;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Input");
                                    goto exit;
                                }

                            case 2:
                                Console.WriteLine("\n ENTER THE WITHDRAW AMOUNT : ");
                                withdraw = int.Parse(Console.ReadLine());
                                if (withdraw % 10 != 0)
                                {
                                    Console.WriteLine("\n PLEASE ENTER THE AMOUNT IN ABOVE 10");
                                }
                                else if (withdraw > (curr_amount - 1000))
                                {
                                    Console.WriteLine("\n SORRY! INSUFFICENT BALANCE");
                                }
                                else
                                {
                                    curr_amount -= withdraw;
                                    Console.WriteLine("\n\n YOU HAVE COLLECTED {0} NAIRA", withdraw);
                                    Console.WriteLine("\n CURRENT BALANCE IS {0} Naira", curr_amount);
                                    count += 1;
                                    if (count > 3)
                                    {
                                        Console.WriteLine("YOU HAVE RUN OUT OF WITHDRAWAL TIMES");
                                    }
                                    else if (count <= 3)
                                    {
                                        count += 1;
                                    }
                                }

                                Console.WriteLine("Do You Want To Perform Another Operation??");
                                Console.WriteLine("1. YES");
                                Console.WriteLine("2. NO");
                                Console.WriteLine("***************");
                                Console.WriteLine("ENTER YOUR CHOICE : \n");
                                dec = int.Parse(Console.ReadLine());
                                if (dec == 1)
                                {
                                    goto back;
                                }
                                else if (dec == 2)
                                {
                                    goto cancel;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Input");
                                    goto exit;
                                }

                            case 3:
                                Console.WriteLine("\n ENTER THE DEPOSIT AMOUNT");
                                deposit = int.Parse(Console.ReadLine());
                                amount += deposit;
                                Console.WriteLine("YOUR AMOUNT HAS BEEN DEPOSITED SUCCESSFULLY..");
                                Console.WriteLine("YOUR TOTAL BALANCE IS {0} Naira", curr_amount);

                                Console.WriteLine("Do You Want To Perform Another Operation??");
                                Console.WriteLine("1. YES");
                                Console.WriteLine("2. NO");
                                Console.WriteLine("***************");
                                Console.WriteLine("ENTER YOUR CHOICE : \n");
                                dec = int.Parse(Console.ReadLine());
                                if (dec == 1)
                                {
                                    goto back;
                                }
                                else if (dec == 2)
                                {
                                    goto cancel;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid Input");
                                    goto exit;
                                }

                            case 4:
                                Console.WriteLine("\n THANK YOU…");
                                goto back;

                            case 5:
                                Console.WriteLine("\n THANK YOU…");
                                goto cancel;

                        }
                    }
                    else if (decision == 3)
                    {
                        goto exit;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input ");
                    }
                }
                else
                {
                    goto exit;
                }
   
            }
        }
    }
}
