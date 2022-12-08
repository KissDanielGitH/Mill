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
using System.Windows.Shapes;
using ViewWPF.ViewModel;
using Model;
using Persistence;
using Persistence.Text;

namespace ViewWPF.View
{
    /// <summary>
    /// Interaction logic for MillWindow.xaml
    /// </summary>
    public partial class MillWindow : Window
    {
        public MillWindow()
        {
            InitializeComponent();
        }
    }
}
