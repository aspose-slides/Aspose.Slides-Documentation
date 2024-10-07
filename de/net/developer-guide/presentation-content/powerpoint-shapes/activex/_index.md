---
title: ActiveX
type: docs
weight: 80
url: /net/activex/
keywords: "ActiveX, ActiveX-Steuerelemente, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Verwalten Sie ActiveX-Steuerelemente in PowerPoint-Präsentationen in C# oder .NET"
---

ActiveX-Steuerelemente werden in Präsentationen verwendet. Aspose.Slides für .NET ermöglicht es Ihnen, ActiveX-Steuerelemente zu verwalten, jedoch ist deren Verwaltung etwas kniffliger und unterscheidet sich von normalen Präsentationsformen. Ab Aspose.Slides für .NET 6.9.0 unterstützt die Komponente die Verwaltung von ActiveX-Steuerelementen. Im Moment können Sie bereits hinzugefügte ActiveX-Steuerelemente in Ihrer Präsentation abrufen und diese mit verschiedenen Eigenschaften ändern oder löschen. Denken Sie daran, dass ActiveX-Steuerelemente keine Formen sind und kein Teil der IShapeCollection der Präsentation, sondern Teil der separaten IControlCollection. Dieser Artikel zeigt, wie man mit ihnen arbeitet.
## **ActiveX-Steuerelemente ändern**
Um ein einfaches ActiveX-Steuerelement wie ein Textfeld und eine einfache Schaltfläche auf einer Folie zu verwalten:

1. Erstellen Sie eine Instanz der Präsentationsklasse und laden Sie die Präsentation mit ActiveX-Steuerelementen.
1. Erhalten Sie eine Folienreferenz nach ihrem Index.
1. Greifen Sie auf die ActiveX-Steuerelemente in der Folie zu, indem Sie auf die IControlCollection zugreifen.
1. Greifen Sie auf das ActiveX-Steuerelement TextBox1 unter Verwendung des ControlEx-Objekts zu.
1. Ändern Sie die verschiedenen Eigenschaften des ActiveX-Steuerelements TextBox1, einschließlich Text, Schriftart, Schriftgröße und Rahmenposition.
1. Greifen Sie auf das zweite Zugriffssteuerlement namens CommandButton1 zu.
1. Ändern Sie die Beschriftung der Schaltfläche, die Schriftart und die Position.
1. Verschieben Sie die Position der ActiveX-Steuerelementrahmen.
1. Schreiben Sie die bearbeitete Präsentation in eine PPTX-Datei.

Der folgende Code-Schnipsel aktualisiert die ActiveX-Steuerelemente auf den Präsentationsfolien wie unten gezeigt.

