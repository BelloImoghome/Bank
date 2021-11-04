using System;
using System.Data.SQLite;
using System.Text.RegularExpressions;
using System.Net;
using EASendMail;


namespace Bank
{
    class Program
    {
        /*
        static void EmailSendingWelcome(string email, string name)
        {
            try
            {
                SmtpMail oMail = new SmtpMail("TryIt")
                {

                    // Your gmail email address
                    From = "belloimoghome08@gmail.com",

                    // Set recipient email address
                    To = email,

                    // Set email subject
                    Subject = "WELCOME",

                    // Set email body
                    TextBody = $"WELCOME {name}, Thank You For Using DaggerFoam Banking Service.",
                };

                // Gmail SMTP server address
                SmtpServer oServer = new SmtpServer("smtp.gmail.com");
                // Gmail user authentication
                // For example: your email is "gmailid@gmail.com", then the user should be the same
                oServer.User = "belloimoghome08@gmail.com";
                oServer.Password = "#MyGmailPassword1";

                // Set 587 port, if you want to use 25 port, please change 587 5o 25
                oServer.Port = 587;

                // detect SSL/TLS automatically
                oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

                //Console.WriteLine("start to send email over SSL ...");

                SmtpClient oSmtp = new SmtpClient();
                oSmtp.SendMail(oServer, oMail);

                //Console.WriteLine("email was sent successfully!");
            }
            catch (Exception ep)
            {
                Console.WriteLine("Failed to send email with the following error:");
                Console.WriteLine(ep.Message);
            }

        }
        */

        static int Check(string ema)
        {
            string sqlite = "SELECT COUNT(*) FROM PersonalAccount WHERE Email = @ema";
            Database databaseObject = new Database();
            SQLiteCommand myCommand = new SQLiteCommand(sqlite, databaseObject.myConnection);
            myCommand.Parameters.AddWithValue("@ema", ema);
            databaseObject.OpenConnection();
            int rowcount = Convert.ToInt32(myCommand.ExecuteScalar());
            databaseObject.CloseConnection();
            return rowcount;
        }

        static int Verify(string pas)
        {
            string sqlite = "SELECT COUNT(*) FROM PersonalAccount WHERE Password = @pas";
            Database databaseObject = new Database();
            SQLiteCommand myCommand = new SQLiteCommand(sqlite, databaseObject.myConnection);
            myCommand.Parameters.AddWithValue("@pas", pas);
            databaseObject.OpenConnection();
            int rowcount = Convert.ToInt32(myCommand.ExecuteScalar());
            databaseObject.CloseConnection();
            return rowcount;
        }

        static void EmailSendingSavingsAmount(string email, string name, int balance)
        {
            try
            {
                SmtpMail oMail = new SmtpMail("TryIt")
                {

                    // Your gmail email address
                    From = "belloimoghome08@gmail.com",

                    // Set recipient email address
                    To = email,

                    // Set email subject
                    Subject = "Account Balance",

                    // Set email body
                    TextBody = $"Dear {name}, Your Savings Account Balance Is #{balance}",
                };

                // Gmail SMTP server address
                SmtpServer oServer = new SmtpServer("smtp.gmail.com");
                // Gmail user authentication
                // For example: your email is "gmailid@gmail.com", then the user should be the same
                oServer.User = "belloimoghome08@gmail.com";
                oServer.Password = "#MyGmailPassword1";

                // Set 587 port, if you want to use 25 port, please change 587 5o 25
                oServer.Port = 587;

                // detect SSL/TLS automatically
                oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

                //Console.WriteLine("start to send email over SSL ...");

                SmtpClient oSmtp = new SmtpClient();
                oSmtp.SendMail(oServer, oMail);

                //Console.WriteLine("email was sent successfully!");
            }
            catch (Exception ep)
            {
                Console.WriteLine("failed to send email with the following error:");
                Console.WriteLine(ep.Message);
            }

        }

