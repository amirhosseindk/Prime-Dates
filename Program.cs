using System.Globalization;

try
{
	Console.WriteLine("Enter the first date (dd-MM-yyyy):");
	string firstDateString = Console.ReadLine();
	DateOnly dateOne = DateOnly.FromDateTime(DateTime.ParseExact(firstDateString, "dd-MM-yyyy", CultureInfo.InvariantCulture));

	Console.WriteLine("Enter the second date (dd-MM-yyyy):");
	string secondDateString = Console.ReadLine();
	DateOnly dateTwo = DateOnly.FromDateTime(DateTime.ParseExact(secondDateString, "dd-MM-yyyy", CultureInfo.InvariantCulture));

	FindLuckyDates(dateOne, dateTwo);
}
catch (FormatException ex)
{
	Console.WriteLine("Invalid date format. Please use dd-MM-yyyy format.",ex);
}


void FindLuckyDates(DateOnly dateOne, DateOnly dateTwo)
{
	int differenceInDays = Math.Abs(dateOne.DayNumber - dateTwo.DayNumber);

	for (int i = 1; i < differenceInDays; i++)
	{
		DateOnly date = dateOne.AddDays(i);
		if (IsLuckyDate(date))
		{
			Console.WriteLine(date.ToString("dd-MM-yyyy"));
		}
	}
}

bool IsLuckyDate(DateOnly date)
{
	string dateAsString = date.ToString("ddMMyyyy");
	long number = Convert.ToInt64(dateAsString);

	return number % 7 == 0 || number % 4 == 0;
}

//void FindLuckyDates(DateOnly dateOne, DateOnly dateTwo)
//{
//	int differenceInDays = Math.Abs(dateOne.DayNumber - dateTwo.DayNumber);

//	for (int i = 1; i < differenceInDays; i++)
//	{
//		DateOnly date = dateOne.AddDays(i);
//		string dateAsString = date.ToString("dd-MM-yyyy");
//		if (IsLuckyDate(dateAsString))
//		{
//			Console.WriteLine(dateAsString);
//		}
//	}
//}

//bool IsLuckyDate(string date)
//{
//	string dateWithOutZero;

//	if (date[0] == '0')
//	{
//		dateWithOutZero = date.Remove(0, 1);
//	}
//	else
//	{
//		dateWithOutZero = date;
//	}

//	for (int i = 0; i < dateWithOutZero.Length; i++)
//	{
//		if (dateWithOutZero[i] == '-')
//		{
//			dateWithOutZero = dateWithOutZero.Remove(i, 1);
//			i--;
//		}
//	}

//	long output = Convert.ToInt64(dateWithOutZero);

//	if (output % 7 == 0 || output % 4 == 0)
//	{
//		return true;
//	}
//	else
//	{
//		return false;
//	}
//}