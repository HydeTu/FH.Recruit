using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nutech.D2.DotNetTopic
{
    public static class DatasourceHelper
    {
        private readonly static DatasourceHelper _instance = new DatasourceHelper();

        private DatasourceHelper()
        { }

        public static DatasourceHelper Instance { get { return _instance; } }

        public ITaxRateTable CreateTaxRateTable()
        {
            return new TaxRateTable();
        }

        public List<IItem> CreateItems()
        {
        }
    }
}