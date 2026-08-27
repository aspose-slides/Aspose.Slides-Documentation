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
description: "Tabellen in PowerPoint‑Folien mit Aspose.Slides für .NET erstellen und bearbeiten. Entdecken Sie einfache C#‑Codebeispiele, um Ihre Tabellenvorgänge zu optimieren."
---
## **Einleitung**

Eine Tabelle in PowerPoint ist ein effizientes Mittel, Informationen darzustellen und zu präsentieren. Die Informationen in einem Raster von Zellen (angeordnet in Zeilen und Spalten) sind übersichtlich und leicht zu verstehen.

Aspose.Slides stellt die [Table](https://reference.aspose.com/slides/de/net/aspose.slides/table/)‑Klasse, das [ITable](https://reference.aspose.com/slides/de/net/aspose.slides/itable/)‑Interface, die [Cell](https://reference.aspose.com/slides/de/net/aspose.slides/cell/)‑Klasse, das [ICell](https://reference.aspose.com/slides/de/net/aspose.slides/icell/)‑Interface und weitere Typen bereit, mit denen Sie Tabellen in allen Arten von Präsentationen erstellen, aktualisieren und verwalten können. 

## **Eine Tabelle von Grund auf erstellen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation).
2. Holen Sie die Referenz einer Folie über ihren Index. 
3. Definieren Sie ein Array von `columnWidth`.
4. Definieren Sie ein Array von `rowHeight`.
5. Fügen Sie der Folie ein [ITable](https://reference.aspose.com/slides/de/net/aspose.slides/itable/)‑Objekt über die Methode [AddTable](https://reference.aspose.com/slides/de/net/aspose.slides/ishapecollection/addtable/) hinzu.
6. Durchlaufen Sie jedes [ICell](https://reference.aspose.com/slides/de/net/aspose.slides/icell/), um die Formatierung der oberen, unteren, rechten und linken Ränder anzuwenden.
7. Führen Sie die ersten beiden Zellen der ersten Tabellenzeile zusammen. 
8. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/textframe/) eines [ICell](https://reference.aspose.com/slides/de/net/aspose.slides/icell/) zu. 
9. Fügen Sie dem [TextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/textframe/) Text hinzu.
10. Speichern Sie die geänderte Präsentation.

Dieser C#‑Code zeigt, wie Sie eine Tabelle in einer Präsentation erstellen:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziiert eine Presentation‑Klasse, die eine PPTX‑Datei darstellt
Presentation pres = new Presentation();

// Greift auf die erste Folie zu
ISlide sld = pres.Slides[0];

// Definiert Spalten mit Breiten und Zeilen mit Höhen
double[] dblCols = { 50, 50, 50 };
double[] dblRows = { 50, 30, 30, 30, 30 };

// Fügt der Folie ein Tabellen‑Shape hinzu
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
// Fügt Zellen 1 und 2 der Zeile 1 zusammen
tbl.MergeCells(tbl.Rows[0][0], tbl.Rows[0][1], false);

// Fügt der zusammengeführten Zelle Text hinzu
tbl.Rows[0][0].TextFrame.Text = "Merged Cells";

// Speichert die Präsentation auf dem Datenträger
pres.Save("table.pptx", SaveFormat.Pptx);
```

## **Nummerierung in einer Standardsabelle**

In einer Standardsabelle ist die Nummerierung der Zellen einfach und nullbasiert. Die erste Zelle einer Tabelle hat den Index 0,0 (Spalte 0, Zeile 0). 

Beispielsweise werden die Zellen in einer Tabelle mit 4 Spalten und 4 Zeilen wie folgt nummeriert:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Dieser C#‑Code erzeugt die oben nummerierte Standard‑4 × 4‑Tabelle und legt das Randformat für jede ihrer Zellen fest:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Instanziiert eine Presentation‑Klasse, die eine PPTX‑Datei darstellt
using (Presentation pres = new Presentation())
{

    // Greift auf die erste Folie zu
    ISlide sld = pres.Slides[0];

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 70, 70, 70, 70 };
    double[] dblRows = { 70, 70, 70, 70 };

    // Fügt der Folie ein Tabellen‑Shape hinzu
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

    // Speichert die Präsentation auf dem Datenträger
    pres.Save("StandardTables_out.pptx", SaveFormat.Pptx);
}
```

## **Zugriff auf eine vorhandene Tabelle**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation).
2. Holen Sie eine Referenz zur Folie, die die Tabelle enthält, über ihren Index. 
3. Erstellen Sie ein [ITable](https://reference.aspose.com/slides/de/net/aspose.slides/itable/)‑Objekt und setzen Sie es auf `null`.
4. Durchlaufen Sie alle [IShape](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/)‑Objekte, bis die Tabelle gefunden wird.

   Wenn Sie vermuten, dass die betreffende Folie nur eine einzige Tabelle enthält, können Sie einfach alle enthaltenen Formen prüfen. Wird eine Form als Tabelle identifiziert, können Sie sie in ein [Table](https://reference.aspose.com/slides/de/net/aspose.slides/table/)‑Objekt umwandeln. Enthält die Folie jedoch mehrere Tabellen, ist es besser, die gewünschte Tabelle über ihren [AlternativeText](https://reference.aspose.com/slides/de/net/aspose.slides/ishape/alternativetext/) zu suchen.

5. Verwenden Sie das [ITable](https://reference.aspose.com/slides/de/net/aspose.slides/itable/)‑Objekt, um mit der Tabelle zu arbeiten. Im nachfolgenden Beispiel haben wir der Tabelle eine neue Zeile hinzugefügt.
6. Speichern Sie die geänderte Präsentation.

Dieser C#‑Code zeigt, wie Sie auf eine vorhandene Tabelle zugreifen und mit ihr arbeiten:

```c#
using Aspose.Slides;

// Instanziiert eine Presentation‑Klasse, die eine PPTX‑Datei darstellt
using (Presentation pres = new Presentation("UpdateExistingTable.pptx"))
{

    // Greift auf die erste Folie zu
    ISlide sld = pres.Slides[0];

    // Initialisiert null TableEx
    ITable tbl = null;

    // Durchläuft die Formen und setzt eine Referenz auf die gefundene Tabelle
    foreach (IShape shp in sld.Shapes)
        if (shp is ITable)
            tbl = (ITable)shp;

    // Setzt den Text für die erste Spalte der zweiten Zeile
    tbl[0, 1].TextFrame.Text = "New";

    // Speichert die geänderte Präsentation auf dem Datenträger
    pres.Save("table1_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Finden Sie die Zelle, die einen TextFrame besitzt**

Wenn generischer Text‑Verarbeitungscode ein [ITextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/) einer Tabelle erhält, verwenden Sie die Eigenschaft [ITextFrame.ParentCell](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/parentcell/), um die zugehörige [ICell](https://reference.aspose.com/slides/de/net/aspose.slides/icell/) zu ermitteln. Für ein TextFrame einer Tabellenzelle ist [ITextFrame.ParentCell](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/parentcell/) gesetzt und [ITextFrame.ParentShape](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/parentshape/) ist `null`, obwohl die Tabelle selbst eine Form ist.

Die Zellkoordinaten stehen über die schreibgeschützten Eigenschaften [ICell.FirstColumnIndex](https://reference.aspose.com/slides/de/net/aspose.slides/icell/firstcolumnindex/) und [ICell.FirstRowIndex](https://reference.aspose.com/slides/de/net/aspose.slides/icell/firstrowindex/) zur Verfügung. [ITextFrame.ParentCell](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/parentcell/) ist ebenfalls schreibgeschützt: Sie bietet eine Navigation zum Besitzer, ändert jedoch nicht den Besitz. Prüfen Sie stets, ob die zurückgegebene Zelle `null` ist, bevor Sie sie verwenden.

Ein vollständiges Beispiel, das Tabellen‑Zell‑ und Form‑Besitzer (einschließlich Formen, die zu SmartArt‑Knoten gehören) identifiziert, finden Sie unter [Search and Replace Text](/slides/de/net/search-and-replace-text/).

## **Text in einer Tabelle ausrichten**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation).
2. Holen Sie die Referenz einer Folie über ihren Index. 
3. Fügen Sie der Folie ein [ITable](https://reference.aspose.com/slides/de/net/aspose.slides/itable/)‑Objekt hinzu. 
4. Greifen Sie von der Tabelle aus auf ein [ITextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/)‑Objekt zu. 
5. Greifen Sie auf das [IParagraph](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraph/) des [ITextFrame](https://reference.aspose.com/slides/de/net/aspose.slides/itextframe/) zu.
6. Richten Sie den Text vertikal aus.
7. Speichern Sie die geänderte Präsentation.

Dieser C#‑Code zeigt, wie Sie den Text in einer Tabelle ausrichten:

```c#
using System.Drawing;
using Aspose.Slides;
using Aspose.Slides.Export;

// Erstellt eine Instanz der Presentation‑Klasse
Presentation presentation = new Presentation();

// Holt die erste Folie 
ISlide slide = presentation.Slides[0];

// Definiert Spalten mit Breiten und Zeilen mit Höhen
double[] dblCols = { 120, 120, 120, 120 };
double[] dblRows = { 100, 100, 100, 100 };

// Fügt das Tabellen‑Shape zur Folie hinzu
ITable tbl = slide.Shapes.AddTable(100, 50, dblCols, dblRows);
tbl[1, 0].TextFrame.Text = "10";
tbl[2, 0].TextFrame.Text = "20";
tbl[3, 0].TextFrame.Text = "30";

// Greift auf das TextFrame zu
ITextFrame txtFrame = tbl[0, 0].TextFrame;

// Erstellt das Paragraph‑Objekt für das TextFrame
IParagraph paragraph = txtFrame.Paragraphs[0];

// Erstellt das Portion‑Objekt für das Paragraph
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

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/net/aspose.slides/presentation/)‑Klasse.
2. Holen Sie die Referenz einer Folie über ihren Index. 
3. Greifen Sie von der Folie aus auf ein [ITable](https://reference.aspose.com/slides/de/net/aspose.slides/itable/)‑Objekt zu.
4. Setzen Sie die [FontHeight](https://reference.aspose.com/slides/de/net/aspose.slides/baseportionformat/fontheight/) für den Text. 
5. Stellen Sie die [Alignment](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/alignment/) und [MarginRight](https://reference.aspose.com/slides/de/net/aspose.slides/iparagraphformat/marginright/) ein. 
6. Setzen Sie den [TextVerticalType](https://reference.aspose.com/slides/de/net/aspose.slides/textframeformat/textverticaltype/).
7. Speichern Sie die geänderte Präsentation. 

Dieser C#‑Code zeigt, wie Sie Ihre bevorzugten Formatierungsoptionen auf den Text einer Tabelle anwenden:

```c#
using Aspose.Slides;

// Erstellt eine Instanz der Presentation‑Klasse
Presentation presentation = new Presentation();
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Nehmen wir an, dass die erste Form auf der ersten Folie eine Tabelle ist

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

## **Tabellenstil‑Eigenschaften abrufen**

Aspose.Slides ermöglicht das Abrufen der Stil‑Eigenschaften einer Tabelle, sodass Sie diese Details für eine andere Tabelle oder an anderer Stelle verwenden können. Dieser C#‑Code zeigt, wie Sie die Stil‑Eigenschaften aus einem vordefinierten Tabellensstil erhalten: 

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // ändert das Standard-Stil-Preset-Thema 

    // Lese das Stil-Preset der Tabelle.
    TableStylePreset stylePreset = table.StylePreset;
    Console.WriteLine($"Table style preset: {stylePreset}");

    // Wendet das abgerufene Stil-Preset auf eine andere Tabelle an.
    ITable anotherTable = pres.Slides[0].Shapes.AddTable(10, 100, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    anotherTable.StylePreset = stylePreset;

    pres.Save("table.pptx", SaveFormat.Pptx);
}
```

## **Seitenverhältnis einer Tabelle sperren**

Das Seitenverhältnis einer geometrischen Form ist das Verhältnis ihrer Größen in verschiedenen Dimensionen. Aspose.Slides stellt die Eigenschaft `AspectRatioLocked` bereit, mit der Sie die Einstellung des Seitenverhältnisses für Tabellen und andere Formen sperren können. 

Dieser C#‑Code zeigt, wie Sie das Seitenverhältnis für eine Tabelle sperren:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

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

**Kann ich die Rechts-nach-Links-Lesrichtung (RTL) für eine gesamte Tabelle und den Text in ihren Zellen aktivieren?**

Ja. Die Tabelle stellt die Eigenschaft [RightToLeft](https://reference.aspose.com/slides/de/net/aspose.slides/table/righttoleft/) bereit, und Absätze besitzen [ParagraphFormat.RightToLeft](https://reference.aspose.com/slides/de/net/aspose.slides/paragraphformat/righttoleft/). Die Kombination beider sorgt für die korrekte RTL‑Reihenfolge und Darstellung innerhalb der Zellen.

**Wie kann ich verhindern, dass Benutzer eine Tabelle in der endgültigen Datei verschieben oder die Größe ändern?**

Verwenden Sie [shape locks](/slides/de/net/applying-protection-to-presentation/), um das Verschieben, Ändern der Größe, Auswählen usw. zu deaktivieren. Diese Sperren gelten auch für Tabellen.

**Wird das Einfügen eines Bildes als Hintergrund in einer Zelle unterstützt?**

Ja. Sie können für eine Zelle eine [picture fill](https://reference.aspose.com/slides/de/net/aspose.slides/picturefillformat/) festlegen; das Bild deckt den Zellenbereich entsprechend dem gewählten Modus (Dehnen oder Kacheln) ab.