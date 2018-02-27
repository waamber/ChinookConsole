using SqlQueries.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SqlQueries
{
    class Program
    {
        static void Main(string[] args)
        {
            var run = true;
            while (run)
            {
                ConsoleKeyInfo userInput = MainMenu();

                switch (userInput.KeyChar)
                {
                    case '0':
                        run = false;
                        break;
                    case '1':
                        Console.Clear();
                        Console.WriteLine();

                        var agentInvoices = new InvoicesByAgent();
                        var invoices = agentInvoices.InvoicesBySalesAgent();

                        foreach (var invoice in invoices)
                        {
                            Console.WriteLine($"Sales Agent: {invoice.FirstName} {invoice.LastName}, Invoice ID: {invoice.InvoiceId}.");
                        }

                        Console.WriteLine("Press enter to continue.");
                        Console.ReadLine();
                        break;

                    case '2':
                        Console.Clear();
                        Console.WriteLine("Invoice Details:");

                        var newInvoice = new InvoiceInfo();
                        var invoiceInfo = newInvoice.InvoiceInformation();

                        foreach (var invoice in invoiceInfo)
                        {
                            Console.WriteLine($"{invoice.CustomerName}, from {invoice.BillingCountry} had and invoice total of {invoice.Total}. The sale was made by {invoice.SalesAgent}.");
                        }

                        Console.WriteLine("Press enter to continue.");
                        Console.ReadLine();
                        break;

                    case '3':
                        Console.Clear();
                        Console.WriteLine("Please enter in an invoice ID to see the total number of line items for that invoice.");


                        
                        Console.ReadLine();
                        break;

                    case '4':
                        Console.Clear();
                        Console.WriteLine("Please enter invoice information.");
                        Console.WriteLine("EX: 'First Name','Last Name', Invoice ID Number, 'Billing Country', 'Email Address'");

                        var userInvoiceInput = Console.ReadLine();
                        var insertInvoice = new InsertNewInvoice("George", "Lucas", 3445, "adldjad", "someemail");

                        Console.ReadLine();
                        break;

                    case '5':
                        Console.Clear();
                        Console.WriteLine("Please enter new Last name and Employee ID:");
                        Console.WriteLine("EX: 455, Smith");

                        var newName = Console.ReadLine();
                        var id = Console.ReadLine();
                        var updateEmployee = new UpdateEmployee();
                        updateEmployee.UpdateEmployeeName(int.Parse(id), newName);

                        Console.ReadLine();
                        break;

                }
            }

            ConsoleKeyInfo MainMenu()
            {
                View mainMenu = new View()
                        .AddMenuOption("Show sales agents and their invoices.")
                        .AddMenuOption("See invoice details.")
                        .AddMenuOption("See number of invoice line items for each invoice.")
                        .AddMenuOption("Add new invoice.")
                        .AddMenuOption("Update an employee name.")
                        .AddMenuText("Press 0 to exit.");

                Console.Write(mainMenu.GetFullMenu());
                ConsoleKeyInfo userOption = Console.ReadKey();
                return userOption;
            }
        }
            
        }
    }

