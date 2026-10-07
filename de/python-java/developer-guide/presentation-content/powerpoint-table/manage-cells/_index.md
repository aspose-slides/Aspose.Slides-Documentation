---
title: Tabellenzellen in Präsentationen mit Python verwalten
linktitle: Zellen verwalten
type: docs
weight: 30
url: /de/python-java/manage-cells/
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
description: "PowerPoint-Tabellenzellen in Python verwalten: zusammengeführte Zellen erkennen, Rahmen entfernen, Zellen teilen und Hintergrundfarben sowie Bilder mit Aspose.Slides für Python via Java festlegen."
---
## **Übersicht**

Aspose.Slides ermöglicht den Zugriff auf und die Modifizierung von Tabellenzellen in PowerPoint‑Präsentationen. Dieser Artikel erklärt, wie man zusammengeführte Tabellenzellen erkennt, Zellrahmen entfernt, mit der Zellnummerierung nach dem Zusammenführen oder Aufteilen von Zellen arbeitet, die Hintergrundfarbe einer Zelle ändert und ein Bild in einer Tabellenzelle einfügt. Die Beispiele zeigen, wie eine Präsentation erstellt oder geöffnet, eine Tabelle aus einer Folie abgerufen, die Zellformatierung über Zelleigenschaften aktualisiert und die geänderte Präsentation als PPTX‑Datei gespeichert wird.

Aspose.Slides verwendet nullbasierte Indizes, um Tabellenzellen in der Reihenfolge `(column, row)` zu adressieren.

## **Identifizieren einer zusammengeführten Tabellenzelle**

