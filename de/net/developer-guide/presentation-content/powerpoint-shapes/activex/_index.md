---
title: Verwalten von ActiveX-Steuerelementen in Präsentationen in .NET
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
- Media Player
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Aspose.Slides für .NET ActiveX nutzt, um PowerPoint-Präsentationen zu automatisieren und zu verbessern, und Entwicklern eine leistungsstarke Kontrolle über Folien bietet."
---

ActiveX‑Steuerelemente werden in Präsentationen verwendet. Aspose.Slides für .NET ermöglicht die Verwaltung von ActiveX‑Steuerelementen, jedoch ist deren Verwaltung etwas komplizierter und unterscheidet sich von normalen Präsentationsformen. Ab Aspose.Slides für .NET 6.9.0 unterstützt die Komponente die Verwaltung von ActiveX‑Steuerelementen. Derzeit können Sie bereits hinzugefügte ActiveX‑Steuerelemente in Ihrer Präsentation über deren verschiedene Eigenschaften zugreifen und sie ändern oder löschen. Beachten Sie, dass ActiveX‑Steuerelemente keine Formen sind und nicht Teil der IShapeCollection der Präsentation, sondern einer separaten IControlCollection sind. Dieser Artikel zeigt, wie man mit ihnen arbeitet.

## **ActiveX-Steuerelemente ändern**

Um ein einfaches ActiveX‑Steuerelement wie ein Textfeld und eine einfache Befehltaste auf einer Folie zu verwalten:

1. Erstellen Sie eine Instanz der Presentation‑Klasse und laden Sie die Präsentation, die ActiveX‑Steuerelemente enthält.  
2. Holen Sie eine Folienreferenz anhand ihres Index.  
3. Greifen Sie über die IControlCollection auf die ActiveX‑Steuerelemente in der Folie zu.  
4. Greifen Sie mit dem ControlEx‑Objekt auf das ActiveX‑Steuerelement TextBox1 zu.  
5. Ändern Sie die verschiedenen Eigenschaften des ActiveX‑Steuerelements TextBox1, einschließlich Text, Schriftart, Schriftgröße und Rahmenposition.  
6. Greifen Sie auf das zweite Steuerelement mit dem Namen CommandButton1 zu.  
7. Ändern Sie die Beschriftung, Schriftart und Position der Schaltfläche.  
8. Verschieben Sie die Position der Rahmen der ActiveX‑Steuerelemente.  
9. Schreiben Sie die modifizierte Präsentation in eine PPTX‑Datei.

Das untenstehende Code‑Snippet aktualisiert die ActiveX‑Steuerelemente auf den Präsentationsfolien wie unten gezeigt.
```c#
// Zugriff auf die Präsentation mit ActiveX-Steuerelementen
Presentation presentation = new Presentation("ActiveX.pptm");

// Zugriff auf die erste Folie in der Präsentation
ISlide slide = presentation.Slides[0];

// Ändern des TextBox-Textes
IControl control = slide.Controls[0];

if (control.Name == "TextBox1" && control.Properties != null)
{
    string newText = "Changed text";
    control.Properties["Value"] = newText;

    // Ändern des Ersatzbildes. PowerPoint ersetzt dieses Bild während der ActiveX-Aktivierung, sodass es manchmal in Ordnung ist, das Bild unverändert zu lassen.

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
    String newCaption = "MessageBox";
    control.Properties["Caption"] = newCaption;

    // Ändern des Ersatzbildes
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

// Verschieben der ActiveX-Frames um 100 Punkte nach unten
foreach (Control ctl in slide.Controls)
{
    IShapeFrame frame = control.Frame;
    control.Frame = new ShapeFrame(
        frame.X, frame.Y + 100, frame.Width, frame.Height, frame.FlipH, frame.FlipV, frame.Rotation);
}

// Speichern der Präsentation mit bearbeiteten ActiveX-Steuerelementen
presentation.Save("withActiveX-edited_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);


// Jetzt werden die Steuerelemente entfernt
slide.Controls.Clear();

// Speichern der Präsentation mit gelöschten ActiveX-Steuerelementen
presentation.Save("withActiveX.cleared_out.pptm", Aspose.Slides.Export.SaveFormat.Pptm);
```


## **ActiveX‑Media‑Player‑Steuerelement hinzufügen**

Um ein ActiveX‑Media‑Player‑Steuerelement hinzuzufügen, führen Sie die folgenden Schritte aus:

1. Erstellen Sie eine Instanz der Presentation‑Klasse und laden Sie die Beispielpräsentation, die Media‑Player‑ActiveX‑Steuerelemente enthält.  
2. Erstellen Sie eine Instanz der Ziel‑Presentation‑Klasse und erzeugen Sie eine leere Präsentationsinstanz.  
3. Klonen Sie die Folie mit dem Media‑Player‑ActiveX‑Steuerelement aus der Vorlagenpräsentation in die Ziel‑Presentation.  
4. Greifen Sie auf die geklonte Folie in der Ziel‑Presentation zu.  
5. Greifen Sie über die IControlCollection auf die ActiveX‑Steuerelemente in der Folie zu.  
6. Greifen Sie auf das Media‑Player‑ActiveX‑Steuerelement zu und setzen Sie den Videopfad über seine Eigenschaften.  
7. Speichern Sie die Präsentation in einer PPTX‑Datei.
```c#
// Instanziiere die Presentation-Klasse, die die PPTX-Datei darstellt
Presentation presentation = new Presentation("template.pptx");

// Erstelle eine leere Präsentationsinstanz
Presentation newPresentation = new Presentation();

// Entferne die Standardsfolie
newPresentation.Slides.RemoveAt(0);

// Klone die Folie mit dem Media Player ActiveX-Steuerelement
newPresentation.Slides.InsertClone(0, presentation.Slides[0]);

// Greife auf das Media Player ActiveX-Steuerelement zu und setze den Videopfad
newPresentation.Slides[0].Controls[0].Properties["URL"] = "Wildlife.mp4";

// Speichere die Präsentation
newPresentation.Save("LinkingVideoActiveXControl_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **FAQ**

**Behält Aspose.Slides ActiveX‑Steuerelemente beim Lesen und erneuten Speichern bei, wenn sie in der Python‑Laufzeit nicht ausgeführt werden können?**  
Ja. Aspose.Slides behandelt sie als Teil der Präsentation und kann ihre Eigenschaften und Rahmen lesen/ändern; das Ausführen der Steuerelemente selbst ist nicht erforderlich, um sie beizubehalten.

**Wie unterscheiden sich ActiveX‑Steuerelemente von OLE‑Objekten in einer Präsentation?**  
ActiveX‑Steuerelemente sind interaktive, verwaltete Steuerelemente (Schaltflächen, Textfelder, Media‑Player), während [OLE](/slides/de/net/manage-ole/) auf eingebettete Anwendungsobjekte (zum Beispiel ein Excel‑Arbeitsblatt) verweist. Sie werden anders gespeichert und verarbeitet und besitzen unterschiedliche Property‑Modelle.

**Funktionieren ActiveX‑Ereignisse und VBA‑Makros, wenn die Datei von Aspose.Slides geändert wurde?**  
Aspose.Slides bewahrt das vorhandene Markup und die Metadaten; jedoch werden Ereignisse und Makros nur in PowerPoint unter Windows ausgeführt, wenn die Sicherheitseinstellungen dies zulassen. Die Bibliothek führt kein VBA aus.