using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Data;
using System.Threading;

namespace FamilyTree.Controls.TreeCanvasHelpers
{
    /// <summary>
    /// Управление отрисовкой линий веремени
    /// </summary>
    public class TimeLinesManager
    {
        TreeCanvas m_canvas;

        readonly Dictionary<DateTime, Line> m_drawedLines = new Dictionary<DateTime, Line>();

        /// <summary>
        /// Отступ для первой линии
        /// </summary>
        public double FirstLineOffset { get; set; } = 20;

        /// <summary>
        /// Расстояние между линиями
        /// </summary>
        public double LineInterval { get; set; } = 20;

        public TimeLinesManager(TreeCanvas canvas)
        {
            m_canvas = canvas ?? throw new ArgumentNullException("Передана пустая ссылка на Canvas для TimeLinesManager");

            if (canvas.Dispatcher.Thread.ManagedThreadId != Thread.CurrentThread.ManagedThreadId)
                throw new InvalidOperationException("Создание экземпляра TimeLinesManager предусмотрено только в потоке Canvas'a. Класс не потокобезопасен");
        }

        /// <summary>
        /// Отрисовка линий времени
        /// </summary>
        public void DrawLines(DateTime start)
        {

        }

        /// <summary>
        /// Отрисовка одной линии
        /// </summary>
        /// <param name="dt"></param>
        void DrawLine(DateTime dt)
        {
            double offset = FirstLineOffset + (m_drawedLines.Count * LineInterval);

            var line = new Line();

            var brush = Brushes.LightGray;
            brush.Freeze();
            line.Fill = brush;
            line.StrokeThickness = 1;

            line.X1 = offset;
            line.Y1 = 0;
            line.X2 = offset;
            line.Y2 = m_canvas.ActualHeight;
            var bind = new Binding(nameof(m_canvas.ActualHeight));
            bind.Source = m_canvas;
            line.SetBinding(Line.Y2Property, bind);

            m_canvas.Children.Add(line);

            m_drawedLines.Add(dt, line);
        }

        void DrawLineLegend()
        {

        }
    }
}
