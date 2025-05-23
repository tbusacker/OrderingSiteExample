public class CartItem
{
    public CartItem() {}

    public CartItem(Product product, int quantity)
    {
        this.Product = product;
        this.Quantity = quantity;
    }

    public Product Product { get; set; }
    public int Quantity { get; set; }

    public void AddQuantity(int quantity)
    {
        this.Quantity += quantity;
    }

    public string Display()
    {
        decimal totalPrice = Quantity * Product.UnitPrice;
        string displayString = 
            Product.Name + " (" + Quantity.ToString()
            + " at " + Product.UnitPrice.ToString("c") + " each = " +  totalPrice.ToString("c") + ")";

        return displayString;
    }
    
}