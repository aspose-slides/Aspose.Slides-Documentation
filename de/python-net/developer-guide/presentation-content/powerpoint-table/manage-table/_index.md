---
title: Präsentationstabellen mit Python verwalten
linktitle: Tabelle verwalten
type: docs
weight: 10
url: /de/python-net/manage-table/
keywords:
- Tabelle hinzufügen
- Tabelle erstellen
- Zugriff auf Tabelle
- Seitenverhältnis
- Text ausrichten
- Textformatierung
- Tabellenstil
- PowerPoint
- OpenDocument
- Präsentation
- Python
- Aspose.Slides
description: "Erstellen und Bearbeiten von Tabellen in PowerPoint- und OpenDocument-Folien mit Aspose.Slides für Python über .NET. Entdecken Sie einfache Codebeispiele, um Ihre Tabellen-Workflows zu optimieren."
---
## **Einführung**

Tabellen in PowerPoint organisieren Informationen in Zeilen und Spalten und erleichtern das Lesen und den Vergleich von Werten.

Aspose.Slides stellt die Klassen [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/) und [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) sowie weitere Typen zur Verfügung, mit denen Sie Tabellen in Präsentationen erstellen, aktualisieren und verwalten können.

## **Erstellen einer Tabelle von Grund auf**

Erstellen Sie eine Tabelle, indem Sie ihre Position, Spaltenbreiten und Zeilenhöhen angeben. Nach dem Hinzufügen zu einer Folie können Sie Zellenränder formatieren, Zellen zusammenführen und Text einfügen.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Holen Sie sich eine Referenz auf die Folie anhand ihres Index.
3. Definieren Sie eine Liste von Spaltenbreiten in Punkten.
4. Definieren Sie eine Liste von Zeilenhöhen in Punkten.
5. Fügen Sie ein [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/)‑Objekt mithilfe der Methode [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) zur Folie hinzu.
6. Iterieren Sie über jede [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/), um die Formatierung für die oberen, unteren, rechten und linken Ränder anzuwenden.
7. Führen Sie die ersten beiden Zellen der ersten Zeile der Tabelle zusammen.
8. Greifen Sie über die Eigenschaft [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/) auf die zusammengeführte Zelle zu.
9. Setzen Sie den Text in der zusammengeführten Zelle.
10. Speichern Sie die geänderte Präsentation.

