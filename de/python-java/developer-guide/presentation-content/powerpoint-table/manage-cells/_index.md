---
title: "Verwalten von Tabellenzellen in Präsentationen mit Python"
linktitle: "Zellen verwalten"
type: docs
weight: 30
url: /de/python-java/manage-cells/
keywords:
- "Tabellenzelle"
- "Zellen zusammenführen"
- "Rahmen entfernen"
- "Zelle teilen"
- "Bild in Zelle"
- "Hintergrundfarbe"
- "PowerPoint"
- "Präsentation"
- "Python"
- "Aspose.Slides"
description: "Verwalten Sie PowerPoint-Tabellenzellen in Python: Erkennen zusammengeführter Zellen, Entfernen von Rahmen, Teilen von Zellen und Festlegen von Hintergrundfarben und Bildern mit Aspose.Slides für Python via Java."
---
## **Übersicht**

Aspose.Slides ermöglicht den Zugriff auf Tabellenzellen in PowerPoint-Präsentationen und deren Änderung. Dieser Artikel erklärt, wie zusammengeführte Tabellenzellen erkannt, Zellrahmen entfernt, die Zellnummerierung nach dem Zusammenführen oder Teilen von Zellen bearbeitet, die Hintergrundfarbe einer Zelle geändert und ein Bild in einer Tabellenzelle hinzugefügt werden kann. Die Beispiele zeigen, wie eine Präsentation erstellt oder geöffnet, eine Tabelle von einer Folie abgerufen, die Zellformatierung über Zelleigenschaften aktualisiert und die modifizierte Präsentation als PPTX-Datei gespeichert wird.

Aspose.Slides verwendet nullbasierte Indizes, um Tabellenzellen in der Reihenfolge `(Spalte, Zeile)` zu adressieren.

## **Erkennen einer zusammengeführten Tabellenzelle**

Das Beispiel öffnet eine vorhandene Präsentation und greift auf die erste Form auf der ersten Folie als Tabelle zu. Es wird angenommen, dass die Folie und die Form existieren und dass die Form eine Tabelle ist. Anschließend wird über alle Zeilen und Spalten iteriert und [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) verwendet, um Zellen in zusammengeführten Bereichen zu erkennen. Für jede Übereinstimmung gibt das Beispiel die Zellkoordinaten in `row;column`‑Reihenfolge, [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan), [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan) und die Startkoordinaten des Bereichs, [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex) und [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) aus.

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

## **Diagonale Zellrahmen hinzufügen**

Verwenden Sie [getBorderDiagonalDown](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderDiagonalDown), um eine Linie von der oberen linken Ecke zur unteren rechten Ecke zu zeichnen, und [getBorderDiagonalUp](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderDiagonalUp), um eine Linie von der unteren linken Ecke zur oberen rechten Ecke zu zeichnen. Eine Diagonale kann eine Ecküberschrift kennzeichnen. Beide Diagonalen können ein X bilden, um eine Zelle als nicht anwendbar zu markieren.

