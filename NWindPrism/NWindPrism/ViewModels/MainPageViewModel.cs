using NWindPrism.Model;
using NWindPrism.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NWindPrism.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        /* public MainPageViewModel(INavigationService navigationService)
             : base(navigationService)
         {

         }*/
        public DelegateCommand AddCommand { get; }
        public DelegateCommand<BatFamily>DeleteCommand { get; }
        public DelegateCommand<BatFamily> UpdateCommand { get; }
        private IBatFamilyService BatItemService { get; }
        private IEnumerable<BatFamily> BatFamilyAll;
        private string inputText;
        public MainPageViewModel(INavigationService navigationService,IBatFamilyService BatSericeParam)
            :base(navigationService)
        {
            BatItemService = BatSericeParam;
            _ItemSeleccionado = new BatFamily();
            GetBatFamilies();
            this.AddCommand = new DelegateCommand(AddTodoItem, () => !string.IsNullOrEmpty(InputText)).ObservesProperty(()=>this.InputText);
            DeleteCommand = new DelegateCommand<BatFamily>(this.DeleteTodoItem);
            UpdateCommand=new DelegateCommand<BatFamily>(UpdateTodoItem);
        }

        private async void GetBatFamilies()
        {
            BatFamilyAlls = await BatItemService.GetAllAsync();
        }

        //private async void AddTodoItem()
        //{
        //    await BatItemService.GetAllAsync();
        //}

        private async void DeleteTodoItem(BatFamily TodoItem)
        {
            await BatItemService.DeleteAsync(TodoItem);
            BatFamilyAlls = await BatItemService.GetAllAsync();
        }

        private async void UpdateTodoItem(BatFamily TodoItem)
        {
            TodoItem.Nombre = inputText;
            InputText = "";
            await BatItemService.UpdateAsync(TodoItem);
            BatFamilyAlls = await BatItemService.GetAllAsync();
        }

        private async void AddTodoItem()
        {
            await BatItemService.InsertAsync(new BatFamily { Nombre = InputText });
            InputText = "";
            BatFamilyAlls = await BatItemService.GetAllAsync();
        }

        public IEnumerable<BatFamily> BatFamilyAlls
        {
            get { return BatFamilyAll; }
            set { SetProperty(ref this.BatFamilyAll, value); }
        }
        public string InputText
        {
            get { return this.inputText; }
            set
            {
                this.SetProperty(ref this.inputText, value);
            }
        }
        //private void DeleteTodoItem(BatFamily BatParent)
        //{
        //    BatItemService.Delete(BatParent.Id);
        //    BatFamilyAlls = BatItemService.GetAll();
        //}
        //private void AddTodoItem()
        //{
        //    BatItemService.Insert(new BatFamily { Nombre = InputText });
        //    InputText = "";
        //    BatFamilyAlls = BatItemService.GetAll();
        //}
        public async void OnNavigatedFrom(NavigationParameters parameters)
        {
            BatFamilyAlls = await BatItemService.GetAllAsync();
        }
        public async void OnNavigatedTo(NavigationParameters parameters)
        {
            BatFamilyAlls = await BatItemService.GetAllAsync();
        }

        private BatFamily _ItemSeleccionado;
        public BatFamily ItemSeleccionado
        {
            get { return _ItemSeleccionado; }
            set
            {
                SetProperty(ref _ItemSeleccionado, value);
                if (_ItemSeleccionado!=null)
                {
                    InputText = _ItemSeleccionado.Nombre;
                }
            }
        }

    }
}
