---
title: Tabellenzellen in Präsentationen mit Python verwalten
linktitle: Zellen verwalten
type: docs
weight: 30
url: /de/python-net/manage-cells/
keywords:
- Tabellenzelle
- Zellen zusammenführen
- Rahmen entfernen
- Zelle teilen
- Bild in Zelle
- Hintergrundfarbe
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Verwalten Sie PowerPoint-Tabellenzellen in Python: zusammengeführte Zellen identifizieren, Rahmen entfernen, Zellen teilen und Hintergrundfarben sowie Bilder mit Aspose.Slides für Python via .NET setzen."
---
## **Übersicht**

Aspose.Slides ermöglicht den Zugriff auf Tabellenzellen in PowerPoint‑Präsentationen und deren Bearbeitung. Dieser Artikel erklärt, wie man zusammengeführte Tabellenzellen erkennt, Zellrahmen entfernt, mit Zellnummerierung nach dem Zusammenführen oder Teilen von Zellen arbeitet, die Hintergrundfarbe einer Zelle ändert und ein Bild innerhalb einer Tabellenzelle hinzufügt. Die Beispiele zeigen, wie man eine Präsentation erstellt oder öffnet, eine Tabelle aus einer Folie erhält, die Zellformatierung über Zelleigenschaften aktualisiert und die modifizierte Präsentation als PPTX‑Datei speichert.

Aspose.Slides verwendet nullbasierte Indizes. Koordinaten in diesem Artikel werden als `(Spalte, Zeile)` geschrieben.

## **Identifizieren einer zusammengeführten Tabellenzelle**

Das Beispiel öffnet eine vorhandene Präsentation und greift auf die erste Form auf der ersten Folie als Tabelle zu. Es wird angenommen, dass Folie und Form existieren und dass die Form eine Tabelle ist. Anschließend wird über alle Zeilen und Spalten iteriert und [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) verwendet, um Zellen in zusammengeführten Bereichen zu identifizieren. Für jede Übereinstimmung gibt es die Zellkoordinaten in der Reihenfolge `row;column` sowie [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/), [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/), und die Startkoordinaten des Bereichs, [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/) und [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) aus.

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

