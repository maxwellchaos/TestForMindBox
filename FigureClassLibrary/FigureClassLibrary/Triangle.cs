using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureClassLibrary
{
    public class Triangle : Poligon
    {
        private double _edge1;
        private double _edge2;
        private double _edge3;
        public Triangle(List<double> edges)
        {
            SetEdges(edges);
        }

        public Triangle(double edge1, double edge2, double edge3)
        {
            SetEdges(edge1, edge2, edge3);
        }

        /// <summary>
        /// установить треунольник по его ребрам
        /// </summary>
        /// <param name="edges">список ребер</param>
        public void SetEdges(List<double> edges)
        {
            if (edges.Count > 3)
            {
                throw new ArgumentException("Слишком много сторон для треугольника.");
            }
            if (edges.Count < 3)
            {
                throw new ArgumentException("Слишком мало сторон для треугольника.");
            }
            SetEdges(edges[0], edges[1], edges[2]);
        }

        /// <summary>
        /// установить треунольник по его ребрам
        /// </summary>
        /// <param name="edge1">ребро треугольника</param>
        /// <param name="edge2">ребро треугольника</param>
        /// <param name="edge3">ребро треугольника</param>
        public void SetEdges(double edge1, double edge2, double edge3)
        {
            if (edge1 <= 0 || edge2 <= 0 || edge3 <= 0)
            {
                throw new ArgumentException("Сторона треугольника не может быть отридцательной или нулевой");
            }
            //Проверка на размеры сторон
            double sum = edge1 + edge2 + edge3;
            double max = Math.Max(Math.Max(edge1, edge2), edge3);
            if(sum-max<=max)
            {
                throw new ArgumentException("Длинна одной из сторон не может превышать сумму длин двух других");
            }
            _edge1 = edge1;
            _edge2 = edge2;
            _edge3 = edge3;
        }

        public override List<double> Edges()
        {
            List<double> edges = new List<double>();
            edges.Add(_edge1);
            edges.Add(_edge2);
            edges.Add(_edge3);
            return edges;
        }

        public override double Square()
        {
            //использую формулу герона
            double halfPerimetr = Perimetr() / 2;
            double square = Math.Sqrt(halfPerimetr
                                        *(halfPerimetr - _edge1) 
                                        *(halfPerimetr - _edge2) 
                                        *(halfPerimetr - _edge3));
            return square;
        }

        /// <summary>
        /// является ли прямоугольник треугольным
        /// </summary>
        /// <returns>true если прямоугольник треугольный</returns>
        public bool IsRightTriangle()
        {
            var edges = Edges();
            double max = edges.Max();

            //если найдено больше одной гепотенузы(стороны равной максимуму)
            if(edges.FindAll(egde => egde == max).Count>1)
            {
                return false;
            }

            //посчитать сумму квадратов катетов
            double squareSum = 0;
            foreach(double edge in edges)
            {
                if(edge != max)
                    squareSum+=edge*edge;
            }

            //подсчитать модуль разницы между квадратом гипотенузы и суммой квадратов катетов
            double delta = Math.Abs(max*max - squareSum);
            
            if(delta<IFigure.accuracy)
            {
                return true;
            }
            return false;
        }
    }
}
