---
title: Textfelder in Präsentationen in .NET verwalten
linktitle: Textfeld verwalten
type: docs
weight: 20
url: /de/net/manage-textbox/
keywords:
- Textfeld
- Textrahmen
- Text hinzufügen
- Text aktualisieren
- Textfeld erstellen
- Textfeld prüfen
- Textspalte hinzufügen
- Hyperlink hinzufügen
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Textfelder in PowerPoint- und OpenDocument-Präsentationen mit Aspose.Slides für .NET erstellen, identifizieren, formatieren und aktualisieren."
---
## **Einführung**

In Aspose.Slides for .NET wird Folientext in Textrahmen gespeichert, die zu Formen gehören. Das [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/)‑Interface stellt die am häufigsten vorkommende texttragende Form dar und stellt ihren Text über die [IAutoShape.TextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/textframe/)‑Eigenschaft bereit.

{{% alert color="info" title="Note" %}}

Jede Auto‑Form implementiert [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/), aber nicht jede Form ist eine Auto‑Form oder unterstützt einen Textrahmen. Beim Verarbeiten einer vorhandenen Präsentation prüfen Sie, ob eine Form `IAutoShape` implementiert, bevor Sie auf ihren Text zugreifen.

{{% /alert %}}

## **Eine Textbox auf einer Folie erstellen**

Um eine Textbox zu erstellen, fügen Sie einer Folie eine Auto‑Form hinzu, fügen Sie ihrem Textrahmen Text hinzu und speichern Sie die Präsentation. Das folgende Beispiel erzeugt eine rechteckige Textbox:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
textBox.AddTextFrame("Aspose TextBox");

presentation.Save("TextBox.pptx", SaveFormat.Pptx);
```

Die an [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addautoshape/) übergebenen Koordinaten und Abmessungen werden in Punkten angegeben. [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/addtextframe/) initialisiert den Textrahmen mit dem bereitgestellten Text.

## **Überprüfen, ob eine Form eine Textbox ist**

Verwenden Sie die [AutoShape.IsTextBox](https://reference.aspose.com/slides/net/aspose.slides/autoshape/istextbox/)‑Eigenschaft, um festzustellen, ob eine Auto‑Form als Textbox behandelt wird. Das ist nützlich, wenn eine Präsentation sowohl texttragende als auch rein grafische Auto‑Formen enthält.

![A text box and a shape](istextbox.png)

Das folgende Beispiel inspiziert jede Auto‑Form in einer Präsentation:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 120, 40);
textBox.AddTextFrame("Text box");
slide.Shapes.AddAutoShape(ShapeType.Ellipse, 150, 10, 40, 40);

foreach (var currentSlide in presentation.Slides)
{
    foreach (var shape in currentSlide.Shapes)
    {
        if (shape is IAutoShape autoShape)
        {
            Console.WriteLine(autoShape.IsTextBox ? "The shape is a text box." : "The shape is not a text box.");
        }
    }
}
```

Eine neu hinzugefügte Auto‑Form wird erst dann als Textbox betrachtet, wenn sie nicht‑leeren Text enthält. Sie können diesen Text über [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/addtextframe/) oder [ITextFrame.Text](https://reference.aspose.com/slides/net/aspose.slides/itextframe/text/) bereitstellen. Das Hinzufügen oder Zuweisen einer leeren Zeichenfolge lässt `IsTextBox` auf `false` gesetzt:

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var shape1 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 10, 100, 40);
shape1.AddTextFrame("Shape 1");
Console.WriteLine(shape1.IsTextBox);

var shape2 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 70, 100, 40);
shape2.TextFrame.Text = "Shape 2";
Console.WriteLine(shape2.IsTextBox);

var shape3 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 130, 100, 40);
shape3.AddTextFrame("");
Console.WriteLine(shape3.IsTextBox);

