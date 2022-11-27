using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_ChainOfResponsibility
{
    public  class Coin
    {
        public double Weight { get; set; }
        public double Diametr { get; set; }
    }

    public abstract class CoinCheckHandler
    {
        public CoinCheckHandler Successor { get; set; } = null!;
        public abstract double Handle(Coin coin);
    }
    public class FiveCoinHandler : CoinCheckHandler
    {
        public override double Handle(Coin coin)
        {
            if (coin.Diametr >= 23.5 && coin.Diametr <= 24.2 && coin.Weight >= 4.2 && coin.Weight <= 4.35)
                return 0.05;
            else
                return Successor.Handle(coin);
        }
    }
    public class TenCoinHandler : CoinCheckHandler
    {
        public override double Handle(Coin coin)
        {
            if (coin.Diametr >= 15.8 && coin.Diametr <= 16.5 && coin.Weight >= 1.6 && coin.Weight <= 1.8)
                return 0.10;
            else
                return Successor.Handle(coin);
        }
    }
    public class TwentyFiveCoinHandler : CoinCheckHandler
    {
        public override double Handle(Coin coin)
        {
            if (coin.Diametr >= 20.3 && coin.Diametr <= 21 && coin.Weight >= 2.8 && coin.Weight <= 2.9)
                return 0.25;
            else
                return Successor.Handle(coin);
        }
    }
    public class FiftyCoinHandler : CoinCheckHandler
    {
        public override double Handle(Coin coin)
        {
            if (coin.Diametr >= 22.5 && coin.Diametr <= 23.2 && coin.Weight >= 4.1 && coin.Weight <= 4.3)
                return 0.50;
            else
                return Successor.Handle(coin);
        }
    }
    public class HryvniaCoinHandler : CoinCheckHandler
    {
        public override double Handle(Coin coin)
        {
            if (coin.Diametr >= 25.5 && coin.Diametr <= 26.2 && coin.Weight >= 7 && coin.Weight <= 7.2)
                return 1;
            else
                return Successor.Handle(coin);
        }
    }
    public class NullCoinHandler : CoinCheckHandler
    {
        public override double Handle(Coin coin)
        {
            return 0;
        }
    }
}
