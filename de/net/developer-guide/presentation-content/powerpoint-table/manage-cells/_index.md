---
title: Verwalten von Tabellenzellen in Präsentationen in .NET
linktitle: Zellen verwalten
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
description: "Verwalten Sie PowerPoint-Tabellenzellen in C#: identifizieren Sie zusammengeführte Zellen, entfernen Sie Ränder, teilen Sie Zellen und setzen Sie Hintergrundfarben und Bilder mit Aspose.Slides für .NET."
---
## **Übersicht**

Aspose.Slides ermöglicht den Zugriff auf Tabellenzellen in PowerPoint-Präsentationen und deren Modifizierung. Dieser Artikel erklärt, wie man zusammengeführte Tabellenzellen ermittelt, Zellränder entfernt, mit Zellnummerierung nach dem Zusammenführen oder Teilen von Zellen arbeitet, die Hintergrundfarbe einer Zelle ändert und ein Bild in einer Tabellenzelle hinzufügt. Die Beispiele zeigen, wie man eine Präsentation erstellt oder öffnet, eine Tabelle von einer Folie erhält, die Zellformatierung über Zelleigenschaften aktualisiert und die modifizierte Präsentation als PPTX-Datei speichert.

Aspose.Slides verwendet nullbasierte Indizes, um Tabellenzellen in der Reihenfolge `(column, row)` zu adressieren.

## **Identifizieren einer zusammengeführten Tabellenzelle**

Das Beispiel öffnet eine vorhandene Präsentation und greift auf die erste Form auf der ersten Folie als Tabelle zu. Es wird davon ausgegangen, dass die Folie und die Form existieren und dass die Form eine Tabelle ist. Anschließend iteriert es über alle Zeilen und Spalten und verwendet [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) um Zellen in zusammengeführten Bereichen zu identifizieren. Für jede Übereinstimmung gibt es die Zellkoordinaten in der Reihenfolge `row;column`, [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/), [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/) und die Startkoordinaten des Bereichs, [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/) und [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) aus.

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

