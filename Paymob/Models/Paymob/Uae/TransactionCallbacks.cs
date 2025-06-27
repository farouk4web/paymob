//public class TransactionCallbacks
//{
//    public Obj? obj { get; set; }
//    public string? type { get; set; }
//}

//public class Obj
//{
//    public int id { get; set; }
//    public bool pending { get; set; }
//    public int amount_cents { get; set; }
//    public bool success { get; set; }
//    public bool is_auth { get; set; }
//    public bool is_capture { get; set; }
//    public bool is_standalone_payment { get; set; }
//    public bool is_voided { get; set; }
//    public bool is_refunded { get; set; }
//    public bool is_3d_secure { get; set; }
//    public int integration_id { get; set; }
//    public int profile_id { get; set; }
//    public bool has_parent_transaction { get; set; }
//    public Order? order { get; set; }
//    public DateTime created_at { get; set; }
//    public object[] transaction_processed_callback_responses { get; set; } = [];
//    public string? currency { get; set; }
//    public Source_Data? source_data { get; set; }
//    public string? api_source { get; set; }
//    public object? terminal_id { get; set; }
//    public bool is_void { get; set; }
//    public bool is_refund { get; set; }
//    public Data? data { get; set; }
//    public bool is_hidden { get; set; }
//    public Payment_Key_Claims? payment_key_claims { get; set; }
//    public bool error_occured { get; set; }
//    public bool is_live { get; set; }
//    public object? other_endpoint_reference { get; set; }
//    public int refunded_amount_cents { get; set; }
//    public int source_id { get; set; }
//    public bool is_captured { get; set; }
//    public int captured_amount { get; set; }
//    public object? merchant_staff_tag { get; set; }
//    public int owner { get; set; }
//    public object? parent_transaction { get; set; }
//}

//public class Order
//{
//    public int id { get; set; }
//    public DateTime created_at { get; set; }
//    public bool delivery_needed { get; set; }
//    public Merchant? merchant { get; set; }
//    public Collector? collector { get; set; }
//    public int amount_cents { get; set; }
//    public Shipping_Data? shipping_data { get; set; }
//    public Shipping_Details? shipping_details { get; set; }
//    public string? currency { get; set; }
//    public bool is_payment_locked { get; set; }
//    public bool is_return { get; set; }
//    public bool is_cancel { get; set; }
//    public bool is_returned { get; set; }
//    public bool is_canceled { get; set; }
//    public object? merchant_order_id { get; set; }
//    public object? wallet_notification { get; set; }
//    public int paid_amount_cents { get; set; }
//    public bool notify_user_with_email { get; set; }
//    public object[] items { get; set; } = [];
//    public string? order_url { get; set; }
//    public int commission_fees { get; set; }
//    public int delivery_fees_cents { get; set; }
//    public int delivery_vat_cents { get; set; }
//    public string? payment_method { get; set; }
//    public object? merchant_staff_tag { get; set; }
//    public string? api_source { get; set; }
//    public object? pickup_data { get; set; }
//    public object[] delivery_status { get; set; } = [];
//}

//public class Merchant
//{
//    public int id { get; set; }
//    public DateTime created_at { get; set; }
//    public string[] phones { get; set; } = [];
//    public string[] company_emails { get; set; } = [];
//    public string? company_name { get; set; }
//    public string? state { get; set; }
//    public string? country { get; set; }
//    public string? city { get; set; }
//    public string? postal_code { get; set; }
//    public string? street { get; set; }
//}

//public class Collector
//{
//    public int id { get; set; }
//    public DateTime created_at { get; set; }
//    public object[] phones { get; set; } = [];
//    public object[] company_emails { get; set; } = [];
//    public string? company_name { get; set; }
//    public string? state { get; set; }
//    public string? country { get; set; }
//    public string? city { get; set; }
//    public string? postal_code { get; set; }
//    public string? street { get; set; }
//}

//public class Shipping_Data
//{
//    public int id { get; set; }
//    public string? first_name { get; set; }
//    public string? last_name { get; set; }
//    public string? street { get; set; }
//    public string? building { get; set; }
//    public string? floor { get; set; }
//    public string? apartment { get; set; }
//    public string? city { get; set; }
//    public string? state { get; set; }
//    public string? country { get; set; }
//    public string? email { get; set; }
//    public string? phone_number { get; set; }
//    public string? postal_code { get; set; }
//    public string? extra_description { get; set; }
//    public string? shipping_method { get; set; }
//    public int order_id { get; set; }
//    public int order { get; set; }
//}

//public class Shipping_Details
//{
//    public int id { get; set; }
//    public int cash_on_delivery_amount { get; set; }
//    public string? cash_on_delivery_type { get; set; }
//    public object? latitude { get; set; }
//    public object? longitude { get; set; }
//    public int is_same_day { get; set; }
//    public int number_of_packages { get; set; }
//    public int weight { get; set; }
//    public string? weight_unit { get; set; }
//    public int length { get; set; }
//    public int width { get; set; }
//    public int height { get; set; }
//    public string? delivery_type { get; set; }
//    public object? return_type { get; set; }
//    public int order_id { get; set; }
//    public string? notes { get; set; }
//    public int order { get; set; }
//}

//public class Source_Data
//{
//    public string? pan { get; set; }
//    public string? type { get; set; }
//    public string? sub_type { get; set; }
//}

//public class Data
//{
//    public string? acq_response_code { get; set; }
//    public string? avs_acq_response_code { get; set; }
//    public string? klass { get; set; }
//    public string? receipt_no { get; set; }
//    public string? order_info { get; set; }
//    public string? message { get; set; }
//    public int gateway_integration_pk { get; set; }
//    public string? batch_no { get; set; }
//    public object? card_num { get; set; }
//    public string? secure_hash { get; set; }
//    public string? avs_result_code { get; set; }
//    public string? card_type { get; set; }
//    public string? merchant { get; set; }
//    public DateTime created_at { get; set; }
//    public string? merchant_txn_ref { get; set; }
//    public string? authorize_id { get; set; }
//    public string? currency { get; set; }
//    public string? amount { get; set; }
//    public string? transaction_no { get; set; }
//    public string? txn_response_code { get; set; }
//    public string? command { get; set; }
//}

//public class Payment_Key_Claims
//{
//    public bool lock_order_when_paid { get; set; }
//    public int integration_id { get; set; }
//    public Billing_Data? billing_data { get; set; }
//    public int order_id { get; set; }
//    public int user_id { get; set; }
//    public string? pmk_ip { get; set; }
//    public int exp { get; set; }
//    public string? currency { get; set; }
//    public int amount_cents { get; set; }
//}

//public class Billing_Data
//{
//    public string? email { get; set; }
//    public string? building { get; set; }
//    public string? apartment { get; set; }
//    public string? street { get; set; }
//    public string? country { get; set; }
//    public string? state { get; set; }
//    public string? last_name { get; set; }
//    public string? first_name { get; set; }
//    public string? postal_code { get; set; }
//    public string? extra_description { get; set; }
//    public string? phone_number { get; set; }
//    public string? floor { get; set; }
//    public string? city { get; set; }
//}
