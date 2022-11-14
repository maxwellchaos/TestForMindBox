using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FigureClassLibrary
{
    //Этот класс сделан с предположением, что будут добавляться многоугольники
    //этот класс сделан абстрактным чтобы можно было написать один код для всех фигур-наследников
    // в этом классе будет универсальный метод выяисления периметра по ребрам для всех многоугольников
    public abstract class Poligon : IFigure
    {
        //Комментарий Summary к этому методу есть в интерфейсе
        abstract public double Square();
        
        /// <summary>
        /// Получить ребра
        /// </summary>
        /// <returns>Возвращает список ребер</returns>
        abstract public List<double> Edges();

        /// <summary>
        /// Получить периметр многоугольника
        /// </summary>
        /// <returns>Возвращает периметр</returns>
        public double Perimetr()
        {
            return Edges().Sum();
        }
    }
}
