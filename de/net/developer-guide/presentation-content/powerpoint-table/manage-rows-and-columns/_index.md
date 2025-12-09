---
title: Zeilen und Spalten in PowerPoint-Tabellen in .NET verwalten
linktitle: Zeilen und Spalten
type: docs
weight: 20
url: /de/net/manage-rows-and-columns/
keywords:
- Tabellenzeile
- Tabellenspalte
- erste Zeile
- Tabellenkopfzeile
- Zeile klonen
- Spalte klonen
- Zeile kopieren
- Spalte kopieren
- Zeile entfernen
- Spalte entfernen
- Textformatierung für Zeile
- Textformatierung für Spalte
- Tabellenstil
- PowerPoint
- Präsentation
- .NET
- C#
- Aspose.Slides
description: "Verwalten Sie Tabellenzeilen und -spalten in PowerPoint mit Aspose.Slides für .NET und beschleunigen Sie das Bearbeiten von Präsentationen sowie Datenaktualisierungen."
---

Um die Zeilen und Spalten einer Tabelle in einer PowerPoint-Präsentation verwalten zu können, stellt Aspose.Slides die Klasse [Table](https://reference.aspose.com/slides/net/aspose.slides/table/) , das Interface [ITable](https://reference.aspose.com/slides/net/aspose.slides/itable/) und viele weitere Typen bereit. 

## **Erste Zeile als Kopfzeile festlegen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) und laden Sie die Präsentation. 
2. Rufen Sie über den Index die Referenz einer Folie ab. 
3. Erstellen Sie ein [ITable]-Objekt und setzen Sie es auf null. 
4. Iterieren Sie über alle [IShape](https://reference.aspose.com/slides/net/aspose.slides/ishape/)‑Objekte, um die betreffende Tabelle zu finden. 
5. Legen Sie die erste Zeile der Tabelle als Kopfzeile fest. 

Dieser C#‑Code zeigt, wie Sie die erste Zeile einer Tabelle als Kopfzeile festlegen:
```c#
// Instanziiert die Presentation-Klasse
Presentation pres = new Presentation("table.pptx");

// Greift auf die erste Folie zu
ISlide sld = pres.Slides[0];

// Initialisiert die null TableEx
ITable tbl = null;

// Durchläuft die Shapes und legt eine Referenz auf die Tabelle fest
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


## **Zeile oder Spalte einer Tabelle duplizieren**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) und laden Sie die Präsentation, 
2. Rufen Sie über den Index die Referenz einer Folie ab. 
3. Definieren Sie ein Array von `columnWidth`. 
4. Definieren Sie ein Array von `rowHeight`. 
5. Fügen Sie der Folie ein [ITable]-Objekt über die Methode [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) hinzu. 
6. Duplizieren Sie die Zeile der Tabelle. 
7. Duplizieren Sie die Spalte der Tabelle. 
8. Speichern Sie die geänderte Präsentation. 

Dieser C#‑Code zeigt, wie Sie die Zeile oder Spalte einer PowerPoint‑Tabelle duplizieren:
```c#
 // Instanziert die Presentation-Klasse
using (Presentation presentation = new Presentation("Test.pptx"))
{
    // Greift auf die erste Folie zu
    ISlide sld = presentation.Slides[0];

    // Definiert Spalten mit Breiten und Zeilen mit Höhen
    double[] dblCols = { 50, 50, 50 };
    double[] dblRows = { 50, 30, 30, 30, 30 };

    // Fügt der Folie ein Tabellenshape hinzu
    ITable table = sld.Shapes.AddTable(100, 50, dblCols, dblRows);

    // Fügt Text zu Zeile 1, Zelle 1 hinzu
    table[0, 0].TextFrame.Text = "Row 1 Cell 1";

    // Fügt Text zu Zeile 1, Zelle 2 hinzu
    table[1, 0].TextFrame.Text = "Row 1 Cell 2";

    // Klont Zeile 1 am Ende der Tabelle
    table.Rows.AddClone(table.Rows[0], false);

    // Fügt Text zu Zeile 2, Zelle 1 hinzu
    table[0, 1].TextFrame.Text = "Row 2 Cell 1";

    // Fügt Text zu Zeile 2, Zelle 2 hinzu
    table[1, 1].TextFrame.Text = "Row 2 Cell 2";

    // Klont Zeile 2 als vierte Zeile der Tabelle
    table.Rows.InsertClone(3,table.Rows[1], false);

    // Klont erste Spalte am Ende
    table.Columns.AddClone(table.Columns[0], false);

    // Klont zweite Spalte an Index 4
    table.Columns.InsertClone(3,table.Columns[1], false);
    
    // Speichert die Präsentation auf dem Datenträger 
    presentation.Save("table_out.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
}
```


## **Zeile oder Spalte aus Tabelle entfernen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) und laden Sie die Präsentation, 
2. Rufen Sie über den Index die Referenz einer Folie ab. 
3. Definieren Sie ein Array von `columnWidth`. 
4. Definieren Sie ein Array von `rowHeight`. 
5. Fügen Sie der Folie ein [ITable]-Objekt über die Methode [AddTable](https://reference.aspose.com/slides/net/aspose.slides/ishapecollection/addtable/) hinzu. 
6. Entfernen Sie die Tabellenzeile. 
7. Entfernen Sie die Tabellenspalte. 
8. Speichern Sie die geänderte Präsentation. 

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


## **Textformatierung auf Zeilenebene einer Tabelle festlegen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) und laden Sie die Präsentation, 
2. Rufen Sie über den Index die Referenz einer Folie ab. 
3. Greifen Sie auf das betreffende [ITable]-Objekt der Folie zu. 
4. Setzen Sie die [FontHeight] der Zellen der ersten Zeile. 
5. Setzen Sie die [Alignment] und [MarginRight] der Zellen der ersten Zeile. 
6. Setzen Sie die [TextVerticalType] der Zellen der zweiten Zeile. 
7. Speichern Sie die geänderte Präsentation. 

Dieser C#‑Code demonstriert den Vorgang.
```c#
 // Erstellt eine Instanz der Presentation-Klasse
Presentation presentation = new Presentation();
           
ISlide slide = presentation.Slides[0];

ITable someTable = presentation.Slides[0].Shapes[0] as ITable; // Angenommen, das erste Shape auf der ersten Folie ist eine Tabelle

// Setzt die Schriftgröße der Zellen der ersten Zeile
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Rows[0].SetTextFormat(portionFormat);

// Setzt die Textausrichtung und den rechten Rand der Zellen der ersten Zeile
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Rows[0].SetTextFormat(paragraphFormat);

// Setzt den Textvertikaltyp der Zellen der zweiten Zeile
TextFrameFormat textFrameFormat = new TextFrameFormat();
textFrameFormat.TextVerticalType = TextVerticalType.Vertical;
someTable.Rows[1].SetTextFormat(textFrameFormat);

// Speichert die Präsentation auf dem Datenträger
presentation.Save("result.pptx", Aspose.Slides.Export.SaveFormat.Pptx);
```


## **Textformatierung auf Spaltenebene einer Tabelle festlegen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation) und laden Sie die Präsentation, 
2. Rufen Sie über den Index die Referenz einer Folie ab. 
3. Greifen Sie auf das betreffende [ITable]-Objekt der Folie zu. 
4. Setzen Sie die [FontHeight] der Zellen der ersten Spalte. 
5. Setzen Sie die [Alignment] und [MarginRight] der Zellen der ersten Spalte. 
6. Setzen Sie die [TextVerticalType] der Zellen der zweiten Spalte. 
7. Speichern Sie die geänderte Präsentation. 

Dieser C#‑Code demonstriert den Vorgang:
```c#
// Erstellt eine Instanz der Presentation-Klasse
Presentation pres = new Presentation();
           
ISlide slide = pres.Slides[0];

ITable someTable = pres.Slides[0].Shapes[0] as ITable; // Angenommen, das erste Shape auf der ersten Folie ist eine Tabelle

// Setzt die Schriftgröße der Zellen der ersten Spalte
PortionFormat portionFormat = new PortionFormat();
portionFormat.FontHeight = 25;
someTable.Columns[0].SetTextFormat(portionFormat);

// Setzt die Textausrichtung und den rechten Rand der Zellen der ersten Spalte in einem Aufruf
ParagraphFormat paragraphFormat = new ParagraphFormat();
paragraphFormat.Alignment = TextAlignment.Right;
paragraphFormat.MarginRight = 20;
someTable.Columns[0].SetTextFormat(paragraphFormat);

// Setzt den vertikalen Texttyp der Zellen der zweiten Spalte
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
    table.StylePreset = TableStylePreset.DarkStyle1; // Ändert das standardmäßige Stilvorlagen-Theme 
    pres.Save("table.pptx", SaveFormat.Pptx);
}
```


## **FAQ**

**Kann ich PowerPoint‑Designs/‑Stile auf eine bereits erstellte Tabelle anwenden?**

Ja. Die Tabelle erbt das Design der Folie/Layout/Master, und Sie können dennoch Füllungen, Rahmen und Textfarben über diesem Design überschreiben.

**Kann ich Tabellenzeilen wie in Excel sortieren?**

Nein, Aspose.Slides‑Tabellen verfügen nicht über integrierte Sortier‑ oder Filterfunktionen. Sortieren Sie Ihre Daten zunächst im Speicher und fügen Sie die Tabellenn Zeilen anschließend in dieser Reihenfolge wieder ein.

**Kann ich banded (gestreifte) Spalten verwenden und gleichzeitig benutzerdefinierte Farben für bestimmte Zellen beibehalten?**

Ja. Schalten Sie banded Spalten ein, dann überschreiben Sie bestimmte Zellen mit lokaler Formatierung; die zellenspezifische Formatierung hat Vorrang vor dem Tabellenstil.