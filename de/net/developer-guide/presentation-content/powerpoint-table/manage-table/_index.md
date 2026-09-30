---
title: Tabellen in Präsentationen mit .NET verwalten
linktitle: Tabelle verwalten
type: docs
weight: 10
url: /de/net/manage-table/
keywords:
- Tabelle hinzufügen
- Tabelle erstellen
- auf Tabelle zugreifen
- Seitenverhältnis
- Text ausrichten
- Textformatierung
- Tabellenstil
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Tabellen in PowerPoint-Folien mit Aspose.Slides für .NET erstellen und bearbeiten. Entdecken Sie einfache C#-Codebeispiele, um Ihre Tabellen-Workflows zu optimieren."
---
## **Einführung**

Tabellen in PowerPoint organisieren Informationen in Zeilen und Spalten, wodurch das Lesen und Vergleichen von Werten erleichtert wird.

Aspose.Slides stellt die Klasse [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) , das Interface [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) , die Klasse [Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/) , das Interface [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) und weitere Typen bereit, mit denen Sie Tabellen in Präsentationen erstellen, aktualisieren und verwalten können.

## **Erstellen einer Tabelle von Grund auf**

Erstellen Sie eine Tabelle, indem Sie ihre Position, Spaltenbreiten und Zeilenhöhen angeben. Nachdem Sie sie zu einer Folie hinzugefügt haben, können Sie Zellrahmen formatieren, Zellen zusammenführen und Text einfügen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Holen Sie sich eine Referenz auf die Folie anhand ihres Index.
3. Definieren Sie ein Array von Spaltenbreiten in Punkten.
4. Definieren Sie ein Array von Zeilenhöhen in Punkten.
5. Fügen Sie ein [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)‑Objekt über die Methode [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) zur Folie hinzu.
6. Durchlaufen Sie jede [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/), um die oberen, unteren, rechten und linken Rahmen zu formatieren.
7. Führen Sie die ersten beiden Zellen der ersten Zeile der Tabelle zusammen.
8. Greifen Sie über die Eigenschaft [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/) auf die zusammengeführte Zelle zu.
9. Setzen Sie den Text in der zusammengeführten Zelle.
10. Speichern Sie die geänderte Präsentation.

