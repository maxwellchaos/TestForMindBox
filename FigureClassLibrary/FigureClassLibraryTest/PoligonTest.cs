using AutoFixture.Xunit2;
using FigureClassLibrary;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureClassLibraryTest
{
    public class PoligonTest
    {
        [Theory,AutoData]
        public void PerimetrTest(List<double> edges)
        {
            var mock = new Mock<Poligon>();
            mock.Setup(polygon => polygon.Edges()).Returns(edges);
            Poligon poligon = mock.Object;

            Assert.Equal(edges.Sum(), poligon.Perimetr());
        }
    }
}
