using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace _2001210776_NguyenTuanVi_MVC_DoAnCuoiKi.Models
{
    public class ShoppingCart
    {
        public List<ShoppingCartItems> Items { get; set; }
        public ShoppingCart()
        {
            this.Items = new List<ShoppingCartItems>();
        }
        public void AddToCart(ShoppingCartItems item, int quantity)
        {
            var checkExits = Items.FirstOrDefault(x => x.ID_Product == item.ID_Product);
            if (checkExits != null)
            {
                checkExits.Quantity += quantity;
                checkExits.TotalPrice = checkExits.Price * checkExits.Quantity;
            }
            else
            {
                Items.Add(item);
            }
        }
        public void Remove(int id)
        {
            var checkExits = Items.SingleOrDefault(x => x.ID_Product == id);
            if (checkExits != null)
            {
                Items.Remove(checkExits);
            }
        }

        public void UpdateQuantity(int id, int quantity)
        {
            var checkExits = Items.SingleOrDefault(x => x.ID_Product == id);
            if (checkExits != null)
            {
                checkExits.Quantity = quantity;
                checkExits.TotalPrice = checkExits.Price * checkExits.Quantity;
            }
        }
        public int GetTotal()
        {
            return Items.Sum(x => x.Quantity);
        }
        public void ClearCart()
        {
            Items.Clear();
        }
    }
    public class ShoppingCartItems
    {
        public int ID_Product { get; set; }
        public int ID_Category { get; set; }
        public string Name_Product { get; set; }
        public int Quantity { get; set; }
        public string Images { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int Price { get; set; }
        public int TotalPrice { get; set; }
    }
}