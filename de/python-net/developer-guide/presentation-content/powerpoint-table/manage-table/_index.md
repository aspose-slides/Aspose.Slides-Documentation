---
title: Tabellenerstellung in Präsentationen mit Python
linktitle: Tabelle verwalten
type: docs
weight: 10
url: /de/python-net/developer-guide/presentation-content/powerpoint-table/manage-table/
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
description: "Erstellen und bearbeiten Sie Tabellen in PowerPoint- und OpenDocument‑Folien mit Aspose.Slides für Python via .NET. Entdecken Sie einfache Code‑Beispiele, um Ihre Tabellen‑Workflows zu optimieren."
---

## **Übersicht**

Eine Tabelle in PowerPoint ist ein effizientes Mittel, um Informationen darzustellen. Informationen, die in einem Raster aus Zellen (Zeilen und Spalten) angeordnet sind, sind leicht verständlich.

Aspose.Slides stellt die [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/)-Klasse, die [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/)-Klasse und weitere verwandte Typen bereit, um Ihnen das Erstellen, Aktualisieren und Verwalten von Tabellen in jeder Präsentation zu erleichtern.

## **Tabellen von Grund auf erstellen**

Dieser Abschnitt zeigt, wie Sie in Aspose.Slides eine Tabelle von Grund auf neu erstellen, indem Sie einer Folie eine Tabellengestalt hinzufügen, Zeilen und Spalten definieren und präzise Größen festlegen. Sie sehen außerdem, wie Sie Zellen mit Text füllen, Ausrichtung und Rahmen anpassen und das Aussehen der Tabelle individuell gestalten.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.
2. Holen Sie sich einen Verweis auf eine Folie über deren Index.
3. Definieren Sie ein Array von Spaltenbreiten.
4. Definieren Sie ein Array von Zeilenhöhen.
5. Fügen Sie der Folie ein [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/)-Objekt hinzu.
6. Durchlaufen Sie jede [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) und formatieren Sie deren oberen, unteren, rechten und linken Rahmen.
7. Kombinieren Sie die ersten beiden Zellen in der ersten Zeile der Tabelle.
8. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) einer [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) zu.
9. Fügen Sie dem [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) Text hinzu.
10. Speichern Sie die geänderte Präsentation.

Das folgende Python‑Beispiel zeigt, wie Sie eine Tabelle in einer Präsentation erstellen:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instanziiert die Presentation‑Klasse, die eine Präsentationsdatei darstellt.
with slides.Presentation() as presentation:
    # Greift auf die erste Folie zu.
    slide = presentation.slides[0]

    # Definiert Spaltenbreiten und Zeilenhöhen.
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Fügt der Folie ein Tabellen‑Shape hinzu.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    # Legt das Rahmenformat für jede Zelle fest.
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
        
    # Kombiniert Zellen von (Zeile 0, Spalte 0) bis (Zeile 1, Spalte 1).
    table.merge_cells(table.rows[0][0], table.rows[1][1], False)

    # Fügt dem zusammengeführten Feld Text hinzu.
    table.rows[0][0].text_frame.text = "Merged Cells"

    # Speichert die Präsentation auf dem Datenträger.
    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Nummerierung in Standardtabellen**

In einer Standardtabelle ist die Zellnummerierung einfach und nullbasiert. Die erste Zelle einer Tabelle hat den Index (0, 0) (Spalte 0, Zeile 0).

Beispielhaft sind bei einer Tabelle mit 4 Spalten und 4 Zeilen die Zellen wie folgt nummeriert:

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

## **Eine vorhandene Tabelle öffnen**

Dieser Abschnitt erklärt, wie Sie eine vorhandene Tabelle in einer Präsentation mit Aspose.Slides finden und bearbeiten. Sie lernen, wie Sie die Tabelle auf einer Folie ausfindig machen, deren Zeilen, Spalten und Zellen zugreifen und Inhalte oder Formatierungen aktualisieren.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.
2. Holen Sie sich einen Verweis auf die Folie, die die Tabelle enthält, über deren Index.
3. Durchlaufen Sie alle [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)-Objekte, bis Sie die Tabelle finden.
4. Verwenden Sie das [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/)-Objekt, um mit der Tabelle zu arbeiten.
5. Speichern Sie die geänderte Präsentation.

{{% alert color="info" %}}

Enthält die Folie mehrere Tabellen, ist es besser, nach der Tabelle zu suchen, die Sie benötigen, über deren `alternative_text`‑Eigenschaft.

{{% /alert %}}

Das folgende Python‑Beispiel zeigt, wie Sie eine vorhandene Tabelle öffnen und bearbeiten:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Instanziiert die Presentation‑Klasse, um eine PPTX‑Datei zu laden.
with slides.Presentation("sample.pptx") as presentation:
    # Greift auf die erste Folie zu.
    slide = presentation.slides[0]

    table = None

    # Durchläuft die Shapes und referenziert die erste gefundene Tabelle.
    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    # Setzt den Text der ersten Zelle in der ersten Zeile.
    if table is not None:
        table.rows[0][0].text_frame.text = "Found"

    # Speichert die geänderte Präsentation auf dem Datenträger.
    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Text in Tabellen ausrichten**

