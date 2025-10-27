---
title: Manage Table Cells in Presentations with Python
linktitle: Manage Cells
type: docs
weight: 30
url: /de/python-net/manage-cells/
keywords:
- table cell
- merge cells
- remove border
- split cell
- image in cell
- background color
- PowerPoint
- OpenDocument
- presentation
- Python
- Aspose.Slides
description: "Effortlessly manage table cells in PowerPoint and OpenDocument with Aspose.Slides for Python via .NET. Master accessing, modifying, and styling cells quickly for seamless slide automation."
---

## **Übersicht**

Dieser Artikel zeigt, wie man mit Aspose.Slides Tabellenzellen in Präsentationen bearbeitet. Sie erfahren, wie Sie zusammengeführte Zellen erkennen, Zellränder löschen oder anpassen und verstehen, wie PowerPoint Zellen nach Zusammenführungs‑ und Teilungs‑Operationen nummeriert, sodass Sie die Indizierung in komplexen Layouts vorhersagen können. Der Artikel demonstriert außerdem gängige Formatierungsaufgaben – etwa das Ändern der Hintergrundfüllung einer Zelle – und zeigt, wie Sie ein Bild direkt in einer Tabellenzelle mit Bildfüll‑Einstellungen platzieren. Jeder Anwendungsfall wird durch kompakte Python‑Beispiele illustriert, die Tabellen erstellen oder bearbeiten und anschließend die aktualisierte Präsentation speichern, sodass Sie die Snippets schnell an Ihre eigenen Folien anpassen können.

## **Erkennen zusammengeführter Tabellenzellen**

Tabellen enthalten häufig zusammengeführte Zellen für Überschriften oder zur Gruppierung verwandter Daten. In diesem Abschnitt sehen Sie, wie Sie feststellen können, ob eine bestimmte Zelle zu einem zusammengeführten Bereich gehört, und wie Sie die Master‑Zelle (oben‑links) referenzieren, um den gesamten Block konsistent zu lesen oder zu formatieren.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Holen Sie die Tabelle von der ersten Folie.  
3. Durchlaufen Sie die Zeilen und Spalten der Tabelle, um zusammengeführte Zellen zu finden.  
4. Geben Sie eine Meldung aus, wenn zusammengeführte Zellen gefunden werden.

Der folgende Python‑Code erkennt zusammengeführte Tabellenzellen in einer Präsentation:

```py
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    # Assuming the first shape on the first slide is a table.
    table = presentation.slides[0].shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print("Cell ({}, {}) is part of a merged region with a row span of {} and a column span of {}, starting from cell ({}, {}).".format(
                    row_index, column_index, cell.row_span, cell.col_span, cell.first_row_index, cell.first_column_index))
```

## **Entfernen von Tabellenzellrändern**

Manchmal lenken Tabellenränder vom Inhalt ab oder erzeugen visuelles Durcheinander. Dieser Abschnitt zeigt, wie Sie Ränder von ausgewählten Zellen – oder einzelnen Seiten einer Zelle – entfernen, um ein saubereres Layout zu erzielen und das Design Ihrer Folie besser zu unterstützen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Holen Sie die Folie über ihren Index.  
3. Definieren Sie ein Array von Spaltenbreiten.  
4. Definieren Sie ein Array von Zeilenhöhen.  
5. Fügen Sie der Folie mit der [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/)-Methode eine Tabelle hinzu.  
6. Durchlaufen Sie jede Zelle und löschen Sie die oberen, unteren, linken und rechten Ränder.  
7. Speichern Sie die modifizierte Präsentation als PPTX‑Datei.

Der folgende Python‑Code zeigt, wie Sie Ränder von Tabellenzellen entfernen:

```python
import aspose.slides as slides

# Instantiate the Presentation class that represents a PPTX file.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Define columns with widths and rows with heights.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Add a table shape to the slide.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Clear the border fill for each cell.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    # Save the PPTX file to disk.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Nummerierung in zusammengeführten Zellen**

Wenn Sie zwei Paare von Zellen zusammenführen – z. B. (1, 1) × (2, 1) und (1, 2) × (2, 2) – behält die resultierende Tabelle dieselbe Zellnummerierung wie die ursprüngliche Tabelle ohne Zusammenführung. Der folgende Python‑Code demonstriert dieses Verhalten:

```python
import aspose.slides as slides

# Instantiate the Presentation class that represents a PPTX file.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Define columns with widths and rows with heights.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Add a table shape to the slide.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Merge cells (1,1) and (2,1).
    table.merge_cells(table.rows[1][1], table.rows[2][1], False)

    # Merge cells (1, 2) and (2, 2).
    table.merge_cells(table.rows[1][2], table.rows[2][2], False)

    # Print the cell indices.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # Save the PPTX file to disk.
    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

Ausgabe:

```text
(0, 0) (0, 1) (0, 2) (0, 3) 
(1, 0) (1, 1) (1, 2) (1, 3) 
(2, 0) (1, 1) (1, 2) (2, 3) 
(3, 0) (3, 1) (3, 2) (3, 3)
```

