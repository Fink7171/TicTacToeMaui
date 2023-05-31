using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicTacToeMaui.Models;

namespace TicTacToeMaui.ViewModel
{
    public partial class TicTacToeGamePageViewModel : ObservableObject
    {
        [ObservableProperty]
        private int _player1Point;

        [ObservableProperty]
        private int _player2Point;

        [ObservableProperty]
        private string _playerWinOrDrawText;

        private int _playerTurn = 0;
        private bool _isAnyoneWin;

        List<int[]> WinPossibilities = new List<int[]>();

        public ObservableCollection<TicTacToeModel> TicTacList { get; set; } = new ObservableCollection<TicTacToeModel>();
        public TicTacToeGamePageViewModel() 
        {
                 SetupGameInfo();
        }

        private void SetupGameInfo()
        {
            WinPossibilities.Clear();


            WinPossibilities.Add(new[] { 0, 1, 2 });
            WinPossibilities.Add(new[] { 3, 4, 5 });
            WinPossibilities.Add(new[] { 6, 7, 8 });

            WinPossibilities.Add(new[] { 0, 3, 6 });
            WinPossibilities.Add(new[] { 1, 4, 7 });
            WinPossibilities.Add(new[] { 2, 5, 8 });

            WinPossibilities.Add(new[] { 0, 4, 8 });
            WinPossibilities.Add(new[] { 2, 4, 6 });


            TicTacList.Clear();
            TicTacList.Add(new TicTacToeModel(0));
            TicTacList.Add(new TicTacToeModel(1));
            TicTacList.Add(new TicTacToeModel(2));
            TicTacList.Add(new TicTacToeModel(3));
            TicTacList.Add(new TicTacToeModel(4));
            TicTacList.Add(new TicTacToeModel(5));
            TicTacList.Add(new TicTacToeModel(6));
            TicTacList.Add(new TicTacToeModel(7));
            TicTacList.Add(new TicTacToeModel(8));

        }

        [RelayCommand]
        private void RestartGame()
        {
            _isAnyoneWin = false;
            PlayerWinOrDrawText = " ";
            _playerTurn = 0;
            SetupGameInfo();
        }


        [RelayCommand]
        public void SelectedItem(TicTacToeModel selectedItem)
        {
            if (!string.IsNullOrWhiteSpace(selectedItem.SelectedText) || _isAnyoneWin) return;

            if(_playerTurn == 0)
            {
                selectedItem.SelectedText = "X";
            }
            else
            {
                selectedItem.SelectedText = "O";
            }

            selectedItem.Player = _playerTurn;
            _playerTurn = _playerTurn == 0 ? 1 : 0;

            CheckForWin();
        }

        private void CheckForWin()
        {
            var player1IndexList = TicTacList.Where(f => f.Player == 0).Select(f => f.Index).ToList();
            var player2IndexList = TicTacList.Where(f => f.Player == 1).Select(f => f.Index).ToList();

            if(player1IndexList.Count > 2 || player2IndexList.Count > 2)
            {
                foreach(var winPossibility in WinPossibilities)
                {
                    if (_isAnyoneWin) break;
                    int player1Count = 0;
                    int player2Count = 0;

                    foreach (var index in player1IndexList)
                    {
                        if (winPossibility.Contains(index))
                        {
                            player1Count++;
                        }
                        if (player1Count == 3)
                        {
                            Player1Point++;
                            PlayerWinOrDrawText = "Player 1 Wins!!!";
                            _isAnyoneWin = true;
                            break;
                        }
                    }
                    foreach (var index in player2IndexList)
                    {
                        if (winPossibility.Contains(index))
                        {
                            player2Count++;
                        }
                        if (player2Count == 3)
                        {
                            Player2Point++;
                            PlayerWinOrDrawText = "Player 2 Wins!!!";
                            _isAnyoneWin = true;
                            break;
                        }
                    }
                }
            }

            if(TicTacList.Count(f => f.Player.HasValue)==9 && !_isAnyoneWin)
            {
                PlayerWinOrDrawText = "It´s a draw...";
            }
        }

        
    }
}
