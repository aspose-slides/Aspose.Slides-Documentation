---
title: Manage Table Cells in Presentations in .NET
linktitle: Manage Cells
type: docs
weight: 30
url: /de/net/manage-cells/
keywords:
- Tabellenzelle
- Zellen zusammenführen
- Rand entfernen
- Zelle teilen
- Bild in Zelle
- Hintergrundfarbe
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "PowerPoint-Tabellenzellen in C# verwalten: zusammengeführte Zellen identifizieren, Ränder entfernen, Zellen teilen und Hintergrundfarben sowie Bilder mit Aspose.Slides für .NET festlegen."
---
## **Übersicht**

Aspose.Slides ermöglicht den Zugriff auf Tabellenzellen in PowerPoint‑Präsentationen und deren Änderung. Dieser Artikel erklärt, wie man zusammengeführte Tabellenzellen erkennt, Zellrahmen entfernt, mit der Zellnummerierung nach dem Zusammenführen oder Aufteilen von Zellen arbeitet, die Hintergrundfarbe einer Zelle ändert und ein Bild innerhalb einer Tabellenzelle hinzufügt. Die Beispiele zeigen, wie man eine Präsentation erstellt oder öffnet, eine Tabelle von einer Folie abruft, die Zellformatierung über Zelleigenschaften aktualisiert und die modifizierte Präsentation als PPTX‑Datei speichert.

Aspose.Slides verwendet nullbasierte Indizes, um Tabellenzellen in der Reihenfolge `(column, row)` zu adressieren.

## **Erkennen einer zusammengeführten Tabellenzelle**

Das Beispiel öffnet eine vorhandene Präsentation und greift auf die erste Form auf der ersten Folie als Tabelle zu. Es wird angenommen, dass die Folie und die Form existieren und dass die Form eine Tabelle ist. Anschließend wird durch alle Zeilen und Spalten iteriert und [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) verwendet, um Zellen in zusammengeführten Bereichen zu erkennen. Für jede Übereinstimmung werden die Zellkoordinaten in der Reihenfolge `row;column`, [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/), [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/), und die Startkoordinaten des Bereichs, [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) und [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/), ausgegeben.

```csharp
using System;
using Aspose.Slides;

using var presentation = new Presentation("presentation_with_table.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var rowCount = table.Rows.Count;
for (var rowIndex = 0; rowIndex < rowCount; rowIndex++)
{
    var columnCount = table.Columns.Count;
    for (var columnIndex = 0; columnIndex < columnCount; columnIndex++)
    {
        var cell = table[columnIndex, rowIndex];
        if (cell.IsMergedCell)
        {
            Console.WriteLine($"Cell {rowIndex};{columnIndex} belongs to a merged region with RowSpan={cell.RowSpan} and ColSpan={cell.ColSpan} starting at {cell.FirstRowIndex};{cell.FirstColumnIndex}.");
        }
    }
}
```

## **Entfernen von Tabellenzellenrahmen**

Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) und fügen Sie ihrer ersten Folie mit [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) eine Tabelle hinzu. Spaltenbreiten, Zeilenhöhen und die Tabellenposition werden in Punkten angegeben. Das Beispiel setzt alle vier Zellrahmen auf [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/), wodurch sie unsichtbar werden.

```csharp
using Aspose.Slides;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 50, 50, 50, 50 };
double[] rowHeights = { 50, 30, 30, 30, 30 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

foreach (var row in table.Rows)
    foreach (var cell in row)
    {
        cell.CellFormat.BorderTop.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.NoFill;
        cell.CellFormat.BorderRight.FillFormat.FillType = FillType.NoFill;
    }

presentation.Save("table.pptx", SaveFormat.Pptx);
```

## **Zusammenführen von Tabellenzellen**

Verwenden Sie [MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/), um einen rechteckigen Bereich von Tabellenzellen zu einer einzigen Zelle zu kombinieren. Geben Sie die Zellen in der linken oberen bzw. rechten unteren Ecke des Bereichs an. Das letzte Argument bestimmt, ob das Zusammenführen Zellen außerhalb des angegebenen Bereichs einschließen darf; `false` hält das Zusammenführen innerhalb dieses Bereichs.