```c#
// Zugriff auf die Präsentation mit ActiveX-Steuerelementen
Presentation presentation = new Presentation("ActiveX.pptm");

// Zugriff auf die erste Folie in der Präsentation
ISlide slide = presentation.Slides[0];

// Ändern des Textfeldtextes
IControl control = slide.Controls[0];

if (control.Name == "TextBox1" && control.Properties != null)
{
    string newText = "Geänderter Text";
    control.Properties["Value"] = newText;

    // Ersetzen des Bildes. PowerPoint ersetzt dieses Bild während der ActiveX-Aktivierung, daher ist es manchmal in Ordnung, das Bild unverändert zu lassen.

    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Window));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    graphics.DrawString(newText, font, brush, 10, 4);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(
        pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);

    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[]
    {
            new System.Drawing.Point(1, image.Height - 1), new System.Drawing.Point(image.Width - 1, image.Height - 1),
            new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

// Ändern der Schaltflächenbeschriftung
control = slide.Controls[1];

if (control.Name == "CommandButton1" && control.Properties != null)
{
    String newCaption = "Nachrichtenfenster";
    control.Properties["Caption"] = newCaption;

    // Ersetzen des Bildes
    Bitmap image = new Bitmap((int)control.Frame.Width, (int)control.Frame.Height);
    Graphics graphics = Graphics.FromImage(image);
    Brush brush = new SolidBrush(Color.FromKnownColor(KnownColor.Control));
    graphics.FillRectangle(brush, 0, 0, image.Width, image.Height);
    brush.Dispose();
    System.Drawing.Font font = new System.Drawing.Font(control.Properties["FontName"], 14);
    brush = new SolidBrush(Color.FromKnownColor(KnownColor.WindowText));
    SizeF textSize = graphics.MeasureString(newCaption, font, int.MaxValue);
    graphics.DrawString(newCaption, font, brush, (image.Width - textSize.Width) / 2, (image.Height - textSize.Height) / 2);
    brush.Dispose();
    Pen pen = new Pen(Color.FromKnownColor(KnownColor.ControlLightLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height - 1), new System.Drawing.Point(0, 0), new System.Drawing.Point(image.Width - 1, 0) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlLight), 1);
    graphics.DrawLines(pen, new System.Drawing.Point[] { new System.Drawing.Point(1, image.Height - 2), new System.Drawing.Point(1, 1), new System.Drawing.Point(image.Width - 2, 1) });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDark), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[]
    {
        new System.Drawing.Point(1, image.Height - 1),
        new System.Drawing.Point(image.Width - 1, image.Height - 1),
        new System.Drawing.Point(image.Width - 1, 1)
    });
    pen.Dispose();
    pen = new Pen(Color.FromKnownColor(KnownColor.ControlDarkDark), 1);
    graphics.DrawLines(pen,new System.Drawing.Point[] { new System.Drawing.Point(0, image.Height), new System.Drawing.Point(image.Width, image.Height), new System.Drawing.Point(image.Width, 0) });
    pen.Dispose();
    graphics.Dispose();
    control.SubstitutePictureFormat.Picture.Image = presentation.Images.AddImage(image);
}

// Verschieben der ActiveX-Rahmen um 100 Punkte nach unten
foreach (Control ctl in slide.Controls)
{
    IShapeFrame frame = control.Frame;
    control.Frame = new ShapeFrame(
        frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

// Speichern der Präsentation mit bearbeiteten ActiveX-Steuerelementen
presentation.Save("withActiveX-edited_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);


// Entfernen von Steuerelementen
slide.Controls.Clear();

// Speichern der Präsentation mit bereinigten ActiveX-Steuerelementen
presentation.Save("withActiveX.cleared_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
```


## **ActiveX Media Player-Steuerelement hinzufügen**
Um ein ActiveX Media Player-Steuerelement hinzuzufügen, führen Sie bitte die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der Präsentationsklasse und laden Sie die Beispielpräsentation mit Media Player ActiveX-Steuerelementen.
1. Erstellen Sie eine Instanz der Ziel-Präsentationsklasse und generieren Sie eine leere Präsentationsinstanz.
1. Klonen Sie die Folie mit dem Media Player ActiveX-Steuerelement in der Vorlage in die Zielpräsentation.
1. Greifen Sie auf die geklonte Folie in der Zielpräsentation zu.
1. Greifen Sie auf die ActiveX-Steuerelemente in der Folie zu, indem Sie auf die IControlCollection zugreifen.
1. Greifen Sie auf das Media Player ActiveX-Steuerelement zu und setzen Sie den Videopfad mit seinen Eigenschaften.
1. Speichern Sie die Präsentation in einer PPTX-Datei.

```c#
// Instanziieren der Präsentationsklasse, die die PPTX-Datei repräsentiert
Presentation presentation = new Presentation("template.pptx");

// Erstellen einer leeren Präsentationsinstanz
Presentation newPresentation = new Presentation();

// Entfernen der Standardfolie
newPresentation.Slides.RemoveAt(0);

// Klonen der Folie mit dem Media Player ActiveX-Steuerelement
newPresentation.Slides.InsertClone(0, presentation.Slides[0]);

// Zugriff auf das Media Player ActiveX-Steuerelement und Setzen des Videopfads
newPresentation.Slides[0].Controls[0].Properties["URL"] = "Wildlife.mp4";

// Speichern der Präsentation
newPresentation.Save("LinkingVideoActiveXControl_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```