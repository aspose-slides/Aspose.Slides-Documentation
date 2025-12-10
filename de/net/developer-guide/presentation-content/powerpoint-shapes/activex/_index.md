---
title: ActiveX-Steuerelemente in Präsentationen in .NET verwalten
linktitle: ActiveX
type: docs
weight: 80
url: /de/net/activex/
keywords:
- ActiveX
- ActiveX-Steuerelement
- ActiveX verwalten
- ActiveX hinzufügen
- ActiveX ändern
- Medien-Player
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für .NET ActiveX nutzt, um PowerPoint-Präsentationen zu automatisieren und zu verbessern, und Entwicklern eine leistungsstarke Kontrolle über Folien bietet."
---

ActiveX‑Steuerelemente werden in Präsentationen verwendet. Aspose.Slides für .NET ermöglicht das Verwalten von ActiveX‑Steuerelementen, aber deren Verwaltung ist etwas kniffliger und unterscheidet sich von normalen Präsentationsformen. Ab Aspose.Slides für .NET 6.9.0 unterstützt die Komponente die Verwaltung von ActiveX‑Steuerelementen. Derzeit können Sie bereits hinzugefügte ActiveX‑Steuerelemente in Ihrer Präsentation zugreifen und sie mithilfe ihrer verschiedenen Eigenschaften ändern oder löschen. Denken Sie daran, dass ActiveX‑Steuerelemente keine Formen sind und nicht Teil der IShapeCollection der Präsentation, sondern einer separaten IControlCollection sind. Dieser Artikel zeigt, wie man mit ihnen arbeitet.

## **ActiveX‑Steuerelemente ändern**
Um ein einfaches ActiveX‑Steuerelement wie ein Textfeld und eine einfache Schaltfläche auf einer Folie zu verwalten:

1. Erstellen Sie eine Instanz der Klasse Presentation und laden Sie die Präsentation, die ActiveX‑Steuerelemente enthält.  
2. Holen Sie sich eine Folienreferenz anhand ihres Index.  
3. Greifen Sie über die IControlCollection auf die ActiveX‑Steuerelemente in der Folie zu.  
4. Greifen Sie mit dem ControlEx‑Objekt auf das ActiveX‑Steuerelement TextBox1 zu.  
5. Ändern Sie die verschiedenen Eigenschaften des ActiveX‑Steuerelements TextBox1, einschließlich Text, Schriftart, Schriftgrad und Rahmenposition.  
6. Greifen Sie auf das zweite Zugriffssteuerelement mit dem Namen CommandButton1 zu.  
7. Ändern Sie die Beschriftung, Schriftart und Position der Schaltfläche.  
8. Verschieben Sie die Position der Rahmen der ActiveX‑Steuerelemente.  
9. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.

Der Codeabschnitt unten aktualisiert die ActiveX‑Steuerelemente auf den Präsentationsfolien wie unten gezeigt.
```c#
// Zugriff auf die Präsentation mit ActiveX-Steuerelementen
Presentation presentation = new Presentation("ActiveX.pptm");

// Zugriff auf die erste Folie in der Präsentation
ISlide slide = presentation.Slides[0];

// Text des Textfelds ändern
IControl control = slide.Controls[0];

if (control.Name == "TextBox1" && control.Properties != null)
{
    string newText = "Changed text";
    control.Properties["Value"] = newText;

    // Ersatzbild ändern. PowerPoint ersetzt dieses Bild während der ActiveX-Aktivierung, sodass es manchmal in Ordnung ist, das Bild unverändert zu lassen.

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

// Schaltflächenbeschriftung ändern
control = slide.Controls[1];

if (control.Name == "CommandButton1" && control.Properties != null)
{
    String newCaption = "MessageBox";
    control.Properties["Caption"] = newCaption;

    // Ersatz ändern
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

// ActiveX-Rahmen 100 Punkte nach unten verschieben
foreach (Control ctl in slide.Controls)
{
    IShapeFrame frame = control.Frame;
    control.Frame = new ShapeFrame(
        frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

// Präsentation mit bearbeiteten ActiveX-Steuerelementen speichern
presentation.Save("withActiveX-edited_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);


// Steuerelemente jetzt entfernen
slide.Controls.Clear();

// Präsentation mit gelöschten ActiveX-Steuerelementen speichern
presentation.Save("withActiveX.cleared_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
```


## **Ein ActiveX Media Player‑Steuerelement hinzufügen**
1. Erstellen Sie eine Instanz der Klasse Presentation und laden Sie die Beispielpräsentation, die Media Player ActiveX‑Steuerelemente enthält.  
2. Erstellen Sie eine Instanz der Ziel‑Presentation‑Klasse und erzeugen Sie eine leere Präsentationsinstanz.  
3. Klonen Sie die Folie mit dem Media Player ActiveX‑Steuerelement aus der Vorlagenpräsentation in die Zielpräsentation.  
4. Greifen Sie auf die geklonte Folie in der Zielpräsentation zu.  
5. Greifen Sie über die IControlCollection auf die ActiveX‑Steuerelemente in der Folie zu.  
6. Greifen Sie auf das Media Player ActiveX‑Steuerelement zu und setzen Sie den Videopfad über seine Eigenschaften.  
7. Speichern Sie die Präsentation als PPTX‑Datei.
```c#
// Präsentationsklasse instanziieren, die die PPTX-Datei repräsentiert
Presentation presentation = new Presentation("template.pptx");

// Leere Präsentationsinstanz erstellen
Presentation newPresentation = new Presentation();

// Standardfolie entfernen
newPresentation.Slides.RemoveAt(0);

// Folie mit Media Player ActiveX-Steuerelement klonen
newPresentation.Slides.InsertClone(0, presentation.Slides[0]);

// Auf das Media Player ActiveX-Steuerelement zugreifen und den Videopfad setzen
newPresentation.Slides[0].Controls[0].Properties["URL"] = "Wildlife.mp4";

// Präsentation speichern
newPresentation.Save("LinkingVideoActiveXControl_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **FAQ**

**Behält Aspose.Slides ActiveX‑Steuerelemente bei, wenn sie beim Lesen und erneuten Speichern nicht in der .NET‑Laufzeit ausgeführt werden können?**  
Ja. Aspose.Slides behandelt sie als Teil der Präsentation und kann ihre Eigenschaften und Rahmen lesen/ändern; die Ausführung der Steuerelemente selbst ist nicht erforderlich, um sie zu erhalten.

**Wie unterscheiden sich ActiveX‑Steuerelemente von OLE‑Objekten in einer Präsentation?**  
ActiveX‑Steuerelemente sind interaktive verwaltete Steuerelemente (Schaltflächen, Textfelder, Media Player), während [OLE](/slides/de/net/manage-ole/) sich auf eingebettete Anwendungsobjekte (z. B. ein Excel‑Arbeitsblatt) bezieht. Sie werden anders gespeichert und verarbeitet und besitzen unterschiedliche Property‑Modelle.

**Funktionieren ActiveX‑Ereignisse und VBA‑Makros, wenn die Datei von Aspose.Slides geändert wurde?**  
Aspose.Slides bewahrt das vorhandene Markup und die Metadaten; jedoch werden Ereignisse und Makros nur innerhalb von PowerPoint unter Windows ausgeführt, sofern die Sicherheit es zulässt. Die Bibliothek führt kein VBA aus.