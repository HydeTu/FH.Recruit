namespace Nuctech.D2.DotNetTopic
{
    public class TaxRateTable : ITaxRateTable
    {
        public float GetTaxRate(EnumItemType type)
        {
            float rate = 0f;
            switch (type)
            {
                case EnumItemType.Book:
                    rate = 0.005f;
                    break;

                case EnumItemType.Clothing:
                    rate = 0.02f;
                    break;

                case EnumItemType.Commodities:
                    rate = 0.01f;
                    break;

                case EnumItemType.Electronics:
                    rate = 0.05f;
                    break;

                case EnumItemType.Medicine:
                    rate = 0f;
                    break;

                case EnumItemType.Other:
                default:
                    rate = 0.03f;
                    break;
            }

            return rate;
        }
    }
}