Das folgende Beispiel erstellt eine Tabelle mit drei Spalten und fünf Zeilen bei (100, 50) Punkten. Es wendet rote Rahmen mit einer Breite von 5 Punkten an, führt die ersten beiden Zellen der ersten Zeile zusammen und speichert das Ergebnis als `table.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 50, 50, 50 };
var rowHeights = new double[] { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

table.MergeCells(table[0, 0], table[1, 0], false);
table[0, 0].TextFrame.Text = "Merged Cells";

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **Nummerierung in einer Standardtabelle**

In einer Standardtabelle sind Zellindizes nullbasiert und verwenden die Reihenfolge (Spalte, Zeile). Die erste Zelle hat den Index (0, 0).

Beispielsweise werden die Zellen in einer Tabelle mit 4 Spalten und 4 Zeilen wie folgt nummeriert:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Dieses Beispiel erzeugt die oben dargestellte 4 × 4‑Tabelle mit Spaltenbreiten und Zeilenhöhen von 70 Punkten sowie roten Zellrahmen von 5 Punkten Breite. Die Koordinaten veranschaulichen die Zellindizes; das Beispiel lässt die Zellen leer und speichert die Tabelle als `StandardTables_out.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 70, 70, 70, 70 };
var rowHeights = new double[] { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
{
    foreach (var cell in row)
    {
        var cellFormat = cell.CellFormat;
        cellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderTop.Width = 5;

        cellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderBottom.Width = 5;

        cellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderLeft.Width = 5;

        cellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
        cellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
        cellFormat.BorderRight.Width = 5;
    }
}

presentation.Save("StandardTables_out.pptx", SaveFormat.Pptx);
```

## **Zugriff auf eine vorhandene Tabelle**

Tabellen werden in der Formensammlung einer Folie gespeichert. Durchlaufen Sie die Formen, um eine Tabelle zu finden, und verwenden Sie das Interface [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/), um deren Zellen zu lesen oder zu aktualisieren.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Holen Sie sich eine Referenz auf die Folie, die die Tabelle enthält, anhand ihres Index.
3. Durchsuchen Sie die [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/)-Objekte und stoppen Sie, wenn eine Tabelle gefunden wird. Enthält die Folie mehrere Tabellen, verwenden Sie [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/), um die gewünschte zu identifizieren.
4. Aktualisieren Sie den Text in der Zielzelle.
5. Speichern Sie die geänderte Präsentation.

Das folgende Beispiel öffnet `UpdateExistingTable.pptx` und findet die erste Tabelle auf der ersten Folie. Es setzt die Zelle in Spalte 0, Zeile 1 auf `New` und speichert das Ergebnis als `table1_out.pptx`. Die Eingabe muss mindestens eine Folie enthalten, und die erste Tabelle auf dieser Folie muss mindestens eine Spalte und zwei Zeilen haben.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("UpdateExistingTable.pptx");
var slide = presentation.Slides[0];
ITable? table = null;

foreach (var shape in slide.Shapes)
{
    if (shape is ITable candidateTable)
    {
        table = candidateTable;
        break;
    }
}

table![0, 1].TextFrame.Text = "New";

presentation.Save("table1_out.pptx", SaveFormat.Pptx);
```

Um die Höhe einer Zeile in einer bestehenden Tabelle zu ändern und zu verstehen, warum die tatsächliche Höhe das angeforderte Minimum überschreiten kann, siehe [Control Row Height](/slides/de/net/manage-rows-and-columns/#control-row-height).

## **Ermitteln der Zelle, die einen Textrahmen besitzt**

Wenn generischer Text‑Verarbeitungscode ein [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) von einer Tabelle erhält, verwenden Sie die Eigenschaft [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/), um die zugehörige [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) abzurufen. Für einen Tabellenzellen‑Textrahmen ist [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) gesetzt und [ITextFrame.ParentShape](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentshape/) ist `null`, obwohl die Tabelle selbst eine Form ist.

Die Zellkoordinaten sind über die schreibgeschützten Eigenschaften [ICell.FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) und [ICell.FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) verfügbar. [ITextFrame.ParentCell](https://reference.aspose.com/slides/net/aspose.slides/itextframe/parentcell/) ist ebenfalls schreibgeschützt: Sie liefert die Navigation zum Eigentümer, ändert jedoch nicht den Besitz. Prüfen Sie stets, ob die zurückgegebene Zelle `null` ist, bevor Sie sie verwenden.

Ein vollständiges Beispiel, das Tabellen‑Zellen‑ und Form‑Eigentümer identifiziert, einschließlich mit SmartArt‑Knoten verknüpfter Formen, finden Sie unter [Search and Replace Text](/slides/de/net/search-and-replace-text/).

## **Text in einer Tabelle ausrichten**

Sie können die vertikale Verankerung und Textausrichtung einzelner Tabellenzellen steuern. Das Beispiel in diesem Abschnitt zentriert den Text in der ersten Zelle und dreht ihn um 270 Grad.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/).
2. Holen Sie sich eine Referenz auf die Folie anhand ihres Index.
3. Fügen Sie ein [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)‑Objekt zur Folie hinzu.
4. Greifen Sie von der Tabelle aus auf ein [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)‑Objekt zu.
5. Greifen Sie auf das erste [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) zu und setzen Sie dessen Text und Farbe.
6. Setzen Sie den [TextAnchorType](https://reference.aspose.com/slides/net/aspose.slides/icell/textanchortype/) und den [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/icell/textverticaltype/) der Zelle.
7. Speichern Sie die geänderte Präsentation.

Dieses Beispiel erstellt eine 4 × 4‑Tabelle mit Spaltenbreiten von 120 Punkten und Zeilenhöhen von 100 Punkten. Es formatiert den Text in Zelle (0, 0), fügt Werte zu den restlichen Zellen der ersten Zeile hinzu und speichert das Ergebnis als `Vertical_Align_Text_out.pptx`.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 120, 120, 120, 120 };
var rowHeights = new double[] { 100, 100, 100, 100 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);
table[1, 0].TextFrame.Text = "10";
table[2, 0].TextFrame.Text = "20";
table[3, 0].TextFrame.Text = "30";

var cell = table[0, 0];
var paragraph = cell.TextFrame.Paragraphs[0];
var portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **Textformatierung auf Tabellenebene festlegen**

Verwenden Sie [SetTextFormat](https://reference.aspose.com/slides/net/aspose.slides/ibulktextformattable/settextformat/), um Textformatierungen auf alle Zellen einer Tabelle anzuwenden. Seine Überladungen akzeptieren Teil‑, Absatz‑ und Textrahmen‑Formatierungen, sodass Sie diese Eigenschaften setzen können, ohne jede Zelle einzeln zu iterieren.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) .
2. Holen Sie sich eine Referenz auf die Folie anhand ihres Index.
3. Greifen Sie von der Folie aus auf ein [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)‑Objekt zu.
4. Setzen Sie die [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) für den Text.
5. Setzen Sie die [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) und [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/).
6. Setzen Sie den [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) .
7. Speichern Sie die geänderte Präsentation.

Das folgende Beispiel öffnet `table.pptx`, das mindestens eine Folie mit einer Tabelle als erste Form enthalten muss. Es setzt die Schriftgröße auf 25 Punkte, richtet Absätze rechtsbündig mit einem rechten Rand von 20 Punkten aus und macht den Text vertikal. Die formatierte Präsentation wird als `result.pptx` gespeichert.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

var portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
table.SetTextFormat(portionFormat);

var paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
table.SetTextFormat(paragraphFormat);

var textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
table.SetTextFormat(textFrameFormat);

presentation.Save("result.pptx", SaveFormat.Pptx);
```

## **Tabellenstil-Eigenschaften abrufen**

Verwenden Sie [StylePreset](https://reference.aspose.com/slides/net/aspose.slides/itable/stylepreset/), um den voreingestellten Stil einer Tabelle zu lesen oder zuzuweisen. Dieses Beispiel wendet [TableStylePreset.DarkStyle1](https://reference.aspose.com/slides/net/aspose.slides/tablestylepreset/) auf eine Tabelle an, gibt den Namen des Presets aus und weist denselben Preset einer zweiten Tabelle zu. Beide Tabellen werden in `table-style.pptx` gespeichert.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

var columnWidths = new double[] { 100, 150 };
var rowHeights = new double[] { 5, 5, 5 };
var table = slide.Shapes.AddTable(10, 10, columnWidths, rowHeights);
table.StylePreset = TableStylePreset.DarkStyle1;

var stylePreset = table.StylePreset;
Console.WriteLine($"Table style preset: {stylePreset}");

var anotherTable = slide.Shapes.AddTable(10, 100, columnWidths, rowHeights);
anotherTable.StylePreset = stylePreset;

presentation.Save("table-style.pptx", SaveFormat.Pptx);
```

## **Seitenverhältnis einer Tabelle sperren**

Das Seitenverhältnis einer Tabelle ist das Verhältnis ihrer Breite zu ihrer Höhe. Verwenden Sie [AspectRatioLocked](https://reference.aspose.com/slides/net/aspose.slides/igraphicalobjectlock/aspectratiolocked/), um dieses Verhältnis für eine Tabelle zu sperren.

Das folgende Beispiel öffnet `pres.pptx`, das mindestens eine Folie mit einer Tabelle als erste Form enthalten muss. Es gibt den aktuellen Sperrstatus aus, aktiviert die Sperre des Seitenverhältnisses, gibt den aktualisierten Status (`True`) aus und speichert das Ergebnis als `pres-out.pptx`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("pres.pptx");
var slide = presentation.Slides[0];

var table = (ITable)slide.Shapes[0];

Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

table.ShapeLock.AspectRatioLocked = true;
Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

presentation.Save("pres-out.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Kann ich die Leserichtung von rechts nach links (RTL) für eine gesamte Tabelle und den Text in ihren Zellen aktivieren?**

Ja. Die Tabelle stellt die Eigenschaft [RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/table/righttoleft/) bereit, und Absätze besitzen [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/righttoleft/). Die Verwendung beider sorgt für die korrekte RTL‑Reihenfolge und Darstellung innerhalb der Zellen.

**Wie kann ich verhindern, dass Benutzer eine Tabelle in der finalen Datei verschieben oder die Größe ändern?**

Verwenden Sie [shape locks](/slides/de/net/applying-protection-to-presentation/), um das Verschieben, die Größenänderung, die Auswahl usw. zu deaktivieren. Diese Sperren gelten ebenfalls für Tabellen.

**Wird das Einfügen eines Bildes als Hintergrund in einer Zelle unterstützt?**

Ja. Sie können für eine Zelle eine [picture fill](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) festlegen; das Bild bedeckt die Zellenfläche entsprechend dem gewählten Modus (Strecken oder Kacheln).