## **Nummerierung in geteilten Zellen**

Im vorherigen Beispiel änderte sich die Nummerierung der übrigen Zellen nicht, wenn Zellen zusammengeführt wurden. Dieses Mal erzeugen wir eine reguläre Tabelle (ohne zusammengeführte Zellen) und teilen dann die Zelle (1, 1), um eine spezielle Tabelle zu erzeugen. Achten Sie auf die Nummerierung dieser Tabelle – sie kann ungewöhnlich erscheinen. Das ist jedoch das Verhalten von Microsoft PowerPoint, und Aspose.Slides folgt diesem Prinzip.

Der folgende Python‑Code demonstriert dieses Verhalten:

```python
import aspose.slides as slides

# Instantiate the Presentation class that represents a PPTX file.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Define column widths and row heights.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Add a table shape to the slide.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Split cell (1, 1).
    table.rows[1][1].split_by_width(table.rows[2][1].width / 2)

    # Print the cell indices.
    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            print(f"{cell.first_row_index, cell.first_column_index} ", end="")
        print()

    # Save the PPTX file to disk.
    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

Ausgabe:

```text
(0, 0) (0, 1) (0, 1) (0, 3) (0, 4) 
(1, 0) (1, 1) (1, 2) (1, 3) (1, 4) 
(2, 0) (2, 1) (2, 1) (2, 3) (2, 4) 
(3, 0) (3, 1) (3, 1) (3, 3) (3, 4) 
```

## **Hintergrundfarbe einer Tabellenzelle ändern**

Das folgende Python‑Beispiel zeigt, wie Sie die Hintergrundfarbe einer Tabellenzelle ändern:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # Create a new table.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Set the background color for a cell.
    cell = table.rows[2][3]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Bilder in Tabellenzellen einfügen**

Dieser Abschnitt zeigt, wie Sie ein Bild in eine Tabellenzelle in Aspose.Slides einfügen. Er behandelt die Anwendung einer Bildfüll‑Option auf die Zielzelle und die Konfiguration von Anzeigeoptionen wie Dehnen oder Kacheln.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.  
2. Holen Sie eine Folienreferenz über ihren Index.  
3. Definieren Sie ein Array von Spaltenbreiten.  
4. Definieren Sie ein Array von Zeilenhöhen.  
5. Fügen Sie der Folie mit der [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/)-Methode eine Tabelle hinzu.  
6. Laden Sie das Bild aus einer Datei.  
7. Fügen Sie das Bild den Präsentations‑Images hinzu, um ein [PPImage](https://reference.aspose.com/slides/python-net/aspose.slides/ppimage/) zu erhalten.  
8. Setzen Sie den [FillType](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) der Tabellenzelle auf `PICTURE`.  
9. Wenden Sie das Bild auf die Tabellenzelle an und wählen Sie einen Füll‑Modus (z. B. `STRETCH`).  
10. Speichern Sie die Präsentation als PPTX‑Datei.

Der folgende Python‑Code zeigt, wie Sie beim Erzeugen einer Tabelle ein Bild in eine Tabellenzelle einbetten:

```python
import aspose.slides as slides

# Instantiate a Presentation object.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Define column widths and row heights.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100]

    # Add a table shape to the slide.
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    # Load the image and add it to the presentation to obtain a PPImage.
    with slides.Images.from_file("image.png") as source_image:
        image = presentation.images.add_image(source_image)

    # Apply the image to the first table cell.
    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = image

    # Save the presentation to disk.
    presentation.save("image_in_table_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kann ich unterschiedliche Linienstärken und -stile für die einzelnen Seiten einer Zelle festlegen?**

Ja. Die [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/)-Ränder besitzen eigene Eigenschaften, sodass die Dicke und der Stil jeder Seite unterschiedlich sein können. Das ergibt sich logisch aus der pro‑Seite‑Rand‑Steuerung, die im Artikel demonstriert wird.

**Was passiert mit dem Bild, wenn ich nach dem Setzen eines Bild‑Backgrounds die Spalten‑/Zeilengröße ändere?**

Das Verhalten hängt vom [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile) ab. Beim Dehnen passt sich das Bild der neuen Zelle an; beim Kacheln werden die Kacheln neu berechnet. Der Artikel beschreibt die Anzeigemodi eines Bildes in einer Zelle.

**Kann ich einem gesamten Zellinhalt einen Hyperlink zuweisen?**

[Hyperlinks](/slides/de/python-net/manage-hyperlinks/) werden auf Textebene (Portion) innerhalb des Textfelds der Zelle oder auf Tabellen‑/Form‑Ebene gesetzt. In der Praxis verknüpfen Sie also entweder einen Textabschnitt oder den gesamten Text in der Zelle.

**Kann ich verschiedene Schriftarten innerhalb einer einzigen Zelle verwenden?**

Ja. Das Textfeld einer Zelle unterstützt [Portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (Runs) mit unabhängiger Formatierung – Schriftfamilie, Stil, Größe und Farbe.