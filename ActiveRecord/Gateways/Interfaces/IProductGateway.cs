namespace RowDataGateway.Gateways.Interfaces
{
    public interface IProductGateway
    {
        int Id { get; set; }
        string Name { get; set; }
        double Price { get; set; }
        int? OrderId { get; set; }

        void Insert();
        void Update();
        bool Delete();
    }
}