var shape4 = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 10, 190, 100, 40);
shape4.TextFrame.Text = "";
Console.WriteLine(shape4.IsTextBox);
```

Die ersten beiden Aufrufe geben `True` aus; die letzten beiden `False`.

## **Ermitteln der Form, die einen Textrahmen besitzt**

Generischer Text‑Verarbeitungscode kann ein [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) erhalten, ohne zu wissen, welches Präsentationsobjekt ihn enthält. Verwenden Sie die schreibgeschützte [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/)‑Eigenschaft, um zu seiner übergeordneten [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) zurückzuwandern.

Für einen Textrahmen, der einer Auto‑Form oder einer anderen texttragenden Form gehört, enthält `ParentShape` den Eigentümer und [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) ist `null`. Prüfen Sie den zurückgegebenen Wert, bevor Sie darauf zugreifen. Um sowohl Form‑ als auch Tabellenzellen‑Eigentümer zu identifizieren, einschließlich Formen, die mit SmartArt‑Knoten verknüpft sind, siehe [Search and Replace Text](/slides/de/net/search-and-replace-text/).

## **Abrufen des Textrechtecks der Form**

Ab Aspose.Slides for .NET 26.11 gibt [ITextFrame.GetTextRect](https://reference.aspose.com/slides/net/aspose.slides/itextframe/gettextrect/) das Text‑Gebiet zurück, das durch die Geometrie der übergeordneten Form definiert ist. Seine Koordinaten und Abmessungen werden in Punkten relativ zur oberen linken Ecke dieser Form angegeben. Zum Beispiel hat eine Ellipse ein kleineres Textrechteck als ihre äußeren Begrenzungen.

Dieses Rechteck beschreibt die Form, nicht die gerenderten Zeichen. Das Ändern des Textes oder der Text‑Rahmen‑Abstände verwandelt es nicht in ein Maß für belegten Text. Verwenden Sie [paragraph bounds](/slides/de/net/paragraph-bounds/) oder [portion bounds](/slides/de/net/portion-bounds/) für Messungen des gerenderten Textes.

Nach dem [installing Aspose.Slides for .NET](/slides/de/net/installation/) 26.11 oder höher führen Sie dieses Beispiel aus, um das Geometrie‑Textrechteck rot zu zeichnen. Die Formen sind nicht rotiert und nicht gruppiert, sodass das Hinzufügen ihrer X/Y‑Position ausreicht, um das Overlay auf der Folie zu platzieren.

```csharp
using System;
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

foreach (var shapeType in new[] { ShapeType.Rectangle, ShapeType.Ellipse })
{
    var x = shapeType == ShapeType.Rectangle ? 50 : 300;
    var shape = slide.Shapes.AddAutoShape(shapeType, x, 200, 200, 100);
    shape.AddTextFrame("Text area");
    var rectangle = shape.TextFrame.GetTextRect();
    Console.WriteLine($"{shapeType}: {rectangle}");

    var overlayX = shape.X + rectangle.X;
    var overlayY = shape.Y + rectangle.Y;
    var outline = slide.Shapes.AddAutoShape(ShapeType.Rectangle, overlayX, overlayY, rectangle.Width, rectangle.Height);
    outline.FillFormat.FillType = FillType.NoFill;
    outline.LineFormat.FillFormat.FillType = FillType.Solid;
    outline.LineFormat.FillFormat.SolidFillColor.Color = Color.Red;
}

