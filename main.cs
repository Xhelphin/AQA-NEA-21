using System;
using System.IO;
using System.Linq;

// EXAMPLE NEA
// WRITTEN BY JACK GREENACRE (@Xhelphin on GitHub)

namespace neacs
{
  static class Globals
  {
    public static string[] jfkArray;
    public static string[] oryArray;
    public static string[] madArray;
    public static string[] amsArray;
    public static string[] caiArray;
    public static int airportCode = 0;
    public static int airportName = 1;
    public static int fromLPL = 2;
    public static int fromBOH = 3;
    public static string ukAirport;
    public static string overseasAirport;
    public static string aircraftType;
    public static int minimumFirstClass;
    public static int capacityStandardClass;
    public static int firstClassSeats;
    public static int standardClassSeats;
  }
  class Program
  {
    static void inputAirport()
    {
      string ukAirport;
      while (true)
      {
        Console.Write("\nPlease select the uk airport to use:\n1. LPL - Liverpool John Lennon\n2. BOH - Bournemouth International\n>>> ");
        ukAirport = Console.ReadLine();
        if (ukAirport == "1")
        {
          break;
        }
        else if (ukAirport == "2")
        {
          break;
        }
        else
        {
          Console.WriteLine("\nYou have selected an airport which doesn't exist");
        }
      }
      if (ukAirport == "1")
      {
        Globals.ukAirport = "LPL";
      }
      else
      {
        Globals.ukAirport = "BOH";
      }
      string overseasAirport;
      while (true)
      {
        Console.Write("\nPlease select the overseas airport to use:\n1. JFK - John F Kennedy International\n2. ORY - Paris-Orly\n3. MAD - Adolfo Suarez Madrid-Barajas\n4. AMS - Amsterdam Schiphol\n5. CAI  - Cairo International\n>>> ");
        overseasAirport = Console.ReadLine();
        if (overseasAirport == "1") {
          break;
        }
        else if (overseasAirport == "2")
        {
          break;
        }
        else if (overseasAirport == "3")
        {
          break;
        }
        else if (overseasAirport == "4")
        {
          break;
        }
        else if (overseasAirport == "5")
        {
          break;
        }
        else
        {
          Console.WriteLine("\nYou have selected an airport which doesn't exist");
        }
      }
      if (overseasAirport == "1")
      {
        Globals.overseasAirport = "JFK";
      }
      else if (overseasAirport == "2")
      {
        Globals.overseasAirport = "ORY";
      }
      else if (overseasAirport == "3")
      {
        Globals.overseasAirport = "MAD";
      }
      else if (overseasAirport == "4")
      {
        Globals.overseasAirport = "AMS";
      }
      else
      {
        Globals.overseasAirport = "CAI";
      }
      Console.WriteLine("");
      Menu();
    }
    static void inputAircraft()
    {
      string aircraftType;
      while (true)
      {
        Console.Write("\nPlease select the type of aircraft to be used:\n1. Medium narrow body\n2. Large narrow body\n3. Medium wide body\n>>> ");
        aircraftType = Console.ReadLine();
        if (aircraftType == "1")
        {
          break;
        }
        else if (aircraftType == "2")
        {
          break;
        }
        else if (aircraftType == "3")
        {
          break;
        }
        else
        {
          Console.WriteLine("\nYou have selected an aircraft which doesn't exist");
        }
      }
      if (aircraftType == "1")
      {
        Globals.aircraftType = "MN";
        Globals.minimumFirstClass = 8;
        Globals.capacityStandardClass = 180;
        Console.WriteLine("\nRunning cost per seat per 100km: £8\nMaximum flight range (km): 2650\nCapacity if all seats are standard-class: 180\nMinimum number of first-class seats (if there are any): 8");
      }
      else if (aircraftType == "2")
      {
        Globals.aircraftType = "LN";
        Globals.minimumFirstClass = 10;
        Globals.capacityStandardClass = 220;
        Console.WriteLine("\nRunning cost per seat per 100km: £7\nMaximum flight range (km): 5600\nCapacity if all seats are standard-class: 220\nMinimum number of first class seats (if there are any): 10");
      }
      else
      {
        Globals.aircraftType = "MW";
        Globals.minimumFirstClass = 14;
        Globals.capacityStandardClass = 406;
        Console.WriteLine("\nRunning cost per seat per 100km: £5\nMaximum flight range (km): 4050\nCapacity if all seats are standard-class: 406\nMinimum number of first-class seats (if there are any): 14");
      }
      string firstClassSeatsStr;
      while (true)
      {
        Console.Write("\nPlease enter the number of first-class seats to be used\n>>> ");
        firstClassSeatsStr = Console.ReadLine();
        Globals.firstClassSeats = Convert.ToInt32(firstClassSeatsStr);
        if (Globals.firstClassSeats != 0)
        {
          if (Globals.firstClassSeats < Globals.minimumFirstClass)
          {
            Console.WriteLine("\nYou have selected a number of first-class seats that is below the minimum");
          }
          else if (Globals.firstClassSeats > (Globals.capacityStandardClass/2))
          {
            Console.WriteLine("\nYou have selected a number of first-class seats that is above half the capacity");
          }
          else
          {
            break;
          }
        }
        else
        {
          break;
        }
      }
      Globals.standardClassSeats = Globals.capacityStandardClass-(Globals.firstClassSeats*2);
      Console.WriteLine("");
      Menu();
    }
    static void enterPriceAndCalculate()
    {
      int maximumFlightRange;
      int runningCost;
      int airportDistance;
      if (Globals.ukAirport == "")
      {
        Console.WriteLine("\nPlease enter the airport data\n");
      }
      else
      {
        if (Globals.overseasAirport == "")
        {
          Console.WriteLine("\nPlease enter the airport data\n");
        }
        else
        {
          if (Globals.aircraftType == "")
          {
            Console.WriteLine("\nPlease enter the aircraft data\n");
          }
          else
          {
            if (Globals.firstClassSeats == 0)
            {
              Console.WriteLine("\nPlease enter the number of first-class seats\n");
            }
            else
            {
              if (Globals.aircraftType == "MN")
              {
                maximumFlightRange = 2650;
                runningCost = 8;
              }
              else if (Globals.aircraftType == "LN")
              {
                maximumFlightRange = 5600;
                runningCost = 7;
              }
              else
              {
                maximumFlightRange = 4050;
                runningCost = 5;
              }
              if (Globals.ukAirport == "LPL")
              {
                if (Globals.overseasAirport == "JFK")
                {
                  airportDistance = Convert.ToInt32(Globals.jfkArray[Globals.fromLPL]);
                }
                else if (Globals.overseasAirport == "ORY")
                {
                  airportDistance = Convert.ToInt32(Globals.oryArray[Globals.fromLPL]);
                }
                else if (Globals.overseasAirport == "MAD")
                {
                  airportDistance = Convert.ToInt32(Globals.madArray[Globals.fromLPL]);
                }
                else if (Globals.overseasAirport == "AMS")
                {
                  airportDistance = Convert.ToInt32(Globals.amsArray[Globals.fromLPL]);
                }
                else
                {
                  airportDistance = Convert.ToInt32(Globals.caiArray[Globals.fromLPL]);
                }
              }
              else
              {
                if (Globals.overseasAirport == "JFK")
                {
                  airportDistance = Convert.ToInt32(Globals.jfkArray[Globals.fromBOH]);
                }
                else if (Globals.overseasAirport == "ORY")
                {
                  airportDistance = Convert.ToInt32(Globals.oryArray[Globals.fromBOH]);
                }
                else if (Globals.overseasAirport == "MAD")
                {
                  airportDistance = Convert.ToInt32(Globals.madArray[Globals.fromBOH]);
                }
                else if (Globals.overseasAirport == "AMS")
                {
                  airportDistance = Convert.ToInt32(Globals.amsArray[Globals.fromBOH]);
                }
                else
                {
                  airportDistance = Convert.ToInt32(Globals.caiArray[Globals.fromBOH]);
                }
              }
              if (!(maximumFlightRange >= airportDistance))
              {
                Console.WriteLine("\nThe distance between the airport is too large for the selected aircraft\n");
              }
              else
              {
                Console.Write("\nPlease enter the price of a standard-class seat with no £\n>>> ");
                string standardPrice = Console.ReadLine();
                Console.Write("\nPlease enter the price of a first-class seat with no £\n>>> ");
                string firstPrice = Console.ReadLine();
                int standardPriceInt = Convert.ToInt32(standardPrice);
                int firstPriceInt = Convert.ToInt32(firstPrice);
                double flightCostPerSeat = Convert.ToDouble(runningCost)*(Convert.ToDouble(airportDistance)/Convert.ToDouble(100));
                double flightCost = flightCostPerSeat*Convert.ToDouble((Convert.ToDouble(Globals.firstClassSeats))+Convert.ToDouble(Globals.standardClassSeats));
                double flightIncome = (Convert.ToDouble(Globals.firstClassSeats)*Convert.ToDouble(firstPriceInt))+(Convert.ToDouble(Globals.standardClassSeats)*Convert.ToDouble(standardPriceInt));
                Console.WriteLine(flightIncome);
                double flightProfit = flightIncome-flightCost;
                Console.WriteLine("\nFlight cost per seat: £" + Convert.ToString(flightCostPerSeat) + "\nFlight cost: £" + Convert.ToString(flightCost) + "\nFlight income: £" + Convert.ToString(flightIncome) + "\nFlight profit: £" + Convert.ToString(flightProfit) + "\n");
              }
            }
          }
        }
      }
      Menu();
    }
    static void clearGlobals()
    {
      Globals.ukAirport = "";
      Globals.overseasAirport = "";
      Globals.aircraftType = "";
      Globals.minimumFirstClass = 0;
      Globals.capacityStandardClass = 0;
      Globals.firstClassSeats = 0;
      Globals.standardClassSeats = 0;
      Console.WriteLine("\nAll stored data has been cleared\n");
      Menu();
    }
    static void Menu()
    {
      string menuSelection;
      while (true)
      {
        Console.Write("1. Input airport data\n2. Input aircraft data\n3. Input price plan and calculate\n4. Clear all stored data\n5. Exit the program\n>>> ");
        menuSelection = Console.ReadLine();
        if (menuSelection == "1")
        {
          break;
        }
        else if (menuSelection == "2")
        {
          break;
        }
        else if (menuSelection == "3")
        {
          break;
        }
        else if (menuSelection == "4")
        {
          break;
        }
        else if (menuSelection == "5")
        {
          Console.WriteLine("\nThank you for using this program!");
          Environment.Exit(1);
        }
        else
        {
          Console.WriteLine("You selected something else\n");
        }
      }
      if (menuSelection == "1")
      {
        inputAirport();
      }
      else if (menuSelection == "2")
      {
        inputAircraft();
      }
      else if (menuSelection == "3")
      {
        enterPriceAndCalculate();
      }
      else
      {
        clearGlobals();
      }
    }
    public static void Main()
    {
      string airportData = File.ReadAllText("Airports.txt");
      string[] airportArray = airportData.Split("\n");
      Globals.jfkArray = airportArray[0].Split(",");
      Globals.oryArray = airportArray[1].Split(",");
      Globals.madArray = airportArray[2].Split(",");
      Globals.amsArray = airportArray[3].Split(",");
      Globals.caiArray = airportArray[4].Split(",");
      Menu();
    }
  }
}
