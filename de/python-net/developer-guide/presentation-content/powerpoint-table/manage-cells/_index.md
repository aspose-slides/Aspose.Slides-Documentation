---
title: Tabellenzellen in Präsentationen mit Python verwalten
linktitle: Zellen verwalten
type: docs
weight: 30
url: /de/python-net/manage-cells/
keywords:
- Tabellenzelle
- Zellen zusammenführen
- Rand entfernen
- Zelle aufteilen
- Bild in Zelle
- Hintergrundfarbe
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "PowerPoint‑Tabellenzellen in Python verwalten: zusammengeführte Zellen identifizieren, Rahmen entfernen, Zellen aufteilen und Hintergrundfarben sowie Bilder mit Aspose.Slides für Python über .NET setzen."
---
## **Übersicht**

Aspose.Slides ermöglicht den Zugriff auf und die Bearbeitung von Tabellenzellen in PowerPoint‑Präsentationen. Dieser Artikel erklärt, wie man zusammengeführte Tabellenzellen erkennt, Zellenrahmen entfernt, die Zellnummerierung nach dem Zusammenführen oder Aufteilen von Zellen handhabt, die Hintergrundfarbe einer Zelle ändert und ein Bild in einer Tabellenzelle einfügt. Die Beispiele zeigen, wie man eine Präsentation erstellt oder öffnet, eine Tabelle von einer Folie abruft, die Zellformatierung über Zelleigenschaften aktualisiert und die modifizierte Präsentation als PPTX‑Datei speichert.

Aspose.Slides verwendet nullbasierte Indizes. Koordinaten in diesem Artikel werden als `(Spalte, Zeile)` angegeben.

## **Erkennen einer zusammengeführten Tabellenzelle**

Das Beispiel öffnet eine vorhandene Präsentation und greift auf die erste Form auf der ersten Folie als Tabelle zu. Es wird davon ausgegangen, dass die Folie und die Form existieren und dass die Form eine Tabelle ist. Anschließend wird über alle Zeilen und Spalten iteriert und dabei [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) verwendet, um Zellen in zusammengeführten Bereichen zu identifizieren. Für jede Übereinstimmung gibt es die Zellkoordinaten in `Zeile;Spalte`‑Reihenfolge, [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/), [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/) und die Startkoordinaten des Bereichs, [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) und [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/), aus.

```python
import aspose.slides as slides

with slides.Presentation("presentation_with_table.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    for row_index in range(len(table.rows)):
        for column_index in range(len(table.columns)):
            cell = table.rows[row_index][column_index]
            if cell.is_merged_cell:
                print(f"Cell {row_index};{column_index} belongs to a merged region with row_span={cell.row_span} and col_span={cell.col_span} starting at {cell.first_row_index};{cell.first_column_index}.")
```

## **Entfernen von Tabellenzellenrahmen**

Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) und fügen Sie ihrer ersten Folie mit [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) eine Tabelle hinzu. Spaltenbreiten, Zeilenhöhen und die Tabellenposition werden in Punkten angegeben. Das Beispiel setzt alle vier Zellenrahmen auf [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/), sodass sie unsichtbar werden.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    for row in table.rows:
        for cell in row:
            cell.cell_format.border_top.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_bottom.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_left.fill_format.fill_type = slides.FillType.NO_FILL
            cell.cell_format.border_right.fill_format.fill_type = slides.FillType.NO_FILL

    presentation.save("table.pptx", slides.export.SaveFormat.PPTX)
