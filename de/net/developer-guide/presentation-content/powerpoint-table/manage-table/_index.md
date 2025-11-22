---
title: "Tabelle verwalten"
type: docs
weight: 10
url: /de/net/manage-table/
keywords: "Tabelle, Tabelle erstellen, Tabelle zugreifen, Tabellenseitenverhältnis, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides for .NET"
description: "Erstellen und Verwalten von Tabellen in PowerPoint-Präsentationen in C# oder .NET"
---

Eine Tabelle in PowerPoint ist ein effizientes Mittel, um Informationen darzustellen und zu vermitteln. Die Informationen in einem Raster aus Zellen (geordnet in Zeilen und Spalten) sind übersichtlich und leicht zu verstehen.

Aspose.Slides stellt die [Table](https://reference.aspose.com/slides/net/aspose.slides/table/)‑Klasse, das [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)‑Interface, die [Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/)‑Klasse, das [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/)‑Interface und weitere Typen bereit, mit denen Sie Tabellen in allen Arten von Präsentationen erstellen, aktualisieren und verwalten können. 

## **Create Table from Scratch**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)‑Klasse.  
2. Holen Sie sich eine Referenz auf die Folie über ihren Index.  
3. Definieren Sie ein Array von `columnWidth`.  
4. Definieren Sie ein Array von `rowHeight`.  
5. Fügen Sie der Folie ein [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)‑Objekt über die [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/)‑Methode hinzu.  
6. Iterieren Sie über jedes [ICell], um die Formatierung für die oberen, unteren, rechten und linken Ränder anzuwenden.  
7. Führen Sie die ersten beiden Zellen der ersten Zeile der Tabelle zusammen.  
8. Greifen Sie auf das [TextFrame] eines [ICell] zu.  
9. Fügen Sie dem [TextFrame] etwas Text hinzu.  
10. Speichern Sie die geänderte Präsentation.

Dieser C#‑Code zeigt, wie Sie eine Tabelle in einer Präsentation erstellen:
```c#
// Instanziiert eine Presentation-Klasse, die eine PPTX-Datei darstellt
Presentation pres = new Presentation();

// Accesses the first slide
ISlide sld = pres.Slides[0];

// Defines columns with widths and rows with heights
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// Adds a table shape to the slide
ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

// Sets the border format for each cell
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
// Fügt die Zellen 1 und 2 der Zeile 1 zusammen
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[1][1], false);

// Fügt Text zur zusammengeführten Zelle hinzu
tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

// Speichert die Präsentation auf der Festplatte
pres.Save("table.pptx", SaveFormat.Pptx);
```


## **Numbering in Standard Table**
In einer Standardtabelle ist die Numerierung von Zellen einfach und nullbasiert. Die erste Zelle in einer Tabelle hat den Index 0,0 (Spalte 0, Zeile 0).

Zum Beispiel werden die Zellen in einer Tabelle mit 4 Spalten und 4 Zeilen wie folgt nummeriert:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Dieser C#‑Code zeigt, wie Sie die Nummerierung von Zellen in einer Tabelle festlegen:
```c#
// Instanziiert eine Presentation-Klasse, die eine PPTX-Datei darstellt
using (Presentation pres = new Presentation())
{

    // Greift auf die erste Folie zu
    ISlide sld = pres.Slides[0];

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Fügt ein Tabellenelement zur Folie hinzu
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Setzt das Rahmenformat für jede Zelle
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


## **Access Existing Table**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)‑Klasse.  
2. Holen Sie sich eine Referenz auf die Folie, die die Tabelle enthält, über ihren Index.  
3. Erstellen Sie ein [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)‑Objekt und setzen Sie es auf null.  
4. Iterieren Sie über alle [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/)‑Objekte, bis die Tabelle gefunden wird.  
   Wenn Sie vermuten, dass die Folie nur eine einzige Tabelle enthält, können Sie einfach alle enthaltenen Shapes prüfen. Wird ein Shape als Tabelle identifiziert, können Sie es in ein [Table](https://reference.aspose.com/slides/net/aspose.slides/table/)‑Objekt casten. Enthält die Folie jedoch mehrere Tabellen, empfiehlt sich die Suche nach der gewünschten Tabelle über deren [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/).  
5. Verwenden Sie das [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)‑Objekt, um mit der Tabelle zu arbeiten. Im folgenden Beispiel haben wir der Tabelle eine neue Zeile hinzugefügt.  
6. Speichern Sie die geänderte Präsentation.

Dieser C#‑Code zeigt, wie Sie auf eine vorhandene Tabelle zugreifen und mit ihr arbeiten:
```c#
// Instanziiert eine Presentation-Klasse, die eine PPTX-Datei darstellt
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // Greift auf die erste Folie zu
    ISlide sld = pres.Slides[0];

    // Initialisiert null TableEx
    ITable tbl = null;

    // Durchläuft die Shapes und setzt eine Referenz auf die gefundene Tabelle
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // Setzt den Text für die erste Spalte der zweiten Zeile
    tbl[0, 1].TextFrame.Text = "New";

    // Speichert die geänderte Präsentation auf der Festplatte
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Align Text in Table**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation)‑Klasse.  
2. Holen Sie sich eine Referenz auf die Folie über ihren Index.  
3. Fügen Sie der Folie ein [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)‑Objekt hinzu.  
4. Greifen Sie vom Tisch ein [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/)‑Objekt ab.  
5. Greifen Sie auf das [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) des [ITextFrame] zu.  
6. Richten Sie den Text vertikal aus.  
7. Speichern Sie die geänderte Präsentation.

