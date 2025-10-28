---
title: Verwalten von Präsentationstabellen mit Python
linktitle: Tabelle verwalten
type: docs
weight: 10
url: /de/python-net/manage-table/
keywords:
- Tabelle hinzufügen
- Tabelle erstellen
- Tabelle zugreifen
- Seitenverhältnis
- Text ausrichten
- Textformatierung
- Tabellenstil
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Tabellen in PowerPoint- und OpenDocument-Folien mit Aspose.Slides für Python über .NET erstellen und bearbeiten. Entdecken Sie einfache Codebeispiele, um Ihre Tabellen‑Workflows zu optimieren."
---

## **Übersicht**

Eine Tabelle in PowerPoint ist ein effizientes Mittel, um Informationen darzustellen. In einem Raster aus Zellen (Zeilen und Spalten) angeordnete Informationen sind übersichtlich und leicht zu verstehen.

Aspose.Slides stellt die Klasse [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) und die Klasse [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) sowie weitere zugehörige Typen bereit, die Ihnen beim Erstellen, Aktualisieren und Verwalten von Tabellen in jeder Präsentation helfen.

## **Tabellen von Grund auf erstellen**

Dieser Abschnitt zeigt, wie Sie in Aspose.Slides eine Tabelle von Grund auf erstellen, indem Sie einer Folie ein Tabellenelement hinzufügen, Zeilen und Spalten definieren und präzise Größen festlegen. Außerdem erfahren Sie, wie Sie Zellen mit Text füllen, Ausrichtung und Rahmen anpassen und das Aussehen der Tabelle anpassen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Holen Sie sich eine Referenz zu einer Folie über deren Index.
3. Definieren Sie ein Array von Spaltenbreiten.
4. Definieren Sie ein Array von Zeilenhöhen.
5. Fügen Sie der Folie ein [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) hinzu.
6. Iterieren Sie über jede [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) und formatieren Sie deren oberen, unteren, rechten und linken Rand.
7. Fassen Sie die ersten beiden Zellen in der ersten Zeile der Tabelle zusammen.
8. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) einer [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) zu.
9. Fügen Sie dem [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) Text hinzu.
10. Speichern Sie die modifizierte Präsentation.

Das folgende Python‑Beispiel zeigt, wie Sie eine Tabelle in einer Präsentation erstellen:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiate the Presentation class that represents a presentation file.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Define column widths and row heights.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Add a table shape to the slide.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Set the border format for each cell.
    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_top.width = 5

            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_bottom.fill_format.solid_fill_color.color= draw.Color.red
            cell.cell_format.border_bottom.width = 5

            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_left.fill_format.solid_fill_color.color =draw.Color.red
            cell.cell_format.border_left.width = 5

            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell.cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell.cell_format.border_right.width = 5
        
    # Merge cells from (row 0, col 0) to (row 1, col 1).
    table.merge_cells(table.rows[0][0], table.rows[1][1], False)

    # Add text to the merged cell.
    table.rows[0][0].text_frame.text = "Merged Cells"

    # Save the presentation to disk.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Nummerierung in Standardtabellen**

In einer Standardtabelle ist die Zellnummerierung einfach und nullbasiert. Die erste Zelle einer Tabelle hat den Index (0, 0) (Spalte 0, Zeile 0).

Beispielsweise sind in einer Tabelle mit 4 Spalten und 4 Zeilen die Zellen wie folgt nummeriert:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Das folgende Python‑Beispiel zeigt, wie Sie Zellen anhand dieser nullbasierten Nummerierung referenzieren:

```python
for row_index in range(len(table.rows)):
    for column_index in range(len(table.rows[row_index])):
        cell = table.rows[row_index][column_index]
        cell.text_frame.text = f"({column_index}, {row_index})"
```

## **Zugriff auf eine vorhandene Tabelle**

Dieser Abschnitt erklärt, wie Sie mithilfe von Aspose.Slides eine vorhandene Tabelle in einer Präsentation finden und bearbeiten. Sie lernen, wie Sie die Tabelle auf einer Folie lokalisieren, auf deren Zeilen, Spalten und Zellen zugreifen und Inhalte bzw. Formatierungen aktualisieren.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Holen Sie sich eine Referenz zu der Folie, die die Tabelle enthält, über deren Index.
3. Durchlaufen Sie alle [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)-Objekte, bis Sie die Tabelle finden.
4. Verwenden Sie das [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/)-Objekt, um mit der Tabelle zu arbeiten.
5. Speichern Sie die modifizierte Präsentation.

{{% alert color="info" %}}
Wenn die Folie mehrere Tabellen enthält, ist es besser, die gewünschte Tabelle über ihre `alternative_text`‑Eigenschaft zu suchen.
{{% /alert %}}