Dieser Abschnitt zeigt, wie Sie die Textausrichtung innerhalb von Tabellenzellen mit Aspose.Slides steuern. Sie lernen, horizontale und vertikale Ausrichtungen für Zellen festzulegen, um Ihren Inhalt klar und konsistent zu halten.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.
2. Holen Sie sich einen Verweis auf die Folie über deren Index.
3. Fügen Sie der Folie ein [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/)-Objekt hinzu.
4. Greifen Sie auf ein [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/)-Objekt aus der Tabelle zu.
5. Richten Sie den Text vertikal aus.
6. Speichern Sie die geänderte Präsentation.

Das folgende Python‑Beispiel zeigt, wie Sie den Text in einer Tabelle ausrichten:

```python
import aspose.pydrawing as draw
import aspose.slides as slides

# Erstellt eine Instanz der Presentation‑Klasse.
with slides.Presentation() as presentation:
    # Greift auf die erste Folie zu.
    slide = presentation.slides[0]

    # Definiert Spaltenbreiten und Zeilenhöhen.
    column_widths = [40, 120, 120, 120]
    row_heights = [100, 100, 100, 100]

    # Fügt der Folie ein Tabellen‑Shape hinzu.
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Numbers"
    table.rows[1][0].text_frame.text = "10"
    table.rows[2][0].text_frame.text = "20"
    table.rows[3][0].text_frame.text = "30"

    # Zentriert den Text und legt die vertikale Ausrichtung fest.
    cell = table.rows[0][0]
    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    # Speichert die Präsentation auf dem Datenträger.
    presentation.save("aligned_cell.pptx", slides.export.SaveFormat.PPTX)
```

## **Textformatierung auf Tabellen­ebene festlegen**

Dieser Abschnitt zeigt, wie Sie Textformatierungen auf Tabellenebene in Aspose.Slides anwenden, sodass jede Zelle einen konsistenten, einheitlichen Stil erbt. Sie lernen, Schriftgrößen, Ausrichtungen und Ränder global zu setzen.

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/)-Klasse.
2. Holen Sie sich einen Verweis auf die Folie über deren Index.
3. Fügen Sie der Folie ein [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/)-Objekt hinzu.
4. Setzen Sie die Schriftgröße (Font‑Height) für den Text.
5. Legen Sie die Absatz‑Ausrichtung und Ränder fest.
6. Setzen Sie die vertikale Textorientierung.
7. Speichern Sie die geänderte Präsentation.

Das folgende Python‑Beispiel zeigt, wie Sie Ihre bevorzugten Formatierungsoptionen auf den Text einer Tabelle anwenden:

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

    # Rechtsbündigen Text und rechten Rand für alle Tabellenzellen festlegen.
    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    # Vertikale Textorientierung für alle Tabellenzellen festlegen.
    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("output.pptx", slides.export.SaveFormat.PPTX)
```

## **Vordefinierte Tabellen­stile anwenden**

Aspose.Slides ermöglicht das Formatieren von Tabellen mithilfe vordefinierter Stile direkt im Code. Das Beispiel demonstriert das Erstellen einer Tabelle, das Anwenden eines integrierten Stils und das Speichern des Ergebnisses – ein effizienter Weg, um einheitliche, professionelle Formatierungen sicherzustellen.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]
    table = slide.shapes.add_table(10, 10, [100, 150], [5, 5, 5])

    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Seitenverhältnis von Tabellen sperren**

Das Seitenverhältnis einer Form ist das Verhältnis ihrer Abmessungen. Aspose.Slides bietet die Eigenschaft `aspect_ratio_locked`, mit der Sie das Seitenverhältnis von Tabellen und anderen Formen sperren können.

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

**Kann ich die Rechts‑zu‑Links‑Lese­richtung (RTL) für eine gesamte Tabelle und den Text in deren Zellen aktivieren?**

Ja. Die Tabelle bietet die Eigenschaft [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/), und Absätze besitzen [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/). Die Kombination stellt die korrekte RTL‑Reihenfolge und -Darstellung in den Zellen sicher.

**Wie kann ich verhindern, dass Benutzer eine Tabelle in der endgültigen Datei verschieben oder die Größe ändern?**

Verwenden Sie [shape locks](/slides/de/python-net/applying-protection-to-presentation/), um Verschieben, Größenänderung, Auswahl usw. zu deaktivieren. Diese Sperren gelten auch für Tabellen.

**Wird das Einfügen eines Bildes als Hintergrund in einer Zelle unterstützt?**

Ja. Sie können für eine Zelle einen [picture fill](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) festlegen; das Bild füllt die Zelle je nach gewähltem Modus (Strecken oder Kacheln).