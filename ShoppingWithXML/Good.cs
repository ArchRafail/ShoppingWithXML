using System;

namespace ShoppingWithXML
{
    enum UnitMeasurements { pcs, kg, pck };
    class Good
    {
        public int Article { get; private set; }
        public string Name { get; private set; }
        UnitMeasurements units;
        public double Price { get; private set; }
        public double Quantity { get; private set; }
        public double Cost { get; private set; }

        public Good()
        {
            Article = 0;
            Name = null;
            units = UnitMeasurements.pcs;
            Price = 0;
            Quantity = 0;
            Cost = Price * Quantity;
        }

        public Good(int article, string name, int number, double price, double qty)
        {
            Article = article;
            Name = name;
            switch (number)
            {
                case 1:
                    units = UnitMeasurements.pcs;
                    break;
                case 2:
                    units = UnitMeasurements.kg;
                    break;
                default:
                    units = UnitMeasurements.pck;
                    break;
            }
            Price = price;
            Quantity = qty;
            Cost = Price * Quantity;
        }

        public override string ToString()
        {
            return $"Art.: {Article}\tName: {Name}\tUnitMeasurement: {units}\tPrice: {Price}\nQuantity: {Quantity}\tCost: {Cost}\n";
        }

        public string GetUnits()
        {
            switch (units)
            {
                case UnitMeasurements.pcs:
                    return Quantity > 1 ? "pcs." : "pc";
                case UnitMeasurements.kg:
                    return "kg";
                default:
                    return Quantity > 1 ? "pcks." : "pck";
            }
        }
    }
}
