using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.AI.OpenAI;
using Yoda.ViewModels;
using Yoda.Views;
using Yoda.Enums;
using Yoda.Config;
using Yoda.Services;
using Yoda.Models;
using CommunityToolkit.Mvvm.Input;
using Yoda.Services.Interfaces;

namespace Yoda.ViewModels
{
    public partial class FactViewModel : BaseViewModel
    {
        private IAiAssistant _assistant;
        public FactViewModel(IAiAssistant AiAssistant)
        {
            _assistant = AiAssistant;
        }

        private ChatMessage _factshow;
        public ChatMessage Factshow
        {
            get { return _factshow; }
            set
            {
                _factshow = value;
                OnPropertyChanged();
            }

        }

        [RelayCommand]
        public async void ShowFact()
        {
            Factshow = await _assistant.GetCompletion();
        }
    }
}