## **Tabellenzellränder entfernen**

Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) und fügen Sie mit [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) eine Tabelle zur ersten Folie hinzu. Spaltenbreiten, Zeilenhöhen und die Position der Tabelle werden in Punkt angegeben. Das Beispiel setzt alle vier Zellränder auf [FillType.NoFill](https://reference.aspose.com/slides/net/aspose.slides/filltype/), wodurch sie unsichtbar werden.

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

## **Diagonale Zellränder hinzufügen**

Verwenden Sie [BorderDiagonalDown](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonaldown/), um eine Linie von der oberen linken Ecke zur unteren rechten zu zeichnen, und [BorderDiagonalUp](https://reference.aspose.com/slides/net/aspose.slides/icellformat/borderdiagonalup/), um eine Linie von der unteren linken Ecke zur oberen rechten zu zeichnen. Eine Diagonale kann eine Ecküberschrift kennzeichnen; beide Diagonalen können ein X bilden, um eine Zelle als nicht anwendbar zu markieren.

Jede Diagonale ist ein [ILineFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/). In seinem [FillFormat](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/fillformat/) setzen Sie [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) auf [FillType.Solid](https://reference.aspose.com/slides/net/aspose.slides/filltype/) und wählen eine [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/). Stellen Sie die [Width](https://reference.aspose.com/slides/net/aspose.slides/ilineformat/width/) der Linie in Punkt ein.

Das Beispiel erstellt drei Zellen in einer Zeile: eine rote diagonale nach unten, eine blaue diagonale nach oben und beide Diagonalen. Es lässt die oberen, unteren, linken und rechten Zellränder unverändert.

```csharp
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 210, 210, 210 };
double[] rowHeights = { 160 };
var table = slide.Shapes.AddTable(45, 130, columnWidths, rowHeights);

var downwardBorder = table[0, 0].CellFormat.BorderDiagonalDown;
downwardBorder.FillFormat.FillType = FillType.Solid;
downwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
downwardBorder.Width = 3;

var upwardBorder = table[1, 0].CellFormat.BorderDiagonalUp;
upwardBorder.FillFormat.FillType = FillType.Solid;
upwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
upwardBorder.Width = 5;

var crossDownwardBorder = table[2, 0].CellFormat.BorderDiagonalDown;
crossDownwardBorder.FillFormat.FillType = FillType.Solid;
crossDownwardBorder.FillFormat.SolidFillColor.Color = Color.Red;
crossDownwardBorder.Width = 3;

var crossUpwardBorder = table[2, 0].CellFormat.BorderDiagonalUp;
crossUpwardBorder.FillFormat.FillType = FillType.Solid;
crossUpwardBorder.FillFormat.SolidFillColor.Color = Color.Blue;
crossUpwardBorder.Width = 5;

presentation.Save("diagonal_cell_borders.pptx", SaveFormat.Pptx);
```

Eine Diagonale ist eine Formatierungseigenschaft, kein Zellsplit. Jede Zelle behält ein einzelnes [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/icell/textframe/); die Bereiche auf beiden Seiten einer Diagonalen können nicht unabhängig voneinander bearbeitet werden.

Die gespeicherte Tabelle, dargestellt in Microsoft PowerPoint:
![Drei Tabellenzellen, die eine rote Diagonale von oben links nach unten rechts, eine blaue Diagonale von unten links nach oben rechts und beide Diagonalen, die ein X bilden, zeigen.](diagonal-cell-borders.png)

*Von links nach rechts: diagonale nach unten (rot, 3 pt), diagonale nach oben (blau, 5 pt) und beide Diagonalen.*

## **Tabellenzellen zusammenführen**

Verwenden Sie [MergeCells](https://reference.aspose.com/slides/net/aspose.slides/itable/mergecells/), um einen rechteckigen Bereich von Tabellenzellen zu einer Zelle zu kombinieren. Geben Sie die Zellen in der oberen linken bzw. unteren rechten Ecke des Bereichs an. Das letzte Argument steuert, ob das Zusammenführen Zellen außerhalb des angegebenen Bereichs einschließen darf; `false` hält das Zusammenführen innerhalb dieses Bereichs.

Das Beispiel erstellt eine 4‑mal 4‑Tabelle mit 70‑Punkt‑Spalten und -Zeilen und führt dann die vier mittleren Zellen von `(1, 1)` bis `(2, 2)` zusammen. Die resultierende Zelle erstreckt sich über zwei Spalten und zwei Zeilen, während das zugrunde liegende Tabellengitter vier Spalten und vier Zeilen beibehält. Um auf den Inhalt oder die Formatierung der zusammengeführten Zelle zuzugreifen, verwenden Sie ihre obere linke Position: `table[1, 1]` in diesem Beispiel. Die anderen Positionen im zusammengeführten Bereich bleiben Teil des Tabellengitters, sodass sich die Indizes der Zellen außerhalb des Bereichs nicht ändern.

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

## **Tabellenzellen teilen**

Das Zusammenführen von Zellen im vorherigen Beispiel erhält das Tabellengitter. Das Teilen einer Zelle kann eine neue Spalte im Raster einführen und die Spaltenindizes der Zellen rechts davon ändern. Aspose.Slides folgt dem Tabellengittermodell von PowerPoint.

Dieses Beispiel erstellt eine 4‑mal 4‑Tabelle mit 70‑Punkt‑Spalten und -Zeilen und ruft [SplitByWidth](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbywidth/) für die Zelle `(1, 1)` auf. Die Hälfte der 70‑Punkt‑Breite der Zelle wird verwendet, um zwei gleich breite Zellen zu erzeugen.

Nach diesem Split werden die beiden Hälften als `table[1, 1]` und `table[2, 1]` adressiert. Das Tabellengitter hat nun fünf Spalten: Zellen, die ursprünglich in Spalte 2 und 3 waren, verschieben sich zu Spalte 3 bzw. 4. Zeilenindizes bleiben unverändert. Verwenden Sie diese aktualisierten Spaltenindizes, wenn Sie nach dem Split auf Zellen zugreifen.

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

### **Zusammengeführte Zellen nach Zeilen- oder Spaltenbereich splitten**

Um zusammengeführte Vorlagenzellen für die Datenbefüllung vorzubereiten, verwenden Sie [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/), um entlang einer vorhandenen Zeilenbegrenzung zu splitten, oder [SplitByColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbycolspan/), um entlang einer Spaltenbegrenzung zu splitten.

Das Argument `index` zählt Zeilen im oberen Teil bzw. Spalten im linken Teil des Splits; es ist relativ zum zusammengeführten Bereich:

- Zeilen‑Split: `0 < index <` [RowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/rowspan/).
- Spalten‑Split: `0 < index <` [ColSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/colspan/).

Das Beispiel erwartet, dass eine Präsentation eine Tabelle als erste Form auf der ersten Folie enthält, wobei `(1, 2)` und `(1, 3)` vertikal zusammengeführt sind. Ausgehend von der unteren Position verwendet es [FirstColumnIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstcolumnindex/) und [FirstRowIndex](https://reference.aspose.com/slides/net/aspose.slides/icell/firstrowindex/), um den Ursprung zu finden und prüft beide Spannen. `SplitByRowSpan(1)` trennt dann die Zeilen 2 und 3 für Produktnamen. Für ein horizontales Zusammenführen von zwei Spalten verwenden Sie stattdessen `SplitByColSpan(1)`.

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

Das Tabellengitter und die umliegenden Zellindizes bleiben unverändert. Rufen Sie die resultierenden Zellen über ihre Koordinaten ab; hier haben beide eine Spanne von 1 und [IsMergedCell](https://reference.aspose.com/slides/net/aspose.slides/icell/ismergedcell/) gibt `False` aus. Größere Bereiche können nach einem Split teilweise zusammengeführt bleiben.

Der ursprüngliche Text und seine Formatierung bleiben in der oberen (bzw. linken) Zelle; die neue Zelle ist leer, erbt jedoch die Zellformatierung wie Füllung, Ränder und Abstände. Befüllen Sie die Zellen nach dem Split und setzen Sie erforderliche Textformatierungen explizit.

Die gespeicherte Präsentation enthält separate "Product A" und "Product B" Zellen mit der Vorlagen‑Zellformatierung beibehalten. Siehe die [Cell-API-Referenz](https://reference.aspose.com/slides/net/aspose.slides/cell/) für Details.

<!-- visual-explanation:manage-cells:start -->
[![Die zusammengeführte Zelle in Spalte 1, Zeilen 2 und 3 teilt sich in Produkt A und Produkt B mit denselben Gitterindizes.](visual-manage-cells-62c80896698e.svg)](visual-manage-cells-62c80896698e.svg)

*Der Zeilen‑Span‑Split nutzt die vorhandene Grenze. Produkt A und Produkt B belegen (1, 2) bzw. (1, 3).*
<!-- visual-explanation:manage-cells:end -->

### **Eine Zelle an einer bestimmten Höhe teilen**

[SplitByHeight](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyheight/) nimmt die Höhe des oberen Teils in Punkten. [SplitByRowSpan](https://reference.aspose.com/slides/net/aspose.slides/icell/splitbyrowspan/) nimmt die Anzahl der vorhandenen Gitterzeilen im oberen Teil. Um eine 40‑Punkt‑Zelle in der rechten Spalte zu zentrieren, subtrahieren Sie 40 von der tatsächlichen Höhe der Zelle und teilen den verbleibenden Raum gleichmäßig darüber und darunter.

```csharp
using Aspose.Slides;
using Aspose.Slides.Export;

using var presentation = new Presentation();
var slide = presentation.Slides[0];

double[] columnWidths = { 160, 160 };
double[] rowHeights = { 140 };

var table = slide.Shapes.AddTable(50, 50, columnWidths, rowHeights);
table[0, 0].TextFrame.Text = "Left";

var height = table[1, 0].Height;
var margin = (height - 40) / 2;

table[1, 0].SplitByHeight(margin);
table[1, 1].SplitByHeight(40);
table[1, 1].TextFrame.Text = "Middle";

presentation.Save("split_by_height.pptx", SaveFormat.Pptx);
```

Der erste Split fügt eine Gitterzeile hinzu und lässt die unteren 90 Punkt bei `[1, 1]`. Der zweite Split richtet sich an diese Zelle und fügt darunter eine weitere Zeile ein. Die rechte Spalte enthält nun `[1, 0]` mit 50 Punkt (`margin`), `[1, 1]` mit 40 Punkt und `[1, 2]` mit 50 Punkt (`margin`). Die linke Zelle erstreckt sich über alle drei Zeilen mit ihrer ursprünglichen Höhe von 140 Punkt.

![Die linke Zelle erstreckt die gesamte Tabellenhöhe neben drei Zellen mit einem mittigen Element in der Mitte.](split-by-height.png)

## **Tabellenzellen‑Hintergrundfarbe ändern**

Dieses Beispiel erstellt eine Tabelle mit 150‑Punkt‑Spalten und 50‑Punkt‑Zeilen. Es setzt [FillType](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/filltype/) auf solid und [SolidFillColor](https://reference.aspose.com/slides/net/aspose.slides/ifillformat/solidfillcolor/) auf rot für die Zelle `(2, 3)`, in der dritten Spalte und vierten Zeile.

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

## **Bild in einer Tabellenzelle hinzufügen**

Legen Sie das Eingabebild vor dem Ausführen dieses Beispiels in das Arbeitsverzeichnis. Es lädt das Bild mit [Images.FromFile](https://reference.aspose.com/slides/net/aspose.slides/images/fromfile/) und fügt es der Bildsammlung der Präsentation mit [AddImage](https://reference.aspose.com/slides/net/aspose.slides/iimagecollection/addimage/) hinzu. Anschließend wird das Bild dem Bildfüllmodus der Zelle `(0, 0)`, der ersten Zelle der Tabelle, zugewiesen.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) streckt das Bild, um die Zelle zu füllen, was das Seitenverhältnis ändern kann. Spaltenbreiten und Zeilenhöhen werden in Punkten angegeben. Das geladene Bild wird durch seine using‑Deklaration automatisch freigegeben.

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

**Kann ich für die einzelnen Seiten einer einzelnen Zelle unterschiedliche Linienstärken und -stile festlegen?**

Ja. Die [top](https://reference.aspose.com/slides/net/aspose.slides/cellformat/bordertop/)/[bottom](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderbottom/)/[left](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderleft/)/[right](https://reference.aspose.com/slides/net/aspose.slides/cellformat/borderright/)‑Ränder besitzen separate Eigenschaften, sodass die Dicke und der Stil jeder Seite unterschiedlich sein können.

**Was passiert mit dem Bild, wenn ich die Spalten‑/Zeilengröße ändere, nachdem ich ein Bild als Hintergrund der Zelle festgelegt habe?**

Das Verhalten hängt vom [fill mode](https://reference.aspose.com/slides/net/aspose.slides/picturefillmode/) (stretch/tile) ab. Beim Strecken passt sich das Bild der neuen Zelle an; beim Kacheln werden die Kacheln neu berechnet.

**Kann ich einem Hyperlink den gesamten Inhalt einer Zelle zuweisen?**

[Hyperlinks](/slides/de/net/manage-hyperlinks/) werden auf Textebene (Portion) innerhalb des Textrahmens einer Zelle oder auf Ebene der gesamten Tabelle/Form gesetzt. In der Praxis weisen Sie den Link einer Portion oder dem gesamten Text in der Zelle zu.

**Kann ich innerhalb einer einzelnen Zelle verschiedene Schriftarten festlegen?**

Ja. Der Textrahmen einer Zelle unterstützt [portions](https://reference.aspose.com/slides/net/aspose.slides/portion/) (Runs) mit unabhängiger Formatierung – Schriftfamilie, Stil, Größe und Farbe.