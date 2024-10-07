---
title: Zellen verwalten
type: docs
weight: 30
url: /python-net/manage-cells/
keywords: "Tabelle, zusammengefügte Zellen, geteilte Zellen, Bild in Tabellenzelle, Python, Aspose.Slides für Python über .NET"
description: "Tabellenzellen in PowerPoint-Präsentationen in Python"
---

## **Zusammengefügte Tabellenzelle identifizieren**
1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.
2. Holen Sie sich die Tabelle von der ersten Folie. 
3. Iterieren Sie durch die Zeilen und Spalten der Tabelle, um zusammengefügte Zellen zu finden.
4. Drucken Sie eine Nachricht, wenn zusammengefügte Zellen gefunden werden.

Dieser Python-Code zeigt Ihnen, wie Sie zusammengefügte Tabellenzellen in einer Präsentation identifizieren:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation(path + "SomePresentationWithTable.pptx") as pres:
    table = pres.slides[0].shapes[0] # davon ausgehend, dass #0.Shape#0 eine Tabelle ist
    for i in range(len(table.rows)):
        for j in range(len(table.columns)):
            currentCell = table.rows[i][j]
            if currentCell.is_merged_cell:
                print("Zelle 01 ist Teil einer zusammengefügten Zelle mit RowSpan=2 und ColSpan=3, beginnend bei Zelle 45.".format(
                    i, j, currentCell.row_span, currentCell.col_span, currentCell.first_row_index, currentCell.first_column_index))
```

## **Tabellenzellenrahmen entfernen**
1. Erstellen Sie eine Instanz der `Presentation`-Klasse.
2. Holen Sie sich die Referenz für eine Folie über ihren Index. 
3. Definieren Sie ein Array von Spalten mit Breite.
4. Definieren Sie ein Array von Zeilen mit Höhe.
5. Fügen Sie der Folie über die `AddTable`-Methode eine Tabelle hinzu.
6. Iterieren Sie durch jede Zelle, um die oberen, unteren, rechten und linken Rahmen zu löschen.
7. Speichern Sie die geänderte Präsentation als PPTX-Datei.

Dieser Python-Code zeigt Ihnen, wie Sie die Rahmen von Tabellenzellen entfernen:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Erstellt eine Instanz der Presentation-Klasse, die eine PPTX-Datei darstellt
with slides.Presentation() as pres:
   # Greift auf die erste Folie zu
    sld = pres.slides[0]

    # Definiert Spalten mit Breiten und Zeilen mit Höhen
    dblCols = [ 50, 50, 50, 50 ]
    dblRows = [ 50, 30, 30, 30, 30 ]

    # Fügt der Folie eine Tabellengestalt hinzu
    tbl = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # Setzt das Rahmenformat für jede Zelle
    for row in tbl.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    # Schriebt die PPTX-Datei auf die Festplatte
    pres.save("table_out.pptx", slides.export.SaveFormat.PPTX)
```


## **Nummerierung in zusammengefügten Zellen**
Wenn wir 2 Paare von Zellen (1, 1) x (2, 1) und (1, 2) x (2, 2) zusammenfügen, wird die resultierende Tabelle nummeriert. Dieser Python-Code demonstriert den Prozess:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Erstellt eine Instanz der Presentation-Klasse, die eine PPTX-Datei darstellt
with slides.Presentation() as presentation:
    # Greift auf die erste Folie zu
    sld = presentation.slides[0]

    # Definiert Spalten mit Breiten und Zeilen mit Höhen
    dblCols =  [70, 70, 70, 70] 
    dblRows =  [70, 70, 70, 70] 

    # Fügt der Folie eine Tabellengestalt hinzu
    tbl = sld.shapes.add_table(100, 50, dblCols, dblRows)

    # Setzt das Rahmenformat für jede Zelle
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

    # Fügt die Zellen (1, 1) x (2, 1) zusammen
    tbl.merge_cells(tbl.rows[1][1], tbl.rows[2][1], False)

    # Fügt die Zellen (1, 2) x (2, 2) zusammen
    tbl.merge_cells(tbl.rows[1][2], tbl.rows[2][2], False)

    presentation.save("MergeCells_out.pptx", slides.export.SaveFormat.PPTX)
