---
title: Zeilen und Spalten verwalten
type: docs
weight: 20
url: /de/python-net/manage-rows-and-columns/
keywords: "Tabelle, Tabellenzeilen und -spalten, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Verwalten von Tabellenzeilen und -spalten in PowerPoint-Präsentationen mit Python"
---

Um Ihnen die Verwaltung der Zeilen und Spalten einer Tabelle in einer PowerPoint-Präsentation zu ermöglichen, bietet Aspose.Slides die [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) Klasse, die [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) Schnittstelle und viele andere Typen an.

## **Erste Zeile als Kopfzeile festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse und laden Sie die Präsentation.
2. Holen Sie sich eine Referenz zur Folie über ihren Index.
3. Erstellen Sie ein [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) Objekt und setzen Sie es auf null.
4. Durchlaufen Sie alle [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) Objekte, um die relevante Tabelle zu finden.
5. Setzen Sie die erste Zeile der Tabelle als Kopfzeile.

Dieser Python-Code zeigt Ihnen, wie Sie die erste Zeile einer Tabelle als Kopfzeile festlegen:

```python
import aspose.slides as slides

# Instanziiert die Presentation-Klasse
with slides.Presentation("table.pptx") as pres:
    # Greift auf die erste Folie zu
    sld = pres.slides[0]

    # Initialisiert die null Tabelle
    tbl = None

    # Durchläuft die Formen und setzt eine Referenz auf die Tabelle
    for shp in sld.shapes:
        if type(shp) is slides.Table:
            tbl = shp

    # Setzt die erste Zeile einer Tabelle als Kopfzeile
    tbl.first_row = True
    
    # Speichert die Präsentation auf der Festplatte
    pres.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Zeile oder Spalte der Tabelle klonen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse und laden Sie die Präsentation.
2. Holen Sie sich eine Referenz zur Folie über ihren Index.
3. Definieren Sie ein Array von `columnWidth`.
4. Definieren Sie ein Array von `rowHeight`.
5. Fügen Sie über die Methode `add_table(x, y, column_widths, row_heights)` ein [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) Objekt zur Folie hinzu.
6. Klonen Sie die Tabellenzeile.
7. Klonen Sie die Tabellen-Spalte.
8. Speichern Sie die bearbeitete Präsentation.

Dieser Python-Code zeigt Ihnen, wie Sie eine Zeile oder Spalte einer PowerPoint-Tabelle klonen:

```python
 import aspose.slides as slides

# Instanziiert die Presentation-Klasse
with slides.Presentation() as presentation:

    # Greift auf die erste Folie zu
    sld = presentation.slides[0]

    # Definiert Spalten mit Breiten und Zeilen mit Höhen
    dblCols =  [50, 50, 50] 
    dblRows =  [50, 30, 30, 30, 30] 

    # Fügt der Folie eine Tischform hinzu
    table = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # Fügt dem Zell 1 der Zeile 1 Text hinzu
    table.rows[0][0].text_frame.text = "Zeile 1 Zelle 1"

    # Fügt dem Zell 2 der Zeile 1 Text hinzu
    table.rows[1][0].text_frame.text = "Zeile 1 Zelle 2"

    # Klont Zeile 1 am Ende der Tabelle
    table.rows.add_clone(table.rows[0], False)

    # Fügt dem Zell 1 der Zeile 2 Text hinzu
    table.rows[0][1].text_frame.text = "Zeile 2 Zelle 1"

    # Fügt dem Zell 2 der Zeile 2 Text hinzu
    table.rows[1][1].text_frame.text = "Zeile 2 Zelle 2"

    # Klont Zeile 2 als 4. Zeile der Tabelle
    table.rows.insert_clone(3,table.rows[1], False)

    # Klont die erste Spalte am Ende
    table.columns.add_clone(table.columns[0], False)

    # Klont die 2. Spalte am Index der 4. Spalte
    table.columns.insert_clone(3,table.columns[1], False)
    
    # Speichert die Präsentation auf der Festplatte
    presentation.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Zeile oder Spalte aus der Tabelle entfernen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse und laden Sie die Präsentation.
2. Holen Sie sich eine Referenz zur Folie über ihren Index.
3. Definieren Sie ein Array von `columnWidth`.
4. Definieren Sie ein Array von `rowHeight`.
5. Fügen Sie über die Methode `add_table(x, y, column_widths, row_heights)` ein [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) Objekt zur Folie hinzu.
6. Entfernen Sie die Tabellenzeile.
7. Entfernen Sie die Tabellen-Spalte.
8. Speichern Sie die bearbeitete Präsentation.