Das folgende Beispiel erstellt eine Tabelle mit drei Spalten und fünf Zeilen bei (100, 50) Punkten. Es wendet rote Ränder mit einer Breite von 5 Punkten an, führt die ersten beiden Zellen der ersten Zeile zusammen und speichert das Ergebnis als `table.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    table.merge_cells(table.rows[0][0], table.rows[0][1], False)
    table.rows[0][0].text_frame.text = "Merged Cells"

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Nummerierung in einer Standardtabelle**

In einer Standardtabelle sind Zellindizes nullbasiert und verwenden die Reihenfolge (Spalte, Zeile). Die erste Zelle hat den Index (0, 0). In Python greift man mit `table.rows[row_index][column_index]` auf eine Zelle zu; der Zeilenindex steht in diesem Ausdruck zuerst.

Zum Beispiel werden die Zellen in einer Tabelle mit 4 Spalten und 4 Zeilen folgendermaßen nummeriert:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Dieses Beispiel erstellt die oben dargestellte 4 × 4‑Tabelle mit Spaltenbreiten und Zeilenhöhen von 70 Punkten sowie roten Zellenrändern mit einer Breite von 5 Punkten. Die Koordinaten veranschaulichen die Zellindizes; das Beispiel lässt die Zellen leer und speichert die Tabelle als `StandardTables_out.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell_format = cell.cell_format
            cell_format.border_top.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_top.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_top.width = 5

            cell_format.border_bottom.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_bottom.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_bottom.width = 5

            cell_format.border_left.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_left.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_left.width = 5

            cell_format.border_right.fill_format.fill_type = slides.FillType.SOLID
            cell_format.border_right.fill_format.solid_fill_color.color = draw.Color.red
            cell_format.border_right.width = 5

    presentation.save("StandardTables_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Zugriff auf eine vorhandene Tabelle**

Tabellen werden in der Formsammlung einer Folie gespeichert. Durchlaufen Sie die Formen, um eine Tabelle zu finden, und verwenden Sie dann die Klasse [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/), um deren Zellen zu lesen oder zu aktualisieren.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Holen Sie sich eine Referenz auf die Folie, die die Tabelle enthält, anhand ihres Index.
3. Durchlaufen Sie die [Shape](https://reference.aspose.com/slides/python-net/aspose.slides/shape/)‑Objekte und stoppen Sie, wenn eine Tabelle gefunden wird. Enthält die Folie mehrere Tabellen, verwenden Sie [alternative_text](https://reference.aspose.com/slides/python-net/aspose.slides/shape/alternative_text/), um die gewünschte zu identifizieren.
4. Aktualisieren Sie den Text in der Zielzelle.
5. Speichern Sie die geänderte Präsentation.

Das folgende Beispiel öffnet `UpdateExistingTable.pptx` und findet die erste Tabelle auf der ersten Folie. Es setzt die Zelle in Spalte 0, Zeile 1 auf `New` und speichert das Ergebnis als `table1_out.pptx`. Die Eingabedatei muss mindestens eine Folie enthalten, und die erste Tabelle auf dieser Folie muss mindestens eine Spalte und zwei Zeilen besitzen.

```python
import aspose.slides as slides

with slides.Presentation("UpdateExistingTable.pptx") as presentation:
    slide = presentation.slides[0]
    table = None

    for shape in slide.shapes:
        if isinstance(shape, slides.Table):
            table = shape
            break

    if table is not None and len(table.rows) >= 2:
        table.rows[1][0].text_frame.text = "New"
        presentation.save("table1_out.pptx", slides.export.SaveFormat.PPTX)
```

Um eine Zeile in einer vorhandenen Tabelle zu ändern und zu verstehen, warum ihre tatsächliche Höhe das angeforderte Minimum überschreiten kann, siehe [Zeilenhöhe steuern](/slides/de/python-net/manage-rows-and-columns/#control-row-height).

## **Finden der Zelle, die einen Textrahmen besitzt**

Wenn generischer Textverarbeitungscode ein [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/) aus einer Tabelle erhält, verwenden Sie die Eigenschaft [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/), um die zugehörige [Cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) abzurufen. Für einen Tabellenzellen‑TextFrame ist [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) gesetzt und [TextFrame.parent_shape](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_shape/) ist `None`, obwohl die Tabelle selbst eine Form ist.

Die Zellkoordinaten stehen über die schreibgeschützten Eigenschaften [Cell.first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) und [Cell.first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) zur Verfügung. [TextFrame.parent_cell](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/parent_cell/) ist ebenfalls schreibgeschützt: Sie ermöglicht die Navigation zum Eigentümer, ändert jedoch nicht das Eigentum. Überprüfen Sie stets, ob die zurückgegebene Zelle `None` ist, bevor Sie sie verwenden.

Für ein vollständiges Beispiel, das Tabellenzellen‑ und Form‑Eigentümer identifiziert, einschließlich Formen, die zu SmartArt‑Knoten gehören, siehe [Suchen und Ersetzen von Text](/slides/de/python-net/search-and-replace-text/).

## **Text in einer Tabelle ausrichten**

Sie können die vertikale Verankerung und Textausrichtung einzelner Tabellenzellen steuern. Das Beispiel in diesem Abschnitt zentriert den Text innerhalb der ersten Zelle und dreht ihn um 270 Grad.

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Holen Sie sich eine Referenz auf die Folie anhand ihres Index.
3. Fügen Sie ein [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/)‑Objekt zur Folie hinzu.
4. Greifen Sie auf ein [TextFrame](https://reference.aspose.com/slides/python-net/aspose.slides/textframe/)‑Objekt aus der Tabelle zu.
5. Greifen Sie auf den ersten [Paragraph](https://reference.aspose.com/slides/python-net/aspose.slides/paragraph/) zu und setzen Sie dessen Text und Farbe.
6. Setzen Sie den [text_anchor_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_anchor_type/) und den [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_vertical_type/) der Zelle.
7. Speichern Sie die geänderte Präsentation.

Dieses Beispiel erstellt eine 4 × 4‑Tabelle mit Spaltenbreiten von 120 Punkten und Zeilenhöhen von 100 Punkten. Es formatiert den Text in Zelle (0, 0), fügt Werte zu den übrigen Zellen der ersten Zeile hinzu und speichert das Ergebnis als `Vertical_Align_Text_out.pptx`.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [120, 120, 120, 120]
    row_heights = [100, 100, 100, 100]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)
    table.rows[0][1].text_frame.text = "10"
    table.rows[0][2].text_frame.text = "20"
    table.rows[0][3].text_frame.text = "30"

    cell = table.rows[0][0]
    paragraph = cell.text_frame.paragraphs[0]
    portion = paragraph.portions[0]
    portion.text = "Text here"
    portion.portion_format.fill_format.fill_type = slides.FillType.SOLID
    portion.portion_format.fill_format.solid_fill_color.color = draw.Color.black

    cell.text_anchor_type = slides.TextAnchorType.CENTER
    cell.text_vertical_type = slides.TextVerticalType.VERTICAL270

    presentation.save("Vertical_Align_Text_out.pptx", slides.export.SaveFormat.PPTX)
```

## **Textformatierung auf Tabellenebene festlegen**

Verwenden Sie [set_text_format](https://reference.aspose.com/slides/python-net/aspose.slides/table/set_text_format/), um die Textformatierung auf alle Zellen einer Tabelle anzuwenden. Die Überladungen akzeptieren Teil‑, Absatz‑ und TextFrame‑Formatierungen, sodass Sie diese Eigenschaften festlegen können, ohne über einzelne Zellen zu iterieren.

1. Laden Sie die Präsentation mit der Klasse [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/).
2. Holen Sie sich eine Referenz auf die Folie anhand ihres Index.
3. Greifen Sie auf ein [Table](https://reference.aspose.com/slides/python-net/aspose.slides/table/)‑Objekt aus der Folie zu.
4. Setzen Sie die [font_height](https://reference.aspose.com/slides/python-net/aspose.slides/baseportionformat/font_height/) für den Text.
5. Setzen Sie die [alignment](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/alignment/) und [margin_right](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/margin_right/).
6. Setzen Sie den [text_vertical_type](https://reference.aspose.com/slides/python-net/aspose.slides/textframeformat/text_vertical_type/).
7. Speichern Sie die geänderte Präsentation.

Das folgende Beispiel öffnet `table.pptx`, das mindestens eine Folie mit einer Tabelle als erste Form enthalten muss. Es setzt die Schriftgröße auf 25 Punkte, richtet Absätze rechtsbündig mit einem rechten Rand von 20 Punkten aus und macht den Text vertikal. Die formatierte Präsentation wird als `result.pptx` gespeichert.

```python
import aspose.slides as slides

with slides.Presentation("table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    portion_format = slides.PortionFormat()
    portion_format.font_height = 25
    table.set_text_format(portion_format)

    paragraph_format = slides.ParagraphFormat()
    paragraph_format.alignment = slides.TextAlignment.RIGHT
    paragraph_format.margin_right = 20
    table.set_text_format(paragraph_format)

    text_frame_format = slides.TextFrameFormat()
    text_frame_format.text_vertical_type = slides.TextVerticalType.VERTICAL
    table.set_text_format(text_frame_format)

    presentation.save("result.pptx", slides.export.SaveFormat.PPTX)
```

## **Tabellenstil‑Eigenschaften abrufen**

Verwenden Sie [style_preset](https://reference.aspose.com/slides/python-net/aspose.slides/table/style_preset/), um den voreingestellten Stil einer Tabelle zu lesen oder zuzuweisen. Dieses Beispiel wendet [TableStylePreset.DARK_STYLE1](https://reference.aspose.com/slides/python-net/aspose.slides/tablestylepreset/) auf eine Tabelle an, gibt den Preset‑Namen aus und weist denselben Preset einer zweiten Tabelle zu. Beide Tabellen werden in `table-style.pptx` gespeichert.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [100, 150]
    row_heights = [5, 5, 5]
    table = slide.shapes.add_table(10, 10, column_widths, row_heights)
    table.style_preset = slides.TableStylePreset.DARK_STYLE1

    style_preset = table.style_preset
    print(f"Table style preset: {style_preset.name}")

    another_table = slide.shapes.add_table(10, 100, column_widths, row_heights)
    another_table.style_preset = style_preset

    presentation.save("table-style.pptx", slides.export.SaveFormat.PPTX)
```

## **Seitenverhältnis einer Tabelle sperren**

Das Seitenverhältnis einer Tabelle ist das Verhältnis ihrer Breite zu ihrer Höhe. Verwenden Sie [aspect_ratio_locked](https://reference.aspose.com/slides/python-net/aspose.slides/graphicalobjectlock/aspect_ratio_locked/), um dieses Verhältnis für eine Tabelle zu sperren.

Das folgende Beispiel öffnet `pres.pptx`, das mindestens eine Folie mit einer Tabelle als erste Form enthalten muss. Es gibt den aktuellen Sperrstatus aus, aktiviert die Sperrung des Seitenverhältnisses, gibt den aktualisierten Status (`True`) aus und speichert das Ergebnis als `pres-out.pptx`.

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")
    
    table.shape_lock.aspect_ratio_locked = True
    print(f"Lock aspect ratio set: {table.shape_lock.aspect_ratio_locked}")

    presentation.save("pres-out.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kann ich die Rechts-nach-Links‑Lese­richtung (RTL) für eine gesamte Tabelle und den Text in ihren Zellen aktivieren?**

Ja. Die Tabelle stellt die Eigenschaft [right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/table/right_to_left/) bereit, und Absätze haben [ParagraphFormat.right_to_left](https://reference.aspose.com/slides/python-net/aspose.slides/paragraphformat/right_to_left/). Die Verwendung beider stellt die korrekte RTL‑Reihenfolge und -Darstellung innerhalb der Zellen sicher.

**Wie kann ich verhindern, dass Benutzer eine Tabelle in der endgültigen Datei verschieben oder die Größe ändern?**

Verwenden Sie [Form‑Sperren](/slides/de/python-net/applying-protection-to-presentation/), um das Verschieben, Ändern der Größe, Auswählen usw. zu deaktivieren. Diese Sperren gelten auch für Tabellen.

**Wird das Einfügen eines Bildes als Hintergrund in einer Zelle unterstützt?**

Ja. Sie können für eine Zelle eine [Bildfüllung](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillformat/) festlegen; das Bild deckt die Zellenfläche gemäß dem gewählten Modus (Strecken oder Kachel) ab.