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
description: "Verwalten Sie mühelos Tabellenzellen in PowerPoint mit Aspose.Slides für Python über Java. Beherrschen Sie das schnelle Zugreifen, Ändern und Gestalten von Zellen für eine nahtlose Folienautomatisierung."
---
## **Übersicht**

Aspose.Slides ermöglicht den Zugriff auf Tabellenzellen in PowerPoint‑Präsentationen sowie deren Änderung. Dieser Artikel erklärt, wie man zusammengeführte Tabellenzellen erkennt, Zellenrahmen entfernt, mit der Zellnummerierung nach dem Zusammenführen oder Aufteilen von Zellen arbeitet, die Hintergrundfarbe einer Zelle ändert und ein Bild in eine Tabellenzelle einfügt. Die Beispiele zeigen, wie man eine Präsentation erstellt oder öffnet, eine Tabelle von einer Folie erhält, die Zellformatierung über Zelleigenschaften aktualisiert und die geänderte Präsentation als PPTX‑Datei speichert.

## **Zusammengeführte Tabellenzelle identifizieren**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie die Tabelle von der ersten Folie.  
3. Durchlaufen Sie die Zeilen und Spalten der Tabelle, um zusammengeführte Zellen zu finden.  
4. Geben Sie eine Meldung aus, wenn zusammengeführte Zellen gefunden werden.

Dieser Python‑Code zeigt, wie man zusammengeführte Tabellenzellen in einer Präsentation erkennt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Table

