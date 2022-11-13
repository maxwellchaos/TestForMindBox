using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureClassLibrary
{
    public interface IFigure
    {
        /// <summary>
        /// Вычисление площади фигуры
        /// </summary>
        double Square();

        /// <summary>
        /// требуемая точность вычислений
        /// применяется при проверках при вычислении угла в треугольнике и в тестах
        /// </summary>
        public const double accuracy = 0.000001;
    }
}
