using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FamilyTree.Controls
{
    /// <summary>
    /// Interaction logic for TreeCanvas.xaml
    /// </summary>
    public partial class TreeCanvas : Canvas
    {
        double m_firstLineOffset = 30;

        /// <summary>
        /// Координаты линий лет
        /// </summary>
        Dictionary<int, double> m_YearLines = new Dictionary<int, double>();

        public static DependencyProperty dp_Orientation = DependencyProperty.Register(nameof(Orientation), typeof(Orientation), typeof(TreeCanvas), new FrameworkPropertyMetadata() { DefaultValue = Orientation.Vertical });
        /// <summary>
        /// Ориентация дерева: сверху вниз или справа на лево
        /// </summary>
        public Orientation Orientation { get { return (Orientation)GetValue(dp_Orientation); } set { SetValue(dp_Orientation, value); } }

        public static DependencyProperty dp_TimeGrows = DependencyProperty.Register(nameof(TimeGrows), typeof(TimelineGrows), typeof(TreeCanvas), new FrameworkPropertyMetadata() { DefaultValue = TimelineGrows.Up });
        public TimelineGrows TimeGrows { get { return (TimelineGrows)GetValue(dp_TimeGrows); } set { SetValue(dp_TimeGrows, value); } }

        public static DependencyProperty dp_Zoom = DependencyProperty.Register(nameof(Zoom), typeof(int), typeof(TreeCanvas), new FrameworkPropertyMetadata() { DefaultValue = default(int) });
        public int Zoom { get { return (int)GetValue(dp_Zoom); } set { SetValue(dp_Zoom, value); } }

        public TreeCanvas()
        {
            InitializeComponent();
        }

        void DrawTimeLines()
        {

        }


    }
}
