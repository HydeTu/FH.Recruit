using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nuctech.D2.DotNetTopic
{
    /// <summary>
    /// 商品接口，定义商品属性和单价
    /// </summary>
    public interface IItem
    {
        /// <summary>
        /// 商品ID，唯一属性
        /// </summary>
        int ID { get; }

        /// <summary>
        /// 名称
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// 商品类型
        /// </summary>
        EnumItemType Type { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        float Price { get; set; }
    }
}