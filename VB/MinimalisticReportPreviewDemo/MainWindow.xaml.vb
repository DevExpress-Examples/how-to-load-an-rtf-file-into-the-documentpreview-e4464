﻿Imports Microsoft.VisualBasic
Imports System
Imports System.Windows
Imports DevExpress.Xpf.Core
Imports DevExpress.Xpf.Themes
Imports DevExpress.Xpf.Printing
Imports Microsoft.Win32
Imports System.IO
' ...

Namespace MinimalisticReportPreviewDemo
	''' <summary>
	''' Interaction logic for MainWindow.xaml
	''' </summary>
	Partial Public Class MainWindow
		Inherits Window
		Public Sub New()
			ThemeManager.ApplicationThemeName = "Office2007Silver"
			InitializeComponent()
		End Sub

		Private Sub ShowPreview(ByVal sender As Object, ByVal e As RoutedEventArgs)
			Dim ofd As New OpenFileDialog()
			If ofd.ShowDialog() = True Then
				Dim report As New Report()
				report.xrRichText1.Rtf = File.ReadAllText(ofd.FileName)
				Dim model As New XtraReportPreviewModel(report)
				Dim window As New DocumentPreviewWindow() With {.Model = model}
				report.CreateDocument(True)
				window.ShowDialog()
			End If
		End Sub

	End Class
End Namespace
