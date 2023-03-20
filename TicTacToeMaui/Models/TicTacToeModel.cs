using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeMaui.ViewModel;

namespace TicTacToeMaui.Models
{
    public partial class TicTacToeModel : ObservableObject
    {
        public TicTacToeModel(int index) 
        {
                 this.Index = index;
        }
        public int Index { get; set; }

        [ObservableProperty]
        public string _selectedText;

        public int? Player { get; set; }
    }
}
