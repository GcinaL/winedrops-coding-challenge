using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace winedrops_coding_challenge.backend
{
    public class model
    {

        public model() { }

        public DataSet getList(char filter)
        {
            string whereClause = "";
            string orderByClause = "";

            switch (filter)
            {
                case 'r':
                    whereClause = "where o.status = 'paid' ";
                    orderByClause = "order by sum(tbl.amount) desc";
                    break;
                case 'b':
                    whereClause = "where o.status in ('paid', 'dispatched') ";
                    orderByClause = "order by sum(tbl.quantity) desc";
                    break;
                case 'o':
                    whereClause = "where o.status in ('paid', 'dispatched') ";
                    orderByClause = "order by sum(tbl.orders) desc";
                    break;
            }

            string sql = @"select "
                        + "ROW_NUMBER () OVER ("+ orderByClause + ") position "
                        + ",m.id "
                        + ",m.name ||' '|| m.vintage [name] "
                        + ",sum(tbl.quantity) [quantity] "
                        + ",PRINTF('£%.2f',sum(tbl.amount)) [amount] "
                        + ",sum(tbl.orders) [orders] "
                        + "from master_wine m "
                        + "join "
                        + "(select "
                        + "p.id "
                        + ",p.master_wine_id "
                        + ",p.name "
                        + ",sum(o.quantity) [quantity] "
                        + ",sum(o.total_amount) [amount] "
                        + ",count(o.id) [orders] "
                        + "from customer_order o "
                        + "join wine_product p on p.id = o.wine_product_id "
                        + whereClause
                        + "group by p.id) "
                        + "tbl on tbl.master_wine_id = m.id "
                        + "group by m.id "
                        + orderByClause;

            return new dbconnector().selectCommand(sql);
        }


    }
}