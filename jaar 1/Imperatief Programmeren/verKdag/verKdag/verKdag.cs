using System;


Console.WriteLine("Gimme your birthday DD-MM-YYYY");
String BDay = Console.ReadLine();
String[] BDayArray = BDay.Split('-');
int day = int.Parse(BDayArray[0]);
int month = int.Parse(BDayArray[1]);
int year = int.Parse(BDayArray[2]);

DateTime birthday = new DateTime(year, month, day);
DateTime today = DateTime.Now;

TimeSpan age = today - birthday;
double ageInDays = (int)age.TotalDays;
Console.WriteLine("Your next Kday is in " + (1000 - (ageInDays % 1000)) + " Days");

