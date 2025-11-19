---
title: Tabellenerstellung und -verwaltung in Präsentationen mit Python
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
description: "Tabellen in PowerPoint- und OpenDocument‑Folien mit Aspose.Slides für Python via .NET erstellen & bearbeiten. Entdecken Sie einfache Codebeispiele, um Ihre Tabellen‑Workflows zu optimieren."
---

## **Übersicht**

Eine Tabelle in PowerPoint ist ein effizienter Weg, Informationen darzustellen. Informationen, die in einem Raster aus Zellen (Zeilen und Spalten) angeordnet sind, sind klar und leicht zu verstehen.

Aspose.Slides stellt die [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) Klasse, die [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) Klasse und andere verwandte Typen zur Verfügung, um Ihnen beim Erstellen, Aktualisieren und Verwalten von Tabellen in jeder Präsentation zu helfen.

## **Tabellen von Grund auf erstellen**

Dieser Abschnitt zeigt, wie Sie in Aspose.Slides eine Tabelle von Grund auf erstellen, indem Sie einer Folie eine Tabellengrafik hinzufügen, deren Zeilen und Spalten definieren und genaue Größen festlegen. Sie sehen außerdem, wie Sie Zellen mit Text füllen, Ausrichtung und Ränder anpassen und das Aussehen der Tabelle anpassen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.  
2. Holen Sie sich eine Referenz zu einer Folie anhand ihres Index.  
3. Definieren Sie ein Array von Spaltenbreiten.  
4. Definieren Sie ein Array von Zeilenhöhen.  
5. Fügen Sie der Folie ein [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) hinzu.  
6. Iterieren Sie über jedes [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) und formatieren Sie dessen obere, untere, rechte und linke Ränder.  
7. Führen Sie die ersten beiden Zellen in der ersten Zeile der Tabelle zusammen.  
8. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) eines [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) zu.  
9. Fügen Sie dem [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) Text hinzu.  
10. Speichern Sie die geänderte Präsentation.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instanziieren Sie die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:
    # Greifen Sie auf die erste Folie zu.
    slide = presentation.slides[0]

    # Definieren Sie die Spaltenbreiten und Zeilenhöhen.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Fügen Sie der Folie ein Tabellenelement hinzu.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Legen Sie das Rahmenformat für jede Zelle fest.
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
        
    # Fügen Sie Zellen von (Zeile 0, Spalte 0) bis (Zeile 1, Spalte 1) zusammen.
    table.merge_cells(table.rows[0][0], table.rows[1][1], False)

    # Fügen Sie Text zur zusammengeführten Zelle hinzu.
    table.rows[0][0].text_frame.text = "Merged Cells"

    # Speichern Sie die Präsentation auf dem Datenträger.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```


## **Nummerierung in Standardtabellen**

In einer Standardtabelle ist die Zellnummerierung einfach und nullbasiert. Die erste Zelle einer Tabelle hat den Index (0, 0) (Spalte 0, Zeile 0).

Zum Beispiel werden in einer Tabelle mit 4 Spalten und 4 Zeilen die Zellen wie folgt nummeriert:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Das folgende Python‑Beispiel zeigt, wie Sie Zellen mit dieser nullbasierten Nummerierung referenzieren:
```python
for row_index in range(len(table.rows)):
    for column_index in range(len(table.rows[row_index])):
        cell = table.rows[row_index][column_index]
        cell.text_frame.text = f"({column_index}, {row_index})"
```


## **Zugriff auf eine vorhandene Tabelle**

Dieser Abschnitt erklärt, wie Sie in einer Präsentation eine vorhandene Tabelle finden und damit arbeiten können, indem Sie Aspose.Slides verwenden. Sie lernen, wie Sie die Tabelle auf einer Folie finden, auf ihre Zeilen, Spalten und Zellen zugreifen und Inhalte oder Formatierungen aktualisieren.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.  
2. Holen Sie sich eine Referenz zu der Folie, die die Tabelle enthält, anhand ihres Index.  
3. Durchlaufen Sie alle [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/) Objekte, bis Sie die Tabelle finden.  
4. Verwenden Sie das [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) Objekt, um mit der Tabelle zu arbeiten.  
5. Speichern Sie die geänderte Präsentation.

{{% alert color="info" %}}
Wenn die Folie mehrere Tabellen enthält, ist es besser, die gewünschte Tabelle über ihre `alternative_text`‑Eigenschaft zu suchen.
{{% /alert %}}

