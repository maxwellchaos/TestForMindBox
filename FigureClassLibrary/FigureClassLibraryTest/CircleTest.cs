using AutoFixture.Xunit2;
using FigureClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureClassLibraryTest
{
    public class CircleTest
    {
        [Theory,AutoData]
        public void NegativeRadiusTest(double radius)
        {
             radius = -Math.Abs(radius);

             Assert.Throws<ArgumentException>(()=>new Circle(radius));
        }

        [Fact]
        public void SetGetRadiusTest()
        {
            Circle circle = new Circle(1.1);

            Assert.Equal(1.1, circle.Radius);
        }

        [Theory,AutoData]
        public void SquareTest(double radius)
        {
            Circle circle = new Circle(Math.Abs(radius));

            Assert.Equal(radius * radius * Math.PI, circle.Square());
        }
    }
}