        static void EmailSendingSavingsWithdrawal(string email, string name, int withdrawal, int balance)
        {
            try
            {
                SmtpMail oMail = new SmtpMail("TryIt")
                {

                    // Your gmail email address
                    From = "belloimoghome08@gmail.com",

                    // Set recipient email address
                    To = email,

                    // Set email subject
                    Subject = "Withdrawal",

                    // Set email body
                    TextBody = $"Dear {name}, Your Savings Account Has Been Debited With #{withdrawal}. Your New Savings Account Balance Is #{balance}",
                };

                // Gmail SMTP server address
                SmtpServer oServer = new SmtpServer("smtp.gmail.com");
                // Gmail user authentication
                // For example: your email is "gmailid@gmail.com", then the user should be the same
                oServer.User = "belloimoghome08@gmail.com";
                oServer.Password = "#MyGmailPassword1";

                // Set 587 port, if you want to use 25 port, please change 587 5o 25
                oServer.Port = 587;

                // detect SSL/TLS automatically
                oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

                //Console.WriteLine("start to send email over SSL ...");

                SmtpClient oSmtp = new SmtpClient();
                oSmtp.SendMail(oServer, oMail);

                //Console.WriteLine("email was sent successfully!");
            }
            catch (Exception ep)
            {
                Console.WriteLine("failed to send email with the following error:");
                Console.WriteLine(ep.Message);
            }

        }

        static void EmailSendingSavingsDeposit(string email, string name, int deposited, int balance)
        {
            try
            {
                SmtpMail oMail = new SmtpMail("TryIt")
                {

                    // Your gmail email address
                    From = "belloimoghome08@gmail.com",

                    // Set recipient email address
                    To = email,

                    // Set email subject
                    Subject = "Withdrawal",

                    // Set email body
                    TextBody = $"Dear {name}, Your Savings Have Been Credited With #{deposited}. Your New Savings Account Balance Is #{balance}",
                };

                // Gmail SMTP server address
                SmtpServer oServer = new SmtpServer("smtp.gmail.com");
                // Gmail user authentication
                // For example: your email is "gmailid@gmail.com", then the user should be the same
                oServer.User = "belloimoghome08@gmail.com";
                oServer.Password = "#MyGmailPassword1";

                // Set 587 port, if you want to use 25 port, please change 587 5o 25
                oServer.Port = 587;

                // detect SSL/TLS automatically
                oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

                //Console.WriteLine("start to send email over SSL ...");

                SmtpClient oSmtp = new SmtpClient();
                oSmtp.SendMail(oServer, oMail);

                //Console.WriteLine("email was sent successfully!");
            }
            catch (Exception ep)
            {
                Console.WriteLine("failed to send email with the following error:");
                Console.WriteLine(ep.Message);
            }

        }

        static void EmailSendingCurrentAmount(string email, string name, int balance)
        {
            try
            {
                SmtpMail oMail = new SmtpMail("TryIt")
                {

                    // Your gmail email address
                    From = "belloimoghome08@gmail.com",

                    // Set recipient email address
                    To = email,

                    // Set email subject
                    Subject = "Account Balance",

                    // Set email body
                    TextBody = $"Dear {name}, Your Current Account's Balance Is #{balance}",
                };

                // Gmail SMTP server address
                SmtpServer oServer = new SmtpServer("smtp.gmail.com");
                // Gmail user authentication
                // For example: your email is "gmailid@gmail.com", then the user should be the same
                oServer.User = "belloimoghome08@gmail.com";
                oServer.Password = "#MyGmailPassword1";

                // Set 587 port, if you want to use 25 port, please change 587 5o 25
                oServer.Port = 587;

                // detect SSL/TLS automatically
                oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

                //Console.WriteLine("start to send email over SSL ...");

                SmtpClient oSmtp = new SmtpClient();
                oSmtp.SendMail(oServer, oMail);

                //Console.WriteLine("email was sent successfully!");
            }
            catch (Exception ep)
            {
                Console.WriteLine("failed to send email with the following error:");
                Console.WriteLine(ep.Message);
            }

        }

        static void EmailSendingCurrentWithdrawal(string email, string name, int withdrawal, int balance)
        {
            try
            {
                SmtpMail oMail = new SmtpMail("TryIt")
                {

                    // Your gmail email address
                    From = "belloimoghome08@gmail.com",

                    // Set recipient email address
                    To = email,

                    // Set email subject
                    Subject = "Withdrawal",

                    // Set email body
                    TextBody = $"Dear {name}, Your 'Current' Account Has Been Debited With #{withdrawal}. Your New 'Current' Account Balance Is #{balance}",
                };

                // Gmail SMTP server address
                SmtpServer oServer = new SmtpServer("smtp.gmail.com");
                // Gmail user authentication
                // For example: your email is "gmailid@gmail.com", then the user should be the same
                oServer.User = "belloimoghome08@gmail.com";
                oServer.Password = "#MyGmailPassword1";

                // Set 587 port, if you want to use 25 port, please change 587 5o 25
                oServer.Port = 587;

                // detect SSL/TLS automatically
                oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

                //Console.WriteLine("start to send email over SSL ...");

                SmtpClient oSmtp = new SmtpClient();
                oSmtp.SendMail(oServer, oMail);

                //Console.WriteLine("email was sent successfully!");
            }
            catch (Exception ep)
            {
                Console.WriteLine("failed to send email with the following error:");
                Console.WriteLine(ep.Message);
            }

        }

