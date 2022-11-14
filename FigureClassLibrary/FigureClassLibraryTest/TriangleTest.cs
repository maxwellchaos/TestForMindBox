using AutoFixture.Xunit2;
using FigureClassLibrary;
using Xunit;

namespace FigureClassLibraryTest
{
    public class TriangleTest
    {
        [Fact]
        public void SetAndGetEdgesInConstructorTest()
        {
            Triangle figure = new Triangle(1.1, 2.1, 2.5);

            var edges = figure.Edges();

            Assert.Equal(1.1, edges[0]);
            Assert.Equal(2.1, edges[1]);
            Assert.Equal(2.5, edges[2]);
        }

        [Fact]
        public void SetAndGetEdgesInConstructorByListTest()
        {
            List<double> InEdges = new List<double>() { 1.1,2.1,2.5};
         

            Triangle figure = new Triangle(InEdges);
            var OutEdges = figure.Edges();

            Assert.Equal(1.1, OutEdges[0]);
            Assert.Equal(2.1, OutEdges[1]);
            Assert.Equal(2.5, OutEdges[2]);
        }

        [Fact]
        public void SetEdgesInConstructorByListFailureTest()
        {
            List<double> InEdges = new List<double>() { 1.1, 2.1 };
            List<double> InEdges2 = new List<double>() { 1.1, 2.1, 1.1, 2.1 };
            List<double> InEdges3 = new List<double>() { 1.1, 2.1, 1.1, 2.1, 1.1, 2.1 };

            Assert.Throws<ArgumentException>(()=> new Triangle(InEdges));
            Assert.Throws<ArgumentException>(() => new Triangle(InEdges2));
            Assert.Throws<ArgumentException>(() => new Triangle(InEdges3));
        }

        [Fact]
        public void SetAndGetEdgesTest()
        {
            Triangle figure = new Triangle(1, 2, 2);
            figure.SetEdges(1.1, 2.1, 2.5);

            var edges = figure.Edges();

            Assert.Equal(1.1, edges[0]);
            Assert.Equal(2.1, edges[1]);
            Assert.Equal(2.5, edges[2]);
        }

        [Fact]
        public void SetAndGetEdgesByListTest()
        {
            List<double> InEdges = new List<double>() { 2, 2, 1 };
            Triangle figure = new Triangle(InEdges);
            List<double> InEdges1 = new List<double>() { 1.1, 2.1, 2.5 }; 
           
            figure.SetEdges(InEdges1);
            var OutEdges = figure.Edges();

            Assert.Equal(1.1, OutEdges[0]);
            Assert.Equal(2.1, OutEdges[1]);
            Assert.Equal(2.5, OutEdges[2]);
        }

        [Fact]
        public void SetEdgesByListFailureTest()
        {
            List<double> InEdges1 = new List<double>() { 1.1, 2.1 };
            Triangle figure1 = new Triangle(1, 2, 2);
            List<double> InEdges2 = new List<double>() { 1.1, 2.1, 1.1, 2.1 };
            Triangle figure2 = new Triangle(1, 2, 2);
            List<double> InEdges3 = new List<double>() { 1.1, 2.1, 1.1, 2.1, 1.1, 2.1 };
            Triangle figure3 = new Triangle(1, 2, 2);

            Assert.Throws<ArgumentException>(() => figure1.SetEdges(InEdges1));
            Assert.Throws<ArgumentException>(() => figure2.SetEdges(InEdges2));
            Assert.Throws<ArgumentException>(() => figure3.SetEdges(InEdges3));
        }

        [Theory]
        [InlineData(-1, 2, 2)]
        [InlineData(1, -2, 2)]
        [InlineData(1, 2, -2)]
        [InlineData(-1, 2, -2)]
        [InlineData(1, -2, -2)]
        [InlineData(-1, -2, 2)]
        [InlineData(-1, -2, -2)]
        public void NegativeEdgesTest(double edge1, double edge2,double edge3)
        {
            Assert.Throws<ArgumentException>(()=>new Triangle(edge1,edge2,edge3));
        }


        [Theory, AutoData]
        public void IsNotTriangleTest(double edge1, double edge2)
        {
            Assert.Throws<ArgumentException>(() => new Triangle(edge1, edge2, edge1 + edge2 + IFigure.accuracy));
            Assert.Throws<ArgumentException>(() => new Triangle(edge1, edge1 + edge2 + IFigure.accuracy, edge2));
            Assert.Throws<ArgumentException>(() => new Triangle(edge1 + edge2 + IFigure.accuracy, edge1, edge2));
        }

        [Theory, AutoData]
        public void SquareTriangleTest(double edge1, double edge2)
        {
            var triangle1 = new Triangle(edge1, edge2, edge1 + edge2 - IFigure.accuracy);
            var triangle2 = new Triangle(edge1, edge1 + edge2 - IFigure.accuracy, edge2);
            var triangle3 = new Triangle(edge1 + edge2 - IFigure.accuracy, edge1, edge2);

            double square1 = triangle1.Square();
            double square2 = triangle2.Square();
            double square3 = triangle3.Square();

            Assert.Equal(square3, square2);
            Assert.Equal(square1, square2);
        }


        [Theory]
        [InlineData(8, 6, 10, true)]
        [InlineData(3, 4, 5, true)]
        [InlineData(1, 2, 2.3, false)]
        [InlineData(1, 1, 1, false)]
        public void RightTriangleTest(double edge1, double edge2, double edge3,bool IsRight)
        {
            var triangle =  new Triangle(edge1, edge2, edge3);

            Assert.Equal(triangle.IsRightTriangle(), IsRight);
        }
    }
}
