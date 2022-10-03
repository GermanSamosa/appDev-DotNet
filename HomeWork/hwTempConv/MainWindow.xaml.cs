using System.Windows;
using System.Windows.Controls;

namespace hwTempConv
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    internal class InputTemp
    {
        public InputTemp(float number, string standard)
        {
            Number = number;
            Standard = standard;
        }
        private float _number; //store data in unique variable
        public float Number
        {
            get { return _number; }
            set { _number = value; }

        }
        public string _stand;
        public string Standard
        {
            get { return _stand; }
            set { _stand = value; }
        }
    }

    internal class OutputTemp
    {
        public OutputTemp(float number, string standard)
        {
            Number = number;
            Standard = standard;
        }
        private float _number; //store data in unique variable
        public float Number
        {
            get { return _number; }
            set { _number = value; }

        }
        public string _stand;
        public string Standard
        {
            get { return _stand; }
            set { _stand = value; }
        }
    }
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        //input start
        private void InputSelected_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //input select
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //input textbox
        }
        //input end

        //output start
        private void OutputSelected_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //output select
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }


        //outputEnd
        public string Text { get; set; }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

                
            try

            {
float inputValue = float.Parse(InBox.Text);
                string inputStandard = InputSelected.Text;

                //float outputValue = float.Parse(OutBox.Text);
                string outputStandard = OutputSelected.Text;
               // InputTemp newInReq = new InputTemp(inputValue, inputStandard);
                //OutputTemp newOutReq = new OutputTemp(outputValue, outputStandard); //classes were useless

                if (!inputStandard.Equals(outputStandard))
                {
                    if (inputStandard.Length < outputStandard.Length)
                    {
                        float res = inputValue * (9 / 5) + 32;
                        MessageBox.Show(inputValue + " C is " + res + " F");

                    }
                    if ((inputStandard.StartsWith("F")) && (outputStandard.StartsWith("C")))
                    {
                        float res = (inputValue - 32) * 5 / 9;
                        MessageBox.Show(inputValue + " F is " + res + " C");
                    }
                }
                else
                {
                    MessageBox.Show(inputValue + " " +inputStandard + " to " + outputStandard+ " is still " +inputValue + " "+outputStandard );
                }
            }
            catch (System.FormatException)
            {
                MessageBox.Show("Please Input Numbers");

            }

        }


    }
}
