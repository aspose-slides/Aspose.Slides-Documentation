---
title: Hyperlink
type: docs
weight: 130
url: /de/net/examples/elements/hyperlink/
keywords:
- Hyperlink
- Hyperlink hinzufügen
- Zugriff auf Hyperlink
- Hyperlink entfernen
- Hyperlink aktualisieren
- Codebeispiel
- PowerPoint
- OpenDocument
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Hyperlinks in Aspose.Slides for .NET hinzufügen und verwalten: Text, Formen und Bilder verlinken, Ziele und Aktionen für PPT, PPTX und ODP mit C#‑Beispielen festlegen."
---
Dieser Artikel demonstriert das Hinzufügen, Zugreifen, Entfernen und Aktualisieren von Hyperlinks auf Formen mit **Aspose.Slides for .NET**.

## **Hyperlink hinzufügen**

Erstellen Sie eine Rechteckform mit einem Hyperlink, der auf eine externe Website verweist.

```csharp
static void AddHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");
}
```

## **Zugriff auf einen Hyperlink**

Lesen Sie Hyperlink-Informationen aus dem Textanteil einer Form.

```csharp
static void AccessHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    var hyperlink = shape.TextFrame.Paragraphs[0].Portions[0].PortionFormat.HyperlinkClick;
}
```

## **Hyperlink entfernen**

Entfernen Sie den Hyperlink aus dem Text einer Form.

```csharp
static void RemoveHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];

    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://www.aspose.com");

    textPortion.PortionFormat.HyperlinkClick = null;
}
```

## **Hyperlink aktualisieren**

Ändern Sie das Ziel eines bestehenden Hyperlinks. Verwenden Sie `HyperlinkManager`, um Text, der bereits einen Hyperlink enthält, zu bearbeiten, was dem sicheren Aktualisieren von Hyperlinks in PowerPoint entspricht.

```csharp
static void UpdateHyperlink()
{
    using var presentation = new Presentation();
    var slide = presentation.Slides[0];
    
    var shape = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 50, 50, 150, 50);
    shape.TextFrame.Text = "Aspose";

    var textPortion = shape.TextFrame.Paragraphs[0].Portions[0];
    textPortion.PortionFormat.HyperlinkClick = new Hyperlink("https://old.example.com");

    // Das Ändern eines Hyperlinks im bestehenden Text sollte über
    // HyperlinkManager erfolgen, anstatt die Eigenschaft direkt zu setzen.
    // Dies ahmt nach, wie PowerPoint Hyperlinks sicher aktualisiert.
    textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://new.example.com");
}
```