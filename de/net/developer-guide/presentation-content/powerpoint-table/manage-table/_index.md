---
title: Tabelle verwalten
type: docs
weight: 10
url: /net/manage-table/
keywords: "Tabelle, Tabelle erstellen, auf Tabelle zugreifen, Tabellen-Seitenverhältnis, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Erstellen und Verwalten von Tabellen in PowerPoint-Präsentationen in C# oder .NET"
---

Eine Tabelle in PowerPoint ist eine effiziente Möglichkeit, Informationen darzustellen und zu visualisieren. Die Informationen in einem Gitter von Zellen (angeordnet in Zeilen und Spalten) sind klar und einfach zu verstehen.

Aspose.Slides bietet die [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) Klasse, das [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) Interface, die [Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/) Klasse, das [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) Interface und weitere Typen, um Ihnen das Erstellen, Aktualisieren und Verwalten von Tabellen in allen Arten von Präsentationen zu ermöglichen.

## **Tabelle von Grund auf neu erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Holen Sie sich den Verweis auf eine Folie über ihren Index.
3. Definieren Sie ein Array von `columnWidth`.
4. Definieren Sie ein Array von `rowHeight`.
5. Fügen Sie ein [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) Objekt zur Folie über die [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) Methode hinzu.
6. Durchlaufen Sie jede [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/), um das Format für die oberen, unteren, rechten und linken Ränder anzuwenden.
7. Fügen Sie die ersten beiden Zellen der ersten Zeile der Tabelle zusammen.
8. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) einer [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) zu.
9. Fügen Sie etwas Text zum [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) hinzu.
10. Speichern Sie die geänderte Präsentation.

Dieser C#-Code zeigt Ihnen, wie Sie eine Tabelle in einer Präsentation erstellen:

```c#
// Instanziiert eine Presentation-Klasse, die eine PPTX-Datei repräsentiert
Presentation pres = new Presentation();

// Greift auf die erste Folie zu
ISlide sld = pres.Slides[0];

// Definiert Spalten mit Breiten und Zeilen mit Höhen
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// Fügt eine Tabellenform zur Folie hinzu
ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

// Setzt das Randformat für jede Zelle
for (int row = 0; row < tbl.Rows.Count; row++)
{
	for (int cell = 0; cell < tbl.Rows[row].Count; cell++)
	{
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderTop.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.FillType = (FillType.Solid);
		tbl.Rows[row][cell].CellFormat.BorderBottom.FillFormat.SolidFillColor.Color= Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderBottom.Width =5;

		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderLeft.FillFormat.SolidFillColor.Color =Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderLeft.Width = 5;

		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
		tbl.Rows[row][cell].CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
		tbl.Rows[row][cell].CellFormat.BorderRight.Width = 5;
	}
}
// Führt die Zellen 1 & 2 der Zeile 1 zusammen
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[1][1], false);

// Fügt etwas Text zur zusammengeführten Zelle hinzu
tbl.Rows[0][0].TextFrame.Text = "Zusammengeführte Zellen";

// Speichert die Präsentation auf der Festplatte
pres.Save("table.pptx", SaveFormat.Pptx);
```

## **Nummerierung in Standardtabelle**

In einer Standardtabelle ist die Nummerierung der Zellen einfach und nullbasiert. Die erste Zelle in einer Tabelle hat den Index 0,0 (Spalte 0, Zeile 0).

Zum Beispiel sind die Zellen in einer Tabelle mit 4 Spalten und 4 Zeilen folgendermaßen nummeriert:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Dieser C#-Code zeigt Ihnen, wie Sie die Nummerierung für Zellen in einer Tabelle angeben:

```c#
// Instanziiert eine Presentation-Klasse, die eine PPTX-Datei repräsentiert
using (Presentation pres = new Presentation())
{

    // Greift auf die erste Folie zu
    ISlide sld = pres.Slides[0];

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Fügt eine Tabellenform zur Folie hinzu
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Setzt das Randformat für jede Zelle
    foreach (IRow row in tbl.Rows)
    {
        foreach (ICell cell in row)
        {
			cell.CellFormat.BorderTop.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderTop.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderTop.Width = 5;

			cell.CellFormat.BorderBottom.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderBottom.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderBottom.Width = 5;

			cell.CellFormat.BorderLeft.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderLeft.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderLeft.Width = 5;

			cell.CellFormat.BorderRight.FillFormat.FillType = FillType.Solid;
			cell.CellFormat.BorderRight.FillFormat.SolidFillColor.Color = Color.Red;
			cell.CellFormat.BorderRight.Width = 5;
        }
    }

    // Speichert die Präsentation auf der Festplatte
    pres.Save("StandardTables_out.pptx", SaveFormat.Pptx);
}
```

## **Zugriff auf vorhandene Tabelle**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.

2. Holen Sie sich einen Verweis auf die Folie, die die Tabelle enthält, über ihren Index.

3. Erstellen Sie ein [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) Objekt und setzen Sie es auf null.

