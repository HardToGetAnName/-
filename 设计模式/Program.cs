using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 设计模式
{
    class Program
    {
        static void Main(string[] args)
        {
            float price = 10f;
            CheckOut checkOut = new CheckOut();
            checkOut.SetAttr(new AttrStrategyForJap());
            Console.WriteLine(  checkOut.Calc(price));

         
            checkOut.SetAttr(new AttrStrategyForAmer());
            Console.WriteLine(checkOut.Calc(price));

            checkOut.SetAttr(new AttrStrategyForChinese());
            Console.WriteLine(checkOut.Calc(price));

            Console.Read();

        }
    }

    
    public class CheckOut
    {
        IAttrStrategyForDifferentCountry attr = null;

        public void SetAttr(IAttrStrategyForDifferentCountry x)
        {
            attr = x;
        }

        public float  Calc(float originMoney)
        {
          return  attr.Calc(originMoney);
        }
    }





   
    public abstract class ICustomer
    {
        //购买商品的总钱数
        protected float allMoney;
        public float GetAllMoney()
        {
            return allMoney;
        }
        public void SetAllMoney(float x)
        {
            allMoney = x;
        }
        //对总钱数的处理策略
        protected IAttrStrategyForDifferentCountry attrStrategyForDifferentCountry = null;

        //设置策略
        public void SetStrategy(IAttrStrategyForDifferentCountry attrStrategyForDifferentCountry)
        {
            this.attrStrategyForDifferentCountry = attrStrategyForDifferentCountry;
        }

        //初始化
        //public virtual void Init()
        //{
        //    attrStrategyForDifferentCountry.InitIAttrStrategyForDifferentCountry(this);
        //}

        //获取处理后的钱数
        //public void  GetNewMoney(ICustomer x)
        //{
        //    attrStrategyForDifferentCountry.Calc(x);
        //}
    }

    public class Jap : ICustomer
    {
        public Jap() { }
        public Jap(float allMoney)
        {
            this.allMoney = allMoney;
        }
    }

    public class American : ICustomer
    {
        public American() { }
        public American(float allMoney)
        {
            this.allMoney = allMoney;
        }
    }

    public abstract class IAttrStrategyForDifferentCountry
    {


        //策略类的处理动作(算钱)
        public abstract float Calc(float originMoney);
    }

    public class AttrStrategyForJap : IAttrStrategyForDifferentCountry
    {


        public override float Calc(float originMoney)
        {


            //具体的计算都跑到这里来了（switch中的case）
            float temp = originMoney;
            temp = temp + temp * 0.015f;
            return temp;
        }

    }

    public class AttrStrategyForAmer : IAttrStrategyForDifferentCountry
    {

        public override float Calc(float originMoney)
        {
            //具体的计算都跑到这里来了（switch中的case）
            float temp = originMoney;
            temp = temp + temp * 0.01f;
            return temp;
        }
    }

    public class AttrStrategyForChinese : IAttrStrategyForDifferentCountry
    {

        public override float Calc(float originMoney)
        {
            //具体的计算都跑到这里来了（switch中的case）
            float temp = originMoney;
            temp = temp * 0.9f;
            return temp;
        }
    }
}
