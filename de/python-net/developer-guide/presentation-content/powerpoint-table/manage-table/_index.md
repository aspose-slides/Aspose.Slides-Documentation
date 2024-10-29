---
title: Tabelle verwalten
type: docs
weight: 10
url: /de/python-net/manage-table/
keywords: "Tabelle, Tabelle erstellen, auf Tabelle zugreifen, Seitenverhältnis der Tabelle, PowerPoint-Präsentation, Python, Aspose.Slides für Python über .NET"
description: "Tabelle in PowerPoint-Präsentationen in Python erstellen und verwalten"

---

Eine Tabelle in PowerPoint ist eine effiziente Methode, um Informationen darzustellen und zu veranschaulichen. Die Informationen in einem Gitter von Zellen (angeordnet in Zeilen und Spalten) sind einfach und leicht verständlich.

Aspose.Slides bietet die [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) Klasse, das [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) Interface, die [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) Klasse, das [ICell](https://reference.aspose.com/slides/python-net/aspose.slides/icell/) Interface und andere Typen, die es Ihnen ermöglichen, Tabellen in allen Arten von Präsentationen zu erstellen, zu aktualisieren und zu verwalten. 

## **Tabelle von Grund auf erstellen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Holen Sie sich eine Referenz zur Folie über ihren Index. 
3. Definieren Sie ein Array von `columnWidth`.
4. Definieren Sie ein Array von `rowHeight`.
5. Fügen Sie ein [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) Objekt zur Folie über die Methode `add_table(x, y, column_widths, row_heights)` hinzu.
6. Durchlaufen Sie jede [ICell](https://reference.aspose.com/slides/python-net/aspose.slides/icell/), um das Format für die oberen, unteren, rechten und linken Ränder anzuwenden.
7. Fügen Sie die ersten beiden Zellen der ersten Zeile der Tabelle zusammen. 
8. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) einer [ICell](https://reference.aspose.com/slides/python-net/aspose.slides/icell/) zu. 
9. Fügen Sie etwas Text zum [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) hinzu.
10. Speichern Sie die modifizierte Präsentation.

Dieser Python-Code zeigt Ihnen, wie Sie eine Tabelle in einer Präsentation erstellen:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Erstellt eine Präsentation, die eine PPTX-Datei darstellt
with slides.Presentation() as pres:
    # Greift auf die erste Folie zu
    sld = pres.slides[0]

    # Definiert Spalten mit Breiten und Zeilen mit Höhen
    dblCols =  [50, 50, 50] 
    dblRows =  [50, 30, 30, 30, 30] 

    # Fügt der Folie eine Tabellengestalt hinzu
    tbl = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # Setzt das Randformat für jede Zelle
    for row in range(len(tbl.rows)):
        for cell in range(len(tbl.rows[row])):
            tbl.rows[row][cell].cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            tbl.rows[row][cell].cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            tbl.rows[row][cell].cell_format.border_top.width = 5

            tbl.rows[row][cell].cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            tbl.rows[row][cell].cell_format.border_bottom.fill_format.solid_fill_color.color= draw.Color.red
            tbl.rows[row][cell].cell_format.border_bottom.width =5

            tbl.rows[row][cell].cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            tbl.rows[row][cell].cell_format.border_left.fill_format.solid_fill_color.color =draw.Color.red
            tbl.rows[row][cell].cell_format.border_left.width = 5

            tbl.rows[row][cell].cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            tbl.rows[row][cell].cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            tbl.rows[row][cell].cell_format.border_right.width = 5
        

    # Fügt die Zellen 1 & 2 von Zeile 1 zusammen
    tbl.merge_cells(tbl.rows[0][0], tbl.rows[1][1], False)

    # Fügt dem zusammengefügten Feld Text hinzu
    tbl.rows[0][0].text_frame.text = "Zusammengeführte Zellen"

    # Speichert die Präsentation auf der Festplatte
    pres.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Nummerierung in Standardtabelle**

In einer Standardtabelle ist die Nummerierung der Zellen unkompliziert und nullbasiert. Die erste Zelle in einer Tabelle ist mit 0,0 (Spalte 0, Zeile 0) indiziert. 

Zum Beispiel sind die Zellen in einer Tabelle mit 4 Spalten und 4 Zeilen folgendermaßen nummeriert:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Dieser Python-Code zeigt Ihnen, wie Sie die Nummerierung für Zellen in einer Tabelle angeben:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Erstellt eine Präsentation, die eine PPTX-Datei darstellt
with slides.Presentation() as pres:
    # Greift auf die erste Folie zu
    sld = pres.slides[0]

    # Definiert Spalten mit Breiten und Zeilen mit Höhen
    dblCols =  [70, 70, 70, 70] 
    dblRows =  [70, 70, 70, 70] 

    # Fügt der Folie eine Tabellengestalt hinzu
    tbl = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # Setzt das Randformat für jede Zelle
    for row in tbl.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5

    # Speichert die Präsentation auf der Festplatte
    pres.save("StandardTables_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Auf vorhandene Tabelle zugreifen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.

2. Holen Sie sich eine Referenz zur Folie, die die Tabelle enthält, über ihren Index. 

3. Erstellen Sie ein [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) Objekt und setzen Sie es auf null.

4. Durchlaufen Sie alle [IShape](https://reference.aspose.com/slides/python-net/aspose.slides/ishape/) Objekte, bis die Tabelle gefunden ist.

   Wenn Sie vermuten, dass die Folie, mit der Sie es zu tun haben, eine einzelne Tabelle enthält, können Sie einfach alle Formen überprüfen, die sie enthält. Wenn eine Form als Tabelle identifiziert wird, können Sie sie als [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) Objekt typcasten. Wenn die Folie, mit der Sie es zu tun haben, mehrere Tabellen enthält, suchen Sie am besten die benötigte Tabelle über das `alternative_text`. 

5. Verwenden Sie das [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) Objekt, um mit der Tabelle zu arbeiten. Im folgenden Beispiel haben wir eine neue Zeile zur Tabelle hinzugefügt.

6. Speichern Sie die modifizierte Präsentation.

Dieser Python-Code zeigt Ihnen, wie Sie auf eine vorhandene Tabelle zugreifen und mit ihr arbeiten:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Erstellt eine Präsentation, die eine PPTX-Datei darstellt
with slides.Presentation(path + "UpdateExistingTable.pptx") as pres:
    # Greift auf die erste Folie zu
    sld = pres.slides[0]

    # Initialisiert null TableEx
    tbl = None

    # Durchläuft die Formen und setzt eine Referenz auf die gefundene Tabelle
    for shp in sld.shapes:
        if type(shp) is slides.Table:
            tbl = shp

    # Setzt den Text für die erste Spalte der zweiten Zeile
    tbl.rows[0][1].text_frame.text = "Neu"

    # Speichert die modifizierte Präsentation auf der Festplatte
    pres.save("table1_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Text in Tabelle ausrichten**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Holen Sie sich eine Referenz zur Folie über ihren Index. 
3. Fügen Sie ein [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) Objekt zur Folie hinzu. 
4. Greifen Sie auf ein [ITextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) Objekt aus der Tabelle zu. 
5. Greifen Sie auf das [ITextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/itextframe/) [IParagraph](https://reference.aspose.com/slides/python-net/aspose.slides/iparagraph/) zu.
6. Richten Sie den Text vertikal aus.
7. Speichern Sie die modifizierte Präsentation.

Dieser Python-Code zeigt Ihnen, wie Sie den Text in einer Tabelle ausrichten:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Erstellt eine Instanz der Presentation-Klasse
with slides.Presentation() as presentation:
    # Greift auf die erste Folie zu 
    slide = presentation.slides[0]

    # Definiert Spalten mit Breiten und Zeilen mit Höhen
    dblCols =  [120, 120, 120, 120] 
    dblRows =  [100, 100, 100, 100] 

    # Fügt der Folie die Tabellengestalt hinzu
    tbl = slide.shapes.add_table(100, 50, dblCols, dblRows)
    tbl.rows[1][0].text_frame.text = "10"
    tbl.rows[2][0].text_frame.text = "20"
    tbl.rows[3][0].text_frame.text = "30"

    # Greift auf das Textfeld zu
    txtFrame = tbl.rows[0][0].text_frame

    # Erstellt das Paragraph-Objekt für das Textfeld
    paragraph = txtFrame.paragraphs[0]

    # Erstellt das Portion-Objekt für den Absatz
    portion = paragraph.portions[0]
    portion.text = "Text hier"
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    # Richtet den Text vertikal aus
    cell = tbl.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Speichert die Präsentation auf der Festplatte
    presentation.save("Vertical_Align_Text_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Textformatierung auf Tabellenebene festlegen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Holen Sie sich eine Referenz zur Folie über ihren Index. 
3. Greifen Sie auf ein [ITable](https://reference.aspose.com/slides/python-net/aspose.slides/itable/) Objekt von der Folie zu.
4. Setzen Sie die `font_height` für den Text. 
5. Setzen Sie die `alignment` und `margin_right`. 
6. Setzen Sie den `text_vertical_type`.
7. Speichern Sie die modifizierte Präsentation. 

Dieser Python-Code zeigt Ihnen, wie Sie Ihre bevorzugten Formatierungsoptionen für den Text in einer Tabelle anwenden:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Erstellt eine Instanz der Presentation-Klasse
with slides.Presentation() as presentation:
    someTable = presentation.slides[0].shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])

    # Setzt die Schriftgröße der Tabellenspalten
    portionFormat = slides.PortionFormat()
    portionFormat.font_height = 25
    someTable.set_text_format(portionFormat)

    # Setzt die Textausrichtung und den rechten Rand in einem Aufruf
    paragraphFormat = slides.ParagraphFormat()
    paragraphFormat.alignment = slides.TextAlignment.RIGHT
    paragraphFormat.margin_right = 20
    someTable.set_text_format(paragraphFormat)

    # Setzt den vertikalen Typ des Textes in der Tabelle
    textFrameFormat = slides.TextFrameFormat()
    textFrameFormat.text_vertical_type = slides.TextVerticalType.VERTICAL
    someTable.set_text_format(textFrameFormat)


    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Tischstil Eigenschaften abrufen**

Aspose.Slides ermöglicht es Ihnen, die Stil Eigenschaften für eine Tabelle abzurufen, damit Sie diese Details für eine andere Tabelle oder an anderer Stelle verwenden können. Dieser Python-Code zeigt Ihnen, wie Sie die Stil Eigenschaften aus einem vordefinierten Tabellenstil abrufen:

```python
import aspose.slides as slides

with slides.Presentation() as pres:
    table = pres.slides[0].shapes.add_table(10, 10, [100, 150], [5, 5, 5])
    table.style_preset = slides.TableStylePreset.DARK_STYLE1
    pres.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Seitenverhältnis der Tabelle sperren**

Das Seitenverhältnis einer geometrischen Form ist das Verhältnis ihrer Größen in verschiedenen Dimensionen. Aspose.Slides stellt die `aspect_ratio_locked` Eigenschaft bereit, um Ihnen zu ermöglichen, die Einstellung des Seitenverhältnisses für Tabellen und andere Formen zu sperren. 

Dieser Python-Code zeigt Ihnen, wie Sie das Seitenverhältnis für eine Tabelle sperren:

```c#
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as pres:
    table = pres.slides[0].shapes.add_table(100, 100, [100, 50, 30], [30, 50, 30])
    print("Seitenverhältnis gesperrt: {0}".format(table.shape_lock.aspect_ratio_locked))

    table.shape_lock.aspect_ratio_locked = not table.shape_lock.aspect_ratio_locked

    print("Seitenverhältnis gesperrt: {0}".format(table.shape_lock.aspect_ratio_locked))

    pres.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```