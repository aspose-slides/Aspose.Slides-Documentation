---
title: Absatzbegrenzungen aus Präsentationen in .NET abrufen
linktitle: Absatzbegrenzungen
type: docs
weight: 43
url: /de/net/paragraph-bounds/
keywords:
- Absatzbegrenzungen
- Absatzkoordinate
- Absatzgröße
- Textfeld
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Absatzbegrenzungen in Aspose.Slides für .NET abrufen, um die Textpositionierung in PowerPoint-Präsentationen zu optimieren."
---
## **Übersicht**

Dieser Artikel erklärt, wie man die Begrenzungen, die Größe und die Koordinaten von Absätzen in Aspose.Slides ermittelt. Er zeigt, wie man ein Absatzrechteck aus einem [ITextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/) mithilfe von [IParagraph.GetRect](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraph/getrect/) abruft, wie man Absatzkoordinaten in einem Textframe einer Tabellenzelle erhält und hebt wichtige Details hervor, wie Maßeinheiten, den Einfluss von Textumbruch auf die Begrenzungen, die Pixelumrechnung und die effektiven Absatzformatierungswerte.

## **Rechteckige Koordinaten eines Absatzes**

Verwenden Sie [IParagraph.GetRect](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraph/getrect/), um das Begrenzungsrechteck eines Absatzes zu erhalten.

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];
var paragraph = shape.TextFrame.Paragraphs[0];
var rectangle = paragraph.GetRect();
```

## **Größe eines Absatzes innerhalb eines TextFrames einer Tabellenzelle ermitteln**

Um die Größe und die Koordinaten eines [IParagraph](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraph/) in einem TextFrame einer Tabellenzelle zu erhalten, verwenden Sie [IParagraph.GetRect](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraph/getrect/). Das zurückgegebene Rechteck ist relativ zum TextFrame der Tabellenzelle, sodass Sie die Tabellenposition und den Zellversatz hinzufügen müssen, wenn Sie Folien‑Ebene‑Koordinaten benötigen.

Das folgende Beispiel ermittelt die Absatzbegrenzungen innerhalb einer Tabellenzelle und zeichnet Rechtecke auf der Folie, um diese Begrenzungen zu visualisieren:

```csharp
using var presentation = new Presentation("source.pptx");
var slide = presentation.Slides[0];
var table = (ITable)slide.Shapes[0];
var cell = table.Rows[1][1];

var cellX = table.X + cell.OffsetX;
var cellY = table.Y + cell.OffsetY;

foreach (var paragraph in cell.TextFrame.Paragraphs)
{
    if (string.IsNullOrEmpty(paragraph.Text))
        continue;

    var paragraphRectangle = paragraph.GetRect();
    var paragraphRectangleX = paragraphRectangle.X + (float)cellX;
    var paragraphRectangleY = paragraphRectangle.Y + (float)cellY;

    var paragraphBoundsShape = presentation.Slides[0].Shapes.AddAutoShape(
        ShapeType.Rectangle,
        paragraphRectangleX,
        paragraphRectangleY,
        paragraphRectangle.Width,
        paragraphRectangle.Height);

    paragraphBoundsShape.FillFormat.FillType = FillType.NoFill;
    paragraphBoundsShape.LineFormat.FillFormat.SolidFillColor.Color = Color.Yellow;
    paragraphBoundsShape.LineFormat.FillFormat.FillType = FillType.Solid;
}

presentation.Save("output.pptx", SaveFormat.Pptx);
```

## **FAQ**

**In welchen Einheiten werden die Absatzkoordinaten gemessen?**

Sie werden in Punkten gemessen, wobei 1 Zoll 72 Punkten entspricht. Dies gilt für alle Koordinaten und Abmessungen auf der Folie.

**Beeinflusst der Textumbruch die Begrenzungen eines Absatzes?**

Ja. Wenn [TextFrameFormat.WrapText](https://reference.aspose.com/slides/de/net/aspose.slides/textframeformat/wraptext/) für das [ITextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/) aktiviert ist, wird der Text so umbrochen, dass er in die Breite des Bereichs passt, was die tatsächlichen Begrenzungen des Absatzes ändert.

**Können Absatzkoordinaten zuverlässig in Pixel im exportierten Bild umgerechnet werden?**

Ja. Konvertieren Sie Punkte mit folgender Formel in Pixel: pixel = punkt × (DPI / 72). Das Ergebnis hängt vom für die Darstellung oder den Export gewählten DPI ab.

**Wie erhalte ich die „effektiven“ Absatzformatierungsparameter unter Berücksichtigung der Stilvererbung?**

Verwenden Sie die [effective paragraph formatting data structure](/slides/de/net/shape-effective-properties/); sie liefert die endgültigen zusammengefassten Werte für Einzüge, Abstand, Umbruch, Rechts‑zu‑Links und mehr.