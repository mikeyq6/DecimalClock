using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecimalClockLibrary
{

    public class DecimalDateTime
    {
        private const decimal SECONDS_MULTIPLIER = 1.15740740740740m;
        private DateTime underlyingTime;

        public DecimalDateTime()
        {
            underlyingTime = DateTime.Now;
        }

        public DecimalDateTime(DateTime baseTime)
        {
            underlyingTime = baseTime;
        }

        public static DecimalDateTime Now
        {
            get
            {
                return new DecimalDateTime(DateTime.Now);
            }
        }

        public int Hour
        {
            get
            {
                decimal seconds = (decimal)underlyingTime.TimeOfDay.TotalSeconds;
                seconds *= SECONDS_MULTIPLIER;
                return (int)Math.Floor(seconds / 10000);
            }
        }

        public int Minute
        {
            get
            {
                decimal seconds = (decimal)underlyingTime.TimeOfDay.TotalSeconds;
                seconds *= SECONDS_MULTIPLIER;
                seconds %= 10000;
                return (int)Math.Floor(seconds / 100);
            }
        }

        public int Second
        {
            get
            {
                decimal seconds = (decimal)underlyingTime.TimeOfDay.TotalSeconds;
                seconds *= SECONDS_MULTIPLIER;
                seconds %= 100;
                return (int)Math.Floor(seconds);
            }
        }

        public int Day
        {
            get
            {
                int day = underlyingTime.Date.Day;
                int m = underlyingTime.Date.Month;

                switch (Month)
                {
                    case 1:
                        if (m == 9)
                            day -= 21;
                        else
                            day += 9;
                        break;
                    case 2:
                        if (m == 10)
                            day -= 21;
                        else
                            day += 10;
                        break;
                    case 3:
                        if (m == 11)
                            day -= 20;
                        else
                            day += 10;
                        break;
                    case 4:
                        if (m == 12)
                            day -= 20;
                        else
                            day += 11;
                        break;
                    case 5:
                        if (m == 1)
                            day -= 19;
                        else
                            day += 12;
                        break;
                    case 6:
                        if (m == 2)
                            day -= 18;
                        else
                            day += 10;
                        break;
                    case 7:
                        if (m == 3)
                            day -= 20;
                        else
                            day += 11;
                        break;
                    case 8:
                        if (m == 4)
                            day -= 19;
                        else
                            day += 11;
                        break;
                    case 9:
                        if (m == 5)
                            day -= 19;
                        else
                            day += 12;
                        break;
                    case 10:
                        if (m == 6)
                            day -= 18;
                        else
                            day += 12;
                        break;
                    case 11:
                        if (m == 7)
                            day -= 18;
                        else
                            day += 13;
                        break;
                    case 12:
                        if (m == 8)
                            day -= 17;
                        else
                            day += 14;
                        break;
                }

                return day;
            }
        }

        public int Month
        {
            get
            {
                int m = underlyingTime.Month;
                int d = underlyingTime.Day;

                if ((m == 9 && d >= 22) || (m == 10 && d <= 21))
                    return 1;
                else if ((m == 10 && d >= 22) || (m == 11 && d <= 20))
                    return 2;
                else if ((m == 11 && d >= 21) || (m == 12 && d <= 20))
                    return 3;
                else if ((m == 12 && d >= 21) || (m == 1 && d <= 19))
                    return 4;
                else if ((m == 1 && d >= 20) || (m == 2 && d <= 18))
                    return 5;
                else if ((m == 2 && d >= 19) || (m == 3 && d <= 20))
                    return 6;
                else if ((m == 3 && d >= 21) || (m == 4 && d <= 19))
                    return 7;
                else if ((m == 4 && d >= 20) || (m == 5 && d <= 19))
                    return 8;
                else if ((m == 5 && d >= 20) || (m == 6 && d <= 18))
                    return 9;
                else if ((m == 6 && d >= 19) || (m == 7 && d <= 18))
                    return 10;
                else if ((m == 7 && d >= 19) || (m == 8 && d <= 17))
                    return 11;
                else if ((m == 8 && d >= 18) || (m == 9 && d <= 16))
                    return 12;
                else
                    return 0;
            }
        }

        public string MonthName
        {
            get
            {
                string mname = "";
                switch (Month)
                {
                    case 1:
                        mname = "Vendémiaire"; break;
                    case 2:
                        mname = "Brumaire"; break;
                    case 3:
                        mname = "Frimaire"; break;
                    case 4:
                        mname = "Nivôse"; break;
                    case 5:
                        mname = "Pluviôse"; break;
                    case 6:
                        mname = "Ventôse"; break;
                    case 7:
                        mname = "Germinal"; break;
                    case 8:
                        mname = "Floréal"; break;
                    case 9:
                        mname = "Prairial"; break;
                    case 10:
                        mname = "Messidor"; break;
                    case 11:
                        mname = "Thermidor"; break;
                    case 12:
                        mname = "Fructidor"; break;
                    case 0:
                        mname = ""; break;
                }

                return mname;
            }
        }

        public uint Year
        {
            get
            {
                uint y = (uint)underlyingTime.Year;

                if (Month == 1)
                    y -= 1791;
                else if (Month == 12)
                    y -= 1792;
                else if (underlyingTime.Month >= 9)
                    y -= 1791;
                else
                    y -= 1792;

                return y;
            }
        }

        public string RomanYear
        {
            get
            {
                return RomanNumeral.GetRomanValue(Year);
            }
        }


        public string DateString()
        {
            string result = string.Empty;

            if (IsLeapYear(underlyingTime.Date) && underlyingTime.Date.Month == 9 && underlyingTime.Date.Day == 23)
                result = "Sextile";
            else if (Month == 0)
            {
                switch(underlyingTime.Day)
                {
                    case 17:
                        result = "La Fête de la Vertu"; break;
                    case 18:
                        result = "La Fête du Génie"; break;
                    case 19:
                        result = "La Fête du Travail"; break;
                    case 20:
                        result = "La Fête de l'Opinion"; break;
                    case 21:
                        result = "La Fête des Récompenses"; break;
                    case 22:
                        result = "La Fête de la Révolution"; break;
                }
            }
            else
            {
                return $"{Day} {MonthName} {RomanYear}";
            }
            return result;
        }

        public string TimeString()
        {
            return $"{Hour}:{Minute.ToString("D2")}:{Second.ToString("D2")}";
        }

        private bool IsLeapYear(DateTime dt)
        {
            if (dt.Year % 4 == 0 && (dt.Year % 100 != 0 || dt.Year % 400 == 0))
                return true;
            else
                return false;
        }
    }
}
