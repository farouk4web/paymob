public class ResponseOrderCreationUAE
{
    public Payment_Keys[] payment_keys { get; set; } = [];
    public string? id { get; set; }
    public Intention_Detail? intention_detail { get; set; }
    public string? client_secret { get; set; }
    public Payment_Methods[] payment_methods { get; set; } = [];
    public string? special_reference { get; set; }
    public Extras? extras { get; set; }
    public bool confirmed { get; set; }
    public string? status { get; set; }
    public DateTime created { get; set; }
    public object? card_detail { get; set; }
    public string? _object { get; set; }
}

public class Intention_Detail
{
    public int amount { get; set; }
    public object[] items { get; set; } = [];
    public string? currency { get; set; }
}

public class Extras
{
    public object? creation_extras { get; set; }
    public object? confirmation_extras { get; set; }
}

public class Payment_Keys
{
    public int integration { get; set; }
    public string? key { get; set; }
    public string? gateway_type { get; set; }
    public object? iframe_id { get; set; }
}

public class Payment_Methods
{
    public int integration_id { get; set; }
    public object? alias { get; set; }
    public object? name { get; set; }
    public string? method_type { get; set; }
    public string? currency { get; set; }
    public bool live { get; set; }
}