        static void EmailSendingCurrentDeposit(string email, string name, int deposited, int balance)
        {
            try
            {
                SmtpMail oMail = new SmtpMail("TryIt")
                {

                    // Your gmail email address
                    From = "belloimoghome08@gmail.com",

                    // Set recipient email address
                    To = email,

                    // Set email subject
                    Subject = "Withdrawal",

                    // Set email body
                    TextBody = $"Dear {name}, Your 'Current' Account Has Been Credited With #{deposited}. Your New 'Current' Account Balance Is #{balance}",
                };

                // Gmail SMTP server address
                SmtpServer oServer = new SmtpServer("smtp.gmail.com");
                // Gmail user authentication
                // For example: your email is "gmailid@gmail.com", then the user should be the same
                oServer.User = "belloimoghome08@gmail.com";
                oServer.Password = "#MyGmailPassword1";

                // Set 587 port, if you want to use 25 port, please change 587 5o 25
                oServer.Port = 587;

                // detect SSL/TLS automatically
                oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

                //Console.WriteLine("start to send email over SSL ...");

                SmtpClient oSmtp = new SmtpClient();
                oSmtp.SendMail(oServer, oMail);

                //Console.WriteLine("email was sent successfully!");
            }
            catch (Exception ep)
            {
                Console.WriteLine("failed to send email with the following error:");
                Console.WriteLine(ep.Message);
            }

        }

        static void InsertStatementSavings(string fullna, string ema, string phnum, int passwo, int savamou, string savamoty)
        {
            Database databaseObject = new Database();
            SQLiteCommand myCommand = new SQLiteCommand("INSERT INTO PersonalAccount (FullName , Email , PhoneNumber , Password , SavingAmount , SavAccountType) VALUES ( @fullna , @ema , @phnum , @passwo , @savamou , @savamoty )", databaseObject.myConnection);
            myCommand.Parameters.AddWithValue("@fullna", fullna);
            myCommand.Parameters.AddWithValue("@ema", ema);
            myCommand.Parameters.AddWithValue("@phnum", phnum);
            myCommand.Parameters.AddWithValue("@passwo", passwo);
            myCommand.Parameters.AddWithValue("@savamou", savamou);
            myCommand.Parameters.AddWithValue("@savamoty", savamoty);
            databaseObject.OpenConnection();
            myCommand.ExecuteNonQuery();
            using (SQLiteDataReader reader = myCommand.ExecuteReader())
            {
                if (reader.Read())
                {
                    String.Format("{0}", reader["result"]);
                    //Console.WriteLine(fullname);
                }
            }
            databaseObject.CloseConnection();
            //return Convert.ToString(result);
        }

        static void InsertStatementCurrent(string fullna, string ema, string phnum, int passwo, int curramou, string curramoty)
        {
            Database databaseObject = new Database();
            SQLiteCommand myCommand = new SQLiteCommand("INSERT INTO PersonalAccount (FullName , Email , PhoneNumber , Password , CurrentAmount , CurrAccountType) VALUES ( @fullna , @ema , @phnum , @passwo , @curramou , @curramoty )", databaseObject.myConnection);
            myCommand.Parameters.AddWithValue("@fullna", fullna);
            myCommand.Parameters.AddWithValue("@ema", ema);
            myCommand.Parameters.AddWithValue("@phnum", phnum);
            myCommand.Parameters.AddWithValue("@passwo", passwo);
            myCommand.Parameters.AddWithValue("@curramou", curramou);
            myCommand.Parameters.AddWithValue("@curramoty", curramoty);
            databaseObject.OpenConnection();
            myCommand.ExecuteNonQuery();
            /*
            using (SQLiteDataReader reader = myCommand.ExecuteReader())
            {
                if (reader.Read())
                {
                    String.Format("{0}", reader["result"]);
                    //Console.WriteLine(fullname);
                }
            }
            */
            databaseObject.CloseConnection();
            //return Convert.ToString(result);
        }