```

## **Zusammenführen von Tabellenzellen**

Verwenden Sie [merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/), um einen rechteckigen Zellenbereich zu einer einzelnen Zelle zu kombinieren. Geben Sie die Zellen an den oberen linken bzw. unteren rechten Ecken des Bereichs an. Das letzte Argument bestimmt, ob das Zusammenführen Zellen außerhalb des angegebenen Bereichs einschließen darf; `False` hält das Zusammenführen innerhalb dieses Bereichs.

Das Beispiel erstellt eine 4 × 4‑Tabelle mit 70‑Punkt‑Spalten und -Zeilen und führt dann die vier mittleren Zellen von `(1, 1)` bis `(2, 2)` zusammen. Die resultierende Zelle erstreckt sich über zwei Spalten und zwei Zeilen, während das zugrunde liegende Gitter der Tabelle weiterhin vier Spalten und vier Zeilen enthält. Um auf den Inhalt oder die Formatierung der zusammengeführten Zelle zuzugreifen, verwenden Sie deren Position oben links: `table.rows[1][1]` in diesem Beispiel. Die anderen Positionen im zusammengeführten Bereich bleiben Teil des Tabellengitters, sodass die Indizes von Zellen außerhalb des Bereichs unverändert bleiben.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.merge_cells(table.rows[1][1], table.rows[2][2], False)

    presentation.save("merged_cells.pptx", slides.export.SaveFormat.PPTX)
```

## **Aufteilen von Tabellenzellen**

Das Zusammenführen von Zellen im vorherigen Beispiel bewahrt das Tabellengitter. Das Aufteilen einer Zelle kann eine neue Gitterspalte einführen und die Spaltenindizes von Zellen rechts von ihr ändern. Aspose.Slides folgt dem Tabellen­gittermodell von PowerPoint.

Dieses Beispiel erstellt eine 4 × 4‑Tabelle mit 70‑Punkt‑Spalten und -Zeilen und ruft [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/) für die Zelle `(1, 1)` auf. Die Hälfte der 70‑Punkt‑Breite der Zelle wird übergeben, um zwei gleich breite Zellen zu erzeugen.

Nach diesem Aufteilen werden die beiden Hälften über `table.rows[1][1]` bzw. `table.rows[1][2]` angesprochen. Das Tabellengitter hat nun fünf Spalten: Zellen, die ursprünglich in den Spalten 2 und 3 waren, verschieben sich zu den Spalten 3 bzw. 4. Zeilenindizes bleiben unverändert. Verwenden Sie diese aktualisierten Spaltenindizes, wenn Sie nach dem Aufteilen auf Zellen zugreifen.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.shapes.add_table(100, 50, column_widths, row_heights)

    table.rows[1][1].split_by_width(table.rows[1][1].width / 2)

    presentation.save("split_cells.pptx", slides.export.SaveFormat.PPTX)
```

### **Aufteilen zusammengeführter Zellen nach Zeilen‑ oder Spalten‑Span**

Um zusammengeführte Vorlagenzellen für die Datenbefüllung vorzubereiten, verwenden Sie [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/), um entlang einer vorhandenen Zeilengrenze zu teilen, oder [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/), um entlang einer Spaltengrenze zu teilen.

Das Argument `index` gibt die Zeilen im oberen Teil bzw. die Spalten im linken Teil der Aufteilung an; es ist relativ zum zusammengeführten Bereich:

- Zeilenaufteilung: `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/).
- Spaltenaufteilung: `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/).

Das Beispiel erwartet, dass eine Präsentation auf der ersten Folie eine Tabelle als erste Form enthält, wobei `(1, 2)` und `(1, 3)` vertikal zusammengeführt sind. Ausgehend von der unteren Position verwendet es [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) und [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/), um den Ursprung zu bestimmen, und prüft beide Spans. `split_by_row_span` mit einem Index von 1 trennt dann die Zeilen 2 und 3 für Produktnamen. Für eine horizontale Zusammenführung über zwei Spalten verwenden Sie stattdessen `split_by_col_span` mit einem Index von 1.

```python
import aspose.slides as slides

with slides.Presentation("table_template.pptx") as presentation:
    slide = presentation.slides[0]
    table = slide.shapes[0]

    selected_cell = table.rows[3][1]
    first_column_index = selected_cell.first_column_index
    first_row_index = selected_cell.first_row_index
    merged_cell = table.rows[first_row_index][first_column_index]

    if merged_cell.is_merged_cell and merged_cell.row_span == 2 and merged_cell.col_span == 1:
        merged_cell.split_by_row_span(1)

        # Abrufen der nach dem Aufteilen resultierenden Zellen aus der Tabelle.
        upper_cell = table.rows[first_row_index][first_column_index]
        lower_cell = table.rows[first_row_index + 1][first_column_index]
        print(f"Upper cell merged: {upper_cell.is_merged_cell}")
        print(f"Lower cell merged: {lower_cell.is_merged_cell}")

        upper_cell.text_frame.text = "Product A"
        lower_cell.text_frame.text = "Product B"

        presentation.save("split_template.pptx", slides.export.SaveFormat.PPTX)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
