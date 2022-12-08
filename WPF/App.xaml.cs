using Microsoft.Win32;
using Model;
using Persistence;
using Persistence.Text;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ViewWPF.View;
using ViewWPF.ViewModel;

namespace ViewWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MalomGame model = null!;
        private MillViewModel viewModel = null!;
        private MillWindow view = null!;

        public App()
        {
            Startup += new StartupEventHandler(App_Startup);
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            model = new MalomGame(new MillTextFileDataAccess());
            model.Mill += Model_Mill;
            model.GameOver += Model_GameOver;

            viewModel = new MillViewModel(model);
            viewModel.NewGame += ViewModel_NewGame;
            viewModel.SaveGame += ViewModel_SaveGame;
            viewModel.LoadGame += ViewModel_LoadGame;
            viewModel.ExitGame += ViewModel_ExitGame;

            view = new MillWindow();

            view.DataContext = viewModel;

            view.Show();
        }

        private void ViewModel_ExitGame(object? sender, EventArgs e)
        {
            view.Close();
        }

        private void ViewModel_LoadGame(object? sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Load previous game";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    model.LoadGame(openFileDialog.FileName);
                }
                catch (MillDataException)
                {
                    MessageBox.Show("An error occured while loading.", "Mill", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ViewModel_SaveGame(object? sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save game";

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    model.SaveGame(saveFileDialog.FileName);
                }
                catch (MillDataException)
                {
                    MessageBox.Show("An error occured while saving.", "Mill", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void ViewModel_NewGame(object? sender, EventArgs e)
        {
            model.resetGame();
        }

        private void Model_GameOver(object? sender, EventArgs e)
        {
            if (model.NumberOfBlackPieces < 3)
            {
                MessageBox.Show($"Congratulations!\n{Players.White.ToString()} won the game!");
            }
            else
            {
                MessageBox.Show($"Congratulations!\n{Players.Black.ToString()} won the game!");
            }
        }

        private void Model_Mill(object? sender, EventArgs e)
        {
            MessageBox.Show("You may remove a piece from your opponent.", "Mill", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