presentation.Save("text-rectangles.pptx", SaveFormat.Pptx);
```

Für die oben gezeigten Formen von 200 × 100 Punkten liefert das Rechteck `(0, 0, 200, 100)`; die Ellipse liefert ungefähr `(29.289, 14.645, 141.421, 70.711)`. Die Methode liest zudem das deklarierte Textrechteck einer benutzerdefinierten Geometrie. Sie berücksichtigt keine Folien‑Rotation oder Gruppen‑Transformationen; diese müssen beim Positionieren eines Overlays separat beachtet werden. Ein Textrahmen ohne Geometrieform, wie ein Tabellenzellen‑Textrahmen, kann eine `InvalidOperationException` auslösen.

## **Spalten zu einer Textbox hinzufügen**

Die [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columncount/)‑Eigenschaft teilt den Textrahmen in Spalten, während [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columnspacing/) den Abstand zwischen den Spalten in Punkten festlegt. Beide Einstellungen gehören zu [ITextFrameFormat](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/) und können über den Textrahmen einer bestehenden Textbox geändert werden. Der Text fließt innerhalb derselben Form zwischen den Spalten um; er setzt nicht in eine andere Form fort.

Das folgende Beispiel erstellt eine dreispaltige Textbox mit 10 Punkten Abstand zwischen den Spalten, speichert die Präsentation und liest die gespeicherten Einstellungen aus der Ausgabedatei:

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 100, 100, 300, 200);
textBox.AddTextFrame("This text is distributed automatically across all columns in the text box.");

var textFrameFormat = textBox.TextFrame.TextFrameFormat;
textFrameFormat.ColumnCount = 3;
textFrameFormat.ColumnSpacing = 10;

presentation.Save("TextBoxColumns.pptx", SaveFormat.Pptx);

using var savedPresentation = new Presentation("TextBoxColumns.pptx");
var savedTextBox = (IAutoShape)savedPresentation.Slides[0].Shapes[0];
var savedFormat = savedTextBox.TextFrame.TextFrameFormat;
Console.WriteLine($"Columns: {savedFormat.ColumnCount}; spacing: {savedFormat.ColumnSpacing} points");
```

## **Text aus einzelnen Spalten extrahieren**

Verwenden Sie [TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/net/aspose.slides/textframe/splittextbycolumns/), um den jedem visuellen Spalteninhalt zugeordneten Text in einem bestehenden Textrahmen abzurufen. Die Methode gibt für jede Spalte einen String in spaltenbasierter Lesereihenfolge zurück. Ein einspaltiger Textrahmen liefert ein Array mit einem Element, und eine leere Spalte wird durch einen leeren String dargestellt. Die Strings enthalten ausschließlich Klartext; Formatierungen auf Portionsebene werden nicht beibehalten.

Das ist nützlich, wenn Sie:

- Text extrahieren und dabei seine spaltenbasierte Lesereihenfolge beibehalten möchten.
- Den Inhalt mehrspaltiger Folien indexieren oder vergleichen möchten.
- Jede Spalte in eine separate Datei, Datenbankfeld oder ein anderes Ziel exportieren möchten.
- Prüfen wollen, wie sich der Text nach Änderungen von [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columncount/), [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/net/aspose.slides/itextframeformat/columnspacing/), der Schriftart oder der Textrahmengröße verteilt.

Die Methode berichtet über den Text, der im aktuellen [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) verteilt ist; sie fließt nicht automatisch zwischen getrennten Formen oder Textboxen. Die Spaltenverteilung kann von verfügbaren Schriftarten und anderen Text‑Layout‑Einstellungen abhängen, daher sollten die erforderlichen Schriftarten vorhanden sein, wenn konsistente Ergebnisse wichtig sind.

Das folgende Beispiel lädt eine Präsentation, findet die erste mehrspaltige Auto‑Form mit Textrahmen, liest die konfigurierte Spaltenanzahl und schreibt den Text jeder Spalte in eine separate Datei. Formen, die keinen Textrahmen bereitstellen, werden übersprungen.

