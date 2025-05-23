using System;
using System.Web.UI;
using System.Data;

public partial class Order : System.Web.UI.Page
{
    private Product selectedProduct;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) ddlProducts.DataBind();
        selectedProduct = this.GetSelectedProduct();
        lblName.Text = selectedProduct.Name;
        lblShortDescription.Text = selectedProduct.ShortDescription;
        lblLongDescription.Text = selectedProduct.LongDescription;
        lblUnitPrice.Text = selectedProduct.UnitPrice.ToString("c") + " each";
        imgProduct.ImageUrl = "Images/Products/" + selectedProduct.ImageFile;
    }
    private Product GetSelectedProduct()
    {
        DataView productsTable = (DataView)SqlDataSource1.Select(DataSourceSelectArguments.Empty);
        productsTable.RowFilter = string.Format("ProductID = '{0}'", ddlProducts.SelectedValue);
        DataRowView row = (DataRowView)productsTable[0];
                Product p = new Product();
        p.ProductID =        row["ProductID"].ToString();
        p.Name =             row["Name"].ToString(); 
        p.ShortDescription = row["ShortDescription"].ToString(); 
        p.LongDescription =  row["LongDescription"].ToString(); 
        p.UnitPrice =        (decimal) row["UnitPrice"]; 
        p.ImageFile =        row["ImageFile"].ToString();
        return p;
    }

}
