using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoloryMAUI.Models
{
    public class FillColor
    {
		private double _r, _g, _b;

        public FillColor(double r, double g, double b)
        {
            _r = r;
            _g = g;
            _b = b;
        }

        public FillColor() : this(0,0,0)
        {
        }

        public double R
		{
			get { return LimitRange(_r); }
			set { _r = value; }
		}

        public double G
        {
            get { return LimitRange(_g); }
            set { _g = value; }
        }
        public double B
        {
            get { return LimitRange(_b); }
            set { _b = value; }
        }

        private double LimitRange(double val)
        {
            if (val > 1.0)
                return 1.0;
            else if (val < 0.0)
                return 0.0;
            else
                return val;
        }
    }
}