```csharp
using System;
using System.IO;
using Aspose.Slides;

using var presentation = new Presentation("MultiColumnText.pptx");

IAutoShape? textBox = null;
foreach (var shape in presentation.Slides[0].Shapes)
{
    if (shape is IAutoShape autoShape && autoShape.TextFrame is not null)
    {
        var columnCount = autoShape.TextFrame.TextFrameFormat.ColumnCount;
        if (columnCount > 1)
        {
            textBox = autoShape;
            break;
        }
    }
}

if (textBox is null)
{
    Console.WriteLine("No multi-column text frame was found.");
}
else
{
    var textFrame = textBox.TextFrame;
    var configuredColumnCount = textFrame.TextFrameFormat.ColumnCount;
    var columnTexts = textFrame.SplitTextByColumns();

    Console.WriteLine($"Configured columns: {configuredColumnCount}");

    for (var columnIndex = 0; columnIndex < columnTexts.Length; columnIndex++)
    {
        var columnNumber = columnIndex + 1;
        var columnText = columnTexts[columnIndex];
        Console.WriteLine($"Column {columnNumber}: {columnText}");
        File.WriteAllText($"Column-{columnNumber}.txt", columnText);
    }
}
```

## **Text aktualisieren**

Um Text in einer gesamten Präsentation zu aktualisieren, iterieren Sie über die Folien und Formen, wählen Auto‑Formen aus und bearbeiten deren Text‑Portionen. Das Arbeiten auf Portionsebene ermöglicht das Ändern sowohl des Textes als auch der Zeichenformatierung.

Das folgende Beispiel ersetzt jedes Vorkommen von `years` durch `months` im Text von Auto‑Formen und macht jede betroffene Portion fett:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("Text.pptx");

foreach (var slide in presentation.Slides)
{
    foreach (var shape in slide.Shapes)
    {
        if (shape is not IAutoShape autoShape)
        {
            continue;
        }

        foreach (var paragraph in autoShape.TextFrame.Paragraphs)
        {
            foreach (var portion in paragraph.Portions)
            {
                portion.Text = portion.Text.Replace("years", "months");
                portion.PortionFormat.FontBold = NullableBool.True;
            }
        }
    }
}

presentation.Save("TextChanged.pptx", SaveFormat.Pptx);
```

Diese Durchquerung aktualisiert Text nur in Auto‑Formen. Text, der in Tabellen, Diagrammen, SmartArt oder gruppierten Formen gespeichert ist, erfordert die Durchquerung der jeweiligen Objekt‑Sammlungen.

## **Eine Textbox mit Hyperlink hinzufügen**

Einem bestimmten Text­abschnitt kann ein Hyperlink zugewiesen werden, sodass nur dieser Text als anklickbarer Link fungiert. Verwenden Sie [IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), um den Abschnitt mit einer externen URL zu verknüpfen.

Das folgende Beispiel erstellt verlinkten Text und speichert ihn in einer Präsentation:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 150, 200, 50);
textBox.AddTextFrame("Aspose.Slides");

var textPortion = textBox.TextFrame.Paragraphs[0].Portions[0];
textPortion.PortionFormat.HyperlinkManager.SetExternalHyperlinkClick("https://www.aspose.com/");

presentation.Save("Hyperlink.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Was ist der Unterschied zwischen einer Textbox und einem Textplatzhalter auf einer Master‑ oder Layoutfolie?**

Ein [placeholder](/slides/de/net/manage-placeholder/) kann seine Position und Formatierung von einer [master slide](https://reference.aspose.com/slides/net/aspose.slides/masterslide/) oder [layout slide](https://reference.aspose.com/slides/net/aspose.slides/layoutslide/) erben. Eine reguläre Textbox ist eine eigenständige Form auf der Folie, auf der sie erstellt wurde, und übernimmt kein Platzhalter‑Verhalten, wenn das Layout geändert wird.

**Wie kann ich Text ersetzen, ohne Text in Diagrammen, Tabellen oder SmartArt zu ändern?**

Beschränken Sie die Durchquerung auf Formen, die [IAutoShape](https://reference.aspose.com/slides/net/aspose.slides/iautoshape/) implementieren, wie im Beispiel „Text aktualisieren“ gezeigt. Diagramme, Tabellen und SmartArt speichern Text in eigenen Objektmodellen, sodass sie von dieser Schleife nicht verändert werden.