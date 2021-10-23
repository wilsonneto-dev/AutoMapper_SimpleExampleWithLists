using AutoMapper;
using Newtonsoft.Json;

var configuration = new MapperConfiguration(cfg => {
    cfg.CreateMap<OrderInput, Order>();
    cfg.CreateMap<CustomerInput, Customer>()
        .ForMember(dest => dest.Orders, opt => opt.MapFrom(src => src.OrdersDTO));
});

var mapper = configuration.CreateMapper();

var customerInput = new CustomerInput() {
    Name = "Cliente",
    Document = "xxx.xxx.xxx-xx",
    OrdersDTO = new List<OrderInput>() {
        new OrderInput() { Code = "0001", Value = 10 },
        new OrderInput() { Code = "0002", Value = 20 },
        new OrderInput() { Code = "0003", Value = 30 }
    }
};

var customer = mapper.Map<Customer>(customerInput);
Console.WriteLine(JsonConvert.SerializeObject(customer));

class Order {
    public string? Code { get; set; }
    public Decimal Value { get; set; }
}

class Customer {
    public string? Name { get; set; }
    public string? Document { get; set; }
    public List<Order>? Orders { get; set; }
}

class OrderInput {
    public string? Code { get; set; }
    public Decimal Value { get; set; }
}

class CustomerInput {
    public string? Name { get; set; }
    public string? Document { get; set; }
    public List<OrderInput>? OrdersDTO { get; set; }
}