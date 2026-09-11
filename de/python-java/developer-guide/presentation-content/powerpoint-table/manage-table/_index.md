---
title: Präsentationstabellen in Python verwalten
linktitle: Tabellen verwalten
type: docs
weight: 10
url: /de/python-java/manage-table/
keywords:
- Tabelle hinzufügen
- Tabelle erstellen
- Tabelle zugreifen
- Seitenverhältnis
- Text ausrichten
- Textformatierung
- Tabellenstil
- PowerPoint
- Präsentation
- Python
- Aspose.Slides
description: "Erstellen & bearbeiten Sie Tabellen in PowerPoint‑Folien mit Aspose.Slides für Python über Java. Entdecken Sie einfache Codebeispiele, um Ihre Tabellen‑Workflows zu optimieren."
---
## **Einleitung**

Eine Tabelle in PowerPoint ist eine effiziente Möglichkeit, Informationen darzustellen. Die Informationen in einem Raster von Zellen (angeordnet in Zeilen und Spalten) sind unkompliziert und leicht zu verstehen.

Aspose.Slides stellt die Klasse [Table](https://reference.aspose.com/slides/de/python-java/aspose.slides/table/), die Klasse [Cell](https://reference.aspose.com/slides/de/python-java/aspose.slides/cell/) und weitere Typen bereit, mit denen Sie Tabellen in allen Arten von Präsentationen erstellen, aktualisieren und verwalten können.

## **Eine Tabelle von Grund auf erstellen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/).
2. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
3. Definieren Sie eine Liste von Spaltenbreiten.
4. Definieren Sie eine Liste von Zeilenhöhen.
5. Fügen Sie der Folie ein [Table](https://reference.aspose.com/slides/de/python-java/aspose.slides/table/)‑Objekt über die Methode [addTable](https://reference.aspose.com/slides/de/python-java/aspose.slides/shapecollection/#addTable) hinzu.
6. Durchlaufen Sie jede [Cell](https://reference.aspose.com/slides/de/python-java/aspose.slides/cell/), um die Formatierung der oberen, unteren, rechten und linken Ränder anzuwenden.
7. Fassen Sie die ersten beiden Zellen der ersten Zeile der Tabelle zusammen.
8. Greifen Sie auf das [TextFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/) einer [Cell](https://reference.aspose.com/slides/de/python-java/aspose.slides/cell/) zu.
9. Fügen Sie dem [TextFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/) Text hinzu.
10. Speichern Sie die geänderte Präsentation.

Dieser Python‑Code zeigt Ihnen, wie Sie eine Tabelle in einer Präsentation erstellen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# Erzeugt ein Presentation-Objekt, das eine PPTX-Datei repräsentiert
presentation = Presentation()
try:

    # Greift auf die erste Folie zu
    slide = presentation.getSlides().get_Item(0)

    # Definiert Spalten mit Breiten und Zeilen mit Höhen
    column_widths = [50, 50, 50]
    row_heights = [50, 30, 30, 30, 30]

    # Fügt der Folie eine Tabellform hinzu
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Setzt das Rahmenformat für jede Zelle
    for row in table.getRows():
        for cell in row:
            cell_format = cell.getCellFormat()
            cell_format.getBorderTop().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderTop().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderTop().setWidth(5)
            cell_format.getBorderBottom().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderBottom().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderBottom().setWidth(5)
            cell_format.getBorderLeft().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderLeft().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderLeft().setWidth(5)
            cell_format.getBorderRight().getFillFormat().setFillType(FillType.Solid)
            cell_format.getBorderRight().getFillFormat().getSolidFillColor().setColor(Color.RED)
            cell_format.getBorderRight().setWidth(5)

    # Fügt die Zellen 1 und 2 der Zeile 1 zusammen
    table.mergeCells(table.getRows().get_Item(0).get_Item(0), table.getRows().get_Item(0).get_Item(1), False)

    # Fügt dem zusammengefügten Feld Text hinzu
    table.getRows().get_Item(0).get_Item(0).getTextFrame().setText("Merged Cells")

    # Speichert die Präsentation auf dem Datenträger
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Nummerierung in einer Standards‑Tabelle**

In einer Standards‑Tabelle ist die Nummerierung der Zellen einfach und nullbasiert. Die erste Zelle einer Tabelle hat den Index 0,0 (Spalte 0, Zeile 0).

Beispielsweise werden die Zellen einer Tabelle mit 4 Spalten und 4 Zeilen folgendermaßen nummeriert:

| (0, 0) | (1, 0) | (2, 0) | (3, 0) |
| :----- | :----- | :----- | :----- |
| (0, 1) | (1, 1) | (2, 1) | (3, 1) |
| (0, 2) | (1, 2) | (2, 2) | (3, 2) |
| (0, 3) | (1, 3) | (2, 3) | (3, 3) |

Dieser Python‑Code zeigt Ihnen, wie Sie eine Tabelle mit standardmäßiger Zellen‑Nummerierung erstellen:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat
from java.awt import Color

# Erstellt ein Presentation-Objekt, das eine PPTX-Datei darstellt
presentation = Presentation()
try:

    # Greift auf die erste Folie zu
    slide = presentation.getSlides().get_Item(0)

    # Definiert Spalten mit Breiten und Zeilen mit Höhen
    column_widths = [70, 70, 70, 70]
    row_heights = [70, 70, 70, 70]

    # Fügt der Folie eine Tabellform hinzu
    table = slide.getShapes().addTable(100, 50, column_widths, row_heights)

    # Setzt das Rahmenformat für jede Zelle
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

    # Speichert die Präsentation auf dem Datenträger
    presentation.save("StandardTables_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Auf eine vorhandene Tabelle zugreifen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/).
2. Holen Sie sich einen Verweis auf die Folie, die die Tabelle enthält, anhand ihres Index.
3. Initialisieren Sie eine Variable für ein [Table](https://reference.aspose.com/slides/de/python-java/aspose.slides/table/)‑Objekt und setzen Sie sie auf `None`.
4. Durchlaufen Sie alle [Shape](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/)‑Objekte, bis die Tabelle gefunden wird.

   Wenn Sie vermuten, dass die betreffende Folie nur eine einzige Tabelle enthält, können Sie einfach alle darin enthaltenen Formen prüfen. Wird eine Form als Tabelle identifiziert, können Sie sie als [Table](https://reference.aspose.com/slides/de/python-java/aspose.slides/table/)‑Objekt verwenden. Enthält die Folie jedoch mehrere Tabellen, ist es besser, die gewünschte Tabelle über deren [getAlternativeText](https://reference.aspose.com/slides/de/python-java/aspose.slides/shape/#getAlternativeText) zu suchen.
5. Verwenden Sie das [Table](https://reference.aspose.com/slides/de/python-java/aspose.slides/table/)‑Objekt, um mit der Tabelle zu arbeiten. Im folgenden Beispiel aktualisieren wir den Text in der ersten Spalte der zweiten Zeile.
6. Speichern Sie die geänderte Präsentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

# Erstellt eine Instanz der Presentation-Klasse, die eine PPTX-Datei darstellt
presentation = Presentation("UpdateExistingTable.pptx")
try:

    # Greift auf die erste Folie zu
    slide = presentation.getSlides().get_Item(0)

    # Initialisiert die Tabellenreferenz.
    table = None

    # Durchläuft die Formen und setzt eine Referenz auf die gefundene Tabelle
    for shape in slide.getShapes():
        if isinstance(shape, Table):
            table = shape

            # Setzt den Text für die erste Spalte der zweiten Zeile
            table.get_Item(0, 1).getTextFrame().setText("New")

    # Speichert die geänderte Präsentation auf dem Datenträger
    presentation.save("table1_out.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Die Zelle finden, die einen Textrahmen besitzt**

Wenn generischer Textverarbeitungscode ein [TextFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/) einer Tabelle erhält, verwenden Sie die Methode [TextFrame.getParentCell](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/#getParentCell), um die zugehörige [Cell](https://reference.aspose.com/slides/de/python-java/aspose.slides/cell/) abzurufen. Für ein TextFrame einer Tabellenzelle liefert [TextFrame.getParentCell](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/#getParentCell) den Eigentümer und [TextFrame.getParentShape](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/#getParentShape) liefert `None`, obwohl die Tabelle selbst eine Form ist.

Die Zellkoordinaten sind über die schreibgeschützten Methoden [Cell.getFirstColumnIndex](https://reference.aspose.com/slides/de/python-java/aspose.slides/cell/#getFirstColumnIndex) und [Cell.getFirstRowIndex](https://reference.aspose.com/slides/de/python-java/aspose.slides/cell/#getFirstRowIndex) verfügbar. [TextFrame.getParentCell](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/#getParentCell) bietet ebenfalls eine schreibgeschützte Navigation: Sie gibt den Eigentümer zurück, ändert jedoch den Besitz nicht. Prüfen Sie stets, ob die zurückgegebene Zelle `None` ist, bevor Sie sie verwenden.

Ein vollständiges Beispiel, das Tabellenzellen‑ und Form‑Eigentümer ermittelt, einschließlich Formen, die mit SmartArt‑Knoten verknüpft sind, finden Sie unter [Search and Replace Text](/slides/de/python-java/search-and-replace-text/).

## **Text in einer Tabelle ausrichten**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/).
2. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
3. Fügen Sie der Folie ein [Table](https://reference.aspose.com/slides/de/python-java/aspose.slides/table/)‑Objekt hinzu.
4. Greifen Sie aus der Tabelle auf ein [TextFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/)‑Objekt zu.
5. Greifen Sie auf das [Paragraph](https://reference.aspose.com/slides/de/python-java/aspose.slides/paragraph/) des [TextFrame](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframe/) zu.
6. Richten Sie den Text vertikal aus.
7. Speichern Sie die geänderte Präsentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import FillType, Presentation, SaveFormat, TextAnchorType, TextVerticalType
from java.awt import Color

    # Erstellt eine Instanz der Presentation-Klasse
    presentation = Presentation()
    try:

        # Ruft die erste Folie ab
        slide = presentation.getSlides().get_Item(0)

        # Definiert Spalten mit Breiten und Zeilen mit Höhen
        column_widths = [120, 120, 120, 120]
        row_heights = [100, 100, 100, 100]

        # Fügt der Folie die Tabellform hinzu
        table = slide.getShapes().addTable(100, 50, column_widths, row_heights)
        table.get_Item(1, 0).getTextFrame().setText("10")
        table.get_Item(2, 0).getTextFrame().setText("20")
        table.get_Item(3, 0).getTextFrame().setText("30")

        # Greift auf den Textrahmen zu
        text_frame = table.get_Item(0, 0).getTextFrame()

        # Greift auf den ersten Absatz im Textrahmen zu.
        paragraph = text_frame.getParagraphs().get_Item(0)

        # Greift auf den ersten Teil im Absatz zu.
        portion = paragraph.getPortions().get_Item(0)
        portion.setText("Text here")
        portion.getPortionFormat().getFillFormat().setFillType(FillType.Solid)
        portion.getPortionFormat().getFillFormat().getSolidFillColor().setColor(Color.BLACK)

        # Richtet den Text vertikal aus
        cell = table.get_Item(0, 0)
        cell.setTextAnchorType(TextAnchorType.Center)
        cell.setTextVerticalType(TextVerticalType.Vertical270)

        # Speichert die Präsentation auf dem Datenträger
        presentation.save("Vertical_Align_Text_out.pptx", SaveFormat.Pptx)
    finally:
        presentation.dispose()
```

## **Textformatierung auf Tabellenebene festlegen**

1. Erstellen Sie eine Instanz der Klasse [Presentation](https://reference.aspose.com/slides/de/python-java/aspose.slides/presentation/).
2. Holen Sie sich einen Verweis auf eine Folie anhand ihres Index.
3. Greifen Sie aus der Folie auf ein [Table](https://reference.aspose.com/slides/de/python-java/aspose.slides/table/)‑Objekt zu.
4. Setzen Sie die Schriftgröße des Textes mit [setFontHeight](https://reference.aspose.com/slides/de/python-java/aspose.slides/baseportionformat/#setFontHeight).
5. Stellen Sie die Ausrichtung und den rechten Rand mit [setAlignment](https://reference.aspose.com/slides/de/python-java/aspose.slides/paragraphformat/#setAlignment) und [setMarginRight](https://reference.aspose.com/slides/de/python-java/aspose.slides/paragraphformat/#setMarginRight) ein.
6. Setzen Sie den vertikalen Texttyp mit [setTextVerticalType](https://reference.aspose.com/slides/de/python-java/aspose.slides/textframeformat/#setTextVerticalType).
7. Speichern Sie die geänderte Präsentation.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import ParagraphFormat, PortionFormat, Presentation, SaveFormat, TextAlignment, TextFrameFormat, TextVerticalType, Table

# Erstellt eine Instanz der Presentation-Klasse
presentation = Presentation("simpletable.pptx")
try:

    # Angenommen, die erste Form auf der ersten Folie ist eine Tabelle
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape

        # Setzt die Schriftgröße der Tabellenzellen
        portion_format = PortionFormat()
        portion_format.setFontHeight(25)
        table.setTextFormat(portion_format)

        # Setzt die Textausrichtung und den rechten Rand der Tabellenzellen in einem Aufruf
        paragraph_format = ParagraphFormat()
        paragraph_format.setAlignment(TextAlignment.Right)
        paragraph_format.setMarginRight(20)
        table.setTextFormat(paragraph_format)

        # Setzt den vertikalen Texttyp der Tabellenzellen
        text_frame_format = TextFrameFormat()
        text_frame_format.setTextVerticalType(TextVerticalType.Vertical)
        table.setTextFormat(text_frame_format)
        presentation.save("result.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **Tabellen‑Stil­eigenschaften abrufen**

Aspose.Slides ermöglicht das Abrufen der Stil­eigenschaften einer Tabelle, sodass Sie diese Details für eine andere Tabelle oder an anderer Stelle verwenden können. Dieser Python‑Code zeigt, wie Sie die Stil­eigenschaften aus einem vordefinierten Tabell­stil erhalten:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, TableStylePreset

presentation = Presentation()
try:
    table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 10, [100, 150], [5, 5, 5])
    table.setStylePreset(TableStylePreset.DarkStyle1)  # ändert das Standard‑Stil‑Preset

    # Ermittelt das Stil‑Preset der Tabelle
    style_preset = table.getStylePreset()
    print("Table style preset: ", style_preset)

    # Wendet das abgerufene Stil‑Preset auf eine andere Tabelle an
    another_table = presentation.getSlides().get_Item(0).getShapes().addTable(10, 100, [100, 150], [5, 5, 5])
    another_table.setStylePreset(style_preset)
    presentation.save("table.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Seitenverhältnis einer Tabelle sperren**

Das Seitenverhältnis einer geometrischen Form ist das Verhältnis ihrer Ausmaße in verschiedenen Dimensionen. Aspose.Slides stellt die Methode [setAspectRatioLocked](https://reference.aspose.com/slides/de/python-java/aspose.slides/graphicalobjectlock/#setAspectRatioLocked) bereit, mit der Sie die Einstellung des Seitenverhältnisses für Tabellen und andere Formen sperren können.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, Table

presentation = Presentation("pres.pptx")
try:
    shape = presentation.getSlides().get_Item(0).getShapes().get_Item(0)
    if isinstance(shape, Table):
        table = shape
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        table.getGraphicalObjectLock().setAspectRatioLocked(not table.getGraphicalObjectLock().getAspectRatioLocked())  # invertieren
        print("Lock aspect ratio set: ", table.getGraphicalObjectLock().getAspectRatioLocked())
        presentation.save("pres-out.pptx", SaveFormat.Pptx)
    else:
        print("The first shape is not a table.")
finally:
    presentation.dispose()
```

## **FAQ**

**Kann ich die Leserichtung von rechts nach links (RTL) für eine gesamte Tabelle und den Text in ihren Zellen aktivieren?**

Ja. Die Tabelle stellt die Methode [setRightToLeft](https://reference.aspose.com/slides/de/python-java/aspose.slides/table/#setRightToLeft) bereit, und Absätze besitzen [ParagraphFormat.setRightToLeft](https://reference.aspose.com/slides/de/python-java/aspose.slides/paragraphformat/#setRightToLeft). Die gleichzeitige Verwendung beider stellt die korrekte RTL‑Reihenfolge und -Darstellung innerhalb der Zellen sicher.

**Wie kann ich verhindern, dass Benutzer eine Tabelle in der endgültigen Datei verschieben oder die Größe ändern?**

Verwenden Sie [shape locks](/slides/de/python-java/applying-protection-to-presentation/), um das Verschieben, Ändern der Größe, die Auswahl usw. zu deaktivieren. Diese Sperren gelten auch für Tabellen.

**Wird das Einfügen eines Bildes als Hintergrund in einer Zelle unterstützt?**

Ja. Sie können für eine Zelle eine [picture fill](https://reference.aspose.com/slides/de/python-java/aspose.slides/picturefillformat/) festlegen; das Bild deckt die Zellenfläche entsprechend dem gewählten Modus (Strecken oder Kacheln) ab.