Dieser Python-Code zeigt Ihnen, wie Sie eine Zeile oder Spalte aus einer Tabelle entfernen:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    slide = pres.slides[0]
    colWidth =  [100, 50, 30] 
    rowHeight =  [30, 50, 30] 

    table = slide.shapes.add_table(100, 100, colWidth, rowHeight)
    table.rows.remove_at(1, False)
    table.columns.remove_at(1, False)
    pres.save("TestTable_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Textformatierung auf Tabellenzeilenebene setzen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse und laden Sie die Präsentation. 
2. Holen Sie sich eine Referenz zur Folie über ihren Index.
3. Greifen Sie auf das relevante [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) Objekt von der Folie zu. 
4. Setzen Sie die `font_height` der Zellen der ersten Zeile. 
5. Setzen Sie die `alignment` und `margin_right` der Zellen der ersten Zeile. 
6. Setzen Sie den `text_vertical_type` der Zellen der zweiten Zeile. 
7. Speichern Sie die bearbeitete Präsentation.

Dieser Python-Code demonstriert die Operation:

```python
import aspose.slides as slides

# Erstellt eine Instanz der Presentation-Klasse
with slides.Presentation() as presentation:
    
    slide = presentation.slides[0]

    someTable = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Setzt die Schriftgröße der Zellen der ersten Zeile
    portionFormat = slides.PortionFormat()
    portionFormat.font_height = 25
    someTable.rows[0].set_text_format(portionFormat)

    # Setzt die Textausrichtung und den rechten Rand der Zellen der ersten Zeile
    paragraphFormat = slides.ParagraphFormat()
    paragraphFormat.alignment = slides.TextAlignment.RIGHT
    paragraphFormat.margin_right = 20
    someTable.rows[0].set_text_format(paragraphFormat)

    # Setzt den vertikalen Texttyp der Zellen der zweiten Zeile
    textFrameFormat = slides.TextFrameFormat()
    textFrameFormat.text_vertical_type = slides.TextVerticalType.VERTICAL
    someTable.rows[1].set_text_format(textFrameFormat)
	
    # Speichert die Präsentation auf der Festplatte
    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Textformatierung auf Tabellen Spaltenebene setzen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse und laden Sie die Präsentation, 
2. Holen Sie sich eine Referenz zur Folie über ihren Index. 
3. Greifen Sie auf das relevante [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) Objekt von der Folie zu. 
4. Setzen Sie die `font_height` der Zellen der ersten Spalte. 
5. Setzen Sie die `alignment` und `margin_right` der Zellen der ersten Spalte. 
6. Setzen Sie den `text_vertical_type` der Zellen der zweiten Spalte.
7. Speichern Sie die bearbeitete Präsentation. 

Dieser Python-Code demonstriert die Operation:

```python
import aspose.slides as slides

# Erstellt eine Instanz der Presentation-Klasse
with slides.Presentation() as pres:
    slide = pres.slides[0]
    someTable = slide.shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Setzt die Schriftgröße der Zellen der ersten Spalte
    portionFormat = slides.PortionFormat()
    portionFormat.font_height = 25
    someTable.columns[0].set_text_format(portionFormat)

    # Setzt die Textausrichtung und den rechten Rand der Zellen der ersten Spalte 
    paragraphFormat = slides.ParagraphFormat()
    paragraphFormat.alignment = slides.TextAlignment.RIGHT
    paragraphFormat.margin_right = 20
    someTable.columns[0].set_text_format(paragraphFormat)

    # Setzt den vertikalen Texttyp der Zellen der zweiten Spalte
    textFrameFormat = slides.TextFrameFormat()
    textFrameFormat.text_vertical_type = slides.TextVerticalType.VERTICAL
    someTable.columns[1].set_text_format(textFrameFormat)

    # Speichert die Präsentation auf der Festplatte
    pres.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Tabellenstil-Eigenschaften abrufen**

Aspose.Slides ermöglicht es Ihnen, die Stileigenschaften für eine Tabelle abzurufen, sodass Sie diese Details für eine andere Tabelle oder an anderer Stelle verwenden können. Dieser Python-Code zeigt Ihnen, wie Sie die Stileigenschaften aus einem Tabellenvoreinstellungsstil abrufen:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    table = pres.slides[0].shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1
    pres.save("table.pptx", slides.export.SaveFormat.PPTX)
```