Das Beispiel öffnet eine vorhandene Präsentation und greift auf die erste Form auf der ersten Folie als Tabelle zu. Es wird vorausgesetzt, dass die Folie und die Form vorhanden sind und dass die Form eine Tabelle ist. Anschließend wird über alle Zeilen und Spalten iteriert und die Methode [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) verwendet, um Zellen in zusammengeführten Bereichen zu identifizieren. Für jeden Treffer werden die Zellenkoordinaten in der Reihenfolge `row;column` ausgegeben, ebenso [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan), [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan) und die Startkoordinaten des Bereichs, [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) und [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex).

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("presentation_with_table.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    row_count = table.getRows().size()
    for row_index in range(row_count):
        column_count = table.getColumns().size()
        for column_index in range(column_count):
            cell = table.get_Item(column_index, row_index)
            if cell.isMergedCell():
                print(f"Cell {row_index};{column_index} belongs to a merged region with RowSpan={cell.getRowSpan()} and ColSpan={cell.getColSpan()} starting at {cell.getFirstRowIndex()};{cell.getFirstColumnIndex()}.")
finally:
    presentation.dispose()
```

## **Entfernen von Tabellenzellenrahmen**

Erstellen Sie eine [Presentation](https://reference.aspose.com/slides/python-java/aspose.slides/presentation/) und fügen Sie ihrer ersten Folie mit [addTable](https://reference.aspose.com/slides/python-java/aspose.slides/shapecollection/#addTable) eine Tabelle hinzu. Spaltenbreiten, Zeilenhöhen und die Tabellenposition werden in Punkten angegeben. Das Beispiel setzt alle vier Zellrahmen auf [FillType.NoFill](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/), wodurch sie unsichtbar werden.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zusammenführen von Tabellenzellen**

Verwenden Sie [mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells), um einen rechteckigen Bereich von Tabellenzellen zu einer einzelnen Zelle zu kombinieren. Geben Sie die Zellen in der oberen linken und unteren rechten Ecke des Bereichs an. Das letzte Argument steuert, ob das Zusammenführen Zellen außerhalb des angegebenen Bereichs einschließen darf; `False` hält das Zusammenführen innerhalb dieses Bereichs.

Das Beispiel erstellt eine 4‑mal 4‑Tabelle mit 70‑Punkt‑Spalten und -Zeilen und führt dann die vier mittleren Zellen von `(1, 1)` bis `(2, 2)` zusammen. Die resultierende Zelle erstreckt sich über zwei Spalten und zwei Zeilen, während das zugrunde liegende Raster der Tabelle vier Spalten und vier Zeilen beibehält. Um auf den Inhalt oder die Formatierung der zusammengeführten Zelle zuzugreifen, verwenden Sie deren Position oben links: `table.get_Item(1, 1)` in diesem Beispiel. Die anderen Positionen im zusammengeführten Bereich bleiben Teil des Tabellengitters, sodass die Indizes der Zellen außerhalb des Bereichs unverändert bleiben.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 2), False)

    presentation.save("merged_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Aufteilen von Tabellenzellen**

Das Zusammenführen von Zellen im vorherigen Beispiel bewahrt das Tabellengitter. Das Aufteilen einer Zelle kann eine neue Gitterspalte einführen und die Spaltenindizes der Zellen zu ihrer rechten Seite ändern. Aspose.Slides folgt dem Tabellenrastermodell von PowerPoint.

Dieses Beispiel erstellt eine 4‑mal 4‑Tabelle mit 70‑Punkt‑Spalten und -Zeilen und ruft [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth) für die Zelle `(1, 1)` auf. Die Hälfte der 70‑Punkt‑Breite der Zelle wird übergeben, um zwei gleich breite Zellen zu erzeugen.

Nach diesem Aufteilen werden die beiden Hälften über `table.get_Item(1, 1)` bzw. `table.get_Item(2, 1)` abgerufen. Das Tabellengitter hat nun fünf Spalten: Zellen, die ursprünglich in Spalte 2 bzw. 3 waren, verschieben sich zu Spalte 3 bzw. 4. Die Zeilenindizes bleiben unverändert. Verwenden Sie diese aktualisierten Spaltenindizes, wenn Sie nach dem Aufteilen auf Zellen zugreifen.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    table.get_Item(1, 1).splitByWidth(table.get_Item(1, 1).getWidth() / 2)

    presentation.save("split_cells.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

### **Zusammengeführte Zellen nach Zeilen‑ oder Spalten­spanne aufteilen**

Um zusammengeführte Vorlagenzellen für die Datenbefüllung vorzubereiten, verwenden Sie [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan), um entlang einer bestehenden Zeilenbegrenzung zu teilen, oder [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan), um entlang einer Spaltenbegrenzung zu teilen.

Das Argument `index` zählt Zeilen im oberen Teil bzw. Spalten im linken Teil der Teilung; es ist relativ zum zusammengeführten Bereich:

- Zeilenteilung: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan).
- Spaltenteilung: `0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan).

Das Beispiel geht davon aus, dass eine Präsentation eine Tabelle als erste Form auf der ersten Folie enthält, wobei `(1, 2)` und `(1, 3)` vertikal zusammengeführt sind. Ausgehend von der unteren Position verwendet es [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) und [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex), um den Ursprung zu ermitteln, und prüft beide Spannen. `splitByRowSpan(1)` trennt dann Zeile 2 und 3 für Produktnamen. Für ein horizontales Zusammenführen von zwei Spalten verwenden Sie stattdessen `splitByColSpan(1)`.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("table_template.pptx")
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().get_Item(0)

    selected_cell = table.get_Item(1, 3)
    first_column_index = selected_cell.getFirstColumnIndex()
    first_row_index = selected_cell.getFirstRowIndex()
    merged_cell = table.get_Item(first_column_index, first_row_index)

    if merged_cell.isMergedCell() and merged_cell.getRowSpan() == 2 and merged_cell.getColSpan() == 1:
        merged_cell.splitByRowSpan(1)

        # Erhalte die resultierenden Zellen aus der Tabelle nach dem Aufteilen.
        upper_cell = table.get_Item(first_column_index, first_row_index)
        lower_cell = table.get_Item(first_column_index, first_row_index + 1)
        print(f"Upper cell merged: {upper_cell.isMergedCell()}")
        print(f"Lower cell merged: {lower_cell.isMergedCell()}")

        upper_cell.getTextFrame().setText("Product A")
        lower_cell.getTextFrame().setText("Product B")

        presentation.save("split_template.pptx", SaveFormat.Pptx)
    else:
        print("Select a merged region spanning exactly two rows and one column.")