        static string Database1FullName(string pas, string email)
        {
            string fullname = "";
            Database databaseObject = new Database();
            SQLiteCommand myCommand = new SQLiteCommand("SELECT FullName FROM PersonalAccount WHERE Password = @pas AND Email = @email", databaseObject.myConnection);
            myCommand.Parameters.AddWithValue("@pas", pas);
            myCommand.Parameters.AddWithValue("@email", email);
            databaseObject.OpenConnection();
            myCommand.ExecuteNonQuery();
            using (SQLiteDataReader reader = myCommand.ExecuteReader())
            {
                if (reader.Read())
                {
                    fullname = String.Format("{0}", reader["FullName"]);
                    //Console.WriteLine(fullname);
                }
            }
            databaseObject.CloseConnection();
            return fullname;
        }

        static int Check2(string pas, string email)
        {
            string sqlite = "SELECT COUNT(*) FROM PersonalAccount WHERE Password = @pas AND Email = @ema";
            Database databaseObject = new Database();
            SQLiteCommand myCommand = new SQLiteCommand(sqlite, databaseObject.myConnection);
            myCommand.Parameters.AddWithValue("@pas", pas);
            myCommand.Parameters.AddWithValue("@ema", email);
            databaseObject.OpenConnection();
            int rowcount = Convert.ToInt32(myCommand.ExecuteScalar());
            databaseObject.CloseConnection();
            return rowcount;
        }

        static string Database1Email(string pas, string emai)
        {
            string email = "";
            Database databaseObject = new Database();
            SQLiteCommand myCommand = new SQLiteCommand("SELECT Email FROM PersonalAccount WHERE Password = @pas AND Email = @emai", databaseObject.myConnection);
            myCommand.Parameters.AddWithValue("@pas", pas);
            myCommand.Parameters.AddWithValue("@emai", emai);
            databaseObject.OpenConnection();
            myCommand.ExecuteNonQuery();
            using (SQLiteDataReader reader = myCommand.ExecuteReader())
            {
                if (reader.Read())
                {
                    email = String.Format("{0}", reader["Email"]);
                    //Console.WriteLine(email);
                }
            }
            databaseObject.CloseConnection();
            return email;
        }

        static int SelectCurrent(string pas)
        {
            int currentamount = 0;
            Database databaseObject = new Database();
            SQLiteCommand myCommand = new SQLiteCommand("SELECT CurrentAmount FROM PersonalAccount WHERE Password = @pas", databaseObject.myConnection);
            myCommand.Parameters.AddWithValue("@pas", pas);
            databaseObject.OpenConnection();
            myCommand.ExecuteNonQuery();
            using (SQLiteDataReader reader = myCommand.ExecuteReader())
            {
                if (reader.Read())
                {
                    currentamount = Convert.ToInt32(String.Format("{0}", reader["CurrentAmount"]));
                    //Console.WriteLine(currentamount);
                }
            }
            databaseObject.CloseConnection();
            return currentamount; ;
        }

        static int SelectSavings(string pas)
        {
            int savingamount = 0;
            Database databaseObject = new Database();
            SQLiteCommand myCommand = new SQLiteCommand("SELECT SavingAmount FROM PersonalAccount WHERE Password = @pas", databaseObject.myConnection);
            myCommand.Parameters.AddWithValue("@pas", pas);
            databaseObject.OpenConnection();
            myCommand.ExecuteNonQuery();
            using (SQLiteDataReader reader = myCommand.ExecuteReader())
            {
                if (reader.Read())
                {
                    savingamount = Convert.ToInt32(String.Format("{0}", reader["SavingAmount"]));
                    //Console.WriteLine(savingamount);
                }
            }
            databaseObject.CloseConnection();
            return savingamount;
        }

        static void UpdateSavings(string pas, int sava)
        {
            Database databaseObject = new Database();
            SQLiteCommand myCommand = new SQLiteCommand("UPDATE PersonalAccount SET SavingAmount = @sava WHERE Password = @pas", databaseObject.myConnection);
            myCommand.Parameters.AddWithValue("@pas", pas);
            myCommand.Parameters.AddWithValue("@sava", sava);
            databaseObject.OpenConnection();
            myCommand.ExecuteNonQuery();
            /*
            using (SQLiteDataReader reader = myCommand.ExecuteReader())
            {
                if (reader.Read())
                {
                    var savup = String.Format("{0}", reader["SavingAmount"]);
                    //Console.WriteLine(savup);
                }
            }
            */
            databaseObject.CloseConnection();
        }

