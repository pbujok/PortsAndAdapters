using System;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime GetCurrent()
    {
        return DateTime.Now;
    }    
}