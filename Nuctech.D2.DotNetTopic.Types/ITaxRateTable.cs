using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nuctech.D2.DotNetTopic
{
    /// <summary>
    /// 商品税率表
    /// </summary>
    public interface ITaxRateTable
    {
        /// <summary>
        /// 获取指定商品税率
        /// </summary>
        /// <param name="type">商品类型</param>
        /// <returns>税率，大于等于0的浮点数</returns>
        float GetTaxRate(EnumItemType type);
    }
}