Das folgende Python‑Beispiel zeigt, wie Sie auf eine vorhandene Tabelle zugreifen und mit ihr arbeiten:
```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instanziieren Sie die Presentation‑Klasse, um eine PPTX‑Datei zu laden.
with slides.Presentation("sample.pptx") as presentation:
    # Greifen Sie auf die erste Folie zu.
    slide = presentation.slides[0]

    table = None

    # Durchlaufen Sie die Formen und referenzieren Sie die erste gefundene Tabelle.
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # Setzen Sie den Text der ersten Zelle in der ersten Zeile.
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # Speichern Sie die geänderte Präsentation auf dem Datenträger.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Text in Tabellen ausrichten**

Dieser Abschnitt zeigt, wie Sie die Textausrichtung in Tabellenzellen mit Aspose.Slides steuern. Sie lernen, horizontale und vertikale Ausrichtung für Zellen festzulegen, um Ihren Inhalt klar und konsistent zu halten.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.  
2. Holen Sie sich eine Referenz zu der Folie anhand ihres Index.  
3. Fügen Sie der Folie ein [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) Objekt hinzu.  
4. Greifen Sie auf ein [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) Objekt aus der Tabelle zu.  
5. Richten Sie den Text vertikal aus.  
6. Speichern Sie die geänderte Präsentation.

Das folgende Python‑Beispiel zeigt, wie Sie den Text in einer Tabelle ausrichten:
```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Erstelle eine Instanz der Presentation-Klasse.
with slides.Presentation() as presentation:
    # Greife auf die erste Folie zu.
    slide = presentation.slides[0]

    # Definiere Spaltenbreiten und Zeilenhöhen.
    column_widths = [40, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Füge der Folie ein Tabellenelement hinzu.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Numbers"
    table.rows[1][0].text_frame.text = "10"
    table.rows[2][0].text_frame.text = "20"
    table.rows[3][0].text_frame.text = "30"

    # Zentriere den Text und setze die vertikale Ausrichtung.
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Speichere die Präsentation auf dem Datenträger.
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```


## **Textformatierung auf Tabellenebene festlegen**

Dieser Abschnitt zeigt, wie Sie in Aspose.Slides Textformatierung auf Tabellenebene anwenden, sodass jede Zelle einen einheitlichen Stil erbt. Sie lernen, Schriftgrößen, Ausrichtungen und Ränder global festzulegen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) Klasse.  
2. Holen Sie sich eine Referenz zu der Folie anhand ihres Index.  
3. Fügen Sie der Folie ein [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) hinzu.  
4. Legen Sie die Schriftgröße (Schrift­höhe) für den Text fest.  
5. Setzen Sie Absatz­ausrichtung und Ränder.  
6. Legen Sie die vertikale Textausrichtung fest.  
7. Speichern Sie die geänderte Präsentation.

Das folgende Python‑Beispiel zeigt, wie Sie Ihre bevorzugten Formatierungsoptionen auf Text in einer Tabelle anwenden:
```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Erstellt eine Instanz der Presentation-Klasse
with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    table = slide.shapes.add_table(20, 20, [100, 50, 30], [30, 50, 30])

    # Legt die Schriftgröße für alle Tabellenzellen fest.
    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    # Setzt rechtsbündigen Text und einen rechten Rand für alle Tabellenzellen.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # Legt die vertikale Textausrichtung für alle Tabellenzellen fest.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```


## **Vordefinierte Tabellenstile anwenden**

Aspose.Slides ermöglicht es Ihnen, Tabellen mithilfe vordefinierter Stile direkt im Code zu formatieren. Das Beispiel demonstriert das Erstellen einer Tabelle, das Anwenden eines integrierten Stils und das Speichern des Ergebnisses – ein effizienter Weg, um konsistente, professionelle Formatierung sicherzustellen.
```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```


## **Seitenverhältnis von Tabellen sperren**

Das Seitenverhältnis einer Form ist das Verhältnis ihrer Abmessungen. Aspose.Slides stellt die `aspect_ratio_locked`‑Eigenschaft bereit, mit der Sie das Seitenverhältnis für Tabellen und andere Formen sperren können.

Das folgende Python‑Beispiel zeigt, wie Sie das Seitenverhältnis für eine Tabelle sperren:
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

**Kann ich die Rechts‑nach‑Links‑Leserichtung (RTL) für eine gesamte Tabelle und den Text in ihren Zellen aktivieren?**

Ja. Die Tabelle stellt die [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/)‑Eigenschaft bereit, und Paragraphen besitzen [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/). Durch die Verwendung beider wird die korrekte RTL‑Reihenfolge und Darstellung in den Zellen sichergestellt.

**Wie kann ich verhindern, dass Benutzer eine Tabelle in der endgültigen Datei verschieben oder skalieren?**

Verwenden Sie [shape locks](/slides/de/python-net/applying-protection-to-presentation/), um Verschieben, Skalieren, Auswählen usw. zu deaktivieren. Diese Sperren gelten auch für Tabellen.

**Wird das Einfügen eines Bildes als Hintergrund in einer Zelle unterstützt?**

Ja. Sie können für eine Zelle ein [picture fill](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) festlegen; das Bild deckt den Zellenbereich gemäß dem gewählten Modus (Dehnen oder Kacheln) ab.