Das Beispiel erstellt eine 4‑by‑4‑Tabelle mit 70‑Punkt‑Spalten und -Zeilen und führt dann die vier mittleren Zellen von `(1, 1)` bis `(2, 2)` zusammen. Die resultierende Zelle erstreckt sich über zwei Spalten und zwei Zeilen, während das zugrunde liegende Raster der Tabelle vier Spalten und vier Zeilen beibehält. Um auf den Inhalt oder die Formatierung der zusammengeführten Zelle zuzugreifen, verwenden Sie deren linke obere Position: `table[1, 1]` in diesem Beispiel. Die anderen Positionen im zusammengeführten Bereich bleiben Teil des Tabellengitters, sodass sich die Indizes von Zellen außerhalb des Bereichs nicht ändern.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table.MergeCells(table[1, 1], table[2, 2], false);

presentation.Save("merged_cells.pptx", SaveFormat.Pptx);
```

## **Aufteilen von Tabellenzellen**

Mergen von Zellen im vorherigen Beispiel erhält das Tabellengitter. Das Aufteilen einer Zelle kann eine neue Gitterspalte einführen und die Spaltenindizes der Zellen zu ihrer rechten Seite ändern. Aspose.Slides folgt dem Tabellengittermodell von PowerPoint.

Dieses Beispiel erstellt eine 4‑by‑4‑Tabelle mit 70‑Punkt‑Spalten und -Zeilen und ruft [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/) für die Zelle `(1, 1)` auf. Die Hälfte der 70‑Punkt‑Breite der Zelle wird verwendet, um zwei gleichbreite Zellen zu erzeugen.

Nach diesem Aufteilen werden die beiden Hälften über `table[1, 1]` und `table[2, 1]` angesprochen. Das Tabellengitter hat nun fünf Spalten: Zellen, die ursprünglich in den Spalten 2 und 3 waren, verschieben sich zu Spalten 3 bzw. 4. Zeilenindizes bleiben unverändert. Verwenden Sie diese aktualisierten Spaltenindizes, wenn Sie nach dem Aufteilen Zellen ansprechen.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 70, 70, 70, 70 };
double[] rowHeights = { 70, 70, 70, 70 };
var table = slide.Shapes.AddTable(100, 50, columnWidths, rowHeights);

table[1, 1].SplitByWidth(table[1, 1].Width / 2);

presentation.Save("split_cells.pptx", SaveFormat.Pptx);
```

### **Aufteilen zusammengeführter Zellen nach Zeilen‑ oder Spaltenbereich**

Um zusammengeführte Vorlagenzellen für die Datenbefüllung vorzubereiten, verwenden Sie [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/), um entlang einer bestehenden Zeilengrenze zu splitten, oder [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/), um entlang einer Spaltengrenze zu splitten.

Das Argument `index` zählt Zeilen im oberen Teil bzw. Spalten im linken Teil des Splits; es ist relativ zum zusammengeführten Bereich:

- Zeilensplit: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/).
- Spaltensplit: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/).

Das Beispiel geht davon aus, dass eine Präsentation eine Tabelle als erste Form auf der ersten Folie enthält, wobei `(1, 2)` und `(1, 3)` vertikal zusammengeführt sind. Ausgehend von der unteren Position verwendet es [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) und [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/), um den Ursprung zu finden, und prüft beide Bereiche. `SplitByRowSpan(1)` trennt dann die Zeilen 2 und 3 für Produktnamen. Für eine horizontale Zwei‑Spalten‑Zusammenführung verwenden Sie stattdessen `SplitByColSpan(1)`.

```csharp
using System;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation("table_template.pptx");
var slide = presentation.Slides[0];
var table = (ITable) slide.Shapes[0];

var selectedCell = table[1, 3];
var firstColumnIndex = selectedCell.FirstColumnIndex;
var firstRowIndex = selectedCell.FirstRowIndex;
var mergedCell = table[firstColumnIndex, firstRowIndex];

if (mergedCell.IsMergedCell && mergedCell.RowSpan == 2 && mergedCell.ColSpan == 1)
{
    mergedCell.SplitByRowSpan(1);

    // Rufen Sie die resultierenden Zellen aus der Tabelle nach dem Aufteilen ab.
    var upperCell = table[firstColumnIndex, firstRowIndex];
    var lowerCell = table[firstColumnIndex, firstRowIndex + 1];
    Console.WriteLine($"Upper cell merged: {upperCell.IsMergedCell}");
    Console.WriteLine($"Lower cell merged: {lowerCell.IsMergedCell}");

    upperCell.TextFrame.Text = "Product A";
    lowerCell.TextFrame.Text = "Product B";

    presentation.Save("split_template.pptx", SaveFormat.Pptx);
}
else
{
    Console.WriteLine("Select a merged region spanning exactly two rows and one column.");
}
```

