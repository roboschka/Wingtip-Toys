﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication3.Models;
using System.Web.ModelBinding; //untuk binding ke cantolan yang udh dibikin

namespace WebApplication3
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //so now we're going to populate it
        public IQueryable<Product> GetProducts([QueryString("id")] int? categoryId)
        {
            var _db = new WebApplication3.Models.ProductContext();
            IQueryable<Product> query = _db.Products;
            if (categoryId.HasValue && categoryId > 0)
            {
                query = query.Where(p => p.CategoryID == categoryId);
            }
            return query;
        }
    }
}