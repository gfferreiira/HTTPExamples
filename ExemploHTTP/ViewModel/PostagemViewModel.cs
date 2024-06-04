using CommunityToolkit.Mvvm.ComponentModel;
using ExemploHTTP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ExemploHTTP.ViewModel
{
    public partial class PostagemViewModel : ObservableObject
    {
        private readonly RestService _restService;
        public PostagemViewModel()
        {
            _restService = new RestService();
            FindPostsAsyncCommand = new Command(async () => await GetPostagensAsync());
        }

        /*
        [ObservableProperty]
        private int _userId;

        [ObservableProperty]
        private int _id;

        [ObservableProperty]
        private string _title;

        [ObservableProperty]
        private string _body;
        */
        private ObservableCollection<Postagem> _posts = new ObservableCollection<Postagem>();
        public ObservableCollection<Postagem> Posts { 
            get { return _posts; } 
            set { _posts = value; }
        }
        
        public ICommand FindPostsAsyncCommand { get; }

        public async Task<ObservableCollection<Postagem>> GetPostagensAsync()
        {
            return await _restService.GetPostagensAsync();

        }
    
    }



}
