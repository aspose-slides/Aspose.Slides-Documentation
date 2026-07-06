---
title: Textabschnittsgrenzen aus Präsentationen in .NET ermitteln
linktitle: Abschnittsgrenzen
type: docs
weight: 47
url: /de/net/portion-bounds/
keywords:
- Textabschnittsgrenzen
- Textabschnitt
- Textteil
- Textkoordinaten
- Textposition
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erfahren Sie, wie Sie Textabschnittsgrenzen in PowerPoint-Präsentationen mit Aspose.Slides für .NET abrufen."
---
## **Übersicht**

Ein Textabschnitt repräsentiert ein bestimmtes Fragment von Text innerhalb eines Absatzes und ermöglicht es Ihnen, mit diesem Fragment unabhängig vom umgebenden Inhalt zu arbeiten. In Aspose.Slides können Abschnitte verwendet werden, wenn Sie die Begrenzungen eines Textfragments ermitteln, die Formatierung nur für einen Teil eines Absatzes anwenden oder das Textverhalten auf einer detaillierteren Ebene steuern müssen.

Dieser Artikel zeigt, wie man das Begrenzungsrechteck eines Abschnitts mit [IPortion.GetRect](https://reference.aspose.com/slides/de/net/aspose.slides/iportion/getrect/) erhält. Er zeigt außerdem, wie man die Koordinaten des Beginns eines Abschnitts mit [IPortion.GetCoordinates](https://reference.aspose.com/slides/de/net/aspose.slides/iportion/getcoordinates/) abruft. Zusätzlich werden gängige szenarienbezogene Anwendungsfälle erläutert, wie das Anwenden eines Hyperlinks auf ein einzelnes Textfragment, das Verständnis der Auflösung von Formatierungen über Abschnitt, Absatz, Textfeld und Themenvererbung sowie der Umgang mit Fällen, in denen eine angegebene Schriftart nicht verfügbar ist.

## **Grenzrechteck eines Textabschnitts ermitteln**

Verwenden Sie [IPortion.GetRect](https://reference.aspose.com/slides/de/net/aspose.slides/iportion/getrect/), um das Begrenzungsrechteck eines Textabschnitts abzurufen:

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var rectangle = portion.GetRect();
        Console.WriteLine($"X = {rectangle.X}; Y = {rectangle.Y}; Width = {rectangle.Width}; Height = {rectangle.Height}");
    }
}
```

## **Koordinaten eines Textabschnitts ermitteln**

Verwenden Sie [IPortion.GetCoordinates](https://reference.aspose.com/slides/de/net/aspose.slides/iportion/getcoordinates/), um die Koordinaten des Beginns eines Textabschnitts abzurufen:

```csharp
using var presentation = new Presentation("Shapes.pptx");
var slide = presentation.Slides[0];
var shape = (IAutoShape)slide.Shapes[0];

foreach (var paragraph in shape.TextFrame.Paragraphs)
{
    foreach (var portion in paragraph.Portions)
    {
        var point = portion.GetCoordinates();
        Console.WriteLine($"X = {point.X}; Y = {point.Y}");
    }
}
```

## **FAQ**

**Kann ich einen Hyperlink nur auf einen Teil des Textes in einem einzelnen Absatz anwenden?**

Ja, Sie können einem einzelnen Abschnitt einen [einen Hyperlink zuweisen](/slides/de/net/manage-hyperlinks/) ; nur dieses Fragment ist anklickbar, nicht der gesamte Absatz.

**Wie funktioniert die Stilvererbung: Was überschreibt ein Abschnitt und was wird von einem Absatz oder Textfeld übernommen?**

Eigenschaften auf Abschnittsebene haben die höchste Priorität. Ist eine Eigenschaft nicht am [IPortion](https://reference.aspose.com/slides/de/net/aspose.slides/iportion/) gesetzt, übernimmt Aspose.Slides sie vom [IParagraph](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraph/). Ist sie dort ebenfalls nicht gesetzt, verwendet Aspose.Slides den Stil des [ITextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/) oder des [theme](https://reference.aspose.com/slides/de/net/aspose.slides.theme/theme/).

**Was passiert, wenn die für einen Abschnitt angegebene Schriftart auf dem Zielgerät oder Server fehlt?**

[Font substitution rules](/slides/de/net/font-selection-sequence/) gelten. Der Text kann umfließen: Metriken, Silbentrennung und Breite können sich ändern, was für eine genaue Positionierung wichtig ist.

**Kann ich die fülltransparenz oder einen Farbverlauf eines Abschnitts unabhängig vom Rest des Absatzes festlegen?**

Ja, Textfarbe, Füllung und Transparenz auf Ebene des [IPortion](https://reference.aspose.com/slides/de/net/aspose.slides/iportion/) können von benachbarten Fragmenten abweichen.