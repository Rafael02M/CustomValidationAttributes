using CustomValidationAttributes.Lib.Attributes;
using System;

namespace CustomValidationAttributes.ConsoleApp
{

    public enum BookingStatus
    {
        Created,
        Confirmed,
        Cancelled,
        Completed
    }
    public class Booking
    {
        [MinLength(3)]
        public string CustomerName { get; set; }

        [Contains("@")]
        public string CustomerEmail { get; set; }

        [MinLength(5)]
        public string ServiceName { get; set; }

        [FutureDate]
        public DateTime StartAtUtc { get; set; }

        [Positive]
        public int GuestsCount { get; set; }

        [Url]
        [RequiredIf(nameof(Status), BookingStatus.Confirmed)]
        public string ConfirmationUrl { get; set; }

        [AllowedEnum(typeof(BookingStatus))]
        public BookingStatus Status { get; set; }

        [AllowedValues("standard", "premium", "vip")]
        public string Package { get; set; }
    }
}