presentation = Presentation("SomePresentationWithTable.pptx")
try:
    # Angenommen, dass das erste Shape auf der ersten Folie eine Tabelle ist.
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        for i in range(table.getRows().size()):
            for j in range(table.getColumns().size()):
                current_cell = table.getRows().get_Item(i).get_Item(j)
                if current_cell.isMergedCell():
                    print(f"Cell {i};{j} is part of a merged cell with RowSpan={current_cell.getRowSpan()} and ColSpan={current_cell.getColSpan()} starting from Cell {current_cell.getFirstRowIndex()};{current_cell.getFirstColumnIndex()}.")
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Tabellenzellen‑Rahmen entfernen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie eine Referenz auf eine Folie über ihren Index.  
3. Definieren Sie eine Liste von Spaltenbreiten.  
4. Definieren Sie eine Liste von Zeilenhöhen.  
5. Fügen Sie über die [addTable](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#addTable)‑Methode eine Tabelle zur Folie hinzu.  
6. Durchlaufen Sie jede Zelle und löschen Sie die oberen, unteren, rechten und linken Rahmen.  
7. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie man die Rahmen von Tabellenzellen entfernt:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat

presentation = Presentation()
try:
    # Zugriff auf die erste Folie.
    slide = presentation.getSlides().get_Item(0)

    # Spaltenbreiten und Zeilenhöhen definieren.
    column_widths = [50, 50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Eine Tabelle zur Folie hinzufügen.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Das Rahmenformat für jede Zelle festlegen.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.NoFill)
            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.NoFill)

    # Die Präsentation als PPTX-Datei speichern.
    presentation.save("table_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nummerierung in zusammengeführten Zellen**

Wenn wir zwei Zellpaare zusammenführen, (1, 1) und (2, 1) sowie (1, 2) und (2, 2), behält die resultierende Tabelle ihre Zellnummerierung bei. Dieser Python‑Code demonstriert den Vorgang:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Zugriff auf die erste Folie.
    slide = presentation.getSlides().get_Item(0)

    # Spaltenbreiten und Zeilenhöhen definieren.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Eine Tabelle zur Folie hinzufügen.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Das Rahmenformat für jede Zelle festlegen.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # Zellen (1, 1) und (2, 1) zusammenführen.
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # Zellen (1, 2) und (2, 2) zusammenführen.
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # Die Präsentation als PPTX-Datei speichern.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Anschließend führen wir die Zellen weiter zusammen, indem wir (1, 1) und (1, 2) zusammenführen. Das Ergebnis ist eine Tabelle mit einer großen zusammengeführten Zelle in der Mitte:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Zugriff auf die erste Folie.
    slide = presentation.getSlides().get_Item(0)

    # Spaltenbreiten und Zeilenhöhen definieren.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Eine Tabelle zur Folie hinzufügen.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Das Rahmenformat für jede Zelle festlegen.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # Zellen (1, 1) und (2, 1) zusammenführen.
    table.mergeCells(table.get_Item(1, 1), table.get_Item(2, 1), False)

    # Zellen (1, 2) und (2, 2) zusammenführen.
    table.mergeCells(table.get_Item(1, 2), table.get_Item(2, 2), False)

    # Zellen (1, 1) und (1, 2) zusammenführen.
    table.mergeCells(table.get_Item(1, 1), table.get_Item(1, 2), True)

    # Die Präsentation als PPTX-Datei speichern.
    presentation.save("MergeCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nummerierung in einer geteilten Zelle**

In den vorherigen Beispielen änderte das Zusammenführen von Tabellenzellen die Nummerierung der anderen Zellen nicht.

Dieses Mal nehmen wir eine normale Tabelle (eine Tabelle ohne zusammengeführte Zellen) und teilen dann die Zelle (1, 1), um eine spezielle Tabelle zu erhalten. Beachten Sie die Nummerierung dieser Tabelle, die möglicherweise ungewöhnlich erscheint. So nummeriert Microsoft PowerPoint Tabellenzellen und Aspose.Slides verhält sich identisch.

Dieser Python‑Code demonstriert den beschriebenen Vorgang:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Zugriff auf die erste Folie.
    slide = presentation.getSlides().get_Item(0)

    # Spaltenbreiten und Zeilenhöhen definieren.
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Eine Tabelle zur Folie hinzufügen.
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Das Rahmenformat für jede Zelle festlegen.
    for row in table.getRows():
        for cell in row:
            cell.getCellFormat().getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderTop().setWidth(5)

            cell.getCellFormat().getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderBottom().setWidth(5)

            cell.getCellFormat().getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderLeft().setWidth(5)

            cell.getCellFormat().getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell.getCellFormat().getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell.getCellFormat().getBorderRight().setWidth(5)


    # Zelle (1, 1) teilen.
    table.get_Item(1, 1).splitByWidth(table.get_Item(2, 1).getWidth() / 2)

    # Die Präsentation als PPTX-Datei speichern.
    presentation.save("SplitCells_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Hintergrundfarbe der Tabellenzelle ändern**

Dieser Python‑Code zeigt, wie Sie die Hintergrundfarbe einer Tabellenzelle ändern:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, FillType, SaveFormat
from java.awt import Color

presentation = Presentation()
try:
    # Zugriff auf die erste Folie.
    slide = presentation.getSlides().get_Item(0)

    # Spaltenbreiten und Zeilenhöhen definieren.
    column_widths = [150, 150, 150, 150]
    row_heights = [50, 50, 50, 50, 50]

    # Eine Tabelle zur Folie hinzufügen.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # Hintergrundfarbe für eine Zelle festlegen.
    cell = table.get_Item(2, 3)
    cell.getCellFormat().getFillFormat().setFillType(FillType.Solid)
    cell.getCellFormat().getFillFormat().getSolidFillColor().setColor(Color.RED)

    # Die Präsentation als PPTX-Datei speichern.
    presentation.save("cell_background_color.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ein Bild in einer Tabellenzelle einfügen**

1. Erstellen Sie eine Instanz der [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/)‑Klasse.  
2. Holen Sie eine Referenz auf eine Folie über ihren Index.  
3. Definieren Sie eine Liste von Spaltenbreiten.  
4. Definieren Sie eine Liste von Zeilenhöhen.  
5. Fügen Sie über die [addTable](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#addTable)‑Methode eine Tabelle zur Folie hinzu.  
6. Laden Sie die Bilddatei mithilfe von [Images.fromFile](https://reference.aspose.com/slides/de/python-java/aspose.slides/images/#fromFile).  
7. Fügen Sie das Bild zur Präsentation hinzu, um ein [PPImage](https://reference.aspose.com/slides/de/python-java/aspose.slides/ppimage/)‑Objekt zu erstellen.  
8. Setzen Sie den [FillFormat](https://reference.aspose.com/slides/de/python-java/aspose.slides/fillformat/)‑Fülltyp der Tabellenzelle auf [FillType.Picture](https://reference.aspose.com/slides/de/python-java/aspose.slides/filltype/#Picture).  
9. Fügen Sie das Bild in die erste Zelle der Tabelle ein.  
10. Speichern Sie die geänderte Präsentation als PPTX‑Datei.

Dieser Python‑Code zeigt, wie Sie beim Erstellen einer Tabelle ein Bild in eine Tabellenzelle einfügen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, Images, FillType, PictureFillMode, SaveFormat

presentation = Presentation()
try:
    # Zugriff auf die erste Folie.
    slide = presentation.getSlides().get_Item(0)

    # Spaltenbreiten und Zeilenhöhen definieren.
    column_widths = [150, 150, 150, 150]
    row_heights = [100, 100, 100, 100, 90]

    # Eine Tabelle zur Folie hinzufügen.
    table = slide.getShapes().addTable(50, 50, column_widths, row_heights)

    # Ein Präsentationsbild aus der Bilddatei erstellen.
    image = Images.fromFile("image.jpg")
    try:
        picture = presentation.getImages().addImage(image)
    finally:
        image.dispose()

    # Das Bild zur ersten Tabellenzelle hinzufügen.
    cell_format = table.get_Item(0, 0).getCellFormat()
    cell_format.getFillFormat().setFillType(FillType.Picture)
    cell_format.getFillFormat().getPictureFillFormat().setPictureFillMode(PictureFillMode.Stretch)
    cell_format.getFillFormat().getPictureFillFormat().getPicture().setImage(picture)

    # Die Präsentation als PPTX-Datei speichern.
    presentation.save("Image_In_TableCell_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **FAQ**

**Kann ich unterschiedliche Linienstärken und -stile für die einzelnen Seiten einer einzigen Zelle festlegen?**

Ja. Die [top](https://reference.aspose.com/slides/de/python-java/aspose.slides/cellformat/#getBorderTop)/[bottom](https://reference.aspose.com/slides/de/python-java/aspose.slides/cellformat/#getBorderBottom)/[left](https://reference.aspose.com/slides/de/python-java/aspose.slides/cellformat/#getBorderLeft)/[right](https://reference.aspose.com/slides/de/python-java/aspose.slides/cellformat/#getBorderRight)‑Grenzen besitzen separate Eigenschaften, sodass die Stärke und der Stil jeder Seite unterschiedlich sein können. Dies ergibt sich logisch aus der im Artikel gezeigten per‑Seite‑Grenzsteuerung einer Zelle.

**Was passiert mit dem Bild, wenn ich die Spalten‑/Zeilengröße ändere, nachdem ich ein Bild als Zellhintergrund festgelegt habe?**

Das Verhalten hängt vom [fill mode](https://reference.aspose.com/slides/de/python-java/aspose.slides/picturefillmode/) (stretch/tile) ab. Beim Strecken passt sich das Bild der neuen Zelle an; beim Kacheln werden die Kacheln neu berechnet. Der Artikel erwähnt die Anzeige‑Modi von Bildern in einer Zelle.

**Kann ich einem Hyperlink den gesamten Inhalt einer Zelle zuweisen?**

[Hyperlinks](/slides/de/python-java/manage-hyperlinks/) werden auf Textebene (Portion) innerhalb des Textframes einer Zelle oder auf Ebene der gesamten Tabelle/des Shapes gesetzt. In der Praxis weisen Sie den Link einer Portion oder dem gesamten Text in der Zelle zu.

**Kann ich unterschiedliche Schriftarten innerhalb einer einzigen Zelle verwenden?**

Ja. Der Textframe einer Zelle unterstützt [portions](https://reference.aspose.com/slides/de/python-java/aspose.slides/portion/) (Runs) mit unabhängiger Formatierung – Schriftfamilie, Stil, Größe und Farbe.