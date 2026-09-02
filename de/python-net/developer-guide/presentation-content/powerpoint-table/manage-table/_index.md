---
title: "Tabellen in Präsentationen mit Python verwalten"
linktitle: "Tabellen verwalten"
type: docs
weight: 10
url: /de/python-net/manage-table/
keywords:
- "Tabelle hinzufügen"
- "Tabelle erstellen"
- "Zugriff auf Tabelle"
- "Seitenverhältnis"
- "Text ausrichten"
- "Textformatierung"
- "Tabellenstil"
- "PowerPoint"
- "OpenDocument"
- "Präsentation"
- "Python"
- "Aspose.Slides"
description: "Erstellen und bearbeiten Sie Tabellen in PowerPoint- und OpenDocument‑Folien mit Aspose.Slides für Python über .NET. Entdecken Sie einfache Code‑Beispiele, um Ihre Tabellen‑Workflows zu optimieren."
---
## **Einführung**

Eine Tabelle in PowerPoint ist ein effizientes Mittel, um Informationen darzustellen. Informationen, die in einem Raster aus Zellen (Zeilen und Spalten) angeordnet sind, sind leicht verständlich.

Aspose.Slides stellt die [Table](https://reference.aspose.com/slides/de/python-net/aspose.slides/table/)‑Klasse, die [Cell](https://reference.aspose.com/slides/de/python-net/aspose.slides/cell/)‑Klasse und weitere zugehörige Typen zur Verfügung, um Tabellen in jeder Präsentation zu erstellen, zu aktualisieren und zu verwalten.

## **Tabellen von Grund auf erstellen**

In diesem Abschnitt wird gezeigt, wie Sie in Aspose.Slides eine Tabelle von Grund auf erstellen, indem Sie einer Folie ein Tabellenshape hinzufügen, deren Zeilen und Spalten definieren und exakte Größen festlegen. Außerdem erfahren Sie, wie Sie Zellen mit Text füllen, Ausrichtung und Rahmen anpassen und das Erscheinungsbild der Tabelle individuell gestalten.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.  
3. Definieren Sie ein Array von Spaltenbreiten.  
4. Definieren Sie ein Array von Zeilenhöhen.  
5. Fügen Sie der Folie ein [Table](https://reference.aspose.com/slides/de/python-net/aspose.slides/table/)‑Objekt hinzu.  
6. Durchlaufen Sie jede [Cell](https://reference.aspose.com/slides/de/python-net/aspose.slides/cell/) und formatieren Sie deren obere, untere, rechte und linke Rahmen.  
7. Verschmelzen Sie die Zellen der ersten beiden Zeilen und der ersten beiden Spalten zu einer einzigen Zelle.  
8. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/) einer [Cell](https://reference.aspose.com/slides/de/python-net/aspose.slides/cell/) zu.  
9. Fügen Sie dem [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/) Text hinzu.  
10. Speichern Sie die geänderte Präsentation.

Das folgende Python‑Beispiel zeigt, wie Sie eine Tabelle in einer Präsentation erstellen:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

    # Instanziiere die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
    with slides.Presentation() as presentation:
        # Greife auf die erste Folie zu.
        slide = presentation.slides[0]

        # Definiere Spaltenbreiten und Zeilenhöhen.
        column_widths = [50, 50, 50]
        row_heights = [50, 30, 30, 30, 30]

        # Füge der Folie ein Tabellenshape hinzu.
        table = slide.shapes.add_table(100, 50, column_widths, row_heights)

        # Setze das Rahmenformat für jede Zelle.
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
        
        # Verschmelze Zellen von (Zeile 0, Spalte 0) bis (Zeile 1, Spalte 1).
        table.merge_cells(table.rows[0][0], table.rows[1][1], False)

        # Füge Text zur zusammengeführten Zelle hinzu.
        table.rows[0][0].text_frame.text = "Merged Cells"

        # Speichere die Präsentation auf Disk.
        presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Nummerierung in Standardtabellen**

In einer Standardtabelle ist die Zellen­nummerierung einfach und nullbasiert. Die erste Zelle einer Tabelle hat den Index (0, 0) (Spalte 0, Zeile 0).

Beispielsweise sind in einer Tabelle mit 4 Spalten und 4 Zeilen die Zellen wie folgt nummeriert:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Das folgende Python‑Beispiel zeigt, wie Sie Zellen anhand dieser nullbasierten Nummerierung referenzieren:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    # Greife auf die erste Folie zu.
    slide = presentation.slides[0]

    # Füge eine Tabelle mit 4 Spalten und 4 Zeilen hinzu.
    table = slide.shapes.add_table(100, 50, [50, 50, 50, 50], [30, 30, 30, 30])

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.rows[row_index])):
            cell = table.rows[row_index][column_index]
            cell.text_frame.text = f"({column_index}, {row_index})"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Zugriff auf eine vorhandene Tabelle**

In diesem Abschnitt erfahren Sie, wie Sie in einer Präsentation eine vorhandene Tabelle finden und damit arbeiten können. Sie lernen, die Tabelle auf einer Folie zu finden, auf ihre Zeilen, Spalten und Zellen zuzugreifen und Inhalt oder Formatierung zu aktualisieren.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich einen Verweis auf die Folie, die die Tabelle enthält, anhand ihres Index.  
3. Durchlaufen Sie alle [Shape](https://reference.aspose.com/slides/de/python-net/aspose.slides/shape/)‑Objekte, bis Sie die Tabelle finden.  
4. Verwenden Sie das [Table](https://reference.aspose.com/slides/de/python-net/aspose.slides/table/)‑Objekt, um mit der Tabelle zu arbeiten.  
5. Speichern Sie die geänderte Präsentation.

{{% alert color="info" title="Hinweis" %}}
Falls die Folie mehrere Tabellen enthält, ist es besser, die gewünschte Tabelle über deren `alternative_text`‑Eigenschaft zu suchen.
{{% /alert %}}

Das folgende Python‑Beispiel zeigt, wie Sie auf eine vorhandene Tabelle zugreifen und damit arbeiten:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instanziiere die Presentation‑Klasse, um eine PPTX‑Datei zu laden.
with slides.Presentation("sample.pptx") as presentation:
    # Greife auf die erste Folie zu.
    slide = presentation.slides[0]

    table = None

    # Durchlaufe die Shapes und referenziere die zuerst gefundene Tabelle.
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # Setze den Text der ersten Zelle in der ersten Zeile.
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # Speichere die geänderte Präsentation auf Disk.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Die Zelle finden, die einen TextFrame besitzt**

Wenn generischer Textverarbeitungscode ein [TextFrame](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/) einer Tabelle erhält, verwenden Sie die Eigenschaft [TextFrame.parent_cell](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/parent_cell/), um die zugehörige [Cell](https://reference.aspose.com/slides/de/python-net/aspose.slides/cell/) zu ermitteln. Für ein Tabellen‑Zellen‑TextFrame ist [TextFrame.parent_cell](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/parent_cell/) gesetzt und [TextFrame.parent_shape](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/parent_shape/) ist `None`, obwohl die Tabelle selbst ein Shape ist.

Die Zellkoordinaten stehen über die schreibgeschützten Eigenschaften [Cell.first_column_index](https://reference.aspose.com/slides/de/python-net/aspose.slides/cell/first_column_index/) und [Cell.first_row_index](https://reference.aspose.com/slides/de/python-net/aspose.slides/cell/first_row_index/) zur Verfügung. [TextFrame.parent_cell](https://reference.aspose.com/slides/de/python-net/aspose.slides/textframe/parent_cell/) ist ebenfalls schreibgeschützt: Sie ermöglicht die Navigation zum Eigentümer, ändert jedoch nichts an der Besitzstruktur. Überprüfen Sie immer, ob die zurückgegebene Zelle `None` ist, bevor Sie sie verwenden.

Ein vollständiges Beispiel, das Tabellen‑Zellen‑ und Shape‑Eigentümer identifiziert, einschließlich der Shapes, die mit SmartArt‑Knoten verknüpft sind, finden Sie unter [Search and Replace Text](/slides/de/python-net/search-and-replace-text/).

## **Text in Tabellen ausrichten**

Dieser Abschnitt zeigt, wie Sie die Textpositionierung innerhalb von Tabellenzellen mit Aspose.Slides steuern. Sie lernen, den Text vertikal in einer Zelle zu verankern und die Schreibrichtung zu ändern.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich einen Verweis auf die Folie anhand ihres Index.  
3. Fügen Sie der Folie ein [Table](https://reference.aspose.com/slides/de/python-net/aspose.slides/table/)‑Objekt hinzu.  
4. Greifen Sie auf ein [Cell](https://reference.aspose.com/slides/de/python-net/aspose.slides/cell/)‑Objekt der Tabelle zu.  
5. Zentrieren Sie den Text vertikal in der Zelle und setzen Sie die Text­richtung.  
6. Speichern Sie die geänderte Präsentation.

Das folgende Python‑Beispiel zeigt, wie Sie den Text in einer Tabelle ausrichten:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Erstelle eine Instanz der Presentation‑Klasse.
with slides.Presentation() as presentation:
    # Greife auf die erste Folie zu.
    slide = presentation.slides[0]

    # Definiere Spaltenbreiten und Zeilenhöhen.
    column_widths = [40, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Füge ein Tabellenshape zur Folie hinzu.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Numbers"
    table.rows[1][0].text_frame.text = "10"
    table.rows[2][0].text_frame.text = "20"
    table.rows[3][0].text_frame.text = "30"

    # Zentriere den Text und setze die vertikale Ausrichtung.
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Speichere die Präsentation auf Disk.
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **Textformatierung auf Tabellenebene festlegen**

In diesem Abschnitt wird beschrieben, wie Sie in Aspose.Slides Textformatierungen auf Tabellenebene anwenden, sodass jede Zelle einen einheitlichen Stil erbt. Sie lernen, Schriftgrößen, Ausrichtungen und Randabstände global festzulegen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-net/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie sich einen Verweis auf die Folie anhand ihres Index.  
3. Fügen Sie der Folie ein [Table](https://reference.aspose.com/slides/de/python-net/aspose.slides/table/)‑Objekt hinzu.  
4. Legen Sie die Schriftgröße (Schrift‑Höhe) für den Text fest.  
5. Definieren Sie die Absatz‑Ausrichtung und die Randabstände.  
6. Setzen Sie die vertikale Text‑Orientierung.  
7. Speichern Sie die geänderte Präsentation.

Das folgende Python‑Beispiel zeigt, wie Sie Ihre bevorzugten Formatierungsoptionen auf Text in einer Tabelle anwenden:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Erstellt eine Instanz der Presentation‑Klasse
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # Setzt die Schriftgröße für alle Tabellenzellen.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    # Setzt rechtsbündigen Text und einen rechten Rand für alle Tabellenzellen.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # Setzt die vertikale Textausrichtung für alle Tabellenzellen.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Vordefinierte Tabellen‑Stile anwenden**

Aspose.Slides ermöglicht Ihnen, Tabellen mithilfe vordefinierter Stile direkt im Code zu formatieren. Das Beispiel demonstriert das Erstellen einer Tabelle, das Anwenden eines integrierten Stils und das Speichern des Ergebnisses – ein effizienter Weg, um einheitliche, professionelle Formatierung sicherzustellen.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Seitenverhältnis von Tabellen sperren**

Das Seitenverhältnis einer Form ist das Verhältnis ihrer Abmessungen. Aspose.Slides stellt die Eigenschaft `aspect_ratio_locked` bereit, mit der Sie das Seitenverhältnis für Tabellen und andere Formen sperren können.

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

**Kann ich die Rechts‑zu‑Links‑(RTL‑)Leserichtung für eine gesamte Tabelle und den Text in ihren Zellen aktivieren?**

Ja. Die Tabelle stellt die Eigenschaft [right_to_left](https://reference.aspose.com/slides/de/python-net/aspose.slides/table/right_to_left/) bereit, und Paragraphen besitzen [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/de/python-net/aspose.slides/paragraphformat/right_to_left/). Die Kombination sorgt für die korrekte RTL‑Reihenfolge und Darstellung innerhalb der Zellen.

**Wie kann ich verhindern, dass Benutzer eine Tabelle in der finalen Datei verschieben oder die Größe ändern?**

Verwenden Sie [shape locks](/slides/de/python-net/applying-protection-to-presentation/), um das Verschieben, Ändern der Größe, Auswählen usw. zu deaktivieren. Diese Sperren gelten ebenfalls für Tabellen.

**Wird das Einfügen eines Bildes als Hintergrund in einer Zelle unterstützt?**

Ja. Sie können für eine Zelle eine [picture fill](https://reference.aspose.com/slides/de/python-net/aspose.slides/picturefillformat/) festlegen; das Bild deckt dann den Zellenbereich gemäß dem gewählten Modus (Strecken oder Kacheln) ab.