using System.ComponentModel;

namespace SBModuleWorkDB
{
    public class Client : INotifyPropertyChanged
    {
        private int _id;
        private string _secondName;
        private string _name;
        private string _patronymic;
        private string _number;
        private string _email;
        public int Id 
        { 
            get { return _id; } 
            private set 
            {
                _id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Id))); 
            } 
        }
        public string SecondName 
        { 
            get { return _secondName; } 
            private set 
            {
                _secondName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SecondName))); 
            } 
        }
        public string Name 
        { 
            get { return _name; } 
            private set 
            {
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name))); 
            } 
        }
        public string Patronymic 
        { 
            get { return _patronymic; } 
            private set 
            {
                _patronymic = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Patronymic))); 
            } 
        }
        public string Number 
        { 
            get { return _number; } 
            private set 
            {
                _number = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Number))); 
            } 
        }
        public string Email 
        { 
            get { return _email; } 
            private set 
            {
                _email = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Email))); 
            } 
        }
        public Client(int id, string secondName, string name, string patr, string phone, string email)
        {
            Id = id;
            SecondName = secondName;
            Name = name;
            Patronymic = patr;
            Number = phone;
            Email = email;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Rewrite(Client client)
        {
            Id = client.Id;
            SecondName = client.SecondName;
            Name = client.Name;
            Patronymic = client.Patronymic;
            Number = client.Number;
            Email = client.Email;
        }
    }
}
