using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nuctech.D2.DotNetTopic
{
    /// <summary>
    /// 购物管理类，用于定义税率表，创建购物清单。
    /// </summary>
    public interface IShoppingManager
    {
        /// <summary>
        /// 当前税率表
        /// </summary>
        ITaxRateTable CurrentTaxRateTable { get; }

        /// <summary>
        /// 创建空白购物清单
        /// </summary>
        /// <returns>空白购物清单。清单的税率表为当前税率表<paramref name="CurrentTaxRateTable"/></returns>
        IShoppingList CreateRandomShoppingList();

        /// <summary>
        /// 根据商品ID获取商品对象
        /// </summary>
        /// <param name="id">商品ID</param>
        /// <returns>商品对象，若没有匹配的商品则返回null</returns>
        IItem GetItem(int id);
    }
}