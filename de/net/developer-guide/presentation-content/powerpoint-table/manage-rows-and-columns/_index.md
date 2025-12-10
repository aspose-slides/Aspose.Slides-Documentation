---
title: Verwalten von Zeilen und Spalten in PowerPoint-Tabellen in .NET
linktitle: Zeilen und Spalten
type: docs
weight: 20
url: /de/net/manage-rows-and-columns/
keywords:
- Tabellenzeile
- Tabellenspalte
- Erste Zeile
- Tabellenkopfzeile
- Zeile klonen
- Spalte klonen
- Zeile kopieren
- Spalte kopieren
- Zeile entfernen
- Spalte entfernen
- Textformatierung der Zeile
- Textformatierung der Spalte
- Tabellenstil
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Verwalten Sie Tabellenzeilen und -spalten in PowerPoint mit Aspose.Slides für .NET und beschleunigen Sie die Bearbeitung von Präsentationen sowie Datenaktualisierungen."
---

Um Ihnen die Verwaltung von Zeilen und Spalten einer Tabelle in einer PowerPoint‑Präsentation zu ermöglichen, stellt Aspose.Slides die Klasse [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) und das Interface [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) sowie viele andere Typen bereit. 

## **Erste Zeile als Kopfzeile festlegen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) und laden Sie die Präsentation. 
2. Rufen Sie die Referenz einer Folie über ihren Index ab. 
3. Erstellen Sie ein [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)‑Objekt und setzen Sie es auf null. 
4. Iterieren Sie über alle [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/)‑Objekte, um die betreffende Tabelle zu finden. 
5. Legen Sie die erste Zeile der Tabelle als Kopfzeile fest. 

Dieser C#‑Code zeigt, wie Sie die erste Zeile einer Tabelle als Kopfzeile festlegen:
```c#
// Instanziiert die Presentation‑Klasse
Presentation pres = new Presentation("table.pptx");

// Greift auf die erste Folie zu
ISlide sld = pres.Slides[0];

// Initialisiert das null TableEx
ITable tbl = null;

// Durchläuft die Shapes und setzt eine Referenz zur Tabelle
foreach (IShape shp in sld.Shapes)
{
    if (shp is ITable)
    {
        tbl = (ITable)shp;
    }
}

// Setzt die erste Zeile einer Tabelle als Kopfzeile
tbl.FirstRow = true;

// Speichert die Präsentation auf dem Datenträger
pres.Save("First_row_header.pptx", SaveFormat.Pptx);
```


## **Kopieren einer Tabellenzeile oder -spalte**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) und laden Sie die Präsentation, 
2. Rufen Sie die Referenz einer Folie über ihren Index ab. 
3. Definieren Sie ein Array von `columnWidth`. 
4. Definieren Sie ein Array von `rowHeight`. 
5. Fügen Sie der Folie ein [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)‑Objekt mittels der Methode [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) hinzu. 
6. Kopieren Sie die Tabellenzeile. 
7. Kopieren Sie die Tabellenspalte. 
8. Speichern Sie die modifizierte Präsentation. 

Dieser C#‑Code zeigt, wie Sie eine Zeile oder Spalte einer PowerPoint‑Tabelle kopieren:
```c#
 // Instanziiert die Presentation‑Klasse
using (Presentation presentation = new Presentation("Test.pptx"))
{
    // Greift auf die erste Folie zu
    ISlide sld = presentation.Slides[0];

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Fügt der Folie ein Tabellen‑Shape hinzu
    ITable table = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Fügt Text zur Zeile 1, Zelle 1 hinzu
    table[0, 0].TextFrame.Text = "Row 1 Cell 1";

    // Fügt Text zur Zeile 1, Zelle 2 hinzu
    table[1, 0].TextFrame.Text = "Row 1 Cell 2";

    // Klont Zeile 1 am Ende der Tabelle
    table.Rows.AddClone(table.Rows[0], false);

    // Fügt Text zur Zeile 2, Zelle 1 hinzu
    table[0, 1].TextFrame.Text = "Row 2 Cell 1";

    // Fügt Text zur Zeile 2, Zelle 2 hinzu
    table[1, 1].TextFrame.Text = "Row 2 Cell 2";

    // Klont Zeile 2 als vierte Zeile der Tabelle
    table.Rows.InsertClone(3,table.Rows[1], false);

    // Klont die erste Spalte am Ende
    table.Columns.AddClone(table.Columns[0], false);

    // Klont die zweite Spalte an Index 4
    table.Columns.InsertClone(3,table.Columns[1], false);
    
    // Speichert die Präsentation auf dem Datenträger 
    presentation.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Entfernen einer Zeile oder Spalte aus einer Tabelle**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) und laden Sie die Präsentation, 
2. Rufen Sie die Referenz einer Folie über ihren Index ab. 
3. Definieren Sie ein Array von `columnWidth`. 
4. Definieren Sie ein Array von `rowHeight`. 
5. Fügen Sie der Folie ein [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)‑Objekt mittels der Methode [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) hinzu. 
6. Entfernen Sie die Tabellenzeile. 
7. Entfernen Sie die Tabellenspalte. 
8. Speichern Sie die modifizierte Präsentation. 

Dieser C#‑Code zeigt, wie Sie eine Zeile oder Spalte aus einer Tabelle entfernen:
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

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) und laden Sie die Präsentation, 
2. Rufen Sie die Referenz einer Folie über ihren Index ab. 
3. Greifen Sie auf das relevante [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)‑Objekt der Folie zu. 
4. Setzen Sie die [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) der Zellen in der ersten Zeile. 
5. Setzen Sie die [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) und [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) der Zellen in der ersten Zeile. 
6. Setzen Sie den [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) der Zellen in der zweiten Zeile. 
7. Speichern Sie die modifizierte Präsentation. 

Dieser C#‑Code demonstriert den Vorgang.
```c#
 // Erzeugt eine Instanz der Presentation-Klasse
