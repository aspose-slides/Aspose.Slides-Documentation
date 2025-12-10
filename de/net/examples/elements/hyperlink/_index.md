---
title: Hyperlink
type: docs
weight: 130
url: /de/net/examples/elements/hyperlink/
keywords:
- Hyperlink-Beispiel
- Hyperlink hinzufügen
- Hyperlink abrufen
- Hyperlink entfernen
- Hyperlink aktualisieren
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Hyperlinks in C# mit Aspose.Slides hinzufügen, bearbeiten und entfernen: Text verknüpfen, Formen, Folien, URLs und E-Mails; Ziele und Aktionen für PPT, PPTX und ODP festlegen."
---

Demonstriert das Hinzufügen, Zugreifen, Entfernen und Aktualisieren von Hyperlinks in Formen mithilfe von **Aspose.Slides for .NET**.

## **Hyperlink hinzufügen**

Erstelle eine Rechteckform mit einem Hyperlink, der auf eine externe Website verweist.
```csharp
static void Add_Hyperlink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");
}
```


## **Hyperlink zugreifen**

Lese Hyperlink‑Informationen aus einem Textsegment einer Form.
```csharp
static void Access_Hyperlink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    var hyperlink = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick;
}
```


## **Hyperlink entfernen**

Entferne den Hyperlink aus dem Text einer Form.
```csharp
static void Remove_Hyperlink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";
    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick = null;
}
```


## **Hyperlink aktualisieren**

Ändere das Ziel eines bestehenden Hyperlinks. Verwende `HyperlinkManager`, um Text, der bereits einen Hyperlink enthält, zu bearbeiten, was dem sicheren Aktualisieren von Hyperlinks in PowerPoint entspricht.
```csharp
static void Update_Hyperlink()
{
    using var pres = new Presentation();
    var slide = pres.Slides[0];
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";
    var portion = shape.TextFrame.Paragraphs[0].Portions[0];
    portion.PortionFormat.HyperlinkClick = new Hyperlink("https://old.example.com");

    // Das Ändern eines Hyperlinks im vorhandenen Text sollte über
    // HyperlinkManager erfolgen, anstatt die Eigenschaft direkt zu setzen.
    // Dies ahmt nach, wie PowerPoint Hyperlinks sicher aktualisiert.
    portion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://new.example.com");
}
```
