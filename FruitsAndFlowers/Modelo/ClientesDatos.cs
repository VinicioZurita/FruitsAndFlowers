using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace FruitsAndFlowers._WS
{
    class ClientesDatos
    {
        public string ced_cli { get; set; }
        public string nom_cli { get; set; }
        public string ape_cli { get; set; }
        public string dir_cli { get; set; }
        public string cel_cli { get; set; }

        public static implicit operator ClientesDatos(ObservableCollection<ClientesDatos> v)
        {
            throw new NotImplementedException();
        }


        /*  private string _ced_cli;

          [JsonProperty("ced_cli")] //This maps the element title of your web service to your model
          public string Title
          {
              get => _ced_cli;
              set
              {
                  _ced_cli = value;
                  OnPropertyChanged(); //This notifies the View or ViewModel that the value that a property in the Model has changed and the View needs to be updated.
              }
          }

          public event PropertyChangedEventHandler PropertyChanged;

          protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
          {
              PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
          }*/
    }

}
