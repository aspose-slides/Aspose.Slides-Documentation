---
title: Verwalten von Präsentationstabellen in .NET
linktitle: Tabelle verwalten
type: docs
weight: 10
url: /de/net/manage-table/
keywords:
- Tabelle hinzufügen
- Tabelle erstellen
- Zugriff auf Tabelle
- Seitenverhältnis
- Text ausrichten
- Textformatierung
- Tabellenstil
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Erstellen und Bearbeiten von Tabellen in PowerPoint-Folien mit Aspose.Slides für .NET. Entdecken Sie einfache C#-Beispiele, um Ihre Tabellen-Workflows zu optimieren."
---

Eine Tabelle in PowerPoint ist eine effiziente Möglichkeit, Informationen darzustellen und zu vermitteln. Die Informationen in einem Raster von Zellen (geordnet in Zeilen und Spalten) sind unkompliziert und leicht zu verstehen.

Aspose.Slides stellt die Klasse [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) das Interface [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) die Klasse [Cell](https://reference.aspose.com/slides/net/aspose.slides/cell/) das Interface [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) und weitere Typen zur Verfügung, mit denen Sie Tabellen in allen Arten von Präsentationen erstellen, aktualisieren und verwalten können. 

## **Eine Tabelle von Grund auf erstellen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Holen Sie sich die Referenz einer Folie über deren Index. 
3. Definieren Sie ein Array von `columnWidth`.
4. Definieren Sie ein Array von `rowHeight`.
5. Fügen Sie ein [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) Objekt der Folie über die Methode [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) hinzu.
6. Iterieren Sie über jedes [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) , um die Formatierung der oberen, unteren, rechten und linken Ränder anzuwenden.
7. Fassen Sie die ersten beiden Zellen der ersten Zeile der Tabelle zusammen. 
8. Greifen Sie auf die [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) eines [ICell](https://reference.aspose.com/slides/net/aspose.slides/icell/) zu.
9. Fügen Sie dem [TextFrame](https://reference.aspose.com/slides/net/aspose.slides/textframe/) etwas Text hinzu.
10. Speichern Sie die geänderte Präsentation.

Dieser C#‑Code zeigt, wie Sie eine Tabelle in einer Präsentation erstellen:
```c#
// Instanziiert eine Presentation-Klasse, die eine PPTX-Datei repräsentiert
Presentation pres = new Presentation();

// Greift auf die erste Folie zu
ISlide sld = pres.Slides[0];

// Definiert Spalten mit Breiten und Zeilen mit Höhen
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// Fügt der Folie ein Tabellen-Shape hinzu
ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

// Legt das Rahmenformat für jede Zelle fest
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
// Führt die Zellen 1 und 2 der Zeile 1 zusammen
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[1][1], false);

// Fügt dem zusammengeführten Feld etwas Text hinzu
tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

// Speichert die Präsentation auf dem Datenträger
pres.Save("table.pptx", SaveFormat.Pptx);
```


## **Nummerierung in einer Standardtabelle**

In einer Standardtabelle erfolgt die Nummerierung der Zellen eindeutig und nullbasiert. Die erste Zelle einer Tabelle hat den Index 0,0 (Spalte 0, Zeile 0). 

Beispielsweise werden die Zellen einer Tabelle mit 4 Spalten und 4 Zeilen wie folgt nummeriert:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Dieser C#‑Code zeigt, wie Sie die Nummerierung der Zellen in einer Tabelle festlegen:
```c#
// Instanziiert eine Presentation-Klasse, die eine PPTX-Datei darstellt
using (Presentation pres = new Presentation())
{

    // Greift auf die erste Folie zu
    ISlide sld = pres.Slides[0];

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Fügt der Folie ein Tabellen-Shape hinzu
    ITable tbl = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Legt das Rahmenformat für jede Zelle fest
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

    // Speichert die Präsentation auf dem Datenträger
    pres.Save("StandardTables_out.pptx", SaveFormat.Pptx);
}
```


## **Zugriff auf eine vorhandene Tabelle**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Holen Sie sich eine Referenz zur Folie, die die Tabelle enthält, über deren Index. 
3. Erstellen Sie ein [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) Objekt und setzen Sie es auf null.
4. Iterieren Sie über alle [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) Objekte, bis die Tabelle gefunden ist.

   Wenn Sie vermuten, dass die Folie, mit der Sie arbeiten, nur eine einzelne Tabelle enthält, können Sie einfach alle enthaltenen Formen überprüfen. Wird eine Form als Tabelle identifiziert, können Sie sie zu einem [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) Objekt casten. Enthält die Folie jedoch mehrere Tabellen, sollten Sie besser die gewünschte Tabelle über deren [AlternativeText](https://reference.aspose.com/slides/net/aspose.slides/ishape/alternativetext/) suchen.

5. Verwenden Sie das [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) Objekt, um mit der Tabelle zu arbeiten. Im folgenden Beispiel haben wir der Tabelle eine neue Zeile hinzugefügt.
6. Speichern Sie die geänderte Präsentation.

Dieser C#‑Code zeigt, wie Sie auf eine vorhandene Tabelle zugreifen und mit ihr arbeiten:
```c#
// Instanziiert eine Presentation-Klasse, die eine PPTX-Datei darstellt
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // Greift auf die erste Folie zu
    ISlide sld = pres.Slides[0];

    // Initialisiert TableEx mit null
    ITable tbl = null;

    // Durchläuft die Shapes und setzt eine Referenz auf die gefundene Tabelle
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // Setzt den Text für die erste Spalte der zweiten Zeile
    tbl[0, 1].TextFrame.Text = "New";

    // Speichert die geänderte Präsentation auf dem Datenträger
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Text in einer Tabelle ausrichten**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation).
2. Holen Sie sich die Referenz einer Folie über deren Index. 
3. Fügen Sie ein [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) Objekt der Folie hinzu. 
4. Greifen Sie auf ein [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) Objekt der Tabelle zu. 
5. Greifen Sie auf das [IParagraph](https://reference.aspose.com/slides/net/aspose.slides/iparagraph/) des [ITextFrame](https://reference.aspose.com/slides/net/aspose.slides/itextframe/) zu.
6. Richten Sie den Text vertikal aus.
7. Speichern Sie die geänderte Präsentation.

Dieser C#‑Code zeigt, wie Sie den Text in einer Tabelle ausrichten:
```c#
// Erstellt eine Instanz der Presentation-Klasse
Presentation presentation = new Presentation();

// Greift auf die erste Folie zu
ISlide slide = presentation.Slides[0];

// Definiert Spalten mit Breiten und Zeilen mit Höhen
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// Fügt der Folie ein Tabellen-Shape hinzu
ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
tbl[1, 0].TextFrame.Text = "10";
tbl[2, 0].TextFrame.Text = "20";
tbl[3, 0].TextFrame.Text = "30";

// Greift auf das Textframe zu
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// Erstellt das Paragraph-Objekt für das Textframe
IParagraph paragraph = txtFrame.Paragraphs[0];

// Erstellt das Portion-Objekt für den Paragraphen
IPortion portion = paragraph.Portions[0];
portion.Text = "Text here";
portion.PortionFormat.FillFormat.FillType = FillType.Solid;
portion.PortionFormat.FillFormat.SolidFillColor.Color = Color.Black;

// Richtet den Text vertikal aus
ICell cell = tbl[0, 0];
cell.TextAnchorType = TextAnchorType.Center;
cell.TextVerticalType = TextVerticalType.Vertical270;

// Speichert die Präsentation auf dem Datenträger
presentation.Save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx);
```


## **Textformatierung auf Tabellenebene festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) Klasse.
2. Holen Sie sich die Referenz einer Folie über deren Index. 
3. Greifen Sie aus der Folie auf ein [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) Objekt zu.
4. Setzen Sie die [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) für den Text. 
5. Setzen Sie die [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) und [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/). 
6. Setzen Sie die [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/).
7. Speichern Sie die geänderte Präsentation. 

Dieser C#‑Code zeigt, wie Sie Ihre bevorzugten Formatierungsoptionen auf den Text in einer Tabelle anwenden:
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


## **Tabellenstil-Eigenschaften abrufen**

Aspose.Slides ermöglicht das Abrufen der Stil‑Eigenschaften einer Tabelle, sodass Sie diese Details für eine andere Tabelle oder an anderer Stelle verwenden können. Dieser C#‑Code zeigt, wie Sie die Stil‑Eigenschaften aus einem vordefinierten Tabellendesign erhalten: 
```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // ändert das standardmäßige Stilvorlagen-Theme
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```


## **Seitenverhältnis einer Tabelle sperren**

Das Seitenverhältnis einer geometrischen Form ist das Verhältnis ihrer Größen in den verschiedenen Dimensionen. Aspose.Slides bietet die Eigenschaft `AspectRatioLocked`, mit der Sie die Einstellung des Seitenverhältnisses für Tabellen und andere Formen sperren können. 

Dieser C#‑Code zeigt, wie Sie das Seitenverhältnis für eine Tabelle sperren:
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

**Kann ich die Leserichtung von rechts nach links (RTL) für eine gesamte Tabelle und den Text in ihren Zellen aktivieren?**

Ja. Die Tabelle stellt die Eigenschaft [RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/table/righttoleft/) bereit, und Absätze besitzen [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/net/aspose.slides/paragraphformat/righttoleft/). Durch die Verwendung beider wird die korrekte RTL‑Reihenfolge und -Darstellung innerhalb der Zellen sichergestellt.

**Wie kann ich verhindern, dass Benutzer eine Tabelle in der endgültigen Datei verschieben oder die Größe ändern?**

Verwenden Sie [shape locks](/slides/de/net/applying-protection-to-presentation/), um das Verschieben, Ändern der Größe, Auswählen usw. zu deaktivieren. Diese Sperren gelten ebenfalls für Tabellen.

**Wird das Einfügen eines Bildes als Hintergrund in einer Zelle unterstützt?**

Ja. Sie können für eine Zelle eine [picture fill](https://reference.aspose.com/slides/net/aspose.slides/picturefillformat/) festlegen; das Bild bedeckt die Zellenfläche gemäß dem gewählten Modus (Strecken oder Kacheln).