Jede Diagonale ist ein [LineFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/). In ihrem [getFillFormat](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#getFillFormat) verwenden Sie [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType), um [FillType.Solid](https://reference.aspose.com/slides/python-java/aspose.slides/filltype/) auszuwählen und über [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) eine Farbe zu wählen. Die Linienbreite in Punkten wird mit [setWidth](https://reference.aspose.com/slides/python-java/aspose.slides/lineformat/#setWidth) festgelegt.

Das Beispiel erstellt drei Zellen in einer Zeile: eine rote abwärts gerichtete Diagonale, eine blaue aufwärts gerichtete Diagonale und beide Diagonalen. Die oberen, unteren, linken und rechten Zellrahmen bleiben unverändert.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color


def format_border(border, color, width):
    fill = border.getFillFormat()
    fill.setFillType(FillType.Solid)
    fill.getSolidFillColor().setColor(color)
    border.setWidth(width)


presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)
    table = slide.getShapes().addTable(45, 130, [210, 210, 210], [160])

    left_cell = table.get_Item(0, 0).getCellFormat()
    middle_cell = table.get_Item(1, 0).getCellFormat()
    right_cell = table.get_Item(2, 0).getCellFormat()
    format_border(left_cell.getBorderDiagonalDown(), Color.RED, 3)
    format_border(middle_cell.getBorderDiagonalUp(), Color.BLUE, 5)
    format_border(right_cell.getBorderDiagonalDown(), Color.RED, 3)
    format_border(right_cell.getBorderDiagonalUp(), Color.BLUE, 5)

    presentation.save("diagonal_cell_borders.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Eine Diagonale ist eine Formatierungseigenschaft, kein Zellsplit. Jede Zelle behält einen einzelnen Textrahmen, der über [getTextFrame](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getTextFrame) zugänglich ist. Die Bereiche auf beiden Seiten einer Diagonale können nicht unabhängig bearbeitet werden.

The saved table, rendered in Microsoft PowerPoint:

![Drei Tabellenzellen mit einer roten Diagonale von oben links nach unten rechts, einer blauen Diagonale von unten links nach oben rechts und beiden Diagonalen, die ein X bilden.](diagonal-cell-borders.png)

*Von links nach rechts: abwärts gerichtete Diagonale (rot, 3 pt), aufwärts gerichtete Diagonale (blau, 5 pt) und beide Diagonalen.*

## **Tabellenzellen zusammenführen**

Verwenden Sie [mergeCells](https://reference.aspose.com/slides/python-java/aspose.slides/table/#mergeCells), um einen rechteckigen Bereich von Tabellenzellen zu einer Zelle zu kombinieren. Geben Sie die Zellen an den oberen linken und unteren rechten Ecken des Bereichs an. Das letzte Argument steuert, ob das Zusammenführen Zellen außerhalb des angegebenen Bereichs einschließen darf; `False` hält das Zusammenführen innerhalb dieses Bereichs.

Das Beispiel erstellt eine 4‑by‑4‑Tabelle mit 70‑Punkt‑Spalten und -Zeilen und führt dann die vier zentralen Zellen von `(1, 1)` bis `(2, 2)` zusammen. Die resultierende Zelle erstreckt sich über zwei Spalten und zwei Zeilen, während das zugrunde liegende Raster der Tabelle vier Spalten und vier Zeilen beibehält. Um auf den Inhalt oder die Formatierung der zusammengeführten Zelle zuzugreifen, verwenden Sie deren obere linke Position: `table.get_Item(1, 1)` in diesem Beispiel. Die anderen Positionen im zusammengeführten Bereich bleiben Teil des Tabellengitters, sodass sich die Indizes der Zellen außerhalb des Bereichs nicht ändern.

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

## **Tabellenzellen teilen**

Das Zusammenführen von Zellen im vorherigen Beispiel erhält das Raster der Tabelle. Das Teilen einer Zelle kann eine neue Rasterspalte einführen und die Spaltenindizes der Zellen rechts davon ändern. Aspose.Slides folgt dem Tabellenrastermodell von PowerPoint.

Dieses Beispiel erstellt eine 4‑by‑4‑Tabelle mit 70‑Punkt‑Spalten und -Zeilen und ruft [splitByWidth](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByWidth) für die Zelle `(1, 1)` auf. Die Hälfte der 70‑Punkt‑Breite der Zelle wird übergeben, um zwei Zellen gleicher Breite zu erzeugen.

Nach diesem Split werden die beiden Hälften über `table.get_Item(1, 1)` und `table.get_Item(2, 1)` angesprochen. Das Tabellengitter hat nun fünf Spalten: Zellen, die ursprünglich in Spalte 2 bzw. 3 waren, verschieben sich in Spalte 3 bzw. 4. Zeilenindizes bleiben unverändert. Verwenden Sie diese aktualisierten Spaltenindizes, wenn Sie nach dem Split Zellen abrufen.

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

<!-- visual-explanation:manage-cells:start -->
[![Eine nicht zusammengeführte 70‑Punkt‑Zelle teilt sich in zwei 35‑Punkt‑Zellen, fügt eine fünfte Rasterspalte hinzu und verschiebt die Indizes rechts davon.](visual-manage-cells-04c40789d81c.svg)](visual-manage-cells-04c40789d81c.svg)

*Der Breiten‑Split betrifft Zelle (1, 1) und verwendet nullbasierte (Spalte, Zeile)-Indizes. Andere Zeilen behalten eine Zelle, die beide neuen Spaltenpositionen überspannt.*
<!-- visual-explanation:manage-cells:end -->

### **Zusammengeführte Zellen nach Zeilen‑ oder Spalten‑Spannweite teilen**

Um zusammengeführte Vorlagenzellen für die Datenbefüllung vorzubereiten, verwenden Sie [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan), um entlang einer bestehenden Zeilenbegrenzung zu teilen, oder [splitByColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByColSpan), um entlang einer Spaltenbegrenzung zu teilen.

Das Argument `index` zählt Zeilen im oberen Teil bzw. Spalten im linken Teil des Splits; es ist relativ zum zusammengeführten Bereich:

- Zeilenteilung: `0 < index <` [getRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getRowSpan).
- Spaltenteilung: `0 < index <` [getColSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getColSpan).

Das Beispiel geht davon aus, dass eine Präsentation eine Tabelle als erste Form auf der ersten Folie enthält, wobei `(1, 2)` und `(1, 3)` vertikal zusammengeführt sind. Ausgehend von der unteren Position verwendet es [getFirstColumnIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstColumnIndex) und [getFirstRowIndex](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#getFirstRowIndex), um den Ursprung zu finden und überprüft beide Spannen. `splitByRowSpan(1)` trennt dann Zeile 2 und 3 für Produktnamen. Für ein horizontales Zusammenführen von zwei Spalten verwenden Sie stattdessen `splitByColSpan(1)`.

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

        # Ermitteln Sie die resultierenden Zellen aus der Tabelle nach dem Teilen.
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

Das Tabellengitter und die umgebenden Zellindizes bleiben unverändert. Rufen Sie die resultierenden Zellen über ihre Koordinaten ab; hier haben beide eine Spannweite von 1 und [isMergedCell](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#isMergedCell) gibt `False` aus. Größere Bereiche können nach einem Split teilweise zusammengeführt bleiben.

Der ursprüngliche Text und dessen Formatierung bleiben in der oberen (bzw. linken) Zelle; die neue Zelle ist leer, erbt jedoch die Zellformatierung wie Füllung, Rahmen und Ränder. Befüllen Sie die Zellen nach dem Split und setzen Sie ggf. die benötigte Textformatierung explizit.

Die gespeicherte Präsentation enthält getrennte Zellen „Product A“ und „Product B“ mit dem beibehaltenen Zellformat der Vorlage. Siehe die [Cell API Reference](https://reference.aspose.com/slides/python-java/aspose.slides/cell/) für Details.

### **Eine Zelle bei einer bestimmten Höhe teilen**

[splitByHeight](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByHeight) nimmt die Höhe des oberen Teils in Punkten. [splitByRowSpan](https://reference.aspose.com/slides/python-java/aspose.slides/cell/#splitByRowSpan) nimmt die Anzahl der bestehenden Rasterzeilen im oberen Teil. Um eine 40‑Punkt‑Zelle in der rechten Spalte zu zentrieren, ziehen Sie 40 von der tatsächlichen Höhe der Zelle ab und teilen den verbleibenden Raum gleichmäßig über und unter ihr.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat
presentation = Presentation()
try:
    slide = presentation.getSlides().get_Item(0)

    table = slide.getShapes().addTable(50, 50, [160, 160], [140])
    table.get_Item(0, 0).getTextFrame().setText("Left")

    height = table.get_Item(1, 0).getHeight()
    margin = (height - 40) / 2
    
    table.get_Item(1, 0).splitByHeight(margin)
    table.get_Item(1, 1).splitByHeight(40)
    table.get_Item(1, 1).getTextFrame().setText("Middle")

    presentation.save("split_by_height.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Der erste Split fügt eine Rasterzeile hinzu und lässt die unteren 90 Punkte in Zelle `(1, 1)` zurück. Der zweite Split teilt diese Zelle in eine mittlere Zelle von 40 Punkten und eine untere Zelle von 50 Punkten. Die rechte Spalte hat jetzt drei Zellen mit Höhen von 50, 40 und 50 Punkten von oben nach unten. Die linke Zelle erstreckt sich über alle drei Zeilen und behält ihre ursprüngliche Höhe von 140 Punkten bei.

![Die linke Zelle erstreckt sich über die gesamte Tabellenhöhe neben drei Zellen, wobei die mittlere Zelle in der Mitte steht.](split-by-height.png)

## **Die Hintergrundfarbe einer Tabellenzelle ändern**

Dieses Beispiel erstellt eine Tabelle mit 150‑Punkt‑Spalten und 50‑Punkt‑Zeilen. Es verwendet [setFillType](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#setFillType), um eine einfarbige Füllung auszuwählen, und setzt die von [getSolidFillColor](https://reference.aspose.com/slides/python-java/aspose.slides/fillformat/#getSolidFillColor) zurückgegebene Farbe für Zelle `(2, 3)` (dritte Spalte, vierte Zeile) auf Rot.

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

## **Ein Bild in einer Tabellenzelle hinzufügen**

Legen Sie das Eingabebild vor dem Ausführen dieses Beispiels in das Arbeitsverzeichnis. Es lädt das Bild mit [Images.fromFile](https://reference.aspose.com/slides/python-java/aspose.slides/images/#fromFile) und fügt es der Bildsammlung der Präsentation mit [addImage](https://reference.aspose.com/slides/python-java/aspose.slides/imagecollection/#addImage) hinzu. Anschließend wird das Bild dem Bildfüllfeld der Zelle `(0, 0)`, der ersten Zelle der Tabelle, zugewiesen.

[PictureFillMode.Stretch](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) streckt das Bild, um die Zelle auszufüllen, wodurch das Seitenverhältnis möglicherweise geändert wird. Spaltenbreiten und Zeilenhöhen werden in Punkten angegeben. Das geladene Bild wird in einem `finally`‑Block freigegeben, nachdem es zur Präsentation hinzugefügt wurde.

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

**Kann ich verschiedene Linienstärken und -stile für unterschiedliche Seiten einer einzelnen Zelle festlegen?**  
Ja. Die [top](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/python-java/aspose.slides/cellformat/#getBorderRight) Rahmen haben separate Eigenschaften, sodass die Dicke und der Stil jeder Seite unterschiedlich sein kann.

**Was passiert mit dem Bild, wenn ich die Spalten‑/Zeilengröße ändere, nachdem ich ein Bild als Zellhintergrund festgelegt habe?**  
Das Verhalten hängt vom [fill mode](https://reference.aspose.com/slides/python-java/aspose.slides/picturefillmode/) ab (stretch/tile). Beim Strecken passt sich das Bild der neuen Zelle an; beim Kacheln werden die Kacheln neu berechnet.

**Kann ich einem Zellinhalt einen Hyperlink zuweisen?**  
[Hyperlinks](/slides/de/python-java/manage-hyperlinks/) werden auf Textebene (Portion) innerhalb des Textframes der Zelle oder auf Ebene der gesamten Tabelle/Form gesetzt. In der Praxis weisen Sie den Link einer Portion oder dem gesamten Text in der Zelle zu.

**Kann ich innerhalb einer einzelnen Zelle verschiedene Schriftarten festlegen?**  
Ja. Der Textrahmen einer Zelle unterstützt [portions](https://reference.aspose.com/slides/python-java/aspose.slides/portion/), also Textabschnitte, mit unabhängiger Formatierung – Schriftfamilie, Stil, Größe und Farbe.