---
title: Verwalten von Zeilen und Spalten
type: docs
weight: 20
url: /net/manage-rows-and-columns/
keywords: "Tabelle, Tabellenzeilen und -spalten, PowerPoint-Präsentation, C#, Csharp, Aspose.Slides für .NET"
description: "Verwalten von Tabellenzeilen und -spalten in PowerPoint-Präsentationen in C# oder .NET"

---

Um Ihnen die Verwaltung der Zeilen und Spalten einer Tabelle in einer PowerPoint-Präsentation zu ermöglichen, bietet Aspose.Slides die [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) Klasse, das [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) Interface und viele andere Typen an.

## **Erste Zeile als Header festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse und laden Sie die Präsentation. 
2. Holen Sie sich den Verweis auf eine Folie über ihren Index. 
3. Erstellen Sie ein [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) Objekt und setzen Sie es auf null.
4. Durchlaufen Sie alle [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/) Objekte, um die relevante Tabelle zu finden. 
5. Setzen Sie die erste Zeile der Tabelle als Header.

Dieser C#-Code zeigt Ihnen, wie Sie die erste Zeile einer Tabelle als Header festlegen:

```c#
// Erstellt eine Instanz der Presentation-Klasse
Presentation pres = new Presentation("table.pptx");

// Greift auf die erste Folie zu
ISlide sld = pres.Slides[0];

// Initialisiert die null TableEx
ITable tbl = null;

// Durchläuft die Formen und setzt einen Verweis auf die Tabelle
foreach (IShape shp in sld.Shapes)
{
    if (shp is ITable)
    {
        tbl = (ITable)shp;
    }
}

// Setzt die erste Zeile einer Tabelle als Header
tbl.FirstRow = true;

// Speichert die Präsentation auf der Festplatte
pres.Save("First_row_header.pptx", SaveFormat.Pptx);
```


## **Zeile oder Spalte der Tabelle klonen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse und laden Sie die Präsentation, 
2. Holen Sie sich den Verweis auf eine Folie über ihren Index. 
3. Definieren Sie ein Array von `columnWidth`.
4. Definieren Sie ein Array von `rowHeight`.
5. Fügen Sie ein [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) Objekt zur Folie über die [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) Methode hinzu.
6. Klonen Sie die Tabellenzeile.
7. Klonen Sie die Tabellenspalte.
8. Speichern Sie die modifizierte Präsentation.

Dieser C#-Code zeigt Ihnen, wie Sie eine Zeile oder Spalte einer PowerPoint-Tabelle klonen:

```c#
// Erstellt eine Instanz der Presentation-Klasse
using (Presentation presentation = new Presentation("Test.pptx"))
{
    // Greift auf die erste Folie zu
    ISlide sld = presentation.Slides[0];

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Fügt eine Tabellenform zur Folie hinzu
    ITable table = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Fügt etwas Text zur Zelle 1 in Zeile 1 hinzu
    table[0, 0].TextFrame.Text = "Zeile 1 Zelle 1";

    // Fügt etwas Text zur Zelle 2 in Zeile 1 hinzu
    table[1, 0].TextFrame.Text = "Zeile 1 Zelle 2";

    // Klont Zeile 1 am Ende der Tabelle
    table.Rows.AddClone(table.Rows[0], false);

    // Fügt etwas Text zur Zelle 1 in Zeile 2 hinzu
    table[0, 1].TextFrame.Text = "Zeile 2 Zelle 1";

    // Fügt etwas Text zur Zelle 2 in Zeile 2 hinzu
    table[1, 1].TextFrame.Text = "Zeile 2 Zelle 2";

    // Klont Zeile 2 als 4. Zeile der Tabelle
    table.Rows.InsertClone(3, table.Rows[1], false);

    // Klont die erste Spalte am Ende
    table.Columns.AddClone(table.Columns[0], false);

    // Klont die 2. Spalte an der 4. Spaltenposition
    table.Columns.InsertClone(3, table.Columns[1], false);
    
    // Speichert die Präsentation auf der Festplatte 
    presentation.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```