finally:
    presentation.dispose()
```

Das Tabellengitter und die umliegenden Zellenindizes bleiben unverändert. Rufen Sie die resultierenden Zellen über ihre Koordinaten ab; hier haben beide eine Spanne von 1 und [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) gibt `False` aus. Größere Bereiche können nach einem Aufteilen teilweise zusammengeführt bleiben.

Der ursprüngliche Text und seine Formatierung bleiben in der oberen (bzw. linken) Zelle; die neue Zelle ist leer, erbt jedoch die Zellformatierung wie Füllung, Rahmen und Ränder. Befüllen Sie die Zellen nach dem Aufteilen und setzen Sie sämtliche benötigte Textformatierung explizit.

Die gespeicherte Präsentation enthält separate "Product A"‑ und "Product B"‑Zellen, wobei die Zellformatierung der Vorlage erhalten bleibt. Siehe die [Cell API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) für Details.

## **Ändern der Hintergrundfarbe einer Tabellenzelle**

Dieses Beispiel erstellt eine Tabelle mit 150‑Punkt‑Spalten und 50‑Punkt‑Zeilen. Es verwendet [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType), um eine einfarbige Füllung auszuwählen, und setzt die von [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) zurückgegebene Farbe für die Zelle `(2, 3)` (dritte Spalte, vierte Zeile) auf Rot.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ein Bild in einer Tabellenzelle einfügen**

Legen Sie das Eingabebild vor dem Ausführen dieses Beispiels im Arbeitsverzeichnis ab. Es lädt das Bild mit [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) und fügt es der Bildsammlung der Präsentation mit [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) hinzu. Anschließend wird das Bild dem Bildfüllmodus der Zelle `(0, 0)`, der ersten Zelle der Tabelle, zugewiesen.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) streckt das Bild, um die Zelle zu füllen, was ihr Seitenverhältnis ändern kann. Spaltenbreiten und Zeilenhöhen werden in Punkten angegeben. Das geladene Bild wird in einem `finally`‑Block freigegeben, nachdem es zur Präsentation hinzugefügt wurde.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    image = Images.fromFile("aspose_logo.jpg")
    try:
        presentation_image = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    table.get_Item(0, 0).getCellFormat().getFillFormat().setFillType(FillType.Picture)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    table.get_Item(0, 0).getCellFormat().getFillFormat().getPictureFillFormat().getPicture().setImage(presentation_image)

    presentation.save("table_cell_with_image.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Kann ich unterschiedliche Linienstärken und -stile für die verschiedenen Seiten einer einzelnen Zelle festlegen?**

Ja. Die [top](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight)-Rahmen besitzen separate Eigenschaften, sodass die Dicke und der Stil jeder Seite unterschiedlich sein können.

**Was passiert mit dem Bild, wenn ich die Spalten‑/Zeilengröße ändere, nachdem ich ein Bild als Hintergrund der Zelle festgelegt habe?**

Das Verhalten hängt vom [fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) (stretch/tile) ab. Beim Strecken passt sich das Bild der neuen Zelle an; beim Kacheln werden die Kacheln neu berechnet.

**Kann ich einem gesamten Zelleninhalt einen Hyperlink zuweisen?**

[Hyperlinks](/slides/de/python-java/manage-hyperlinks/) werden auf Textebene (Portion) innerhalb des Textfelds der Zelle oder auf Ebene der gesamten Tabelle/Form festgelegt. In der Praxis weisen Sie den Link einer Portion oder dem gesamten Text in der Zelle zu.

**Kann ich innerhalb einer einzelnen Zelle unterschiedliche Schriftarten festlegen?**

Ja. Das Textfeld einer Zelle unterstützt [portions](https://reference.aspose.com/slides/python-java/aspose.slides/portion/) (Lauftexte) mit unabhängiger Formatierung – Schriftfamilie, Stil, Größe und Farbe.