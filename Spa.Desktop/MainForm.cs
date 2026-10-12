using System.Windows.Forms;

public class MainForm : Form
{
    public MainForm()
    {
        Text="Spa Reserva - Administración";
        Width=1100; Height=700;
        var title=new Label{Text="PANEL DE ADMINISTRACIÓN DEL SPA",Dock=DockStyle.Top,Height=60,Font=new System.Drawing.Font("Segoe UI",18,System.Drawing.FontStyle.Bold),TextAlign=System.Drawing.ContentAlignment.MiddleCenter};
        var menu=new FlowLayoutPanel{Dock=DockStyle.Left,Width=220,FlowDirection=FlowDirection.TopDown};
        foreach(var name in new[]{"Reservas","Clientes","Servicios","Profesionales","Pagos","Reportes","Configuración"})
        { var b=new Button{Text=name,Width=190,Height=45,Margin=new Padding(10)}; menu.Controls.Add(b); }
        var info=new Label{Text="Conecta este panel con la API del proyecto para administrar las reservas online.",Dock=DockStyle.Fill,TextAlign=System.Drawing.ContentAlignment.MiddleCenter};
        Controls.Add(info); Controls.Add(menu); Controls.Add(title);
    }
}
