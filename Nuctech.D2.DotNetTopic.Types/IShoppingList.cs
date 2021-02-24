using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nuctech.D2.DotNetTopic
{
    /// <summary>
    /// 购物清单
    /// </summary>
    public interface IShoppingList : IEnumerable<IItem>
    {
        /// <summary>
        /// 清单创建时间
        /// </summary>
        DateTime Time { get; }

        /// <summary>
        /// 根据顺序号索引商品
        /// </summary>
        /// <param name="index">商品在ShoppingList中的顺序号，从0开始</param>
        /// <returns>在ShoppingList中索引号为<paramref name="index"/>的商品。 若索引号超出范围，则返回空</returns>
        IItem this[int index] { get; set; }

        /// <summary>
        /// 向购物清单添加指定数量的商品
        /// </summary>
        /// <param name="item">商品</param>
        /// <param name="count">商品数量</param>
        /// <returns>是否成功。true=成功；false=失败</returns>
        bool Add(IItem item, int count);

        /// <summary>
        /// 向购物清单添加一件商品
        /// </summary>
        /// <param name="item">商品</param>
        /// <returns>是否成功。true=成功；false=失败</returns>
        bool Add(IItem item);

        /// <summary>
        /// 从购物清单中删除指定数量的商品。若清单中的商品数量小于指定数量，或无该商品，不删除指定商品。
        /// </summary>
        /// <param name="item">指定商品</param>
        /// <param name="count">指定数量</param>
        /// <returns>true=删除成功；false=删除失败</returns>
        bool RemoveItem(IItem item, int count);

        /// <summary>
        /// 删除所有指定商品
        /// </summary>
        /// <param name="item">指定商品</param>
        /// <returns>true=删除成功；false=删除失败</returns>
        bool RemoveAllItem(IItem item);

        /// <summary>
        /// 删除所有商品。删除后为空白清单
        /// </summary>
        /// <returns>true=删除成功；false=删除失败</returns>
        bool RemoveAll();

        /// <summary>
        /// 获取所有商品总数
        /// </summary>
        /// <returns>商品总数。无商品返回0</returns>
        int GetAllItemCount();

        /// <summary>
        /// 获取指定商品的数量
        /// </summary>
        /// <param name="item">指定商品</param>
        /// <returns>指定商品数量。若无商品，则返回0</returns>
        int GetItemCount(IItem item);

        /// <summary>
        /// 计算商品总金额.
        /// 总金额先按公式“总金额 = SUM(商品单价 * 商品数量 * (1 + TaxRate))”计算。
        /// 得到总金额后，以四舍五入，保留1位小数。
        /// 再将保留一位小数的总金额按最小价格单元0.5进行“取整”：小数为0.5则不处理；不足0.5元，按0.5元计算。大于0.5按1计算。即小数位只能是0或5。
        /// 如 11.0取整后为11.0；28.9取整后为29.0； 103.2取整后为103.5；55.5取整后为55.5。
        /// </summary>
        /// <param name="taxRate">商品税率表</param>
        /// <returns>商品总金额，最小单元为0.5。</returns>
        float Sum(ITaxRateTable taxRate);

        /// <summary>
        /// 是否为空白购物清单：无商品,或商品总数量为0
        /// </summary>
        /// <returns>true=空白清单；false=有商品</returns>
        bool IsEmpty();
    }
}