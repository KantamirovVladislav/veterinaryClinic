﻿using System.Windows.Controls;
using veterinaryClinic.ViewModel;

namespace veterinaryClinic.ApplicationPages;

public partial class TablesPage : Page
{
    public TablesPage()
    {
        InitializeComponent();
        TeblesPageVM avm = new TeblesPageVM();
        DataContext = avm;
    }
}