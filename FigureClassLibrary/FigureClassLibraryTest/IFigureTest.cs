using FigureClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureClassLibraryTest
{
    public class IFigureTest
    {
        [Fact]
        public void PolimorfizmTest()
        {
            IFigure circle = new Circle(1.1);
            IFigure triangle = new Triangle(3, 4, 5);

            Assert.Equal(1.1 * 1.1 * Math.PI, circle.Square());
            Assert.Equal(3 * 4 / 2, triangle.Square());
        }
    }
}
