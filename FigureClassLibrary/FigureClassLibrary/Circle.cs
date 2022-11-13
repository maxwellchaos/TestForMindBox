using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureClassLibrary
{
    public class Circle : IFigure
    {
        private double _radius;
        public double Radius {
            get=>_radius;
            set
            {
                if(value<=0)
                {
                    throw new ArgumentException("Радиус должен быть больше нуля");
                }
                _radius = value;
            }
        }
        public Circle(double radius)
        {
            Radius = radius;
        }
        public double Square()
        {
            return Math.PI*_radius*_radius;
        }
    }
}
