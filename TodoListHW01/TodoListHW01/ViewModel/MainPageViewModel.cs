using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace TodoListHW01.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {
        public MainPageViewModel()
        {
            Items = new ObservableCollection<TodoItem>();
            Item = new TodoItem();

        }
        public TodoItem Item { get; set; }

        public ObservableCollection<TodoItem> Items { get; private set; }

        private Command addItem;
        public Command AddItem => addItem ?? (addItem = new Command(
            () =>
            {
                Item.Name = ItemText;
                Items.Add(Item);
                ItemText = null;
            },
            () =>
            {
                return true;
            }));
        
        private string itemText;

        public string ItemText
        {
            get => itemText;
            set 
            {
                SetField(ref itemText, value);
                AddItem.ChangeCanExecute();
            }
        }
    }
}