Presentation presentation = new Presentation();
           
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Nehmen wir an, dass die erste Form auf der ersten Folie eine Tabelle ist

// Setzt die Schrifthöhe der Zellen in der ersten Zeile
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Rows[0].SetTextFormat(portionFormat);

// Setzt die Textausrichtung und den rechten Rand der Zellen in der ersten Zeile
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Rows[0].SetTextFormat(paragraphFormat);

// Setzt den Textvertikaltyp der Zellen in der zweiten Zeile
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Rows[1].SetTextFormat(textFrameFormat);

// Speichert die Präsentation auf dem Datenträger
presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **Textformatierung auf Tabellenspaltenebene festlegen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) und laden Sie die Präsentation, 
2. Rufen Sie die Referenz einer Folie über ihren Index ab. 
3. Greifen Sie auf das relevante [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/)‑Objekt der Folie zu. 
4. Setzen Sie die [FontHeight](https://reference.aspose.com/slides/net/aspose.slides/baseportionformat/fontheight/) der Zellen in der ersten Spalte. 
5. Setzen Sie die [Alignment](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/alignment/) und [MarginRight](https://reference.aspose.com/slides/net/aspose.slides/iparagraphformat/marginright/) der Zellen in der ersten Spalte. 
6. Setzen Sie den [TextVerticalType](https://reference.aspose.com/slides/net/aspose.slides/textframeformat/textverticaltype/) der Zellen in der zweiten Spalte. 
7. Speichern Sie die modifizierte Präsentation. 

Dieser C#‑Code demonstriert den Vorgang: 
```c#
// Erstellt eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
           
ISlide slide = pres.Slides[0];

ITable someTable = pres.Slides[0].Shapes[0] as ITable; // Angenommen, die erste Form auf der ersten Folie ist eine Tabelle

// Setzt die Schrifthöhe der Zellen in der ersten Spalte
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Columns[0].SetTextFormat(portionFormat);

// Setzt die Textausrichtung und den rechten Rand der Zellen in der ersten Spalte in einem Aufruf
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Columns[0].SetTextFormat(paragraphFormat);

// Setzt den Textvertikaltyp der Zellen in der zweiten Spalte
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Columns[1].SetTextFormat(textFrameFormat);

// Speichert die Präsentation auf dem Datenträger
pres.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **Tabellenstil‑Eigenschaften abrufen**

Aspose.Slides ermöglicht das Abrufen der Stil‑Eigenschaften einer Tabelle, sodass Sie diese Details für eine andere Tabelle oder an anderer Stelle verwenden können. Dieser C#‑Code zeigt, wie Sie die Stil‑Eigenschaften aus einem vordefinierten Tabellenstil erhalten: 
```c#
using (Presentation pres = new Presentation())
{
    ITable table = pres.Slides[0].Shapes.AddTable(10, 10, new double[] { 100, 150 }, new double[] { 5, 5, 5 });
    table.StylePreset = TableStylePreset.DarkStyle1; // ändert das Standard-Stil-Preset-Theme
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Kann ich bereits erstellte Tabellen mit PowerPoint‑Themen/‑Stilen versehen?**

Ja. Die Tabelle erbt das Thema der Folie/Layout/Master, und Sie können dennoch Füllungen, Rahmen und Textfarben über diesem Thema überschreiben.

**Kann ich Tabellenzeilen wie in Excel sortieren?**

Nein, Tabellen von Aspose.Slides besitzen keine integrierte Sortierung oder Filter. Sortieren Sie Ihre Daten zunächst im Speicher und füllen Sie anschließend die Tabellenzeilen in dieser Reihenfolge neu.

**Kann ich gestreifte Spalten haben und gleichzeitig benutzerdefinierte Farben für bestimmte Zellen beibehalten?**

Ja. Aktivieren Sie gestreifte Spalten und überschreiben Sie dann bestimmte Zellen mit lokaler Formatierung; die Zellen‑Formatierung hat Vorrang vor dem Tabellenstil.