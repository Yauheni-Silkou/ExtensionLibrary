using System;
using System.Collections.Generic;
using System.Text;

namespace Extensions.DateTimeExtension
{
    public static class DateTimeEx
    {
        public static DateTime January(this int day, int year)
        {
            _ = new int[3].NoAny(x => x > 9);
            return new DateTime(year, 1, day);
        }
        public static DateTime February(this int day, int year)
        {
            return new DateTime(year, 2, day);
        }
        public static DateTime March(this int day, int year)
        {
            return new DateTime(year, 3, day);
        }
        public static DateTime April(this int day, int year)
        {
            return new DateTime(year, 4, day);
        }
        public static DateTime May(this int day, int year)
        {
            return new DateTime(year, 5, day);
        }
        public static DateTime June(this int day, int year)
        {
            return new DateTime(year, 6, day);
        }
        public static DateTime July(this int day, int year)
        {
            return new DateTime(year, 7, day);
        }
        public static DateTime August(this int day, int year)
        {
            return new DateTime(year, 8, day);
        }
        public static DateTime September(this int day, int year)
        {
            return new DateTime(year, 9, day);
        }
        public static DateTime October(this int day, int year)
        {
            return new DateTime(year, 10, day);
        }
        public static DateTime November(this int day, int year)
        {
            return new DateTime(year, 11, day);
        }
        public static DateTime December(this int day, int year)
        {
            return new DateTime(year, 12, day);
        }
        public static DateTime At(this DateTime date, int hours, int minutes = 0, int seconds = 0)
        {
            return new DateTime(date.Year, date.Month, date.Day, hours, minutes, seconds);
        }
        public static DateTime Midnight(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
        }
        public static DateTime Morning(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 6, 0, 0);
        }
        public static DateTime Midday(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 12, 0, 0);
        }
        public static DateTime Evening(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 18, 0, 0);
        }
        public static DateTime Yesterday(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day - 1, date.Hour, date.Minute, date.Second, date.Millisecond);
        }
        public static DateTime Tommorow(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day + 1, date.Hour, date.Minute, date.Second, date.Millisecond);
        }



        public static DateTime DaysBefore(this DateTime date, int days)
        {
            return new DateTime(date.Year, date.Month, date.Day - days, date.Hour, date.Minute, date.Second, date.Millisecond);
        }
        public static DateTime DaysBefore(this int days, DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day - days, date.Hour, date.Minute, date.Second, date.Millisecond);
        }
        public static DateTime DaysAfter(this DateTime date, int days)
        {
            return new DateTime(date.Year, date.Month, date.Day + days, date.Hour, date.Minute, date.Second, date.Millisecond);
        }
        public static DateTime DaysAfter(this int days, DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day + days, date.Hour, date.Minute, date.Second, date.Millisecond);
        }
        public static DateTime WeeksBefore(this DateTime date, int weeks)
        {
            return new DateTime(date.Year, date.Month, date.Day - 7 * weeks, date.Hour, date.Minute, date.Second, date.Millisecond);
        }
        public static DateTime WeeksBefore(this int weeks, DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day - 7 * weeks, date.Hour, date.Minute, date.Second, date.Millisecond);
        }
        public static DateTime WeeksAfter(this DateTime date, int weeks)
        {
            return new DateTime(date.Year, date.Month, date.Day + 7 * weeks, date.Hour, date.Minute, date.Second, date.Millisecond);
        }
        public static DateTime WeeksAfter(this int weeks, DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day + 7 * weeks, date.Hour, date.Minute, date.Second, date.Millisecond);
        }
        public static DateTime MonthsBefore(this DateTime date, int months)
        {
            return new DateTime(date.Year, date.Month - months, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond);
        }
        public static DateTime MonthsBefore(this int months, DateTime date)
        {
            return new DateTime(date.Year, date.Month - months, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond);
        }
        public static DateTime MonthsAfter(this DateTime date, int months)
        {
            return new DateTime(date.Year, date.Month + months, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond);
        }
        public static DateTime MonthsAfter(this int months, DateTime date)
        {
            return new DateTime(date.Year, date.Month + months, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond);
        }
        public static DateTime YearsBefore(this DateTime date, int years)
        {
            return new DateTime(date.Year - years, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond);
        }
        public static DateTime YearsBefore(this int years, DateTime date)
        {
            return new DateTime(date.Year - years, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond);
        }
        public static DateTime YearsAfter(this DateTime date, int years)
        {
            return new DateTime(date.Year + years, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond);
        }
        public static DateTime YearsAfter(this int years, DateTime date)
        {
            return new DateTime(date.Year + years, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond);
        }

        public static DateTime ThisSunday(this DateTime date)
        {
            return date.AddDays(0 - (int)date.DayOfWeek);
        }
        public static DateTime ThisMonday(this DateTime date)
        {
            return date.AddDays(1 - (int)date.DayOfWeek);
        }
        public static DateTime ThisTuesday(this DateTime date)
        {
            return date.AddDays(2 - (int)date.DayOfWeek);
        }
        public static DateTime ThisWednesday(this DateTime date)
        {
            return date.AddDays(3 - (int)date.DayOfWeek);
        }
        public static DateTime ThisThursday(this DateTime date)
        {
            return date.AddDays(4 - (int)date.DayOfWeek);
        }
        public static DateTime ThisFriday(this DateTime date)
        {
            return date.AddDays(5 - (int)date.DayOfWeek);
        }
        public static DateTime ThisSaturday(this DateTime date)
        {
            return date.AddDays(6 - (int)date.DayOfWeek);
        }
        public static DateTime LastSunday(this DateTime date)
        {
            return date.AddDays(0 - 7 - (int)date.DayOfWeek);
        }
        public static DateTime LastMonday(this DateTime date)
        {
            return date.AddDays(1 - 7 - (int)date.DayOfWeek);
        }
        public static DateTime LastTuesday(this DateTime date)
        {
            return date.AddDays(2 - 7 - (int)date.DayOfWeek);
        }
        public static DateTime LastWednesday(this DateTime date)
        {
            return date.AddDays(3 - 7 - (int)date.DayOfWeek);
        }
        public static DateTime LastThursday(this DateTime date)
        {
            return date.AddDays(4 - 7 - (int)date.DayOfWeek);
        }
        public static DateTime LastFriday(this DateTime date)
        {
            return date.AddDays(5 - 7 - (int)date.DayOfWeek);
        }
        public static DateTime LastSaturday(this DateTime date)
        {
            return date.AddDays(6 - 7 - (int)date.DayOfWeek);
        }
        public static DateTime NextSunday(this DateTime date)
        {
            return date.AddDays(0 + 7 - (int)date.DayOfWeek);
        }
        public static DateTime NextMonday(this DateTime date)
        {
            return date.AddDays(1 + 7 - (int)date.DayOfWeek);
        }
        public static DateTime NextTuesday(this DateTime date)
        {
            return date.AddDays(2 + 7 - (int)date.DayOfWeek);
        }
        public static DateTime NextWednesday(this DateTime date)
        {
            return date.AddDays(3 + 7 - (int)date.DayOfWeek);
        }
        public static DateTime NextThursday(this DateTime date)
        {
            return date.AddDays(4 + 7 - (int)date.DayOfWeek);
        }
        public static DateTime NextFriday(this DateTime date)
        {
            return date.AddDays(5 + 7 - (int)date.DayOfWeek);
        }
        public static DateTime NextSaturday(this DateTime date)
        {
            return date.AddDays(6 + 7 - (int)date.DayOfWeek);
        }
    }
}
