﻿/*
 * Created by SharpDevelop.
 * User: Peter Forstmeier
 * Date: 12.01.2013
 * Time: 17:34
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

using ICSharpCode.SharpDevelop.Gui;
using ICSharpCode.SharpDevelop.Services;

namespace ICSharpCode.SharpDevelop.Gui.OptionPanels
{
	/// <summary>
	/// Interaction logic for DebuggingSymbolsPanelXaml.xaml
	/// </summary>
	public partial class DebuggingSymbolsPanelXaml : OptionPanel
	{
		public DebuggingSymbolsPanelXaml()
		{
			InitializeComponent();
			this.DataContext = this;
		}
		
		public override void LoadOptions()
		{
			base.LoadOptions();
			editor.LoadList(DebuggingOptions.Instance.SymbolsSearchPaths);
		}
		
		
		public override bool SaveOptions()
		{
			DebuggingOptions.Instance.SymbolsSearchPaths = editor.GetList();
			DebuggingOptions.ResetStatus(
				proc => {
					proc.Debugger.ReloadModuleSymbols();
					proc.Debugger.ResetJustMyCodeStatus();
				});
			return base.SaveOptions();
		}
	}
}