4. Durchlaufen Sie alle [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) Objekte, bis die Tabelle gefunden wird.

   Wenn Sie vermuten, dass die Folie, mit der Sie es zu tun haben, eine einzelne Tabelle enthält, können Sie einfach alle Formen überprüfen, die sie enthält. Wenn eine Form als Tabelle identifiziert wird, können Sie sie als [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) Objekt typcasten. Wenn die Folie, mit der Sie es zu tun haben, jedoch mehrere Tabellen enthält, sollten Sie besser nach der Tabelle suchen, die Sie benötigen, über deren [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/).

5. Verwenden Sie das [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) Objekt, um mit der Tabelle zu arbeiten. Im folgenden Beispiel haben wir eine neue Zeile zur Tabelle hinzugefügt.

6. Speichern Sie die geänderte Präsentation.

Dieser C#-Code zeigt Ihnen, wie Sie auf eine vorhandene Tabelle zugreifen und mit ihr arbeiten:

```c#
// Instanziiert eine Presentation-Klasse, die eine PPTX-Datei repräsentiert
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // Greift auf die erste Folie zu
    ISlide sld = pres.Slides[0];

    // Initialisiert null TableEx
    ITable tbl = null;

    // Durchläuft die Formen und setzt einen Verweis auf die gefundene Tabelle
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // Setzt den Text für die erste Spalte der zweiten Zeile
    tbl[0, 1].TextFrame.Text = "Neu";

    // Speichert die modifizierte Präsentation auf der Festplatte
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Text in der Tabelle ausrichten**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse.
2. Holen Sie sich den Verweis auf eine Folie über ihren Index.
3. Fügen Sie ein [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) Objekt zur Folie hinzu.
4. Greifen Sie auf ein [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) Objekt aus der Tabelle zu.
5. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) zu.
6. Richten Sie den Text vertikal aus.
7. Speichern Sie die geänderte Präsentation.

Dieser C#-Code zeigt Ihnen, wie Sie den Text in einer Tabelle ausrichten:

```c#
// Erstellt eine Instanz der Presentation-Klasse
Presentation presentation = new Presentation();

// Holt sich die erste Folie
ISlide slide = presentation.Slides[0];

// Definiert Spalten mit Breiten und Zeilen mit Höhen
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// Fügt die Tabellenform zur Folie hinzu
ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
tbl[1, 0].TextFrame.Text = "10";
tbl[2, 0].TextFrame.Text = "20";
tbl[3, 0].TextFrame.Text = "30";

// Greift auf das TextFrame zu
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// Erstellt das Paragraph-Objekt für das TextFrame
IParagraph paragraph = txtFrame.Paragraphs[0];

// Erstellt das Portion-Objekt für das Paragraph
IPortion portion = paragraph.Portions[0];
portion.Text = "Text hier";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Richtet den Text vertikal aus
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// Speichert die Präsentation auf der Festplatte
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```

## **Textformatierung auf Tabellenebene festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse.
2. Holen Sie sich den Verweis auf eine Folie über ihren Index.
3. Greifen Sie auf ein [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) Objekt von der Folie zu.
4. Setzen Sie die [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) für den Text.
5. Setzen Sie die [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) und [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/).
6. Setzen Sie den [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/).
7. Speichern Sie die geänderte Präsentation.

Dieser C#-Code zeigt Ihnen, wie Sie Ihre bevorzugten Formatierungsoptionen auf den Text in einer Tabelle anwenden:

```c#
// Erstellt eine Instanz der Presentation-Klasse
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Angenommen, die erste Form auf der ersten Folie ist eine Tabelle

// Setzt die Schriftgröße der Tabellenzellen
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.SetTextFormat(portionFormat);

// Setzt die Textausrichtung und den rechten Rand der Tabellenzellen in einem Aufruf
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.SetTextFormat(paragraphFormat);

// Setzt den vertikalen Texttyp der Tabellenzellen
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.SetTextFormat(textFrameFormat);

presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Tabelle Stil Eigenschaften abrufen**

Aspose.Slides ermöglicht es Ihnen, die Stileigenschaften für eine Tabelle abzurufen, damit Sie diese Details für eine andere Tabelle oder anderswo verwenden können. Dieser C#-Code zeigt Ihnen, wie Sie die Stileigenschaften aus einem vorausgewählten Stil für Tabellen abrufen:

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // Ändert das Standardstilvorgabethema
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **Aspektverhältnis der Tabelle sperren**

Das Seitenverhältnis einer geometrischen Form ist das Verhältnis ihrer Größen in verschiedenen Dimensionen. Aspose.Slides bietet die `AspectRatioLocked`-Eigenschaft, um Ihnen zu ermöglichen, die Einstellung des Seitenverhältnisses für Tabellen und andere Formen zu sperren.

Dieser C#-Code zeigt Ihnen, wie Sie das Seitenverhältnis für eine Tabelle sperren:

```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"Seitenverhältnis gesperrt: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // umkehren

    Console.WriteLine($"Seitenverhältnis gesperrt: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```