```

Das Tabellengitter und die umgebenden Zellenindizes bleiben unverändert. Rufen Sie die resultierenden Zellen über ihre Koordinaten ab; beide haben nun einen Span von 1 und [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) gibt `False` zurück. Größere Bereiche können nach einem Aufteilen teilweise zusammengeführt bleiben.

Der ursprüngliche Text und seine Formatierung verbleiben in der oberen (bzw. linken) Zelle; die neue Zelle ist leer, erbt jedoch die Zellformatierung wie Füllung, Rahmen und Ränder. Befüllen Sie die Zellen nach dem Aufteilen und setzen Sie bei Bedarf die Textformatierung explizit.

Die gespeicherte Präsentation enthält separate „Product A“‑ und „Product B“‑Zellen, wobei die Formatierung der Vorlage erhalten bleibt. Siehe die [Zell‑API‑Referenz](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) für Details.

## **Ändern der Hintergrundfarbe einer Tabellenzelle**

Dieses Beispiel erstellt eine Tabelle mit 150‑Punkt‑Spalten und 50‑Punkt‑Zeilen. Es setzt [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) auf solid und [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) auf rot für die Zelle `(2, 3)`, also die dritte Spalte und vierte Zeile.

```python
import aspose.pydrawing as draw
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = draw.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Ein Bild in einer Tabellenzelle einfügen**

Platzieren Sie das Eingabebild im Arbeitsverzeichnis, bevor Sie dieses Beispiel ausführen. Es lädt das Bild mit [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) und fügt es der Bildsammlung der Präsentation mit [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/) hinzu. Anschließend wird das Bild dem Bildfüllmodus der Zelle `(0, 0)`, der ersten Zelle in der Tabelle, zugewiesen.

[PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) streckt das Bild, sodass es die Zelle ausfüllt, was das Seitenverhältnis ändern kann. Spaltenbreiten und Zeilenhöhen werden in Punkten angegeben. Das geladene Bild wird automatisch freigegeben, wenn sein `with`‑Block endet.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    with slides.Images.from_file("aspose_logo.jpg") as image:
        presentation_image = presentation.images.add_image(image)

    cell = table.rows[0][0]
    cell.cell_format.fill_format.fill_type = slides.FillType.PICTURE
    cell.cell_format.fill_format.picture_fill_format.picture_fill_mode = slides.PictureFillMode.STRETCH
    cell.cell_format.fill_format.picture_fill_format.picture.image = presentation_image

    presentation.save("table_cell_with_image.pptx", slides.export.SaveFormat.PPTX)
```

## **FAQ**

**Kann ich unterschiedliche Linienstärken und -stile für die einzelnen Seiten einer einzelnen Zelle festlegen?**

Ja. Die [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/) Rahmen besitzen separate Eigenschaften, sodass die Stärke und der Stil jeder Seite unterschiedlich sein können.

**Was passiert mit dem Bild, wenn ich nach dem Festlegen eines Bildes als Hintergrund der Zelle die Spalten‑/Zeilengröße ändere?**

Das Verhalten hängt vom [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile) ab. Beim Strecken wird das Bild an die neue Zelle angepasst; beim Kacheln werden die Kacheln neu berechnet.

**Kann ich einem Hyperlink den gesamten Inhalt einer Zelle zuweisen?**

[Hyperlinks](/slides/de/python-net/manage-hyperlinks/) werden auf Textebene (Portion) innerhalb des Textfeldes der Zelle oder auf Ebene der gesamten Tabelle/Form gesetzt. Praktisch weisen Sie den Link einer Portion oder dem gesamten Text in der Zelle zu.

**Kann ich innerhalb einer einzelnen Zelle unterschiedliche Schriften festlegen?**

Ja. Das Textfeld einer Zelle unterstützt [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (Runs) mit unabhängiger Formatierung – Schriftfamilie, Stil, Größe und Farbe.