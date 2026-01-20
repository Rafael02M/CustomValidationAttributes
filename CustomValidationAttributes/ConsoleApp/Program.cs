using CustomValidationAttributes.ConsoleApp;
using CustomValidationAttributes.Lib.Core;

namespace ConsoleApp;

class Program
{
    static void Main(string[] args)
    {
        var booking = new Booking
        {
            CustomerName = "Rafael",
            CustomerEmail = "user@gmail.com",
            ServiceName = "Example",
            StartAtUtc = DateTime.UtcNow.AddDays(7),
            GuestsCount = 2,
            ConfirmationUrl = "Https://example.com/booking",
            Package = "vip"

        };

        var validator = new Validator();

        var result = validator.Validate(booking);

        if (!result.IsValid)
        {
            foreach (ValidationError error in result.Errors)
            {
                Console.WriteLine(error);
            }
        }
        else
        {
            Console.WriteLine("Validation successful!");
        }
    }
}

