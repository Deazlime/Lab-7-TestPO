namespace lab
{
    public class Func
    {
        private const int max = 100;

        public static double Sin(double x)
        {
            double res=1;
            double term=x;
            for (int n=0;n<max;n++)
            {
                res+=term;
                term*=-x*x/((2*n+2)*(2*n+3));
            }
            return res;
        }
        public static double Cos(double x)
        {
            double res = 0;
            double term = 1;
            for (int n=0;n<max;n++)
            {
                res+=term;
                term*=-x*x/((2*n+1)*(2*n+2));
            }
            return res;
        }


        public static double Ln(double x)
        {
            if (x<=0)
                throw new ArgumentOutOfRangeException();

            double res = 0;
            for (int i=1;i<=max;i++)
            {
                res += Math.Pow((x-1)/x,i)/i;
            }
            return res;
        }


        public static double F(double x)
        {
            double res;

            if (x < 0)
            {
                double sinX=Sin(x);
                double cosX=Cos(x);
                res=sinX*sinX+cosX*cosX+Ln(Math.Abs(sinX));
            }
            else
            {
                double sinX=Sin(x);
                double lnX=Ln(x);
                res=Math.Sqrt(sinX*sinX+Cos(lnX*lnX));
            }

            return Math.Round(res,2);
        }

    }
}