```

Wir fügen dann die Zellen weiter zusammen, indem wir (1, 1) und (1, 2) zusammenführen. Das Ergebnis ist eine Tabelle, die eine große zusammengefügte Zelle in der Mitte enthält: 

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Erstellt eine Instanz der Presentation-Klasse, die eine PPTX-Datei darstellt
with slides.Presentation() as presentation:
    # Greift auf die erste Folie zu
    slide = presentation.slides[0]

    # Definiert Spalten mit Breiten und Zeilen mit Höhen
    dblCols =  [70, 70, 70, 70] 
    dblRows =  [70, 70, 70, 70]

    # Fügt der Folie eine Tabellengestalt hinzu
    table = slide.shapes.add_table(100, 50, dblCols, dblRows)

    # Setzt das Rahmenformat für jede Zelle
    for row in table.rows:
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

    # Fügt die Zellen (1, 1) x (2, 1) zusammen
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # Fügt die Zellen (1, 2) x (2, 2) zusammen
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # Fügt die Zellen (1, 2) x (2, 2) zusammen
    table.merge_cells(table.rows[1][1], table.rows[1][2], True)

    # Schriebt die PPTX-Datei auf die Festplatte
    presentation.save("MergeCells1_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Nummerierung in geteilten Zellen**
In den vorherigen Beispielen ändert sich die Numerierung oder das Nummerierungssystem in anderen Zellen nicht, wenn Tabellenzellen zusammengefügt werden. 

Diesmal nehmen wir eine normale Tabelle (eine Tabelle ohne zusammengefügte Zellen) und versuchen dann, die Zelle (1,1) zu teilen, um eine spezielle Tabelle zu erhalten. Sie möchten vielleicht auf die Nummerierung dieser Tabelle achten, die als seltsam angesehen werden kann. Das ist jedoch die Art und Weise, wie Microsoft PowerPoint Tabellenzellen nummeriert, und Aspose.Slides macht es auf die gleiche Weise. 

Dieser Python-Code demonstriert den beschriebenen Prozess:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Erstellt eine Instanz der Presentation-Klasse, die eine PPTX-Datei darstellt
with slides.Presentation() as presentation:
    # Greift auf die erste Folie zu
    slide = presentation.slides[0]

    # Definiert Spalten mit Breiten und Zeilen mit Höhen
    dblCols =  [70, 70, 70, 70] 
    dblRows =  [70, 70, 70, 70] 

    # Fügt der Folie eine Tabellengestalt hinzu
    table = slide.shapes.add_table(100, 50, dblCols, dblRows)

    # Setzt das Rahmenformat für jede Zelle
    for row in table.rows:
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

    # Fügt die Zellen (1, 1) x (2, 1) zusammen
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # Fügt die Zellen (1, 2) x (2, 2) zusammen
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # Teilt die Zelle (1, 1). 
    table.rows[1][1].split_by_width(table.rows[2][1].width / 2)

    # Schriebt die PPTX-Datei auf die Festplatte
    presentation.save("CellSplit_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Hintergrundfarbe der Tabellenzelle ändern**

Dieser Python-Code zeigt Ihnen, wie Sie die Hintergrundfarbe einer Tabellenzelle ändern:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    dblCols = [ 150, 150, 150, 150 ]
    dblRows = [ 50, 50, 50, 50, 50 ]

    # Erstellt eine neue Tabelle
    table = slide.shapes.add_table(50, 50, dblCols, dblRows)

    # Setzt die Hintergrundfarbe für eine Zelle 
    cell = table.rows[2][3]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Bild in Tabellenzelle hinzufügen**
1. Erstellen Sie eine Instanz der`Presentation`-Klasse.
2. Holen Sie sich die Referenz für eine Folie über ihren Index.
3. Definieren Sie ein Array von Spalten mit Breite.
4. Definieren Sie ein Array von Zeilen mit Höhe.
5. Fügen Sie der Folie über die `AddTable`-Methode eine Tabelle hinzu. 
6. Erstellen Sie ein `Bitmap`-Objekt, um die Bilddatei zu halten.
7. Fügen Sie das Bitmap-Bild zum `IPPImage`-Objekt hinzu.
8. Setzen Sie das `FillFormat` für die Tabellenzelle auf `Picture`.
9. Fügen Sie das Bild zur ersten Zelle der Tabelle hinzu.
10. Speichern Sie die geänderte Präsentation als PPTX-Datei.

Dieser Python-Code zeigt Ihnen, wie Sie ein Bild in einer Tabellenzelle platzieren, während Sie eine Tabelle erstellen:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Erstellt ein Objekt der Presentation-Klasse
with slides.Presentation() as presentation:
    # Greift auf die erste Folie zu
    islide = presentation.slides[0]

    # Definiert Spalten mit Breiten und Zeilen mit Höhen
    dblCols =  [150, 150, 150, 150] 
    dblRows =  [100, 100, 100, 100, 90] 

    # Fügt der Folie eine Tabellengestalt hinzu
    tbl = islide.shapes.add_table(50, 50, dblCols, dblRows)

    # Erstellt ein Bitmap-Bildobjekt, um die Bilddatei zu halten
    image = draw.Bitmap(path + "aspose-logo.jpg")

    # Erstellt ein IPPImage-Objekt mit dem Bitmapobjekt
    imgx1 = presentation.images.add_image(image)

    # Fügt das Bild zur ersten Tabellenzelle hinzu
    tbl.rows[0][0].cell_format.fill_format.fill_type = slides.FillType.PICTURE
    tbl.rows[0][0].cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    tbl.rows[0][0].cell_format.fill_format.picture_fill_format.picture.image = imgx1

    # Speichert die PPTX auf der Festplatte
    presentation.save("Image_In_TableCell_out.pptx", slides.export.SaveFormat.PPTX)
```