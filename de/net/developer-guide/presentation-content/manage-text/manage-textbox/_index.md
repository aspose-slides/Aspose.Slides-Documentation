---
title: Textfelder in Präsentationen mit .NET verwalten
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

In Aspose.Slides für .NET wird der Folientext in Textrahmen gespeichert, die zu Formen gehören. Das [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) Interface stellt die am häufigsten vorkommende texttragende Form dar und stellt ihren Text über die [IAutoShape.TextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/textframe/) Eigenschaft bereit.

{{% alert color="info" title="Note" %}}
Jede Autoform implementiert [IShape](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/), aber nicht jede Form ist eine Autoform oder unterstützt einen Textrahmen. Beim Verarbeiten einer vorhandenen Präsentation sollte geprüft werden, ob eine Form `IAutoShape` implementiert, bevor auf ihren Text zugegriffen wird.
{{% /alert %}}

## **Erstellen einer Textbox auf einer Folie**

Um eine Textbox zu erstellen, fügen Sie einer Folie eine Autoform hinzu, fügen Sie ihrem Textrahmen Text hinzu und speichern Sie die Präsentation. Das folgende Beispiel erstellt eine rechteckige Textbox:

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];
var textBox = slide.Shapes.AddAutoShape(ShapeType.Rectangle, 150, 75, 300, 50);
textBox.AddTextFrame("Aspose TextBox");