Das Tabellengitter und die umgebenden Zellindizes bleiben unverändert. Rufen Sie die resultierenden Zellen über ihre Koordinaten ab; hier haben beide eine Spannweite von 1 und [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) gibt `False` aus. Größere Bereiche können nach einem Split teilweise zusammengeführt bleiben.

Der ursprüngliche Text und seine Formatierung verbleiben in der oberen (bzw. linken) Zelle; die neue Zelle ist leer, erbt jedoch Zellformatierungen wie Füllung, Rahmen und Ränder. Befüllen Sie die Zellen nach dem Aufteilen und setzen Sie alle erforderlichen Textformatierungen explizit.

Die gespeicherte Präsentation enthält separate Zellen „Product A“ und „Product B“ mit dem Format der Vorlage beibehalten. Siehe die [Cell API Reference](https://reference.aspose.com/slides/net/aspose.slides/cell/) für Details.

## **Ändern der Hintergrundfarbe einer Tabellenzelle**

Dieses Beispiel erstellt eine Tabelle mit 150‑Punkt‑Spalten und 50‑Punkt‑Zeilen. Es setzt [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) auf solid und [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) auf Rot für die Zelle `(2, 3)`, in der dritten Spalte und vierten Zeile.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 50, 50, 50, 50, 50 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

var cell = table[2, 3];
cell.CellFormat.FillFormat.FillType = FillType.Solid;
cell.CellFormat.FillFormat.SolidFillColor.Color = Color.Red;

presentation.Save("cell_background_color.pptx", SaveFormat.Pptx);
```

## **Ein Bild in einer Tabellenzelle hinzufügen**

Legen Sie das Eingabebild vor der Ausführung dieses Beispiels in das Arbeitsverzeichnis. Es lädt das Bild mit [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) und fügt es der Bildsammlung der Präsentation mit [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/) hinzu. Anschließend weist es das Bild dem Bildfüllmodus der Zelle `(0, 0)`, der ersten Zelle in der Tabelle, zu.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) streckt das Bild, um die Zelle zu füllen, was das Seitenverhältnis ändern kann. Spaltenbreiten und Zeilenhöhen werden in Punkten angegeben. Das geladene Bild wird automatisch durch die using‑Deklaration freigegeben.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 150, 150, 150, 150 };
double[] rowHeights = { 100, 100, 100, 100, 90 };
var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);

using var image = Images.FromFile("aspose_logo.jpg");
var ppImage = presentation.Images.AddImage(image);

table[0, 0].CellFormat.FillFormat.FillType = FillType.Picture;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.PictureFillMode = PictureFillMode.Stretch;
table[0, 0].CellFormat.FillFormat.PictureFillFormat.Picture.Image = ppImage;

presentation.Save("table_cell_with_image.pptx", SaveFormat.Pptx);
```

## **FAQ**

**Kann ich unterschiedliche Linienstärken und -stile für die einzelnen Seiten einer einzelnen Zelle festlegen?**

Ja. Die [oben](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[unten](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[links](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[rechts](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/) Rahmen haben separate Eigenschaften, sodass die Dicke und der Stil jeder Seite unterschiedlich sein kann.

**Was passiert mit dem Bild, wenn ich die Spalten‑/Zeilen‑Größe ändere, nachdem ich ein Bild als Hintergrund der Zelle festgelegt habe?**

Das Verhalten hängt vom [Füllmodus](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (stretch/tile) ab. Beim Strecken passt sich das Bild der neuen Zelle an; beim Kacheln werden die Kacheln neu berechnet.

**Kann ich einem gesamten Zellinhalt einen Hyperlink zuweisen?**

[Hyperlinks](/slides/de/net/manage-hyperlinks/) werden auf Ebene des Textes (Abschnitt) innerhalb des Textframes einer Zelle oder auf Ebene der gesamten Tabelle/Form gesetzt. In der Praxis weist man den Link einem Abschnitt oder dem gesamten Text in der Zelle zu.

**Kann ich innerhalb einer einzelnen Zelle unterschiedliche Schriftarten festlegen?**

Ja. Das Textframe einer Zelle unterstützt [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/) (Läufe) mit unabhängiger Formatierung – Schriftfamilie, Stil, Größe und Farbe.