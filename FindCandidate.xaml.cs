﻿using BL;
using DAL.Models;
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
using System.Windows.Shapes;

namespace UI
{
    /// <summary>
    /// Interaction logic for FindCandidate.xaml
    /// </summary>
    public partial class FindCandidate : Window
    {
        private Dictionary<int, List<dynamic>> interviewsByCandidate;
        InterviewsMBL interviewsMBL;
        public FindCandidate()
        {
            interviewsMBL = new InterviewsMBL();

            InitializeComponent();

            interviewsByCandidate = interviewsMBL.GetInterviewsDetails();

            var candidate = interviewsMBL.GetNameCandidencies();
            ComboboxChooseCandidate.ItemsSource = candidate;
            ComboboxChooseCandidate.DisplayMemberPath = "Name";
            ComboboxChooseCandidate.SelectedValuePath = "Id";
        }

        private void ComboboxChooseCandidate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboboxChooseCandidate.SelectedValue is int selectedCandidateId)
            {
                // הצגת פרטי הראיונות עבור המועמד הנבחר
                var interviews = interviewsByCandidate.GetValueOrDefault(selectedCandidateId, new List<dynamic>());
                DataGridInterviews.ItemsSource = interviews;
            }
        }
        private void DataGridInterviews_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}