presentation.Save("TextBox.pptx", SaveFormat.Pptx);
```

Die an [IShapeCollection.AddAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/ishapecollection/addautoshape/) übergebenen Koordinaten und Abmessungen werden in Punkten gemessen. [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/addtextframe/) initialisiert den Textrahmen mit dem übergebenen Text.

## **Prüfen, ob eine Form eine Textbox ist**

Verwenden Sie die [AutoShape.IsTextBox](https://reference.aspose.com/slides/de/net/aspose.slides/autoshape/istextbox/) Eigenschaft, um festzustellen, ob eine Autoform als Textbox behandelt wird. Dies ist nützlich, wenn eine Präsentation sowohl texttragende als auch rein grafische Autoformen enthält.

![Eine Textbox und eine Form](istextbox.png)

Das folgende Beispiel untersucht jede Autoform in einer Präsentation:

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

Eine neu hinzugefügte Autoform wird erst dann als Textbox angesehen, wenn sie nicht leeren Text enthält. Sie können diesen Text über [IAutoShape.AddTextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/addtextframe/) oder [ITextFrame.Text](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/text/) bereitstellen. Das Hinzufügen oder Zuordnen eines leeren Strings lässt `IsTextBox` auf `false` setzen:

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

Die ersten beiden Aufrufe geben `True` aus; die letzten beiden geben `False` aus.

## **Die Form finden, die einen Textrahmen besitzt**

Allgemeiner Textverarbeitungscode kann ein [ITextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/) erhalten, ohne zu wissen, welches Präsentationsobjekt ihn enthält. Verwenden Sie die schreibgeschützte [ITextFrame.ParentShape](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/parentshape/) Eigenschaft, um zurück zu der zugehörigen [IShape](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/) zu navigieren.

Für einen Textrahmen, der einer Autoform oder einer anderen texttragenden Form gehört, enthält `ParentShape` den Besitzer und [ITextFrame.ParentCell](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/parentcell/) ist `null`. Prüfen Sie den zurückgegebenen Wert, bevor Sie darauf zugreifen. Um sowohl Form- als auch Tabellenzellenbesitzer zu identifizieren, einschließlich Formen, die zu SmartArt‑Knoten gehören, siehe [Search and Replace Text](/slides/de/net/search-and-replace-text/).

## **Spalten zu einer Textbox hinzufügen**

Die [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/de/net/aspose.slides/itextframeformat/columncount/) Eigenschaft teilt den Textrahmen in Spalten, während [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/de/net/aspose.slides/itextframeformat/columnspacing/) den Abstand zwischen den Spalten in Punkten festlegt. Beide Einstellungen gehören zu [ITextFrameFormat](https://reference.aspose.com/slides/de/net/aspose.slides/itextframeformat/) und können über den Textrahmen einer vorhandenen Textbox geändert werden. Der Text fließt zwischen den Spalten innerhalb derselben Form um; er wird nicht in eine andere Form fortgesetzt.

Das folgende Beispiel erstellt eine Textbox mit drei Spalten und einem Abstand von 10 Punkten zwischen den Spalten, speichert die Präsentation und liest die gespeicherten Einstellungen aus der Ausgabedatei zurück:

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

Verwenden Sie [TextFrame.SplitTextByColumns](https://reference.aspose.com/slides/de/net/aspose.slides/textframe/splittextbycolumns/), um den jedem visuellen Spaltenbereich zugeordneten Text in einem bestehenden Textrahmen abzurufen. Die Methode gibt für jede Spalte einen String zurück, in spaltenbasierter Lesereihenfolge. Ein einspaltiger Textrahmen liefert ein Array mit einem Element, und eine leere Spalte wird durch einen leeren String repräsentiert. Die Strings enthalten ausschließlich reinen Text; formatierungsbezogene Informationen auf Teilzeichenebene werden nicht beibehalten.

Dies ist nützlich, wenn Sie:
- Text extrahieren und dabei die spaltenbasierte Lesereihenfolge beibehalten möchten.
- Inhalte mehrspaltiger Folien indexieren oder vergleichen wollen.
- Jede Spalte in eine separate Datei, Datenbankfeld oder ein anderes Ziel exportieren möchten.
- Untersuchen wollen, wie sich Text nach dem Ändern von [ITextFrameFormat.ColumnCount](https://reference.aspose.com/slides/de/net/aspose.slides/itextframeformat/columncount/), [ITextFrameFormat.ColumnSpacing](https://reference.aspose.com/slides/de/net/aspose.slides/itextframeformat/columnspacing/), der Schriftart oder der Größe des Textrahmens umverteilt.

Die Methode gibt den Text zurück, der im aktuellen [ITextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/) verteilt ist; sie fließt nicht automatisch Text zwischen separaten Formen oder Textboxen. Die Spaltenverteilung kann von verfügbaren Schriftarten und anderen Textlayout‑Einstellungen abhängen, stellen Sie also sicher, dass die erforderlichen Schriftarten verfügbar sind, wenn konsistente Ergebnisse wichtig sind.

Das folgende Beispiel lädt eine Präsentation, findet die erste mehrspaltige Autoform mit einem Textrahmen, liest deren konfigurierten Spaltenzähler und schreibt den Text jeder Spalte in eine separate Datei. Formen, die keinen Textrahmen bereitstellen, werden übersprungen.

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

Um Text in einer gesamten Präsentation zu aktualisieren, iterieren Sie über die Folien und Formen, wählen Autoformen aus und bearbeiten dann deren Textteile. Das Arbeiten auf Teil‑Ebene ermöglicht das Ändern von Text und Zeichenformatierung.

Das folgende Beispiel ersetzt jedes Vorkommen von `years` durch `months` in Autoform‑Text und macht jeden betroffenen Teil fett:

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

Dieser Durchlauf aktualisiert Text nur in Autoformen. In Tabellen, Diagrammen, SmartArt oder Gruppierungen gespeicherter Text erfordert die Traversierung der jeweiligen Objektsammlungen.

## **Eine Textbox mit Hyperlink hinzufügen**

Einem bestimmten Textteil kann ein Hyperlink zugewiesen werden, sodass nur dieser Text als anklickbarer Link fungiert. Verwenden Sie [IHyperlinkManager.SetExternalHyperlinkClick](https://reference.aspose.com/slides/de/net/aspose.slides/ihyperlinkmanager/setexternalhyperlinkclick/), um den Teil mit einer externen URL zu verknüpfen.

Das folgende Beispiel erstellt verknüpften Text und speichert ihn in einer Präsentation:

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

**Was ist der Unterschied zwischen einer Textbox und einem Text‑Platzhalter auf einer Master‑ oder Layout‑Folie?**

Ein [placeholder](/slides/de/net/manage-placeholder/) kann seine Position und Formatierung von einer [master slide](https://reference.aspose.com/slides/de/net/aspose.slides/masterslide/) oder [layout slide](https://reference.aspose.com/slides/de/net/aspose.slides/layoutslide/) erben. Eine reguläre Textbox ist eine eigenständige Form auf der Folie, auf der sie erstellt wurde, und übernimmt kein Platzhalter‑Verhalten, wenn sich das Layout ändert.

**Wie kann ich Text ersetzen, ohne Text in Diagrammen, Tabellen oder SmartArt zu ändern?**

Begrenzen Sie die Traversierung auf Formen, die [IAutoShape](https://reference.aspose.com/slides/de/net/aspose.slides/iautoshape/) implementieren, wie im Beispiel „Text aktualisieren“ gezeigt. Diagramme, Tabellen und SmartArt speichern Text in eigenen Objektmodellen und werden durch diese Schleife nicht geändert.