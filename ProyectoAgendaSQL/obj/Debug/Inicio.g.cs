﻿#pragma checksum "..\..\Inicio.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "CF835F8EBE011FE480A40023D6060889"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ProyectoAgendaSQL {
    
    
    /// <summary>
    /// Inicio
    /// </summary>
    public partial class Inicio : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\Inicio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ProyectoAgendaSQL.Inicio Bienvenida;
        
        #line default
        #line hidden
        
        
        #line 8 "..\..\Inicio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBoxItem itemInicio;
        
        #line default
        #line hidden
        
        
        #line 9 "..\..\Inicio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBoxItem itemAdmin;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\Inicio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBoxItem itemConsultas;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\Inicio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBoxItem itemEmpleado;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Inicio.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBoxItem CerrarSeción;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ProyectoAgendaSQL;component/inicio.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Inicio.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Bienvenida = ((ProyectoAgendaSQL.Inicio)(target));
            return;
            case 2:
            this.itemInicio = ((System.Windows.Controls.ListBoxItem)(target));
            return;
            case 3:
            this.itemAdmin = ((System.Windows.Controls.ListBoxItem)(target));
            
            #line 9 "..\..\Inicio.xaml"
            this.itemAdmin.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.itemAdmin_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 4:
            this.itemConsultas = ((System.Windows.Controls.ListBoxItem)(target));
            
            #line 10 "..\..\Inicio.xaml"
            this.itemConsultas.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.itemConsultas_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 5:
            this.itemEmpleado = ((System.Windows.Controls.ListBoxItem)(target));
            
            #line 11 "..\..\Inicio.xaml"
            this.itemEmpleado.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.itemEmpleado_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 6:
            this.CerrarSeción = ((System.Windows.Controls.ListBoxItem)(target));
            
            #line 12 "..\..\Inicio.xaml"
            this.CerrarSeción.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.CerrarSeción_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