## **Zeile oder Spalte aus der Tabelle entfernen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse und laden Sie die Präsentation, 
2. Holen Sie sich den Verweis auf eine Folie über ihren Index. 
3. Definieren Sie ein Array von `columnWidth`.
4. Definieren Sie ein Array von `rowHeight`.
5. Fügen Sie ein [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) Objekt zur Folie über die [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) Methode hinzu.
6. Entfernen Sie die Tabellenzeile.
7. Entfernen Sie die Tabellenspalte.
8. Speichern Sie die modifizierte Präsentation. 

Dieser C#-Code zeigt Ihnen, wie Sie eine Zeile oder Spalte aus einer Tabelle entfernen:

```c#
Presentation pres = new Presentation();

ISlide slide = pres.Slides[0];
double[] colWidth = { 100, 50, 30 };
double[] rowHeight = { 30, 50, 30 };

ITable table = slide.Shapes.AddTable(100, 100, colWidth, rowHeight);
table.Rows.RemoveAt(1, false);
table.Columns.RemoveAt(1, false);
pres.Save("TestTable_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Textformatierung auf Tabellenzeilenebene festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse und laden Sie die Präsentation, 
2. Holen Sie sich den Verweis auf eine Folie über ihren Index. 
3. Greifen Sie auf das relevante [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) Objekt von der Folie zu. 
4. Legen Sie die [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) der Zellen in der ersten Zeile fest. 
5. Legen Sie die [Ausrichtung](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) und den [Rechtsabstand](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) der Zellen in der ersten Zeile fest. 
6. Legen Sie den [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) der Zellen in der zweiten Zeile fest.
7. Speichern Sie die modifizierte Präsentation.

Dieser C#-Code zeigt den Vorgang.

```c#
// Erstellt eine Instanz der Presentation-Klasse
Presentation presentation = new Presentation();
           
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Angenommen, die erste Form auf der ersten Folie ist eine Tabelle

// Legt die Schriftgröße der Zellen in der ersten Zeile fest
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Rows[0].SetTextFormat(portionFormat);

// Legt die Textausrichtung und den rechten Rand der Zellen in der ersten Zeile fest
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Rows[0].SetTextFormat(paragraphFormat);

// Legt den vertikalen Texttyp der Zellen in der zweiten Zeile fest
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Rows[1].SetTextFormat(textFrameFormat);

// Speichert die Präsentation auf der Festplatte
presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```

## **Textformatierung auf Tabellen-Spaltenebene festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) Klasse und laden Sie die Präsentation, 
2. Holen Sie sich den Verweis auf eine Folie über ihren Index. 
3. Greifen Sie auf das relevante [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) Objekt von der Folie zu. 
4. Legen Sie die [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) der Zellen in der ersten Spalte fest. 
5. Legen Sie die [Ausrichtung](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) und den [Rechtsabstand](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) der Zellen in der ersten Spalte fest. 
6. Legen Sie den [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) der Zellen in der zweiten Spalte fest.
7. Speichern Sie die modifizierte Präsentation. 

Dieser C#-Code zeigt den Vorgang: 

```c#
// Erstellt eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
           
ISlide slide = pres.Slides[0];

ITable someTable = pres.Slides[0].Shapes[0] as ITable; // Angenommen, die erste Form auf der ersten Folie ist eine Tabelle

// Legt die Schriftgröße der Zellen in der ersten Spalte fest
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Columns[0].SetTextFormat(portionFormat);

// Legt die Textausrichtung und den rechten Rand der Zellen in der ersten Spalte in einem Aufruf fest
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Columns[0].SetTextFormat(paragraphFormat);

// Legt den vertikalen Texttyp der Zellen in der zweiten Spalte fest
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Columns[1].SetTextFormat(textFrameFormat);

// Speichert die Präsentation auf der Festplatte
pres.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);

```

## **Tabellenstil-Eigenschaften abrufen**

Aspose.Slides ermöglicht es Ihnen, die Stileigenschaften für eine Tabelle abzurufen, damit Sie diese Details für eine andere Tabelle oder an anderer Stelle verwenden können. Dieser C#-Code zeigt Ihnen, wie Sie die Stileigenschaften aus einem vordefinierten Tabellenstil abrufen: 

```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // Ändert das standardmäßige Stilvorlagenthema 
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```