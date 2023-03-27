using System;
using System.Collections.Generic;

namespace ClassLibrary.Entities;

public partial class SendMoney
{
    public int Id { get; set; }

    public decimal AmountToSend { get; set; }

    public decimal AmountReceived { get; set; }

    public string SenderName { get; set; } = null!;

    public string ReceiverName { get; set; } = null!;

    public string Purpose { get; set; } = null!;
}