## **Entfernen von Tabellenzellrahmen**

Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/python-net/aspose.slides/presentation/) und fügen Sie mit [add_table](https://reference.aspose.com/slides/python-net/aspose.slides/shapecollection/add_table/) eine Tabelle zur ersten Folie hinzu. Spaltenbreiten, Zeilenhöhen und die Tabellposition werden in Punkten angegeben. Das Beispiel setzt alle vier Zellrahmen auf [FillType.NO_FILL](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/), wodurch sie unsichtbar werden.

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

## **Diagonale Zellrahmen hinzufügen**

Verwenden Sie [border_diagonal_down](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_down/), um eine Linie von der oberen linken Ecke zur unteren rechten Ecke zu zeichnen, und [border_diagonal_up](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_diagonal_up/), um eine Linie von der unteren linken Ecke zur oberen rechten Ecke zu zeichnen. Eine Diagonale kann einen Eckkopf markieren; beide Diagonalen können ein X bilden, um eine Zelle als nicht anwendbar zu kennzeichnen.

Jede Diagonale ist ein [LineFormat](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/). In seinem [fill_format](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/fill_format/) setzen Sie [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) auf [FillType.SOLID](https://reference.aspose.com/slides/python-net/aspose.slides/filltype/) und wählen eine [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/). Setzen Sie die [width](https://reference.aspose.com/slides/python-net/aspose.slides/lineformat/width/) der Linie in Punkten.

Das Beispiel erstellt drei Zellen in einer Zeile: eine rote diagonal nach unten, eine blaue diagonal nach oben und beide Diagonalen. Es lässt die oberen, unteren, linken und rechten Zellrahmen unverändert.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [210, 210, 210]
    row_heights = [160]
    table = slide.shapes.add_table(45, 130, column_widths, row_heights)

    downward_border = table.rows[0][0].cell_format.border_diagonal_down
    downward_border.fill_format.fill_type = slides.FillType.SOLID
    downward_border.fill_format.solid_fill_color.color = slides.Color.red
    downward_border.width = 3

    upward_border = table.rows[0][1].cell_format.border_diagonal_up
    upward_border.fill_format.fill_type = slides.FillType.SOLID
    upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    upward_border.width = 5

    cross_downward_border = table.rows[0][2].cell_format.border_diagonal_down
    cross_downward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_downward_border.fill_format.solid_fill_color.color = slides.Color.red
    cross_downward_border.width = 3

    cross_upward_border = table.rows[0][2].cell_format.border_diagonal_up
    cross_upward_border.fill_format.fill_type = slides.FillType.SOLID
    cross_upward_border.fill_format.solid_fill_color.color = slides.Color.blue
    cross_upward_border.width = 5

    presentation.save("diagonal_cell_borders.pptx", slides.export.SaveFormat.PPTX)
```

Eine Diagonale ist eine Formatierungseigenschaft, kein Zellen‑Split. Jede Zelle behält ein einzelnes [text_frame](https://reference.aspose.com/slides/python-net/aspose.slides/cell/text_frame/); die Bereiche auf beiden Seiten einer Diagonale können nicht unabhängig bearbeitet werden.

Die gespeicherte Tabelle, gerendert in Microsoft PowerPoint:

![Drei Tabellenzellen mit einer roten Diagonale von oben links nach unten rechts, einer blauen Diagonale von unten links nach oben rechts und beiden Diagonalen, die ein X bilden.](diagonal-cell-borders.png)

*Links nach rechts: diagonale nach unten (rot, 3 pt), diagonale nach oben (blau, 5 pt) und beide Diagonalen.*

## **Tabellenzellen zusammenführen**

Verwenden Sie [merge_cells](https://reference.aspose.com/slides/python-net/aspose.slides/table/merge_cells/), um einen rechteckigen Bereich von Tabellenzellen zu einer Zelle zu kombinieren. Geben Sie die Zellen an den oberen linken und unteren rechten Ecken des Bereichs an. Das letzte Argument steuert, ob der Merge Zellen außerhalb des angegebenen Bereichs einschließen darf; `False` hält den Merge innerhalb dieses Bereichs.

Das Beispiel erstellt eine 4 × 4‑Tabelle mit 70‑Punkt‑Spalten und -Zeilen und führt die vier Mittenzellen von `(1, 1)` bis `(2, 2)` zusammen. Die resultierende Zelle erstreckt sich über zwei Spalten und zwei Zeilen, während das zugrundeliegende Raster der Tabelle vier Spalten und vier Zeilen beibehält. Um auf den Inhalt oder die Formatierung der zusammengeführten Zelle zuzugreifen, verwenden Sie deren obere linke Position: `table.rows[1][1]` in diesem Beispiel. Die anderen Positionen im zusammengeführten Bereich bleiben Teil des Tabellengitters, sodass sich die Indizes der Zellen außerhalb des Bereichs nicht ändern.

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

## **Tabellenzellen teilen**

Das Zusammenführen von Zellen im vorherigen Beispiel bewahrt das Tabellengitter. Das Teilen einer Zelle kann eine neue Gitterspalte einführen und die Spaltenindizes der rechts davon liegenden Zellen ändern. Aspose.Slides folgt dem Tabellen‑Gittermodell von PowerPoint.

Dieses Beispiel erstellt eine 4 × 4‑Tabelle mit 70‑Punkt‑Spalten und -Zeilen und ruft [split_by_width](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_width/) für die Zelle `(1, 1)` auf. Die Hälfte der 70‑Punkt‑Breite wird übergeben, um zwei gleich breite Zellen zu erzeugen.

Nach diesem Split werden die beiden Hälften als `table.rows[1][1]` und `table.rows[1][2]` angesprochen. Das Tabellengitter hat nun fünf Spalten: Zellen, die ursprünglich in Spalte 2 und 3 waren, verschieben sich zu Spalte 3 bzw. 4. Die Zeilenindizes bleiben unverändert. Verwenden Sie diese aktualisierten Spaltenindizes, wenn Sie nach dem Split auf Zellen zugreifen.

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


<!-- visual-explanation:manage-cells:start -->
[![Eine nicht zusammengeführte 70‑Punkt‑Zelle teilt sich in zwei 35‑Punkt‑Zellen, fügt eine fünfte Gitterspalte hinzu und verschiebt die Indizes rechts davon.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Der Breiten‑Split betrifft Zelle (1, 1) unter Verwendung nullbasierter (Spalte, Zeile)‑Indizes. Andere Zeilen behalten eine Zelle, die beide neuen Spaltenpositionen überspannt.*
<!-- visual-explanation:manage-cells:end -->

### **Zusammengeführte Zellen nach Zeilen- oder Spaltenbereich teilen**

Um zusammengeführte Vorlagenzellen für die Datenbefüllung vorzubereiten, verwenden Sie [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) zum Teilen entlang einer bestehenden Zeilengrenze oder [split_by_col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_col_span/) zum Teilen entlang einer Spaltengrenze.

Das Argument `index` zählt Zeilen im oberen Teil bzw. Spalten im linken Teil des Splits; es bezieht sich relativ auf den zusammengeführten Bereich:

- Zeilensplit: `0 < index <` [row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/row_span/).
- Spaltensplit: `0 < index <` [col_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/col_span/).

Das Beispiel geht davon aus, dass eine Präsentation eine Tabelle als erste Form auf der ersten Folie enthält, wobei `(1, 2)` und `(1, 3)` vertikal zusammengeführt sind. Ausgehend von der unteren Position verwendet es [first_column_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_column_index/) und [first_row_index](https://reference.aspose.com/slides/python-net/aspose.slides/cell/first_row_index/), um den Ursprung zu finden, und prüft beide Spannen. `split_by_row_span` mit einem Index von 1 trennt dann Zeile 2 und 3 für Produktnamen. Für ein horizontales Zwei‑Spalten‑Merge verwenden Sie stattdessen `split_by_col_span` mit einem Index von 1.

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

        # Die resultierenden Zellen aus der Tabelle nach dem Aufteilen abrufen.
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

Das Tabellengitter und die umgebenden Zellindizes bleiben unverändert. Rufen Sie die resultierenden Zellen über ihre Koordinaten ab; hier haben beide eine Spannweite von 1 und [is_merged_cell](https://reference.aspose.com/slides/python-net/aspose.slides/cell/is_merged_cell/) gibt `False` aus. Größere Bereiche können nach einem Split teilweise zusammengeführt bleiben.

Der ursprüngliche Text und seine Formatierung bleiben in der oberen (bzw. linken) Zelle; die neue Zelle ist leer, erbt jedoch die Zellformatierung wie Füllung, Rahmen und Ränder. Befüllen Sie die Zellen nach dem Split und setzen Sie ggf. die gewünschte Textformatierung explizit.

Die gespeicherte Präsentation enthält separate „Product A“- und „Product B“-Zellen, wobei die Formatierung der Vorlage erhalten bleibt. Siehe die [Cell API Reference](https://reference.aspose.com/slides/python-net/aspose.slides/cell/) für Details.

### **Eine Zelle an einer bestimmten Höhe teilen**

[split_by_height](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_height/) nimmt die Höhe des oberen Teils in Punkten. [split_by_row_span](https://reference.aspose.com/slides/python-net/aspose.slides/cell/split_by_row_span/) nimmt die Anzahl der vorhandenen Gitterzeilen im oberen Teil. Um eine 40‑Punkt‑Zelle vertikal in der rechten Spalte zu zentrieren, subtrahieren Sie 40 von der tatsächlichen Höhe der Zelle und teilen den verbleibenden Raum gleichmäßig über und unter ihr auf.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [160, 160]
    row_heights = [140]
    
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)
    table.rows[0][0].text_frame.text = "Left"

    height = table.rows[0][1].height
    margin = (height - 40) / 2

    table.rows[0][1].split_by_height(margin)
    table.rows[1][1].split_by_height(40)
    table.rows[1][1].text_frame.text = "Middle"

    presentation.save("split_by_height.pptx", slides.export.SaveFormat.PPTX)
```

Der erste Split fügt eine Gitterzeile hinzu und lässt die unteren 90 Punkte in `table.rows[1][1]`. Der zweite Split teilt diese Zelle in eine 40‑Punkt‑Mittellinie und eine 50‑Punkt‑Unterrippe. Die drei Zellen in der rechten Spalte sind nun von oben nach unten 50, 40 und 50 Punkt hoch. Die linke Zelle erstreckt sich über alle drei Zeilen mit ihrer ursprünglichen Höhe von 140 Punkt.

![Die linke Zelle erstreckt die gesamte Tabellhöhe neben drei Zellen mit „Middle“ in der Mitte.](split-by-height.png)

## **Hintergrundfarbe der Tabellenzelle ändern**

Dieses Beispiel erstellt eine Tabelle mit 150‑Punkt‑Spalten und 50‑Punkt‑Zeilen. Es setzt [fill_type](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/fill_type/) auf solid und [solid_fill_color](https://reference.aspose.com/slides/python-net/aspose.slides/fillformat/solid_fill_color/) auf rot für Zelle `(2, 3)`, also die dritte Spalte und vierte Zeile.

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    slide = presentation.slides[0]

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.shapes.add_table(50, 50, column_widths, row_heights)

    cell = table.rows[3][2]
    cell.cell_format.fill_format.fill_type = slides.FillType.SOLID
    cell.cell_format.fill_format.solid_fill_color.color = slides.Color.red

    presentation.save("cell_background_color.pptx", slides.export.SaveFormat.PPTX)
```

## **Ein Bild in einer Tabellenzelle hinzufügen**

Legen Sie das Eingabebild vor dem Ausführen dieses Beispiels im Arbeitsverzeichnis ab. Es lädt das Bild mit [Images.from_file](https://reference.aspose.com/slides/python-net/aspose.slides/images/from_file/) und fügt es der Bildsammlung der Präsentation mit [add_image](https://reference.aspose.com/slides/python-net/aspose.slides/imagecollection/add_image/) hinzu. Anschließend wird das Bild dem Bildfüllmodus der Zelle `(0, 0)`, der ersten Zelle in der Tabelle, zugewiesen.

[PictureFillMode.STRETCH](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) streckt das Bild, sodass die Zelle vollständig gefüllt wird, wobei das Seitenverhältnis ggf. angepasst wird. Spaltenbreiten und Zeilenhöhen werden in Punkten angegeben. Das geladene Bild wird beim Verlassen des `with`‑Blocks automatisch freigegeben.

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

Ja. Die [top](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_top/)/[bottom](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_bottom/)/[left](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_left/)/[right](https://reference.aspose.com/slides/python-net/aspose.slides/cellformat/border_right/)‑Rahmen besitzen separate Eigenschaften, sodass die Stärke und der Stil jeder Seite unterschiedlich sein können.

**Was passiert mit dem Bild, wenn ich die Spalten‑/Zeilen‑Größe nach dem Setzen eines Bildes als Zellhintergrund ändere?**

Das Verhalten hängt vom [fill mode](https://reference.aspose.com/slides/python-net/aspose.slides/picturefillmode/) (stretch/tile) ab. Beim Stretch‑Modus passt das Bild sich an die neue Zelle an, beim Tile‑Modus werden die Kacheln neu berechnet.

**Kann ich einem gesamten Zellinhalt einen Hyperlink zuweisen?**

[Hyperlinks](/slides/de/python-net/manage-hyperlinks/) werden auf der Textebene (Portion) innerhalb des Textframes der Zelle oder auf Ebene der gesamten Tabelle/Form gesetzt. In der Praxis weisen Sie den Link einer Portion oder dem gesamten Text der Zelle zu.

**Kann ich unterschiedliche Schriftarten innerhalb einer einzelnen Zelle verwenden?**

Ja. Der Textframe einer Zelle unterstützt [portions](https://reference.aspose.com/slides/python-net/aspose.slides/portion/) (Laufwerke) mit unabhängiger Formatierung – Schriftfamilie, Stil, Größe und Farbe.