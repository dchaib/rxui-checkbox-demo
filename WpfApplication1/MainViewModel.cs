using System;
using System.Reactive.Linq;
using ReactiveUI;

namespace WpfApplication1
{
    public class MainViewModel : ReactiveObject
    {
        public MainViewModel()
        {
            this.CheckedValue = true;
            this.CheckedTimeStamp = string.Empty;

            UpdateTimestampCommand = ReactiveCommand.CreateAsyncObservable(o =>
            {
                var val = (bool)o;
                DateTime now = DateTime.Now;
                if (val)
                {
                    if (now.Second % 2 == 0)
                    {
                        CheckedTimeStamp += "Checked at " + now.ToString() + "\r\n";
                    }
                    else
                    {
                        CheckedTimeStamp += "Error at " + now.ToString() + "\r\n";
                        this.CheckedValue = false;
                    }
                }
                else
                {
                    CheckedTimeStamp += "Unchecked at " + now.ToString() + "\r\n";
                }
                return Observable.Return<object>(null);
            });

        }

        bool _checkedValue;
        public bool CheckedValue
        {
            get { return _checkedValue; }
            private set { this.RaiseAndSetIfChanged(ref _checkedValue, value); }
        }

        string _checkedTimeStamp;
        public string CheckedTimeStamp
        {
            get { return _checkedTimeStamp; }
            private set { this.RaiseAndSetIfChanged(ref _checkedTimeStamp, value); }
        }

        public ReactiveCommand<object> UpdateTimestampCommand { get; private set; }
    }
}