Das folgende Python‑Beispiel zeigt, wie Sie auf eine vorhandene Tabelle zugreifen und sie bearbeiten:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instantiate the Presentation class to load a PPTX file.
with slides.Presentation("sample.pptx") as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    table = None

    # Iterate through shapes and reference the first table found.
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # Set the text of the first cell in the first row.
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # Save the modified presentation to disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Text in Tabellen ausrichten**

Dieser Abschnitt zeigt, wie Sie die Textausrichtung innerhalb von Tabellenzellen mit Aspose.Slides steuern. Sie lernen, horizontale und vertikale Ausrichtung für Zellen festzulegen, um Inhalte klar und konsistent zu halten.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Holen Sie sich eine Referenz zu der Folie über deren Index.
3. Fügen Sie der Folie ein [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/)-Objekt hinzu.
4. Greifen Sie auf ein [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/)-Objekt aus der Tabelle zu.
5. Richten Sie den Text vertikal aus.
6. Speichern Sie die modifizierte Präsentation.

Das folgende Python‑Beispiel zeigt, wie Sie den Text in einer Tabelle ausrichten:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Create an instance of the Presentation class.
with slides.Presentation() as presentation:
    # Access the first slide.
    slide = presentation.slides[0]

    # Define column widths and row heights.
    column_widths = [40, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Add a table shape to the slide.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Numbers"
    table.rows[1][0].text_frame.text = "10"
    table.rows[2][0].text_frame.text = "20"
    table.rows[3][0].text_frame.text = "30"

    # Center the text and set vertical orientation.
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Save the presentation to disk.
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **Textformatierung auf Tabellenebene festlegen**

Dieser Abschnitt zeigt, wie Sie in Aspose.Slides Textformatierung auf Tabellenebene anwenden, sodass jede Zelle einen konsistenten, einheitlichen Stil übernimmt. Sie lernen, Schriftgrößen, Ausrichtungen und Ränder global festzulegen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Holen Sie sich eine Referenz zu der Folie über deren Index.
3. Fügen Sie der Folie ein [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) hinzu.
4. Legen Sie die Schriftgröße (Schrift‑höhe) für den Text fest.
5. Setzen Sie Absatzausrichtung und -ränder.
6. Definieren Sie die vertikale Textausrichtung.
7. Speichern Sie die modifizierte Präsentation.

Das folgende Python‑Beispiel zeigt, wie Sie Ihre bevorzugten Formatierungsoptionen auf Texte in einer Tabelle anwenden:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Creates an instance of the Presentation class
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # Set the font size for all table cells.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    # Set right-aligned text and a right margin for all table cells.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # Set the vertical text orientation for all table cells.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Vordefinierte Tabellenstile anwenden**

Aspose.Slides ermöglicht das Formatieren von Tabellen mithilfe vordefinierter Stile direkt im Code. Das Beispiel demonstriert das Erstellen einer Tabelle, das Anwenden eines integrierten Stils und das Speichern des Ergebnisses – ein effizienter Weg, um einheitliche, professionelle Formatierung sicherzustellen.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Seitenverhältnis von Tabellen sperren**

Das Seitenverhältnis einer Form ist das Verhältnis ihrer Abmessungen. Aspose.Slides stellt die Eigenschaft `aspect_ratio_locked` bereit, mit der Sie das Seitenverhältnis von Tabellen und anderen Formen sperren können.

Das folgende Python‑Beispiel zeigt, wie Sie das Seitenverhältnis einer Tabelle sperren:

```py
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    table.shape_lock.aspect_ratio_locked = not table.shape_lock.aspect_ratio_locked
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kann ich die Rechts‑nach‑Links‑Lese­richtung (RTL) für eine gesamte Tabelle und den Text in ihren Zellen aktivieren?**

Ja. Die Tabelle stellt die Eigenschaft [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/) bereit, und Absätze besitzen [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/). Die Nutzung beider sorgt für die korrekte RTL‑Reihenfolge und -Darstellung innerhalb der Zellen.

**Wie kann ich verhindern, dass Benutzer eine Tabelle in der endgültigen Datei verschieben oder die Größe ändern?**

Verwenden Sie [shape locks](/slides/de/python-net/applying-protection-to-presentation/), um Verschieben, Größenänderung, Auswahl usw. zu deaktivieren. Diese Sperren gelten auch für Tabellen.

**Wird das Einfügen eines Bildes als Hintergrund in einer Zelle unterstützt?**

Ja. Sie können für eine Zelle eine [picture fill](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) festlegen; das Bild deckt den Zellbereich je nach gewähltem Modus (Strecken oder Kacheln) ab.