        static void UpdateCurrent(string pas, int curre)
        {
            Database databaseObject = new Database();
            SQLiteCommand myCommand = new SQLiteCommand("UPDATE PersonalAccount SET CurrentAmount = @curre WHERE Password = @pas", databaseObject.myConnection);
            myCommand.Parameters.AddWithValue("@pas", pas);
            myCommand.Parameters.AddWithValue("@curre", curre);
            databaseObject.OpenConnection();
            myCommand.ExecuteNonQuery();
            /*
            using (SQLiteDataReader reader = myCommand.ExecuteReader())
            {
                if (reader.Read())
                {
                    var currup = String.Format("{0}", reader["CurrentAmount"]);
                    //Console.WriteLine(currup);
                }
            }
            */
            databaseObject.CloseConnection();
        }

        static void Main(string[] args)
        {
            //Database databaseObject = new Database();

            //string query = $"INSERT INTO PersonalAccount (FullName,Email,PhoneNumber,Password,SavingAmount,CurrentAmount) VALUES ('Blessings','bb@gmail.com','8342687','2345','50000','50000')";


            int deposit, withdraw, decision, dec, count = 0, counter = 5, pins = 0;
            int choice, sav_amount, curr_amount;
            //Console.WriteLine("Operation Carried Out : {0}", result);
            //Console.ReadKey();

            while (true)
            {
                exit:
                    Console.WriteLine("");
                int pick;
                Console.WriteLine("WELCOME TO DAGGERFOAM BANKING SERVICE");
                Console.WriteLine("Do You Have An Account?");
                Console.WriteLine("1. YES");
                Console.WriteLine("2. NO");
                Console.WriteLine("***************");
                Console.WriteLine("ENTER YOUR CHOICE : ");
                pick = int.Parse(Console.ReadLine());
                if (pick == 1)
                {
                    repeatpin:
                    Console.WriteLine("Enter Your 4 Digit Pin ");
                    string pin = Console.ReadLine();
                    if (pin.Length != 4 || String.IsNullOrEmpty(pin) || !int.TryParse(pin, out pins))
                    {
                        Console.WriteLine("Invalid Pin");
                        goto repeatpin;
                    }
                    //Console.WriteLine("Valid Pin");

                    int confirmation = Verify(pin);
                    if (confirmation == 0)
                    {
                        counter--;
                        Console.WriteLine("Wrong Password");
                        Console.WriteLine("You Have {0} Tries Left\n", counter);
                        if (counter == 0)
                        {
                            Console.WriteLine("You Do Not Have An Account With Us.");
                            goto exit;
                        }
                        goto repeatpin; 
                    }
                    else if (confirmation > 0)
                    {
                        Console.Write("");
                    }

                    resd:
                    Console.WriteLine("\nPlease Enter Your Pin Again : ");
                    string pi = Console.ReadLine();
                    Console.WriteLine("Enter Your Email : ");
                    string em = Console.ReadLine();
                    int res = Check2(pi, em);
                    if (res == 0)
                    {
                        counter--;
                        Console.WriteLine("No Such Account..");
                        Console.WriteLine("Enter Pin And Email Again..");
                        Console.WriteLine("You Have {0} Tries Left\n", counter);
                        if (counter == 0)
                        {
                            Console.WriteLine("I Don't Think You Have An Account With Us.");
                            goto exit;
                        }
                        goto resd;
                    }
                    else if (res > 0)
                    {
                        Console.Write("");
                    }
                    string userName = Database1FullName(pi, em);
                    string example = Database1Email(pi, em);

                cancel:
                        Console.WriteLine(" ");
                    Console.WriteLine("WELCOME {0}", userName);
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
                                sav_amount = SelectSavings(pin); 
                                Console.WriteLine("\n YOUR CURRENT BALANCE IS {0} Naira", sav_amount);
                                UpdateSavings(pin, sav_amount);
                                EmailSendingSavingsAmount(example, userName, sav_amount);

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
                                sav_amount = SelectSavings(pin);
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
                                    UpdateSavings(pin, sav_amount);
                                    EmailSendingSavingsWithdrawal(example, userName, withdraw, sav_amount);
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
                                sav_amount = SelectSavings(pin);
                                Console.WriteLine("\n ENTER THE DEPOSIT AMOUNT");
                                deposit = int.Parse(Console.ReadLine());
                                sav_amount += deposit;
                                Console.WriteLine("YOUR AMOUNT HAS BEEN DEPOSITED SUCCESSFULLY..");
                                Console.WriteLine("YOUR TOTAL BALANCE IS {0} Naira", sav_amount);
                                UpdateSavings(pin, sav_amount);
                                EmailSendingSavingsDeposit(example, userName, deposit, sav_amount);


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
                                goto exit;

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
                                curr_amount = SelectCurrent(pin);
                                Console.WriteLine("\n YOUR CURRENT BALANCE IS {0} Naira", curr_amount);
                                UpdateCurrent(pin, curr_amount);
                                EmailSendingCurrentAmount(example, userName, curr_amount);

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
                                curr_amount = SelectCurrent(pin);
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
                                    UpdateCurrent(pin, curr_amount);
                                    EmailSendingCurrentWithdrawal(example, userName, withdraw, curr_amount);
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
                                curr_amount = SelectCurrent(pin);
                                Console.WriteLine("\n ENTER THE DEPOSIT AMOUNT");
                                deposit = int.Parse(Console.ReadLine());
                                curr_amount += deposit;
                                Console.WriteLine("YOUR AMOUNT HAS BEEN DEPOSITED SUCCESSFULLY..");
                                Console.WriteLine("YOUR TOTAL BALANCE IS {0} Naira", curr_amount);
                                UpdateCurrent(pin, curr_amount);
                                EmailSendingCurrentDeposit(example, userName, deposit, curr_amount);

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

                        }
                    }
                    else if (decision == 3)
                    {
                        goto exit;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input ");
                        goto exit;
                    }
                }
                else if (pick == 2)
                {
                    Console.WriteLine("Enter Your Full Name");
                    string fname = Console.ReadLine();
                    select:
                        Console.WriteLine(" ");
                    Console.WriteLine("What Type Of Account Do You Want To Open?");
                    Console.WriteLine("1. Savings");
                    Console.WriteLine("2. Current");
                    int acctTypeNo = Convert.ToInt32(Console.ReadLine());
                    int savamount = 0;
                    int curramount = 0;
                    string SavingaccountType = "";
                    string CurrentaccountType = "";
                    if (acctTypeNo == 1)
                    {
                        SavingaccountType = "Savings";
                    }
                    else if (acctTypeNo == 2)
                    {
                        CurrentaccountType = "Current";
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                        goto select;
                    }

                    repeatemail:
                    Console.WriteLine("Enter Your Valid E-mail");
                    string email = Console.ReadLine();
                    //Verify E-mail
                    if (!Regex.IsMatch(email, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase))
                    {
                        Console.WriteLine("Invalid E-mail");
                        goto repeatemail;
                    }
                    Console.WriteLine("Valid E-mail");
                    string Email = email;

                    Console.WriteLine("Enter Your Phone Number");
                    string phoneno = Console.ReadLine();

                    repeatpassw:
                    Console.WriteLine("Enter Your Pin");
                    var passw = Console.ReadLine();
                    //Verify Pin
                    if (passw.Length != 4 || String.IsNullOrEmpty(passw) || !int.TryParse(passw, out pins))
                    {
                        Console.WriteLine("Invalid Pin");
                        goto repeatpassw;
                    }
                    pins = Convert.ToInt32(passw);
                    Console.WriteLine($"Valid Pin. Your New Pin Is {pins}");

                    //int SavExist = Convert.ToInt32($"SELECT COUNT(*) FROM PersonalAccount WHERE FullName = '{fname}' AND Email = '{Email}' AND PhoneNumber = '{phoneno}' AND Password = '{pins}' AND SavAccountType = '{SavingaccountType}' ");
                    //To Check If The User Exists
                    if (acctTypeNo == 1)
                    {
                        int SavExist = Check(Email);
                        if (SavExist > 0)
                        {
                            Console.WriteLine("You Already Have A Savings Account");
                        }
                        else
                        {
                            InsertStatementSavings(fname, Email, phoneno, pins, savamount, SavingaccountType);
                            Console.WriteLine("SUCCESSFULLY ADDED");
                        }
                    }
                    else if (acctTypeNo == 2)
                    {
                        int CurrExist = Check(Email);
                        if (CurrExist > 0)
                        {
                            Console.WriteLine("You Already Have A Current Account");
                        }
                        else
                        {
                            InsertStatementCurrent(fname, Email, phoneno, pins, curramount, CurrentaccountType);
                            Console.WriteLine("SUCCESSFULLY ADDED");
                        }
                    }
                    goto exit;
                }
                else
                {
                    goto exit;
                }

            }
        }
    }
}