Dieser C#‑Code zeigt, wie Sie den Text in einer Tabelle ausrichten:
```c#
// Creates an instance of the Presentation class
Presentation presentation = new Presentation();

// Gets the first slide 
ISlide slide = presentation.Slides[0];

// Defines columns with widths and rows with heights
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// Adds the table shape to the slide
ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
tbl[1, 0].TextFrame.Text = "10";
tbl[2, 0].TextFrame.Text = "20";
tbl[3, 0].TextFrame.Text = "30";

// Accesses the text frame
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// Creates the Paragraph object for the text frame
IParagraph paragraph = txtFrame.Paragraphs[0];

// Creates the Portion object for paragraph
IPortion portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Aligns the text vertically
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// Saves the presentation to disk
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```


## **Set Text Formatting on Table Level**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich eine Referenz auf die Folie über ihren Index.  
3. Greifen Sie vom Slide ein [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)‑Objekt ab.  
4. Setzen Sie die [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) für den Text.  
5. Setzen Sie die [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) und [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/).  
6. Setzen Sie den [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/).  
7. Speichern Sie die geänderte Präsentation.

Dieser C#‑Code zeigt, wie Sie Ihre bevorzugten Formatierungsoptionen auf den Text in einer Tabelle anwenden:
```c#
// Erstellt eine Instanz der Presentation-Klasse
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Wir gehen davon aus, dass das erste Shape auf der ersten Folie eine Tabelle ist

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


## **Get Table Style Properties**
Aspose.Slides ermöglicht das Abrufen der Stil‑Eigenschaften einer Tabelle, sodass Sie diese Details für eine andere Tabelle oder an anderer Stelle verwenden können. Dieser C#‑Code zeigt, wie Sie die Stil‑Eigenschaften aus einem Tabellenvorlagenstil erhalten:
```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // ändert das Standard‑Stil‑Preset 
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```


## **Lock Aspect Ratio of Table**
Das Seitenverhältnis einer geometrischen Form ist das Verhältnis ihrer Größen in verschiedenen Dimensionen. Aspose.Slides stellt die Eigenschaft `AspectRatioLocked` bereit, um das Seitenverhältnis von Tabellen und anderen Formen zu sperren.

Dieser C#‑Code zeigt, wie Sie das Seitenverhältnis einer Tabelle sperren:
```c#
using (Presentation pres = new Presentation("pres.pptx"))
{
    ITable table = (ITable)pres.Slides[0].Shapes[0];
    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    table.ShapeLock.AspectRatioLocked = !table.ShapeLock.AspectRatioLocked; // invertieren

    Console.WriteLine($"Lock aspect ratio set: {table.ShapeLock.AspectRatioLocked}");

    pres.Save("pres-out.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Can I enable right-to-left (RTL) reading direction for an entire table and the text in its cells?**  
Ja. Die Tabelle stellt die [RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/table/righttoleft/)‑Eigenschaft bereit, und Absätze besitzen [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/righttoleft/). Die Nutzung beider Eigenschaften stellt die korrekte RTL‑Reihenfolge und -Darstellung innerhalb der Zellen sicher.

**How can I prevent users from moving or resizing a table in the final file?**  
Verwenden Sie [shape locks](/slides/de/net/applying-protection-to-presentation/), um das Verschieben, Ändern der Größe, Auswählen usw. zu deaktivieren. Diese Sperren gelten auch für Tabellen.

**Is inserting an image inside a cell as a background supported?**  
Ja. Sie können für eine Zelle eine [picture fill](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) festlegen; das Bild füllt die Zelle gemäß dem gewählten Modus (Strecken oder Kacheln).