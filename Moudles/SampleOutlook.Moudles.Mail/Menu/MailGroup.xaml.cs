﻿using SampleOutlook.Business;
using SampleOutlook.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SampleOutlook.Moudles.Mail.Menu
{
    /// <summary>
    /// Interaction logic for MailGroup.xaml
    /// </summary>
    public partial class MailGroup : TabItem, IOutlookBarGroup
    {
        public MailGroup()
        {
            InitializeComponent();
        }

        public string DefaultNavigationPath
        {
            get
            {
                var item = _dataTree.SelectedItem;
                if(item != null)
                {
                    return ((NavigationItem)item).NavigationPath;
                }
                return "MailList";
            }
            
        }
    }
}
