using Barkfors_Kodtest.VehicleFolder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Barkfors_Kodtest
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public Vehicle CreatedVehicle { get; private set; }

        public AddWindow()
        {
            InitializeComponent();

            FillWithEnum(BrandBox, typeof(Brands), typeof(ComboBoxItem));
            FillWithEnum(FuelBox, typeof(FuelTypes), typeof(ComboBoxItem));
            FillWithEnum(EquipmentBox, typeof(Equipment), typeof(CheckBox));
            PopulateColorBox();
        }

        private static void FillWithEnum(ComboBox box, Type items, Type itemType)
        {
            foreach (var item in Enum.GetValues(items))
            {
                object newItem = Activator.CreateInstance(itemType);
                
                if (itemType == typeof(ComboBoxItem) || itemType == typeof(CheckBox))
                    ((ContentControl)newItem).Content = item.ToString();

                box.Items.Add(newItem);
            }
            
            if (itemType == typeof(ComboBoxItem))
                box.SelectedIndex = 0;
        }

        private void PopulateColorBox()
        {
            MethodInfo[] allMethods = typeof(Color).GetMethods();
            List<MethodInfo> resultingInfos = new();

            foreach (MethodInfo info in allMethods)
                if (info.IsStatic && info.ReturnType == typeof(Color) && info.GetParameters().Length == 0)
                    resultingInfos.Add(info);

            foreach (MethodInfo info in resultingInfos)
            {
                string colorName = ((Color)info.Invoke(null, null)).Name;
                colorName = AddSpaceAtBigLetters(colorName);

                ComboBoxItem newItem = new();
                newItem.Content = colorName;
                _ = ColorBox.Items.Add(newItem);
            }

            ColorBox.SelectedIndex = 0;
        }

        private static string AddSpaceAtBigLetters(string theString)
        {
            StringBuilder res = new();
            res.Append(theString);

            for (int i = 1; i < res.Length; i++)
                if (char.IsUpper(res[i]))
                {
                    res = res.Insert(i, " ");
                    i++;
                }

            return res.ToString();
        }

        /***
         * Temporary solution to disallow changing selectedindex
         */
        private void EquipmentBox_DropDownClosed(object sender, EventArgs e)
        {
            EquipmentBox.SelectedIndex = -1;
        }

        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            Brands brand = (Brands)Enum.Parse(typeof(Brands), ((ComboBoxItem)BrandBox.SelectedItem).Content.ToString());
            FuelTypes types = (FuelTypes)Enum.Parse(typeof(FuelTypes), ((ComboBoxItem)FuelBox.SelectedItem).Content.ToString());

            IEnumerable<CheckBox> equipmentBoxes = EquipmentBox.Items.Cast<CheckBox>().Where(e => e.IsChecked == true);
            Equipment[] equipment = new Equipment[equipmentBoxes.Count()];

            for (int i = 0; i < equipmentBoxes.Count(); i++)
                equipment[i] = (Equipment)Enum.Parse(typeof(Equipment), equipmentBoxes.ElementAt(i).Content.ToString());

            CreatedVehicle = new(ModelNameBox.Text, brand, types, ((ComboBoxItem)ColorBox.SelectedItem).Content.ToString(), equipment);

            Close();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Hide();
        }
    }
}
